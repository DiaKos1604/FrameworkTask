using OpenQA.Selenium;

namespace FrameworkTask.PageObject
{
    public class CloudHomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _addToEstimateButton = By.XPath("//span[text()='Add to estimate'");
        public CloudHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAddToEstimate()
        {
            _driver.FindElement(_addToEstimateButton).Click();
        }
    }
}