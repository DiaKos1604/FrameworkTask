using FrameworkTask.Models;
using OpenQA.Selenium;

namespace FrameworkTask.PageObject
{
    public class PricingCalculatorPage
    {
        private readonly IWebDriver _driver;
        public PricingCalculatorPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By _addToEstimateButton = By.XPath("//span[text()='Add to estimate']");
        private readonly By _selectComputerEngine = By.XPath("//h2[(text()='Compute Engine')]");
        private readonly By _numberOfInstances = By.XPath("c13");
        private readonly By _operatingSystemDropdown = By.XPath("");
        private readonly By _provisioningModelDropdown = By.XPath("//label[text()='Regular']");
        private readonly By _seriesDropdown = By.XPath("");
        private readonly By _machineTypeDropdown = By.XPath("");
        private readonly By _addGPUsCheckbox = By.XPath("");
        private readonly By _gpuTypeDropdown = By.XPath("");
        private readonly By _numberOfGPUsDropdown = By.XPath("");
        private readonly By _localSSDDropdown = By.XPath("");
        private readonly By _datacenterLocationDropdown = By.XPath("");
        private readonly By _shareButton = By.XPath("//button[contains(text(),'Add to Estimate')]");
        private readonly By _estimateSummaryButton = By.XPath("//button[contains(text(),'Email Estimate')]");

        public void FillComputeEngineForm(ComputeEngineModel model)
        {
            _driver.FindElement(_selectComputerEngine).Click();

            _driver.FindElement(_addToEstimateButton).Click();
           
            _driver.FindElement(_numberOfInstances).SendKeys(model.NumberOfInstances.ToString());
            _driver.FindElement(_operatingSystemDropdown).SendKeys(model.OperatingSystem);
            _driver.FindElement(_provisioningModelDropdown).SendKeys(model.ProvisioningModel);
            _driver.FindElement(_seriesDropdown).SendKeys(model.Series);
            _driver.FindElement(_machineTypeDropdown).SendKeys(model.MachineType);

            _driver.FindElement(_addGPUsCheckbox).Click();
            _driver.FindElement(_gpuTypeDropdown).SendKeys(model.GPUType);
            _driver.FindElement(_numberOfGPUsDropdown).SendKeys(model.NumberOfGPUs.ToString());
            _driver.FindElement(_localSSDDropdown).SendKeys(model.LocalSSD);
            _driver.FindElement(_datacenterLocationDropdown).SendKeys(model.DatacenterLocation);
        }
        public void ClickShareButton()
        {
            _driver.FindElement(_shareButton).Click();
        }

        public void ClickOpenEstimateSummary()
        {
            _driver.FindElement(_estimateSummaryButton).Click();
        }
        public bool VerifyEstimate()
        {
            return true;
        }

    }
}
