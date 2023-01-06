
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MyfirstAutomation
{
    public enum browserType
    {
        Chrome = 0,
        Firefox = 1,
        Edge = 2
    }

    public class Hooks
    {
        public IWebDriver driver; //Globalization
        browserType browser = browserType.Chrome;
        //browserType browser = (int)browserType.Edge;

        [SetUp]
        public void initialize()
        {
            //Traditional way
            //if (browser == browserType.Chrome)
            //{
            //    ChromeOptions options = new ChromeOptions();
            //    options.AddArguments("--start-maximized", "--incognito");
            //    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            //    driver = new ChromeDriver(options);
            //}
            //else if(browser == browserType.Firefox)
            //{
            //    FirefoxOptions options = new FirefoxOptions();
            //    options.AddArguments("--width=1920");
            //    options.AddArguments("--height=1080");
            //    options.AddArguments("--private");
            //    new DriverManager().SetUpDriver(new FirefoxConfig());
            //    driver = new FirefoxDriver(options);
            //}
            //else if(browser == browserType.Edge)
            //{
            //    EdgeOptions options = new EdgeOptions();
            //    options.AddArguments("--start-maximized", "--InPrivate");
            //    new DriverManager().SetUpDriver(new EdgeConfig());
            //    driver = new EdgeDriver(options);
            //}

            //Conventional way
            //Terary if statement
            //var chromeBrowser = browser == browserType.Chrome 
            //    ? driver = new ChromeDriver(Chromeopts()) 
            //    : browser == browserType.Firefox
            //    ? driver = new FirefoxDriver(Firefoxoption())
            //    : null;

            //Switch statements
            //switch (browser)
            //{
            //    case browserType.Chrome:
            //        driver = new ChromeDriver(Chromeopts());
            //        break;
            //    case browserType.Firefox:
            //        driver = new FirefoxDriver(Firefoxoption());
            //        break;
            //    default:
            //        throw new Exception("Sorry no such browser");
            //}

            driver = runthisbrowser(browser);

            //driver.Navigate().GoToUrl("https://youtube.com");
            //driver.Url = "https://youtube.com";
            //driver.Navigate().GoToUrl("https://amazon.co.uk");
            driver.Navigate().GoToUrl("https://demoqa.com");
        }

        public IWebDriver runthisbrowser(browserType browser) => browser switch
        {
            browserType.Chrome => driver = new ChromeDriver(Chromeopts()),
            browserType.Firefox => driver = new FirefoxDriver(Firefoxoption()),
            _ => throw new Exception("No such browser found")
        };

        public ChromeOptions Chromeopts()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            return options;
        }

        public FirefoxOptions Firefoxoption()
        {
            FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("--width=1920");
                options.AddArguments("--height=1080");
                options.AddArguments("--private");
            return options;
        }

        [TearDown]
        public void CloseBrowser()
        {
            //The code that gets executed last
            driver.Quit();
        }
    }
}
