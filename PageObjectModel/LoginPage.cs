using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }


        public IWebElement textEmail => driver.FindElement(By.XPath("//div[@class='form-group']//input[@id='login_input']"));
        public IWebElement textPassword => driver.FindElement(By.XPath("//div[@class='form-group']//input[@id='login_pass']"));
        public IWebElement buttonRegister => driver.FindElement(By.XPath("//button[@class='btn btn-block btn-primary login_btn']"));

        public void SignInAccount(string email, string password)
        {
            Thread.Sleep(1000);
            textEmail.SendKeys(email);
            textPassword.SendKeys(password);
            buttonRegister.Click();
        }
    }
}
