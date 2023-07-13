using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ECommerceSystemTests.Pages.SearchResultsFilterPage;
public partial class SearchResultsFilterPage
{
    public IWebElement SearchCriteriaInput => FindById("input-search");
    public IWebElement SearchCriteriaButton => FindById("button-search");
    public IWebElement SearchInDescriptions => FindById("description");
    public SelectElement CategoriesSelect
    {
        get
        {
            var innerElement = FindByName("category_id");    
            return new SelectElement(innerElement);
        }
    }
}
