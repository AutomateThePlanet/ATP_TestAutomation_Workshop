using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

namespace ECommerceSystemTests.Infrastructure;
public static class DriverFactory
{
    public static IWebDriver Start(Browsers browser)
    {
        IWebDriver driver;
        switch (browser)
        {
            case Browsers.FIREFOX:
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
                break;
            case Browsers.EDGE:
                new DriverManager().SetUpDriver(new EdgeConfig());
                driver = new EdgeDriver();
                break;
            case Browsers.CHROME:
            default:
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                break;
        }

        return driver;
    }
}
