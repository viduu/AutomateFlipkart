using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.TeamFoundation.TestManagement.WebApi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using SpecFlowProject2.Utilities;
//using SpecFlowProject2.Variables;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject2.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        #region variables
        static AventStack.ExtentReports.ExtentReports extent;
        [ThreadStatic]
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario, step;
        #endregion

        #region path
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "TestReports"
            + Path.DirectorySeparatorChar + "TestReports"
            + DateTime.Now.ToString("ddMMyyyy HHmmss");
        #endregion
        #region methods
        [BeforeScenario("@chrome")]
        public void BeforeScenarioWithTag()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.flipkart.com/");
            PropertiesCollection.driver.Manage().Window.Maximize();


        }
       

        [BeforeTestRun]
        public static void BeforeTestRun()
        {   
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlreport);
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch).WriteTo.File(reportpath + @"\Logs", outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff}|{Level:u3}|{Message}{NewLine}",
                rollingInterval:RollingInterval.Day).CreateLogger();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
            Log.Information("Selecting feature file {0} to run ",context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            Log.Information("Selecting feature file {0} to run ", context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                step.Log(AventStack.ExtentReports.Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                Log.Error("Test Step Failed | "+context.TestError.Message);
                string base64 = GetScreenshot();
                step.Log(AventStack.ExtentReports.Status.Fail, context.StepContext.StepInfo.Text,MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                PropertiesCollection.driver.Quit(); 


            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
            
        }

        [AfterScenario("@chrome")]
        public void AfterScenario()
        {
            PropertiesCollection.driver.Quit();
        }

        public string GetScreenshot()
        {
            return ((ITakesScreenshot)PropertiesCollection.driver).GetScreenshot().AsBase64EncodedString;
        }
        #endregion

    }
}