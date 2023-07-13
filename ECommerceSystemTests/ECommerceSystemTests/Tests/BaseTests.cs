using ECommerceSystemTests.Infrastructure;
using ECommerceSystemTests.Pages.CheckoutPage;
using ECommerceSystemTests.Pages.MainPage;
using ECommerceSystemTests.Pages.SearchResultsFilterPage;
using OpenQA.Selenium;

namespace ECommerceSystemTests.Tests;

public class BaseTests
{
    protected IWebDriver _driver;
    protected MainPage _mainPage;
    protected SearchResultsFilterPage _searchResultsFilterPage;
    protected CheckoutPage _checkoutPage;

    [SetUp]
    public void TestInit()
    {
        _driver = DriverFactory.Start(Browsers.CHROME);
        _mainPage = new MainPage(_driver);
        _searchResultsFilterPage = new SearchResultsFilterPage(_driver);
        _checkoutPage = new CheckoutPage(_driver);
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }
}