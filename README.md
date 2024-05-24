# JobCandidateHub

This project is a .NET 8 Web API designed to manage candidate profiles efficiently. It facilitates the addition of new candidates and seamlessly updates existing profiles if they already exist in the system. Leveraging the power of .NET 8, it provides a robust and scalable solution for handling candidate data with ease and precision.

## Table of Contents

- [Project Overview](#project-overview)
- [Technologies Used](#technologies-used)
- [Setup Instructions](#setup-instructions)
- [Usage](#usage)
- [Improvements](#improvements)
- [Assumptions](#assumptions)
- [Time Spent](#time-spent)

## Project Overview

This project represents a robust Web API developed using the .NET 8, crafted with adherence to the principles of clean architecture design pattern. The architecture fosters a separation of concerns, ensuring maintainability, scalability, and extensibility.

At its core, the API serves as a streamlined interface for performing Create, Read, Update, and Delete (CRUD) operations, offering a seamless interaction experience for managing data. Its intuitive design promotes efficiency and simplicity in data manipulation tasks.

Utilizing Microsoft SQL Server as its underlying data storage solution, the API leverages the robustness and reliability of SQL databases to securely persist application data. The relational model ensures data integrity and consistency, crucial aspects in modern application development.

To bridge the gap between the application domain and the underlying data storage, Entity Framework Core is employed as the Object-Relational Mapping (ORM) framework. This powerful tool simplifies data access by abstracting away the complexities of database interactions, thereby enhancing developer productivity and code maintainability.

In summary, this project embodies a sophisticated yet elegant solution for building resilient and performant web APIs, underpinned by industry-leading technologies and architectural best practices.


## Technologies Used

- .NET Core version 8
- Entity Framework Core (EF Core)
- AutoMapper
- MSSQL Server

## Setup Instructions

1. Clone the repository.
2. Navigate to the project directory.
3. Restore NuGet packages: `dotnet restore`.
4. Build the solution: `dotnet build`.
5. (Optional) Update database schema: `dotnet ef database update`.
6. Run the application: `dotnet run`.

## Usage

After successfully installing the application, you can run it either from Visual Studio or the command line. Follow these steps:

### Visual Studio:

1. Open the solution file (.sln) in Visual Studio.
2. Set the startup project to the desired project containing the API.
3. Press F5 or click on the "Start" button to run the application.

### Command Line:

1. Navigate to the project directory containing the API project.
2. Run the following command:


## Improvements

- **Performance Optimization**: Optimize database queries and other performance-critical operations to handle large data set when usage increases.
- **Security Enhancements**: Implementing proper authentication and authorization mechanisms using OAuth 2.0 or JWT in the API.
- **Integration Tests**: Add integration tests to complement existing unit tests.
- **Documentation**: Document the codebase, API documentation, and README files. Ensure that the code is well-documented and easy for other developers to understand and contribute


## Assumptions

- **User Requirements**: It is assumed that when a user adds a candidate with an email that already exists in the system, the existing candidate's details will be updated rather than creating a duplicate entry. This assumption is based on the requirement that email addresses must be unique within the system
  
- **Technical Assumptions**: The project assumes compatibility with the chosen technology stack, including the .NET framework or .NET Core version specified, Entity Framework Core for data access, and AutoMapper for object-to-object mapping. Additionally, it assumes compatibility with the underlying operating system and any other dependencies used in the project.
  
- **Scope Limitations**: Authentication and authorization mechanisms have not been implemented in the current version of the application. This decision was made based on the assumption that there are no active clients interacting with the API at the moment. However, it is acknowledged that authentication and authorization may be required in future iterations or when clients begin to interact with the system.


## Time Spent

Total time spent on the task: 6 hours

