using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyfirstAutomation.Extensions
{
    public static class WebdriverExtensions
    {
        public static IWebElement FindmyElement(this IWebDriver driver, string by, string locator)
        {
            IWebElement element = null;
            if (by.Equals("Id"))
            {
                element = driver.FindElement(By.Id(locator));
            }
            if (by.Equals("Name"))
            {
                element = driver.FindElement(By.Name(locator));
            }
            if (by.Equals("Xpath"))
            {
                element = driver.FindElement(By.XPath(locator));
            }

            return element;
        }

        public static IWebElement FindmyElementtenery(this IWebDriver driver, string by, string locator)
        {
            IWebElement element = null!;
            element = by.Equals("Id") ? driver.FindElement(By.Id(locator))
                : by.Equals("Name") ? driver.FindElement(By.Name(locator))
                : by.Equals("Xpath") ? driver.FindElement(By.XPath(locator))
                : null!;
            return element;
        }

        public static IWebElement FindmyElement2(this IWebDriver driver, locator locator, string element) => locator switch
        {
            locator.Id => driver.FindElement(By.Id(element)),
            locator.Name => driver.FindElement(By.Name(element)),
            locator.Xpath => driver.FindElement(By.XPath(element)),
            _ => throw new Exception("No such locator found")
        };

        public static IWebElement FindmyElement3(this IWebDriver driver, locator locator, string element)
        {
            IWebElement elem = null;
            switch (locator)
            {
                case locator.Id:
                    elem = driver.FindElement(By.Id(element));
                    break;
                case locator.Name:
                    elem = driver.FindElement(By.Name(element));
                    break;
                case locator.Xpath:
                    elem = driver.FindElement(By.XPath(element));

                    break;
                default:
                    break;
            }
            return elem;
        }
    }

    public enum locator
    {
        Id,
        Name,
        Xpath
    }
}
