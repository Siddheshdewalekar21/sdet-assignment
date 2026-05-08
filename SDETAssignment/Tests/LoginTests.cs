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
        public async Task ValidLogin_WithCorrectCredentials_ShouldSucceed()
        {
            // Note: Valid test credentials should be provided or created before running
            // For this demo, we skip this test as we don't have test account setup
            Assert.Inconclusive("Valid credentials not available in test environment. Setup test user account first.");
        }

        [Test]
        public async Task InvalidCredentials_ShouldDisplayErrorMessage()
        {
            string invalidLogin = "invaliduser123";
            string invalidPassword = "wrongpassword";

            await _loginPage.Login(invalidLogin, invalidPassword);

            // Assert error message appears
            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue("Error message should be displayed for invalid credentials");

            var errorText = await _loginPage.GetErrorMessageText();
            errorText.Should().Contain("Incorrect", "Error message should indicate incorrect credentials");
        }

        [Test]
        public async Task EmptyLoginName_WithPasswordOnly_ShouldShowError()
        {
            await _loginPage.EnterPassword("somepassword");
            await _loginPage.ClickLoginButton();

            // Wait for error
            await Page.WaitForTimeoutAsync(1000);
            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue("Error message should be displayed when login name is empty");
        }

        [Test]
        public async Task EmptyPassword_WithLoginNameOnly_ShouldShowError()
        {
            await _loginPage.EnterLoginName("testuser");
            await _loginPage.ClickLoginButton();

            // Wait for error
            await Page.WaitForTimeoutAsync(1000);
            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue("Error message should be displayed when password is empty");
        }

        [Test]
        public async Task BothFieldsEmpty_ShouldShowError()
        {
            await _loginPage.ClickLoginButton();

            // Wait for error
            await Page.WaitForTimeoutAsync(1000);
            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue("Error message should be displayed when both fields are empty");
        }

        [Test]
        public async Task InvalidLogin_WithSpecialCharacters_ShouldShowError()
        {
            await _loginPage.Login("<script>alert('xss')</script>", "password@123");

            // Wait for error
            await Page.WaitForTimeoutAsync(1000);
            var isErrorVisible = await _loginPage.IsErrorMessageVisible();
            isErrorVisible.Should().BeTrue("Error message should be displayed for special characters in login");
        }
    }
}