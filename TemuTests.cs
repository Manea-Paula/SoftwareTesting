using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Proiect1TPS.PageObjectModel;
using Proiect1TPS.TestData;
using System;
using System.Threading;

namespace Proiect1TPS
{
    [TestClass]
    public class TemuTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private LogoutPage logoutPage;
        private CookieConsent cookieConsent;
        private MenuItemsBeforeSignIn menuItemsBeforeSignIn;
        private SearchParticularItem searchParticularItem;
        

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver(options); 
            driver.Manage().Window.Maximize();
            
            driver.Navigate().GoToUrl("https://www.okazii.ro/");

            cookieConsent = new CookieConsent(driver);
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
            menuItemsBeforeSignIn = new MenuItemsBeforeSignIn(driver);
            searchParticularItem = new SearchParticularItem(driver);

            cookieConsent.GoToMenuAfterCookieAccept();
        }



        [TestMethod]
        public void LoginValidAccount()
        {
            Thread.Sleep(1000);
            menuItemsBeforeSignIn.GoToLogin();

            loginPage.SignInAccount(Resources.email, Resources.password);

            //Wait for page to load
            Thread.Sleep(2000);

        }

        [TestMethod]
        public void LogoutValidAccount()
        {
            menuItemsBeforeSignIn.GoToLogin();

            loginPage.SignInAccount(Resources.email, Resources.password);

            //Wait for page to load
            Thread.Sleep(2000);

            logoutPage.SignOutAccount();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void SearchProductAndCustomize()
        {
            searchParticularItem.SearchProductInKeyboardBar(Resources.product);
            Thread.Sleep(1000);
            searchParticularItem.CustomizeSearch();
            Thread.Sleep(5000);
        }



        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
