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
        private ILocator ErrorMessage => _page.Locator(".alert"); // Error messages are in alert class
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
            // Check for successful navigation to account dashboard or similar
            try
            {
                await _page.WaitForURLAsync(url => !url.Contains("login"), new() { Timeout = 5000 });
                return !_page.Url.Contains("login");
            }
            catch
            {
                return false;
            }
        }
    }
}