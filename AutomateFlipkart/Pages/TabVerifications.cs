using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecFlowProject2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace AutomateFlipkart.Pages
{
    internal class TabVerifications
    {

        #region Elements
        public TabVerifications()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[text()='Mobiles']")]
        public IWebElement Mobliles { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Fashion']")]
        public IWebElement Fashion { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Grocery']")]
        public IWebElement Grocery { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Home']")]
        public IWebElement Home { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Appliances']")]
        public IWebElement Appliances { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Travel']")]
        public IWebElement Travel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Beauty,Toys & more']")]
        public IWebElement Beauty_and_More { get; set; }
        [FindsBy(How = How.TagName, Using = "h1")]
        public IWebElement verifymobiletext { get; set; }
        [FindsBy(How = How.XPath, Using = "(//div[@class='xtXmba'])[5]")]
        public IWebElement Electronics { get; set; }

        #endregion



        #region Method
        public void Flipkart_Tabs(string tabs)
        {
            IWebElement element = PropertiesCollection.driver.FindElement(By.XPath(($"//div[@class='xtXmba'][.='{tabs}']")));
            string text = Methods.Get_Text(element);
            Verify.Equals(text, tabs);
            Serilog.Log.Debug("{0} Tab Exists",text);

        } 
        #endregion





    }
}
