#Project Setup Guide

Follow the steps below to properly configure, build, and run the application:

---

## 1. Configure the Database Connection

- Open the `appsettings.json` file located at the root of the project directory.
- Locate the connection string placeholder and replace it with your actual SQL Server connection string.

---

## 2. Extract Project Files

- Download and unzip the project archive.
- Extract all contents to a directory of your choice.

---

## 3. Set Up the Database

- Launch **SQL Server Management Studio (SSMS)**.
- Open the `Oritso.sql` script file located in the extracted folder.
- Execute the script to create the necessary database and tables.

---

## 4. Build and Run the Project

- Open the solution (`.sln`) in **Visual Studio 2022**.
- Make sure the **.NET 8.0 SDK** is installed on your machine.
- In **Solution Explorer**, right-click the main project and select **Set as Startup Project**.
- Press `F5` or click **Start Debugging** to build and launch the application.

---

✅ Once the application starts, it should connect to the configured database and be ready for use.

