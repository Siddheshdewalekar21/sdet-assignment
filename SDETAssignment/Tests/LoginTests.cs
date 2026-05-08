using NUnit.Framework;
using Microsoft.Playwright.NUnit;
using FluentAssertions;
using SDETAssignment.Pages;

namespace SDETAssignment.Tests
{
    [TestFixture]
    public class LoginTests : PageTest
    {
        private LoginPage _loginPage;

        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://automationteststore.com/index.php?rt=account/login");
            _loginPage = new LoginPage(Page);
        }

        [Test]
        public async Task ValidLogin_ShouldSucceed()
        {
            // Assuming valid credentials: loginname and password
            // For demo, use test data; in real, use config or test data
            string validLogin = "testuser"; // Replace with actual valid login
            string validPassword = "testpass"; // Replace with actual valid password

            await _loginPage.Login(validLogin, validPassword);

            // Assert login success
            var isLoggedIn = await _loginPage.IsLoginSuccessful();
            isLoggedIn.Should().BeTrue();
        }

        [Test]
        public async Task InvalidLogin_ShouldShowError()
        {
            string invalidLogin = "invaliduser";
            string invalidPassword = "invalidpass";

            await _loginPage.Login(invalidLogin, invalidPassword);

            // Assert error message
            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue();

            var errorText = await _loginPage.GetErrorMessageText();
            errorText.Should().Contain("Error"); // Or specific message
        }

        [Test]
        public async Task EmptyLoginName_ShouldShowError()
        {
            await _loginPage.EnterPassword("somepass");
            await _loginPage.ClickLoginButton();

            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue();
        }

        [Test]
        public async Task EmptyPassword_ShouldShowError()
        {
            await _loginPage.EnterLoginName("somelogin");
            await _loginPage.ClickLoginButton();

            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue();
        }

        [Test]
        public async Task BothFieldsEmpty_ShouldShowError()
        {
            await _loginPage.ClickLoginButton();

            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue();
        }
    }
}