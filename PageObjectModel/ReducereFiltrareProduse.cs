using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Proiect1TPS.PageObjectModel
{
    internal class ReducereFiltrareProduse
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IJavaScriptExecutor jsExecutor;
        private Actions actions;

        public ReducereFiltrareProduse(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            jsExecutor = (IJavaScriptExecutor)driver;
            actions = new Actions(driver);
        }

        private void ScrollToElement(IWebElement element)
        {
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        private void ClickElement(IWebElement element)
        {
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public IWebElement GetProdusNouCheckbox() => wait.Until(driver => driver.FindElement(By.Id("cbx_nou")));
        public IWebElement GetRatingProdusCheckbox() => wait.Until(driver => driver.FindElement(By.Name("rating_product")));
        public IWebElement GetPretMinInput() => wait.Until(driver => driver.FindElement(By.Id("pret_min")));
        public IWebElement GetPretMaxInput() => wait.Until(driver => driver.FindElement(By.Id("pret_max")));
        public IWebElement GetLocalizareDropdown() => wait.Until(driver => driver.FindElement(By.XPath("//button[@data-id='judete' and @title='Oriunde in Romania']")));

        // Use XPath with index to select the correct input element
        public IWebElement GetLocalizareSearchInput() => wait.Until(driver => driver.FindElement(By.XPath("(//div[@class='bootstrap-select-searchbox']//input[@type='text'])[1]")));
        public IWebElement GetIasiOption() => wait.Until(driver => driver.FindElement(By.XPath("//span[text()='Iasi']")));
        public IWebElement GetLocalitateDropdown() => wait.Until(driver => driver.FindElement(By.XPath("//button[@data-id='localitati' and @title='Toate localitatile']")));

        // Use XPath with index to select the correct input element
        public IWebElement GetLocalitateSearchInput() => wait.Until(driver => driver.FindElement(By.XPath("(//div[@class='bootstrap-select-searchbox']//input[@type='text'])[2]")));
        public IWebElement GetIasiLocalitateOption() => wait.Until(driver => driver.FindElement(By.XPath("//li[@rel='184']//a")));

        public IWebElement GetLivrareGratuitaCheckbox() => wait.Until(driver => driver.FindElement(By.XPath("//div[@id='livrare_gratuita']//label[@class='checkbox']")));
        public IWebElement GetCuFacturaCheckbox() => wait.Until(driver => driver.FindElement(By.XPath("//label[contains(@onclick, 'invoice=1')]")));
        public IWebElement GetCuGarantieCheckbox() => wait.Until(driver => driver.FindElement(By.XPath("//label[contains(@onclick, 'warranty=1')]")));
        //public IWebElement GetPoateFiReturnatCheckbox() => wait.Until(driver => driver.FindElement(By.XPath("//label[contains(@onclick, 'poate_fi_returnat=1')]")));
        public void SelectReducerile()
        {
            var veziReducerileLink = wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(), 'Vezi reducerile')]")));
            ScrollToElement(veziReducerileLink);
            ClickElement(veziReducerileLink);
        }

        public void SetPret(int min, int max)
        {
            var pretMinInput = GetPretMinInput();
            var pretMaxInput = GetPretMaxInput();
            ScrollToElement(pretMinInput);
            pretMinInput.Clear();
            pretMinInput.SendKeys(min.ToString());
            pretMaxInput.Clear();
            pretMaxInput.SendKeys(max.ToString());
            pretMaxInput.SendKeys(Keys.Enter);
        }

        public void SelectLocalizareIasi()
        {
            try
            {
                var localizareDropdown = GetLocalizareDropdown();
                ScrollToElement(localizareDropdown);
                ClickElement(localizareDropdown);

                var localizareSearchInput = GetLocalizareSearchInput();
                localizareSearchInput.SendKeys("Iasi");
                Thread.Sleep(500);

                var iasiOption = GetIasiOption();
                ClickElement(iasiOption);
                Thread.Sleep(1000);

                var localitateDropdown = GetLocalitateDropdown();
                ScrollToElement(localitateDropdown);
                ClickElement(localitateDropdown);
                Thread.Sleep(500);

                var localitateSearchInput = GetLocalitateSearchInput();
                localitateSearchInput.SendKeys("Iasi");
                Thread.Sleep(500);

                var iasiLocalitateOption = GetIasiLocalitateOption();
                ScrollToElement(iasiLocalitateOption);

                actions.MoveToElement(iasiLocalitateOption).Perform();
                Thread.Sleep(500);

                ClickElement(iasiLocalitateOption);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not found: " + ex.Message);
            }
            catch (ElementClickInterceptedException ex)
            {
                Console.WriteLine("Element click intercepted: " + ex.Message);
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Element not clickable within timeout: " + ex.Message);
            }
        }

        public void BifeazaCheckbox(IWebElement checkbox)
        {
            ScrollToElement(checkbox);
            Thread.Sleep(2000);
            ClickElement(checkbox);
        }
    }
}
