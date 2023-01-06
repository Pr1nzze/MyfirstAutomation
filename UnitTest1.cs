using AngleSharp.Common;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using SeleniumExtras.WaitHelpers;
using MyfirstAutomation.PageObject;

namespace MyfirstAutomation
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Tests : Hooks
    {
        //Saving elements into variables
        //Use the variable to perform required actions
        //Performing click action and sendkeys
        //Working with FindElement and FindElements
        //Hooks
        //Assertions or Validations (Nunit assertion, FluentAssertions)
        //Cross browser testing
        //Conditional statements
        //WebdriverWaits using Expectedcondition class and dynamic and Stopwatch

        //Page object model
        //Extension methods/Reusable methods


        [Test]
        [Ignore("BrowserTest")]
        public void BrowserTest()
        {
            Thread.Sleep(3000);
            driver.Url = "https://google.com";
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[text() ='Accept all']")).Click();

            Thread.Sleep(2000);
            var searchbtn = driver.FindElement(By.Name("q"));

            //Nunit assertions
            //Assert.IsTrue(searchbtn.Displayed);
            //Assert.That(searchbtn.Displayed, Is.EqualTo(true));
            //Assert.AreEqual(true, searchbtn.Displayed);

            //Fluent Assertions
            searchbtn.Displayed.ToString().ToUpper().Should().Be("TRUE");
            searchbtn.Displayed.Should().Be(true);

            Thread.Sleep(3000);

            //driver.Navigate().Back();
            //Thread.Sleep(3000);

            //driver.Navigate().Forward();

            //Implicit wait : driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Explicit wait :
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            ////wait.Until(x => x.FindElement(By.Name("hbfjksdbjk")));
            //var isdisplayed = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("ojeufjan"))).Displayed;
        }


        [Test]
        [Ignore("AmazonTest")]
        public void AmazonTest()
        {
            driver.Navigate().GoToUrl("https://amazon.co.uk");
            driver.FindElement(By.Name("field-keywords")).Click();

            var search = driver.FindElement(By.Name("field-keywords"));
            search.SendKeys("Football");

            if (driver.FindElement(By.Id("sp-cc-accept")).Displayed)
            {
                driver.FindElement(By.Id("sp-cc-accept")).Click();
            }
            else
            {
                throw new NoSuchElementException();
            }


            //if (driver.FindElement(By.Id("sp-cc-accept")).Displayed)
            //    driver.FindElement(By.Id("sp-cc-accept")).Click();
            //else
            //    throw new NoSuchElementException();

            //Tenery if statement
            //var result = driver.FindElement(By.Id("sp-cc-accept")).Displayed
            //    ? true: throw new NoSuchElementException();


            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.PartialLinkText("Last Minute")).Click();
            Thread.Sleep(3000);

            ReadOnlyCollection<IWebElement> nums;
            if (driver.FindElements(By.ClassName("nav-line-2")).Count == 5)
            {
                Console.WriteLine("Total is 5");
                nums = driver.FindElements(By.CssSelector("div[id='nav-xshop']>a ")); //div[@id='nav-xshop']/a
                Console.WriteLine(nums.Count);

                //for (int i = 0; i < nums.Count; i++)
                //{
                //    Console.WriteLine(nums[i].Text);
                //}

                foreach (var num in nums)
                {
                    Console.WriteLine(num.Text);
                }
            }
            else
            {
                Console.WriteLine("Total is not as expected");
                Assert.Fail("Total not as expected  : " + driver.FindElements(By.ClassName("nav-line-0")).Count);
            }
        }

        [Test]
        public void AmazonTest2()
        {
            driver.FindElement(By.Name("field-keywords")).Click();
            driver.FindElement(By.Name("field-keywords")).SendKeys("Football");

            var acceptbtn = driver.FindElement(By.Id("sp-cc-accept"));
            if (acceptbtn.Displayed)
            {
                acceptbtn.Click();
            }
            else
            {
                throw new NoSuchElementException();
            }

            //Save element in a variable and use the variable to perform required action
            var submitbutton = driver.FindElement(By.Id("nav-search-submit-button"));
            submitbutton.Click();

            Thread.Sleep(1000);
            IWebElement lastmin = driver.FindElement(By.PartialLinkText("Last Minute"));
            lastmin.Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void AmazonTestWithPageObject()
        {
            LandingPage landingPage = new LandingPage(driver); //Object of a class
            landingPage.SetTextToSearchField();
            Thread.Sleep(2000);
            ResultPage resultPage = new ResultPage(driver);
            Console.WriteLine(resultPage.GetResultHeaderText());
            Assert.IsTrue(resultPage.GetResultHeaderText().Equals("1-48 of over 10,000 results for \"Football\""));
            Assert.That(resultPage.GetResultHeaderText(), Is.EqualTo("1-48 of over 10,000 results for \"Football\""));
            resultPage.GetResultHeaderText().Should().Be("1-48 of over 10,000 results for \"Football\"");
        }

        [Test]
        public void AmazonTestWithPageObjectDemoqa()
        {
            LandingPage landingPage = new LandingPage(driver); //Object of a class
            landingPage.ClickElements();
            ElementsPage epage = new ElementsPage(driver);
            //epage.ClickTextBox();
            epage.ClickTextBoxWithparam("Text Box");
            epage.fillForm("My full name", "abc@abc.com", "my current address", "my perm address");
            Thread.Sleep(2000);
            epage.Reset();
            Thread.Sleep(3000);
            epage.fillForm("Joseph", "joseph@abc.com", "my current address", "my perm address");
            Thread.Sleep(3000);
        }
    }
}