# SDET Assignment - Login Flow Automation

## Overview
This project automates the login functionality of the Automation Test Store using C#, Playwright, NUnit, and FluentAssertions.

## Prerequisites
- .NET 10.0 or later
- Playwright browsers installed

## Setup Instructions
1. Clone or download the repository.
2. Navigate to the project directory: `cd SDETAssignment`
3. Restore packages: `dotnet restore`
4. Build the project: `dotnet build`
5. Install Playwright browsers: `powershell bin/Debug/net10.0/playwright.ps1 install`

## Running Tests
- Run all tests: `dotnet test`
- Run with Playwright HTML report: `dotnet test -- Playwright.Tracing=1 -- Playwright.Screenshots=1`
- View report: Open `test-results/index.html` in a browser

## Test Scenarios Covered
- Valid login
- Invalid credentials
- Empty login name
- Empty password
- Both fields empty

## Project Structure
- `Pages/`: Page Object Model classes
- `Tests/`: Test classes
- `README.md`: This file
- `TestStrategy.md`: Test strategy document

## Technologies Used
- C# .NET 10
- Playwright for UI automation
- NUnit for test framework
- FluentAssertions for assertions