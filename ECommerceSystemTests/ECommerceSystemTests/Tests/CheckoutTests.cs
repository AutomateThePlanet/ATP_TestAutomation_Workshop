using ECommerceSystemTests.Pages.CheckoutPage;

namespace ECommerceSystemTests.Tests;

public class CheckoutTests : BaseTests
{
    [Test]
    public void SearchProduct()
    {
        _mainPage.Open();
        _mainPage.SearchSection.Search("camera");

        _searchResultsFilterPage.Search("cannon", TestData.ProductCategories.MAC, true);
    }

    [Test]
    public void CheckoutSpecificTest()
    {
        // Arrange
        var input = new PurchaseInput()
        {
            FirstName = "Anton",
            LastName = "Angelov",
            Company = "Automate The Planet",
            Country = "Bulgaria",
            // etc.
        };

        // Act
        _mainPage.Open();
        _checkoutPage.Open();
        _checkoutPage.FillInfo(PurchaseType.GUEST_CHECKOUT, input);

        // Assert
        _checkoutPage.AssertPrices();
    }
}