using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyfirstAutomation.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClickElement(this IWebElement element, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromSeconds(5)
            };
            wait.Until(x => element).Click();
        } 
    }
}
