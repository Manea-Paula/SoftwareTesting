using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    public class MenuItemsBeforeSignIn : MenuItems
    {

        private IWebDriver driver;

        public MenuItemsBeforeSignIn(IWebDriver browser) : base(browser)
        {
            driver = browser;
        }

        public IWebElement linkSign => driver.FindElement(By.XPath("//div[@id='ajax-user-menu']//span[@class='orange d-inline b']"));
       
        public LoginPage GoToLogin()
        {
            Thread.Sleep(2000);
            linkSign.Click();

            return new LoginPage(driver);
        }

        


    }
}
