using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Utilities
{
    public enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssSelector,
        ClassName,
        XPath
    }
    class PropertiesCollection
    {
        public static WebDriver driver { get; set; }
    }
}
