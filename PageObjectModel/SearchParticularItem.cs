using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    class SearchParticularItem
    {
        private IWebDriver driver;

        public SearchParticularItem(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement searchBar => driver.FindElement(By.XPath("//span[@class='twitter-typeahead']//input[@id='terms']"));
        public IWebElement buttonSearch => driver.FindElement(By.XPath("//input[@id='main-search-button']"));
        public IWebElement productBrand => driver.FindElement(By.XPath("//label[@id='b_46']//span[@class='custom-checkbox']//span[@class='box']"));
        public IWebElement productSupplyBattery => driver.FindElement(By.XPath("//label[@id='at_1634026__1578906']//span[@class='custom-checkbox']//span[@class='box']"));


        public void SearchProductInKeyboardBar(string product)
        {
            searchBar.SendKeys(product);
            Thread.Sleep(1000);
            buttonSearch.Click();
            Thread.Sleep(3000);
        }

        public void CustomizeSearch()
        {
            productBrand.Click();
            Thread.Sleep(3000);
            productSupplyBattery.Click();

        }

    }
}
