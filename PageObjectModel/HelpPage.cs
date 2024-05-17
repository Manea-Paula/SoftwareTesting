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
    public class HelpPage
    {
        private IWebDriver driver;
        private CookieConsent cookieConsentHelpForm;

        public HelpPage(IWebDriver browser)
        {
            driver = browser;
            cookieConsentHelpForm = new CookieConsent(browser);
        }

        

        public IWebElement buttonHelp => driver.FindElement(By.XPath("//div[@class='help-item d-inline']/a"));
        public IWebElement formHelpLink => driver.FindElement(By.XPath("//div[@class='row']/nav[@role='navigation']/a[text()='Formular ajutor']"));
      //  public IWebElement ReasonDropdown => driver.FindElement(By.CssSelector("select[name='n_pb']"));
        public IWebElement btnConsentHelpForm => driver.FindElement(By.Id("cn-close-notice"));

        public void GoToHelp()
        {
            Thread.Sleep(2000);
            buttonHelp.Click();
            Thread.Sleep(3000);
           
            btnConsentHelpForm.Click();
            formHelpLink.Click();

        }


    }
}
