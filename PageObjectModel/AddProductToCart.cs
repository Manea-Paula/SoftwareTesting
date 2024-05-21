using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    public class AddProductToCart
    {
        private IWebDriver driver;
        public AddProductToCart (IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement addToCart => driver.FindElement(By.XPath("//button[@class='add-to-cart-button-link ajax']"));
        public IWebElement goToCart => driver.FindElement(By.XPath("//a[@class='btn btn-gradient-light-blue btn-blue-light btn-sm  btn-block btn-primary product-info-row-actions-seecart']"));

        public void AddToCart()
        {
            Thread.Sleep(1000);
            addToCart.Click();
            Thread.Sleep(3000);
            goToCart.Click();
          
        }
    }
}
