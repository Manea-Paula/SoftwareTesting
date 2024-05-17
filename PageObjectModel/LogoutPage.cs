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
        public IList <IWebElement> settingsList => driver.FindElements(By.XPath("//div[@class='head-dropdown user-actions logged-in']//ul/li"));
       // public IWebElement bttnLogout => driver.FindElement(By.XPath("//li[@class='dotted-grey user-logout']"));


   

        public void SignOutAccount()
        {

            Thread.Sleep(7000);
            buttonList.Click();
            Thread.Sleep(2000);
            settingsList.ElementAt(2).Click();
          //  bttnLogout.Click();
            Thread.Sleep(1000);
        }
    }
}
