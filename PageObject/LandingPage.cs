using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyfirstAutomation.PageObject
{
    public class LandingPage
    {
        private readonly IWebDriver driver;

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement searchField => driver.FindElement(By.Name("field-keywords")); //Property

        private ReadOnlyCollection<IWebElement> elements => driver.FindElements(By.XPath("//div[@class='card mt-4 top-card']"));


        public void SetTextToSearchField() => searchField.SendKeys("Football" + Keys.Enter); //Methiod which is calling the property

        public void ClickElements() => elements[0].Click();
    }
}
