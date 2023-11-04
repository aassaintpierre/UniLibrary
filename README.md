# UniLibrary

**UniLibrary** is a library management system web application designed to 
efficiently manage and optimize libraries, whether in the context of public, school, university, or other 
organizations. It offers comprehensive features for cataloging, tracking loans, and managing resource copies

## User Stories

The following functionalities are completed:

- [x] User can login as normal user or admin.
- [x] User have access to his/her profile.
- [x] User can see the list of books available.
- [x] Admin can add books from the system.
- [x] Only Super admin can remove books.
- [x] Admin can check-in and check-out books to users.
- [x] Admin can see all the users in the system.
- [x] Admin can see the history of all loaned books.
- [x] Admin can manage member in the system.
- [x] Admin can add new users.
- [x] Super admin can add new admins.

## Demo

Here's a demo of implemented user stories:

</>

## Open-source libraries used

- [SSMS](https://learn.microsoft.com/fr-fr/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- [Bootstrap](https://getbootstrap.com/)
- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)

## How to test

- Clone the project.
- Open the project in Visual Studio.
- Remove the "Migrations" folder so that the database can be update to your local machine.
- Open the "Package Manager Console"
- Write down the following commands: "enable migrations", "add-migration MigrationName", "update-database".
- Use Microsoft SQL Server Management Studio to view the changes in the database and to add a Super Admin.
- Run the project.
