using OpenQA.Selenium;


namespace MyfirstAutomation.PageObject
{
    public class ResultPage
    {
        private readonly IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement rsultHeader => driver.FindElement(By.XPath("//div[@class='a-section a-spacing-small a-spacing-top-small']"));


        public string GetResultHeaderText() => rsultHeader.Text;
    }
}
