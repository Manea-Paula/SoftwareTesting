using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1TPS.PageObjectModel
{
    public class MenuItems
    {
        private IWebDriver driver;

        public MenuItems(IWebDriver browser)
        {
            driver = browser;
        }
    }
}
