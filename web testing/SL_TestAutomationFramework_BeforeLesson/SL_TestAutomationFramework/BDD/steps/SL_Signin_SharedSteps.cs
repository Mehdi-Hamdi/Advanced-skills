using OpenQA.Selenium.Chrome;
using SL_TestAutomationFramework.lib.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SL_TestAutomationFramework.BDD.steps
{
    public class SL_Signin_SharedSteps
    {
        private SL_Website<ChromeDriver> SL_Website = new();

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            SL_Website.SL_HomePage.VisitHomePage();
        }

        [Given(@"I enter a valid username")]
        public void GivenIEnterAValidUsername()
        {
            SL_Website.SL_HomePage.EnterUserName(AppConfigReader.UserName);
        }
    }
}
