using OpenQA.Selenium.Chrome;
using SL_TestAutomationFramework.BDD.NewFolder;
using SL_TestAutomationFramework.lib.pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SL_TestAutomationFramework.BDD.steps;

[Binding]
public class SL_SigninStepDefinitions
{
    private SL_Website<ChromeDriver> SL_Website = new();
    private Credentials _creds;


    [Given(@"I enter a valid password")]
    public void GivenIEnterAValidPassword()
    {
        SL_Website.SL_HomePage.EnterPassword(AppConfigReader.Password);
    }

    [When(@"I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        SL_Website.SL_HomePage.ClickLoginButton();
    }

    [Then(@"I should land on the inventory page")]
    public void ThenIShouldLandOnTheInventoryPage()
    {
        Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.InventoryPageUrl));
    }

    [Given(@"I enter an invalid password of ""([^""]*)""")]
    public void GivenIEnterAnInvalidPasswordOf(string passwords)
    {
        SL_Website.SL_HomePage.EnterPassword(passwords);
    }

    [Then(@"I should see an error message that contains ""([^""]*)""")]
    public void ThenIShouldSeeAnErrorMessageThatContains(string expected)
    {
        Assert.That(SL_Website.SL_HomePage.CheckErrorMessage(), Does.Contain(expected));
    }

    [Given(@"I have the following credentials:")]
    public void GivenIHaveTheFollowingCredentials(Table table)
    {
        _creds = table.CreateInstance<Credentials>();
    }

    [Given(@"enter these credentials")]
    public void GivenEnterTheseCredentials()
    {
        SL_Website.SL_HomePage.EnterUserName(_creds.UserName);
        SL_Website.SL_HomePage.EnterPassword(_creds.Password);
    }

    //[BeforeScenario("@HappyPath")]
    //public void ExampleOfScoping()
    //{
    //    SL_Website.SeleniumDriver.Navigate().GoToUrl(@"https://c.tenor.com/TGU9Y4QljOMAAAAi/wontae-hamster.gif");
    //    Thread.Sleep(10000);
    //}

    [AfterScenario]
    public void DisposableWebDriver() 
    {
        SL_Website.SeleniumDriver.Close();
        SL_Website.SeleniumDriver.Quit();
    }
}
