using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    public class CookieConsent
    {
        private IWebDriver driver;

        public CookieConsent(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement btnConsent => driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
        

        public MenuItemsBeforeSignIn GoToMenuAfterCookieAccept()
        {
            Thread.Sleep(2000);

            btnConsent.Click();

            return new MenuItemsBeforeSignIn(driver);
        }

    }
}
