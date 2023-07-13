using OpenQA.Selenium;

namespace ECommerceSystemTests.Pages.CheckoutPage;
public partial class CheckoutPage : WebPage
{
    public CheckoutPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=common/home";

    public void FillInfo(PurchaseType purchaseType, PurchaseInput input)
    {
        switch (purchaseType)
        {
            case PurchaseType.GUEST_CHECKOUT:
                FillPersonalDetails(input);
                break;
            case PurchaseType.LOGIN:
                break;
            case PurchaseType.REGISTER:
                FillPersonalDetails(input);
                break;
            case PurchaseType.ALREADY_LOGGED_IN:
                break;
        }

        UserAgreementCheckbox.Click();
        ContinueButton.Click();
    }

    private void FillPersonalDetails(PurchaseInput input)
    {
        FirstNameInput.SendKeys(input.FirstName);
        LastNameInput.SendKeys(input.LastName);
        PasswordInput.SendKeys(input.LastName);
        // TODO: finish
    }

    public void UpdateProductQuantity(string productName)
    {
        //PanasonicSeriesBanner.Click();
    }

    public void RemoveProductFromCart(string productName)
    {
        //PanasonicSeriesBanner.Click();
    }

    public override void WaitForPageToLoad()
    {
    }
}
