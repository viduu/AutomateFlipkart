using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SpecFlowProject2.Utilities;
using System.Collections;

namespace AutomateFlipkart.Pages
{
    public class Homepage
    {
        #region Elements
        public Homepage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div")]
        public IWebElement Popup_window { get; set; }
        [FindsBy(How = How.XPath, Using = " /html/body/div[2]/div/div/button")]
        public IWebElement Cancelpopup { get; set; }
        #endregion


        #region Methods
        public void Verifyhomepage(WebDriver driver)
        {
            string title = driver.Title;
            Serilog.Log.Debug("\n\tWELCOME to FlipKart \nThe {0} ",title);
            string expectedTitle = "Online Shopping Site for Mobiles, Electronics, Furniture, Grocery, Lifestyle, Books & More. Best Offers!";
            if (title.Equals(expectedTitle))
            {
               Serilog.Log.Information("Title Matched");
            }

            else
            {
                Serilog.Log.Information("Title didn't match");
                PropertiesCollection.driver.Quit();


            }
        }
        public void Pop_Up_Window()
        {
            try
            {
                Methods.IsElementPresent(Popup_window);
                Methods.Clickbutton(Cancelpopup);

            }
            catch (Exception ex)
            {
                Serilog.Log.Debug(ex.ToString());

            }
        }

        #endregion




    }


}
