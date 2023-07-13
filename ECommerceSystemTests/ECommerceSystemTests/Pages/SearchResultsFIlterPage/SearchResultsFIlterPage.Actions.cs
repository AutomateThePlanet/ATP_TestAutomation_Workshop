using ECommerceSystemTests.TestData;
using OpenQA.Selenium;

namespace ECommerceSystemTests.Pages.SearchResultsFilterPage;
public partial class SearchResultsFilterPage : WebPage
{
    public SearchResultsFilterPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch";

    public void Search(string query, ProductCategories category, bool searchInDescriptions = false)
    {
        SearchCriteriaInput.SendKeys(query);
        CategoriesSelect.SelectByValue(((int)category).ToString());

        bool shouldCheckDescription = searchInDescriptions && !SearchInDescriptions.Selected;
        bool shouldUncheckDescription = !searchInDescriptions && SearchInDescriptions.Selected;
        if (shouldCheckDescription || shouldUncheckDescription)
        {
            SearchInDescriptions.Click();
        }
    }

    public override void WaitForPageToLoad()
    {
        throw new NotImplementedException();
    }
}
