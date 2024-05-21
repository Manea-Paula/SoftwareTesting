using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Proiect1TPS.PageObjectModel
{
    internal class ProductFromCatalog
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IJavaScriptExecutor jsExecutor;

        public ProductFromCatalog(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            jsExecutor = (IJavaScriptExecutor)driver;
        }
        private void ScrollToFooter()
        {
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='list-unstyled']")));
        }
        private void ScrollToElement(IWebElement element)
        {
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public IWebElement catalogOkaziiLink => wait.Until(driver => driver.FindElement(By.XPath("//a[@title='Catalog Okazii.ro']")));


        public IWebElement laptopImage => wait.Until(driver => driver.FindElement(By.XPath("//img[@alt='Laptop, Computere, Gadgets']")));


        public IWebElement adeziviTelefonLink => wait.Until(driver => driver.FindElement(By.XPath("//a[@title='Adezivi telefon']")));

        public void ClickCatalogOkazii()
        {
            ScrollToFooter();
            catalogOkaziiLink.Click();
        }


        public void ClickLaptopImage()
        {
            ScrollToElement(laptopImage);
            laptopImage.Click();
        }

        public void ClickAdeziviTelefon()
        {
            ScrollToElement(adeziviTelefonLink);
            adeziviTelefonLink.Click();
        }
    }
}
