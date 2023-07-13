using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ECommerceSystemTests.Pages;
public abstract class WebSection
{
    private const int WAIT_TIMEOUT_IN_SECONDS = 30;
    public WebSection(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_IN_SECONDS));
        Actions = new Actions(driver);
    }

    protected IWebDriver Driver { get; }
    protected WebDriverWait Wait { get; }
    protected Actions Actions { get; }
 

    protected IWebElement FindElement(By by)
    {
        return Wait.Until(ExpectedConditions.ElementExists(by));
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
}
