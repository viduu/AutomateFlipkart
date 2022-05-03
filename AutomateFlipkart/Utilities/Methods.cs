using AutomateFlipkart.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Utilities
{
    public static class Methods
    {
        #region Get_Methods
        public static void Enter_Text_By_Sendkeys(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);

        }
        public static void Clickbutton( this IWebElement element)
        {
          element.Click();
        }
        public static void SelectDropdown(this IWebElement element, string value)
        {
           new SelectElement(element).SelectByText(value);
        }
        public static void SelectByText(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText(text);
            Console.WriteLine(text + " text selected on " + elementName);
        }

        public static void SelectByIndex(this IWebElement element, int index, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByIndex(index);
            Console.WriteLine(index + " index selected on " + elementName);
        }

        public static void SelectByValue(this IWebElement element, string text, string elementName)
        {
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByValue(text);
            Console.WriteLine(text + " value selected on " + elementName);
        }
        #endregion

        #region Set_Methods
        public static string Get_Text(this IWebElement element)
        {
           return element.Text;
            
        }
        public static string GetTextAttribute(this IWebElement element)
        {
           return element.GetAttribute("VALUE");
        }
        public static string GetTextfromDDL(this IWebElement element)
        {
          return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
          
        }
        #endregion
        public static Dictionary<string,string>ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string,string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0],row[1]);
            }
            return dictionary;
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsDisplayed(this IWebElement element, string elementName)
        {
            bool result;
            try
            {
                result = element.Displayed;
                Console.WriteLine(elementName + " is Displayed.");
            }
            catch (Exception)
            {
                result = false;
                Console.WriteLine(elementName + " is not Displayed.");
            }

            return result;
        }
        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();
            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
        public static void Mousehover(this IWebElement element)
        {
            Actions actions = new Actions(PropertiesCollection.driver);
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            actions.MoveToElement(element).Perform();
        }
        public static void WaitforpagetoLoad()
        {
            Thread.Sleep(2000);
        }
    }
}
