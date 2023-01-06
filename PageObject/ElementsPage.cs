using MyfirstAutomation.Extensions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace MyfirstAutomation.PageObject
{
    public class ElementsPage
    {
        private readonly IWebDriver driver;

        public ElementsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ReadOnlyCollection<IWebElement> textBox => driver.FindElements(By.XPath("//li[@id='item-0']"));
        IWebElement textBoxwithparam(string name) => driver.FindmyElement3(locator.Xpath, $"//li[@id='item-0'][.='{name}']");

        private IWebElement fullname => driver.FindElement(By.Id("userName"));
        private IWebElement email => driver.FindElement(By.Id("userEmail"));
        private IWebElement currentaddress => driver.FindElement(By.Id("currentAddress"));
        private IWebElement permanentaddress => driver.FindElement(By.Id("permanentAddress"));


        public void ClickTextBox() => textBox[0].ClickElement(driver);
        public void ClickTextBoxWithparam(string name) => textBoxwithparam(name).ClickElement(driver);

        public void fillForm(string fname, string mail, string caddress, string paddress)
        {
            fullname.SendKeys(fname);
            email.SendKeys(mail);
            currentaddress.SendKeys(caddress);
            permanentaddress.SendKeys(paddress);
        }

        public void Reset()
        {
            fullname.Clear();
            email.Clear();
            currentaddress.Clear();
            permanentaddress.Clear();
        }
    }
}
