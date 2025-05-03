#Project Setup Guide

Follow the steps below to properly configure, build, and run the application:

---

## 1. Update the Database Connection

- Open the `appsettings.json` file located at the root of the project directory.
- Locate the connection string placeholder and replace it with your actual SQL Server connection string.

---

## 2. Extract Project Files

- Extract the ZIP file's contents to a convenient location on your computer.

---

## 3. Set Up the Database

- Run SQL Server Management Studio (SSMS).
- Open the Oritso.sql script file located in the extracted folder.
- Execute the script to create the necessary database and tables.

---

## 4. Build and Run the Project

- Open the solution in **Visual Studio 2022**.
-Verify that your machine has the .NET 8.0 SDK installed.
- In **Solution Explorer**, right-click the main project and select **Project**.
- Press `F5` or click **Start Debugging** to build and launch the application.

---

