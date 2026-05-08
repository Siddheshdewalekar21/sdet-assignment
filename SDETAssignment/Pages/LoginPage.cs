using Microsoft.Playwright;

namespace SDETAssignment.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator LoginNameInput => _page.Locator("input[name='loginname']");
        private ILocator PasswordInput => _page.Locator("input[name='password']");
        private ILocator LoginButton => _page.Locator("button:has-text('Login')");
        private ILocator ErrorMessage => _page.Locator(".alert-danger"); // Assuming error messages are in alert-danger class
        private ILocator SuccessMessage => _page.Locator(".alert-success");

        // Actions
        public async Task EnterLoginName(string loginName)
        {
            await LoginNameInput.FillAsync(loginName);
        }

        public async Task EnterPassword(string password)
        {
            await PasswordInput.FillAsync(password);
        }

        public async Task ClickLoginButton()
        {
            await LoginButton.ClickAsync();
        }

        public async Task Login(string loginName, string password)
        {
            await EnterLoginName(loginName);
            await EnterPassword(password);
            await ClickLoginButton();
        }

        // Assertions
        public async Task<bool> IsErrorMessageVisible()
        {
            return await ErrorMessage.IsVisibleAsync();
        }

        public async Task<string> GetErrorMessageText()
        {
            return await ErrorMessage.TextContentAsync() ?? string.Empty;
        }

        public async Task<bool> IsLoginSuccessful()
        {
            // Assuming after login, redirected to account page or success message
            await _page.WaitForURLAsync("**/account/**");
            return _page.Url.Contains("account");
        }
    }
}