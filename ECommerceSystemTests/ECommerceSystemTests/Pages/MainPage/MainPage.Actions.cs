using OpenQA.Selenium;

namespace ECommerceSystemTests.Pages.MainPage;
public partial class MainPage : WebPage
{
    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=common/home";

    public void OpenPanasonicSeries()
    {
        PanasonicSeriesBanner.Click();
    }

    public override void WaitForPageToLoad()
    {
    }
}
