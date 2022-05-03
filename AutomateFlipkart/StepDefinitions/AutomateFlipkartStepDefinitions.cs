using AutomateFlipkart.Hooks;
using AutomateFlipkart.Pages;
using Microsoft.EntityFrameworkCore.Metadata;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject2.Utilities;
using System;
using System.Data;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutomateFlipkart.StepDefinitions
{
    [Binding]
    public class AutomateFlipkartStepDefinitions
    {
        #region objects
        Homepage home, home1;
        TabVerifications tab;
        ProductPage product; 
        #endregion

        //Hooks1 hook;
        // [Given(@"I open the flipkart site on the following ""([^""]*)""")]
        /*public void GivenILaunchTheFlipkartSiteOnTheFollowing(string chrome)
        {
            hook = new Hooks1();
            hook.BeforeScenarioWithTag(chrome);
            
        }*/

        [Given(@"I launch the  flipkart website")]
        public void GivenILaunchTheFlipkartWebsite()
        {
            home = new Homepage();
            Serilog.Log.Information("The Website launched Successfully");
        }

        [When(@"The site opens A popup window that should be  handle")]
        public void WhenTheSiteOpensAPopupWindowAppearsThatShouldBeHandle()
        {
            home.Pop_Up_Window();
            home.Verifyhomepage(PropertiesCollection.driver);

        }

       [When(@"I Check for the Tabs on the flipkart site")]
        public void WhenINavigateTheFlipkartSiteAndClickOnTheTabs()
        {
            Serilog.Log.Information("Verify the tabs");
        }

        [Then(@"Verify the Tab with Title of the tabs on the flipkart site")]
        public void ThenVerifyTheTabWithTitleOfTheTabsOnTheFlipkartSite(Table table)
        {
            tab = new TabVerifications();
            List<string> TABS = new List<string>();
            foreach (TableRow row in table.Rows)
            {
                foreach (String value in row.Values)
                {
                    tab.Flipkart_Tabs(value);
                }
            }
            Serilog.Log.Information("Furniture Tab not Exists");
        }

        [Given(@"I Click on the electronics section")]
        public void GivenIClickOnTheElectronicsSection()
        {   home1 = new Homepage();
            home1.Pop_Up_Window();
            product = new ProductPage();
           
        }

        [Given(@"I select the  air conditioner of type '([^']*)'")]
        public void GivenISelectTheAirConditionerOfType(string airConditioner, Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            product.Select_AirConditioner((string)data.AirConditioner);
        }

        [Then(@"I Verify the Acs result displayed is more than (.*)")]
        public void ThenIVerifyTheAcsResultDisplayedIsMoreThan(int p0)
        {
            product.VerifytheResults(p0);
            
        }

        [When(@"I click on Any Result Item")]
        public void WhenIClickOnAnyResultItem()
        {
            product.verifyproductprices();
        }

        [Then(@"I Verify ""([^""]*)"" and AfterPrice")]
        public void ThenIVerifyAndAfterPrice(string beforePrice, Table table)
        {   dynamic Data = table.CreateDynamicInstance();
            product.verifyprices((string)Data.BeforePrice);

        }


    }


}
