using FrameworkTask.Drivers;
using FrameworkTask.PageObject;
using OpenQA.Selenium;

namespace FrameworkTask.Tests
{
    [TestFixture]
    public class CloudHomePageTest
    {
        private IWebDriver _driver;
        private string _screenshotFolder = @"C:\Screenshots";

        [SetUp]
        public void SetUp()
        {
            _driver = WebDriverFactory.GetDriver();
            _driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator/?hl=en");
        }

        [Test]
        public void ClickAddToEstimateButtonTest()
        {
            var mainPage = new CloudHomePage(_driver);
            mainPage.ClickAddToEstimate();
            Assert.IsTrue(_driver.Url.Contains("products/calculator"), "URL doesn't contains calculator.");

        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}