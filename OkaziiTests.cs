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
    public class OkaziiTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private LogoutPage logoutPage;
        private CookieConsent cookieConsent;
        private MenuItemsBeforeSignIn menuItemsBeforeSignIn;
        private SearchParticularItem searchParticularItem;
        private HelpPage helpPage;
        private AddProductToFavorite favouriteProduct;
        private RemoveProductFromFavorite productToRenove;
        

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
            helpPage = new HelpPage(driver);
            favouriteProduct = new AddProductToFavorite(driver);
            productToRenove = new RemoveProductFromFavorite(driver);
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

        [TestMethod]
        public void HelpContact()
        {
            helpPage.GoToHelp();
            
        }
        [TestMethod]
        public void FavoriteProduct()
        {
            menuItemsBeforeSignIn.GoToLogin();

            loginPage.SignInAccount(Resources.email, Resources.password);
            Thread.Sleep(2000);
            searchParticularItem.SearchProductInKeyboardBar(Resources.product);
            Thread.Sleep(1000);
            searchParticularItem.CustomizeSearch();
            Thread.Sleep(1000);
            favouriteProduct.AddFavorite();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void RemoveProduct()
        {
            menuItemsBeforeSignIn.GoToLogin();

            loginPage.SignInAccount(Resources.email, Resources.password);
            Thread.Sleep(2000);
            productToRenove.DeleteProduct();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void AndroidPhonePageTest()
        {
            menuItemsBeforeSignIn.GoToLogin();
            Thread.Sleep(2000);
            loginPage.SignInAccount(Resources.email, Resources.password);
            Thread.Sleep(2000);
            var androidPhonePage = new AndroidPhonePage(driver);
            androidPhonePage.ClickAplicatieAndroid();
            Thread.Sleep(2000);
            androidPhonePage.ClickDescarcaGooglePlay();
            Thread.Sleep(2000);
        }
       
        [TestMethod]
        public void ProductFromCatalogTest()
        {
           
            menuItemsBeforeSignIn.GoToLogin();
            Thread.Sleep(2000);
            loginPage.SignInAccount(Resources.email, Resources.password);
            Thread.Sleep(2000);
            var productFromCatalog = new Proiect1TPS.PageObjectModel.ProductFromCatalog(driver);
            productFromCatalog.ClickCatalogOkazii();
            Thread.Sleep(2000);
            productFromCatalog.ClickLaptopImage();
            Thread.Sleep(2000);
            productFromCatalog.ClickAdeziviTelefon();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void ReducereFiltrareProduseTest()
        {
            var productFilterPage = new ReducereFiltrareProduse(driver);

            productFilterPage.SelectReducerile();
            Thread.Sleep(2000);

            productFilterPage.BifeazaCheckbox(productFilterPage.GetProdusNouCheckbox());
            Thread.Sleep(2000);

            productFilterPage.BifeazaCheckbox(productFilterPage.GetRatingProdusCheckbox());
            Thread.Sleep(2000);

            productFilterPage.SetPret(100, 1000);
            Thread.Sleep(2000);

            productFilterPage.SelectLocalizareIasi();
            Thread.Sleep(2000);

            productFilterPage.BifeazaCheckbox(productFilterPage.GetLivrareGratuitaCheckbox());
            Thread.Sleep(2000);

            productFilterPage.BifeazaCheckbox(productFilterPage.GetCuFacturaCheckbox());
            Thread.Sleep(2000);

            productFilterPage.BifeazaCheckbox(productFilterPage.GetCuGarantieCheckbox());
            Thread.Sleep(3000);

            //productFilterPage.BifeazaCheckbox(productFilterPage.GetPoateFiReturnatCheckbox());
            //Thread.Sleep(2000);
        }




        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
