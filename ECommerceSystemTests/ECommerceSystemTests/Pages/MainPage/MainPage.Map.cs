using OpenQA.Selenium;

namespace ECommerceSystemTests.Pages.MainPage;
public partial class MainPage
{
    public IWebElement ShopNowButton => FindElement(By.XPath("//a[text()='SHOP NOW']"));
    public IWebElement PanasonicSeriesBanner => FindElement(By.XPath("//a[@title='Lumix S Series From Panasonic']"));
}
