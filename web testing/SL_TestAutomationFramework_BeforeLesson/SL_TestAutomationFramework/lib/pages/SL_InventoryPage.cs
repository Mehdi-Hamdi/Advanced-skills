using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL_TestAutomationFramework.lib.pages
{
    public class SL_InventoryPage
    {
        public SL_InventoryPage(IWebDriver seleniumDriver)
        {
            SeleniumDriver = seleniumDriver;
        }

        public IWebDriver SeleniumDriver { get; }
    }
}
