# SDET Assignment - Login Flow Automation

## Project Overview
This is a complete test automation solution for the **Login Flow** of the Automation Test Store application. The solution demonstrates best practices in SDET including the Page Object Model pattern, clean code, and comprehensive test coverage.

**Application Under Test:** https://automationteststore.com/index.php?rt=account/login

## Technology Stack
- **Language:** C# .NET 10
- **UI Automation Framework:** Playwright for .NET v1.59.0
- **Test Framework:** NUnit 5.0.0
- **Assertion Library:** FluentAssertions 8.9.0
- **Version Control:** Git

## Prerequisites
- .NET 10.0 or later installed
- Git installed
- Windows OS (tested on Windows 10/11)

## Project Structure
```
SDETAssignment/
├── Pages/
│   └── LoginPage.cs          # Page Object Model for login page
├── Tests/
│   └── LoginTests.cs         # Test cases for login functionality
├── SDETAssignment.csproj    # Project file with dependencies
└── bin/, obj/               # Build artifacts
```

## Setup Instructions

### Step 1: Clone/Download Repository
```powershell
cd c:\path\to\SDET_Assignment\SDETAssignment
```

### Step 2: Restore NuGet Packages
```powershell
dotnet restore
```

### Step 3: Build Project
```powershell
dotnet build
```

### Step 4: Install Playwright Browsers
```powershell
powershell bin/Debug/net10.0/playwright.ps1 install
```

## Running Tests

### Run All Tests
```powershell
dotnet test
```

### Run Specific Test
```powershell
dotnet test --filter "LoginTests.InvalidCredentials_ShouldDisplayErrorMessage"
```

### Run with Verbose Output
```powershell
dotnet test --verbosity normal
```

## Test Scenarios Covered

| Test Case | Description | Expected Result |
|-----------|-------------|-----------------|
| InvalidCredentials_ShouldDisplayErrorMessage | Login with wrong credentials | Error message displayed |
| EmptyLoginName_WithPasswordOnly_ShouldShowError | Login name empty, password filled | Error message displayed |
| EmptyPassword_WithLoginNameOnly_ShouldShowError | Login name filled, password empty | Error message displayed |
| BothFieldsEmpty_ShouldShowError | Both login fields empty | Error message displayed |
| InvalidLogin_WithSpecialCharacters_ShouldShowError | Special characters in login | Error message displayed |
| ValidLogin_WithCorrectCredentials_ShouldSucceed | Valid credentials (requires test setup) | Inconclusive (test account needed) |

## Test Strategy
See [TestStrategy.md](TestStrategy.md) for detailed test strategy, scope, risks, and assumptions.

## Page Object Model Details

### LoginPage.cs
- **Locators:** Correctly identifies all form elements using Playwright selectors
- **Actions:** Encapsulates user interactions (enter text, click buttons)
- **Assertions:** Provides methods to verify login status and error messages
- **Error Handling:** Robust null-safety and timeout handling

## Automation Decisions

1. **Page Object Model (POM):** Improves maintainability and readability
2. **FluentAssertions:** Provides readable, fluent assertion syntax
3. **NUnit:** Enterprise-grade testing framework with good Playwright integration
4. **Timeout Handling:** Proper waits to avoid flaky tests
5. **Error Message Validation:** Verifies exact error text for comprehensive validation

## CI/CD Ready
This project is ready for CI/CD integration with GitHub Actions or Azure DevOps pipelines.

## Known Limitations
- Valid login test requires test account setup (marked as Inconclusive)
- Tests run in headed mode by default (can be configured for headless)
- Single browser context (can be extended for multi-browser testing)

## Future Enhancements
- Multi-browser support (Chrome, Firefox, WebKit)
- Test data management from external sources
- Allure or HTML reporting integration
- Parallel test execution
- Screenshot/video capture on failures