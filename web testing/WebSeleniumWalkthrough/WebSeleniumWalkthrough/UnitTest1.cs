using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace WebSeleniumWalkthrough;

public class Tests
{
    [Test]
    [Category("Happy")]
    public void GivenIAmOnHomePage_WhenIEnterAValidEmailAddressAndPassword_ThenIShouldLandOnTheInventoryPage()
    {
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //navigate to saucedemo.com
            driver.Navigate().GoToUrl("http://saucedemo.com");

            //grab username field
            var usernNameField = driver.FindElement(By.Id("user-name"));

            //enter username
            usernNameField.SendKeys("standard_user");

            //grab password field
            var passwordField = driver.FindElement(By.Id("password"));

            //enter password 
            passwordField.SendKeys("secret_sauce");

            //click the sign in page
            driver.FindElement(By.Id("login-button")).Click();

            //assert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

        }

    }

    [Test]
    [Category("sad")]
    public void GivenIAmOnHomePage_WhenIEnterAnInValidEmailAddress_ThenIShouldStayOnTheHompeage()
    {
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //navigate to saucedemo.com
            driver.Navigate().GoToUrl("http://saucedemo.com");

            //grab username field
            var usernNameField = driver.FindElement(By.Id("user-name"));

            //enter username
            usernNameField.SendKeys("*");

            //grab password field
            var passwordField = driver.FindElement(By.Id("password"));

            //enter password 
            passwordField.SendKeys("secret_sauce");

            //click the sign in page
            driver.FindElement(By.Id("login-button")).Click();

            //assert that we are on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

        }

    }

    [Test]
    public void GivenIAmOnLoginPage_WhenIEnterAValidEmailAddressAndPassword_ThenIShouldLandOnTheSecureAreaPage()
    {
        //Given that I am on the login page
        //When I enter a valid email and password
        //then I should land on the secure area page
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //setup headless driver

            //navigate to herokuapp
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            //grab username field
            var usernNameField = driver.FindElement(By.Id("username"));

            //enter username
            usernNameField.SendKeys("tomsmith");

            //grab password field
            var passwordField = driver.FindElement(By.Id("password"));

            //enter password 
            passwordField.SendKeys("SuperSecretPassword!");

            //click the sign in page
            driver.FindElement(By.ClassName("radius")).Click();

            //assert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"));

        }

    }
    [Test]
    public void GivenIAmOnForgotPasswordPage_WhenIEnterInvalidEmail_ThenIShouldGetInternalServerError()
    {
        //Given that I am on the forgot password page
        //When I enter an invalid email
        //then I should get an internal server error messagde
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //navigate to herokuapp
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/forgot_password");

            //grab username field
            var emailField = driver.FindElement(By.Id("email"));

            //enter email
            emailField.SendKeys("*");

            //click the retrieve password
            driver.FindElement(By.ClassName("radius")).Click();

            var errorMessage = driver.FindElement(By.TagName("h1")).Text;

            //assert that error message displays
            Assert.That(errorMessage, Is.EqualTo("Internal Server Error"));

        }

    }
    [Test]
    public void GivenIAmOnKeyPressesPage_WhenITypeL_ThenIShouldGetAMessageSayingYouTypedL()
    {
        //Given that I am on the key presses page
        //When I type L
        //Then I Should Get A Message Saying You Typed L
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //navigate to herokuapp
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/key_presses");

            //grab key presses field
            var keyPressesField = driver.FindElement(By.Id("target"));

            //enter L
            keyPressesField.SendKeys("l");

            var display = driver.FindElement(By.Id("result"));

            //assert that message displays
            Assert.That(display.Text, Is.EqualTo("You entered: L"));
        }

    }
    [Test]
    public void GivenIAmOnTheRedirectorPage_WhenIClickTheLink_ThenIShouldLandOnTheStatusCodesPage()
    {
        //Given I am on the redirector page
        //when i click the redirect link
        //then i should get redirected to the status code page
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //navigate to saucedemo.com
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/redirector");

            //click the here link
            driver.FindElement(By.Id("redirect")).Click();

            //assert that we are on the status code page
            Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/status_codes"));

        }

    }
    //Found DEFECT
    [Test]
    public void GivenIAmOnEntryAdPage_WhenIClickLink_ThenIShouldGetAPopUp()
    {
        //Given that I am on the forgot password page
        //When I enter an invalid email
        //then I should get an internal server error messagde
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use  web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {
            //navigate to herokuapp
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

            //click the click here link
            driver.FindElement(By.XPath("//*[@id=\"content\"]/ul/li[15]/a")).Click();

            var popUp = driver.FindElement(By.XPath("//*[@id=\"modal\"]/div[2]/div[1]/h3"));

            //assert that error message displays
            Assert.That(popUp.Text, Is.EqualTo("THIS IS A MODAL WINDOW"));
        }
    }
}