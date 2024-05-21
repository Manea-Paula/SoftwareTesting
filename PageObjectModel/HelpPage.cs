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
        //public IWebElement formHelpLink => driver.FindElement(By.XPath("//div[@class='row']/nav[@role='navigation']/a[text()='Formular ajutor']"));
        //public IWebElement ReasonDropdown => driver.FindElement(By.CssSelector("select[name='n_pb']"));
        public IWebElement SearchText => driver.FindElement(By.XPath("//input[@name='s']"));
        public IWebElement SearchButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        //public IWebElement btnConsentHelpForm => driver.FindElement();
        public IWebElement TermsButton => driver.FindElement(By.XPath("//a[@title='Permanent Link to Termeni și Condiții']"));
        public IWebElement ClauzeGenerale => driver.FindElement(By.XPath("//a[@href='#statutul1']"));

        public void GoToHelp()
        {
            Thread.Sleep(2000);
            buttonHelp.Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            SearchText.SendKeys("Termeni și Condiții");
            SearchButton.Click();
            Thread.Sleep(2000);
            TermsButton.Click();
            Thread.Sleep(2000);
            ClauzeGenerale.Click();
            Thread.Sleep(2000);
            //btnSell.Click();
            //btnConsentHelpForm.Click();
            //formHelpLink.Click();

        }


    }
}
