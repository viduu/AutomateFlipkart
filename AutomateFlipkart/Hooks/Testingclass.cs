using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using SpecFlowProject2.Utilities;
using TechTalk.SpecFlow;

namespace AutomateFlipkart.Hooks
{
    [Binding]
    public sealed class Testingclass
    {


       /* [BeforeScenario("@chrome")]
        public void BeforeScenarioWithTag()
        {   
                PropertiesCollection.driver = new ChromeDriver();
                PropertiesCollection.driver.Navigate().GoToUrl("https://www.flipkart.com/");
                PropertiesCollection.driver.Manage().Window.Maximize();
          

        }
        [AfterScenario("@chrome")]
        public void AfterScenario()
        {
            PropertiesCollection.driver.Quit();
        }

*/
       /* [BeforeScenario("@firefox")]
        public void BeforeScenarioWithTag1()
        {
            PropertiesCollection.driver = new FirefoxDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.flipkart.com/");
            PropertiesCollection.driver.Manage().Window.Maximize();

        }
       [AfterScenario("@firefox")]
        public void AfterScenario1()
        {
            PropertiesCollection.driver.Quit();
        }*/
    }
}