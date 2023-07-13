using ECommerceSystemTests.Pages.Sections;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ECommerceSystemTests.Pages;
public abstract class WebPage
{
    private const int WAIT_TIMEOUT_IN_SECONDS = 30;

    public WebPage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_IN_SECONDS));
        Actions = new Actions(driver);
    }

    public SearchSection SearchSection => new SearchSection(Driver);
    protected IWebDriver Driver { get; }
    protected WebDriverWait Wait { get; }
    protected Actions Actions { get; }
    protected abstract string Url { get; }

    public void Open()
    {
        Driver.Navigate().GoToUrl(Url);
        WaitForPageToLoad();
    }

    protected IWebElement FindElement(By by)
    {
        return Wait.Until(ExpectedConditions.ElementExists(by));
    }

    protected IWebElement FindByXpath(string xpath)
    {
        return Wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
    }

    protected IWebElement FindById(string id)
    {
        return Wait.Until(ExpectedConditions.ElementExists(By.Id(id)));
    }

    protected IWebElement FindByName(string name)
    {
        return Wait.Until(ExpectedConditions.ElementExists(By.Name(name)));
    }

    protected IWebElement FindByCss(string css)
    {
        return Wait.Until(ExpectedConditions.ElementExists(By.CssSelector(css)));
    }

    protected IWebElement WaitToBeClickable(By by)
    {
        return Wait.Until(ExpectedConditions.ElementToBeClickable(by));
    }

    protected void MoveToElement(IWebElement element)
    {
        Actions.MoveToElement(element).Perform();
    }

    protected void DragAndDrop(IWebElement source, IWebElement destination)
    {
        Actions.DragAndDrop(source, destination).Perform();
    }

    public abstract void WaitForPageToLoad();
}
