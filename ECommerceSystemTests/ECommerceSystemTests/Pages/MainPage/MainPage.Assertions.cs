namespace ECommerceSystemTests.Pages.MainPage;
public partial class MainPage
{
    public void AssertShopNowButtonLink()
    {
        Assert.AreEqual("#", ShopNowButton.GetAttribute("href"));
    }
}
