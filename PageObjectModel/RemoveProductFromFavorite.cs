using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    internal class RemoveProductFromFavorite
    {
        private IWebDriver driver;
        private IAlert alert;
        public RemoveProductFromFavorite(IWebDriver browser)
        {
            driver = browser;
            
        }

        public IWebElement favoriteButton => driver.FindElement(By.XPath("//a[@title='Favorite']"));
        public IWebElement checkBox => driver.FindElement(By.XPath("//tr[@class='tr_auction']/td/input"));
        public IWebElement deleteButton => driver.FindElement(By.XPath("//span[@id='std_btn_doi']/input[@value='Sterge']"));

        public void DeleteProduct()
        {
            favoriteButton.Click();
            Thread.Sleep(1000);
            checkBox.Click();
            deleteButton.Click();
            Thread.Sleep(1000);
            alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }

    
}
