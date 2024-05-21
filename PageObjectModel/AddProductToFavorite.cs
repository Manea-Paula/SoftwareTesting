using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    
    internal class AddProductToFavorite
    {
        private IWebDriver driver;
        public AddProductToFavorite(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement product => driver.FindElement(By.XPath("//h2/a[@ajaxtrackableposition='1']"));
        public IWebElement addFavoriteButton => driver.FindElement(By.XPath("//a[@id='btn_addToWatchList']"));
        public IWebElement ConfirmButton => driver.FindElement(By.XPath("//div[@class='f-right']/button"));
        public IWebElement favoriteButton => driver.FindElement(By.XPath("//a[@title='Favorite']"));

        public void AddFavorite()
        {
            product.Click();
            Thread.Sleep(1000);
            addFavoriteButton.Click();
            Thread.Sleep(1000);
            ConfirmButton.Click();
            favoriteButton.Click();
        }
    }
}
