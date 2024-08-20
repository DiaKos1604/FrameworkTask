using FrameworkTask.Drivers;
using FrameworkTask.Models;
using FrameworkTask.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

[TestFixture]
public class PricingCalcuratorTest
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
    public void EstimateCostTest()
    {
        try
        {
            var mainPage = new CloudHomePage(_driver);
            mainPage.ClickAddToEstimate();

            var pricingCalculatorPage = new PricingCalculatorPage(_driver);
            var computeEngineModel = new ComputeEngineModel
            {
                NumberOfInstances = 4,
                OperatingSystem = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)",
                ProvisioningModel = "Regular",
                Series = "N1",
                MachineType = "n1-standard-8 (vCPUs: 8, RAM: 30 GB)",
                AddGPUs = true,
                GPUType = "NVIDIA V100",
                NumberOfGPUs = 1,
                LocalSSD = "2x375 Gb",
                DatacenterLocation = "Netherlands (europe-west4)"
            };
            pricingCalculatorPage.FillComputeEngineForm(computeEngineModel);
            pricingCalculatorPage.ClickShareButton();
            pricingCalculatorPage.ClickOpenEstimateSummary();

            var estimateSummaryPage = new PricingCalculatorPage(_driver);
            Assert.IsTrue(estimateSummaryPage.VerifyEstimate());
        }
        catch (Exception ex)
        {
            CaptureScreenshot();
            Assert.Fail($"Test failed: {ex.Message}");
        }
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    private void CaptureScreenshot()
    {
        var screenshot = _driver.TakeScreenshot();
        var fileName = Path.Combine(_screenshotFolder, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
        screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
    }
}
