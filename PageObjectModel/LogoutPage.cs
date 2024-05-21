using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        Actions actions;

        public LogoutPage(IWebDriver browser)
        {
            driver = browser;
            actions = new Actions(driver);
        }

        public IWebElement buttonList => driver.FindElement(By.XPath("//div[@class='my-account inline-box d-inline with-notifier']"));
        public IList <IWebElement> settingsList => driver.FindElements(By.XPath("//div[@class='head-dropdown user-actions logged-in']//ul/li"));
       // public IWebElement bttnLogout => driver.FindElement(By.XPath("//li[@class='dotted-grey user-logout']"));


   

        public void SignOutAccount()
        {

            Thread.Sleep(7000);
            //buttonList.Click();
            actions.MoveToElement(buttonList).Perform();
            //Thread.Sleep(5000);
            settingsList.ElementAt(13).Click();
          //  bttnLogout.Click();
            Thread.Sleep(2000);
        }
    }
}
