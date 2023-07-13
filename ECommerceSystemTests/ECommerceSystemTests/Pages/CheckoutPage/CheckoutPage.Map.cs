using OpenQA.Selenium;

namespace ECommerceSystemTests.Pages.CheckoutPage;
public partial class CheckoutPage
{
    public IWebElement FirstNameInput => FindById("input-payment-company");
    public IWebElement LastNameInput => FindById("input-payment-company");
    public IWebElement CityInput => FindById("input-payment-company");
    public IWebElement EmailInput => FindById("input-payment-company");
    public IWebElement PasswordInput => FindById("input-payment-company");
    public IWebElement PasswordConfirmInput => FindById("input-payment-company");
    public IWebElement CompanyInput => FindById("input-payment-company");
    public IWebElement UserAgreementCheckbox => FindByXpath("//label[@for='input-agree']");
    public IWebElement ContinueButton => FindById("button-save");
}
