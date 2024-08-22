# Banking System API

## Overview

This is a simple Banking System API built with ASP.NET Core and Entity Framework Core. It allows you to manage bank accounts, including creating accounts, depositing money, withdrawing money, and retrieving account details.

## Prerequisites

- [.NET 6.0 SDK or later]
- [Visual Studio 2022]

## Getting Started

### 1. Open the Project

- Open the project in Visual Studio.

### 2. Install Dependencies

- Visual Studio should automatically restore the required NuGet packages when you open the project. If not, you can restore them manually:
  - In Visual Studio, go to **Tools > NuGet Package Manager > Manage NuGet Packages for Solution...** and ensure all packages are installed.

### 3. Build the Project

- Build the project to ensure everything is set up correctly:
 

### 4. Run the Application

- Run the project:
  - Press **F5** in Visual Studio, or click the green play button.
  - The application will start, and a browser window will open with Swagger UI, typically at `http://localhost:5000/swagger` or similar.

### 5. Use Swagger UI to Test the API

- Swagger UI will list all available API endpoints. You can use it to test each endpoint by providing the required parameters and request bodies.

## API Endpoints

### Create an Account
- **URL:** `POST /api/accounts`
- **Body:**
  ```json
  {
    "owner": "John Doe",
    "balance": 100.00
  }