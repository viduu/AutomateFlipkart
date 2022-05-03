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
    internal class ProductPage
    {
        #region Elements
        public ProductPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//div[@class='xtXmba'][.='Appliances']")]
        public IWebElement Appliances { get; set; }
        //span[@class='_2I9KP_ _2WDRax']
        [FindsBy(How = How.XPath,Using = "//span[text()='TVs & Appliances']")]
        public IWebElement Appliance{ get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Air Conditioners']")]
        public IWebElement AirConditioner { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Split ACs']")]
        public IWebElement SplitAc { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='_2kHMtA'])[1]")]
        public IWebElement first_product { get; set; }
        [FindsBy(How = How.ClassName, Using = "_2tDckM")]
        public IWebElement ResultsFound { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[text()='₹36,499']")]
        public IWebElement prices { get; set; }
        #endregion


        #region Methods
        public void Select_AirConditioner(string AirConditioners)
        {
            Methods.Clickbutton(Appliances);
            Methods.Mousehover(Appliance);
            Methods.Clickbutton(SplitAc);
            Serilog.Log.Debug("Selected AC is of {0} type", AirConditioners," ");
            Methods.WaitforpagetoLoad();

        }

        public void VerifytheResults(int number)
        {
            string result = Methods.Get_Text(ResultsFound);
            char res = result[14];
            Verify.Equals(number, (int)res);
            Serilog.Log.Information("More than 2 results found");
        }

        public void verifyproductprices()
        {
            string details = Methods.Get_Text(first_product);
            Serilog.Log.Debug("\n\t\t\tProduct Details \n\t\t\t{0} ",details);
            Methods.Clickbutton(first_product);
            Methods.WaitforpagetoLoad();
        }
        public void verifyprices(string price)
        {
            string productprice = Methods.Get_Text(prices);
            if (Verify.Equals(productprice, price))
            {
                Serilog.Log.Information("Same Price Before and After");
            }
            else
            {
                Serilog.Log.Error("Different Price");
            }


        } 
        #endregion
    }
}
