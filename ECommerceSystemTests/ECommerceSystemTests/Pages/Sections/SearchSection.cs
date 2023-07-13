using OpenQA.Selenium;

namespace ECommerceSystemTests.Pages.Sections;
public class SearchSection : WebSection
{
    public SearchSection(IWebDriver driver) : base(driver)
    {
    }

    private IWebElement SearchInput => FindByXpath("//input[@placeholder='Search For Products']");
    private IWebElement SearchButton => FindByXpath("//button[text()='Search']");

    public void Search(string query)
    {
        SearchInput.SendKeys(query);
        SearchButton.Click();
    }
}
