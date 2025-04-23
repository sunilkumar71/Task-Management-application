# Task Management Application

![Index](https://github.com/user-attachments/assets/52d464be-dbfe-492b-9b4e-0aef2bb52510)
![Create](https://github.com/user-attachments/assets/8fff49c4-61c7-40b4-8aa6-aeceff156a1f)
![Edit](https://github.com/user-attachments/assets/f5ce7cec-a7ea-4228-b223-40be028469e2)
![Details](https://github.com/user-attachments/assets/78ba3158-c04e-4cea-acb1-f89ce7518bbf)
![Delete](https://github.com/user-attachments/assets/2cf1bbaf-64e8-4e3f-9b4d-559228678268)

## Overview
A comprehensive Task Management System built with ASP.NET Core MVC that enables users to create, track, and manage tasks with full CRUD operations and search functionality. The system includes user authentication and maintains complete audit trails of all task modifications.

## DB Design

### ER Diagram
![ER Diagram](docs/er_diagram.png)
- **Users**: Stores user authentication details
- **TaskItems**: Core task entities with relationships to users
 ### Data Dictionary
 #### TasksItems Table
 | Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| Id | INT | PRIMARY KEY | Task identifier |
| Title | NVARCHAR(MAX) | NOT NULL | Task name/heading |
| Description | NVARCHAR(500) | NOT NULL | Detailed task description (500 char limit)|
| DueDate | DATETIME2(7) |NOT NULL | Deadline with precision to 100ns |
| Status | NVARCHAR(  MAX) | NOT NULL| Current status (e.g., "Complete", "In Progress") |
| Remarks | NVARCHAR(  MAX) | NOT NULL| Yes/No|
| CreatedOn | DATETIME2 | NOT NULL | Creation timestamp |
| LastUpdatedOn | DATETIME2 | NOT NULL |Last Modification timestamp |
| CreatedById | NVARCHAR(450) | FOREIGN KEY | User ID/NAME of creator |
| UpdatedById | NVARCHAR(450) | FOREIGN KEY | User ID/NAME of last modifier |

#### Users Table
 | Column | Type | Constraints | Description |
|--------|------|-------------|-------------|
| Id | INT | PRIMARY KEY | User identifier |
| Name | NVARCHAR(MAX) | NOT NULL | Full name of user |

### Indexes Documentation
1. **IX_Tasks_CreatedById**  
   ```sql
   CREATE NONCLUSTERED INDEX IX_Tasks_CreatedById ON Tasks(CreatedById)
   INCLUDE (Id,Title,Name)
2. **IX_Tasks_Title**: Full-text index for search operations
    ```sql
    CREATE FULLTEXT INDEX ON Tasks(Title)
    KEY INDEX PK_Tasks_Id

 ### Database Approach: Code-First
  **Rationale**: 
- Faster development cycles with C# class definitions
- Easier schema evolution through migrations
- Better alignment with domain-driven design principles
- Automatic tracking of Created/Updated timestamps

## Application Structure

### Architecture: MVC with Server-Side Rendering
**Selected Approach**: Standard MVC server-side page rendering 
**Justification**:
- More suitable for content-focused applications
- Built-in support for form validation and model binding
- Easier implementation of server-side features
- Better SEO capabilities out-of-the-box

## Frontend Structure

### Web Application Frontend
**Technology Choices**:
- **ASP.NET Core Razor Pages**: For dynamic server-rendered views
- **Bootstrap 5**: Responsive layout and components

## Build and Installation

###  Environment Requirements

Make sure your development environment meets the following requirements:

- **Runtime**: [.NET 8.0 SDK (Windows x64)](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.408-windows-x64-installer)
- **Database**: SQL Server 2019 or later (SQL Server Express is also supported)
- **IDE**: [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (Recommended)
- **Tools**:
  - [Git](https://git-scm.com/) (for version control)
  - [Entity Framework Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (for migrations and database operations)

### Build Instructions
1. Clone the repository and set up database
```bash
# Clone the repository
git clone https://github.com/sunilkumar71/Task-Management-application.git
cd Task-Management-application

# Configure database connection (edit appsettings.json)
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CompanyTask;Trusted_Connection=True;MultipleActiveResultSets=true"
}
# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
















  







