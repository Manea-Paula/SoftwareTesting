using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Proiect1TPS.PageObjectModel
{
    internal class AndroidPhonePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private IJavaScriptExecutor jsExecutor;

        public AndroidPhonePage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Ajustează timpul de așteptare după necesități
            jsExecutor = (IJavaScriptExecutor)driver;
        }

        public IWebElement aplicatieAndroidLink => wait.Until(driver => driver.FindElement(By.XPath("//a[@title='Aplicatie Android']")));
        public IWebElement descarcaGooglePlayLink => wait.Until(driver => driver.FindElement(By.XPath("//a[@title='descarca din Google play']")));

        public void ClickAplicatieAndroid()
        {
            ScrollToFooter();
            aplicatieAndroidLink.Click();
        }
        public void ClickDescarcaGooglePlay()
        {
            ScrollToElement(descarcaGooglePlayLink);
            descarcaGooglePlayLink.Click();
        }

        private void ScrollToFooter()
        {
            jsExecutor.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            wait.Until(driver => driver.FindElement(By.XPath("//ul[@class='list-unstyled']")));
        }
        private void ScrollToElement(IWebElement element)
        {
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
