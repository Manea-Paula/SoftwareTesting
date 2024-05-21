using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

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
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//ul[@class='list-unstyled']"));
        }
        private void ScrollToElement(IWebElement element)
        {
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public IWebElement catalogOkaziiLink => driver.FindElement(By.XPath("//a[@title='Catalog Okazii.ro']"));

        public IWebElement laptopImage =>  driver.FindElement(By.XPath("//img[@alt='Laptop, Computere, Gadgets']"));

        public IWebElement adeziviTelefonLink  => driver.FindElement(By.XPath("//a[@title='Adezivi telefon']"));

        public void ClickCatalogOkazii()
        {
            ScrollToFooter();
            Thread.Sleep(2000);
            catalogOkaziiLink.Click();
        }


        public void ClickLaptopImage()
        {
            ScrollToElement(laptopImage);
            Thread.Sleep(1000);
            laptopImage.Click();
        }

        public void ClickAdeziviTelefon()
        {
            ScrollToElement(adeziviTelefonLink);
            Thread.Sleep(1000);
            adeziviTelefonLink.Click();
        }
    }
}
