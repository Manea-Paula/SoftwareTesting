using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    class LogoutPage
    {

        private IWebDriver driver;

        public LogoutPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement buttonList => driver.FindElement(By.XPath("//div[@class='my-account inline-box d-inline with-notifier']"));
        public IWebElement buttonLogout => driver.FindElement(By.XPath("//li[@class='dotted-grey user-logout']"));

        public void SignOutAccount()
        {
            Thread.Sleep(1000);
            buttonList.Click();
            Thread.Sleep(3000);
            buttonLogout.Click();
            
        }
    }
}
