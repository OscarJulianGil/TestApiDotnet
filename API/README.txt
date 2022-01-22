HOW TO CREATE WITH ENTITY FRAMEWORK
ENTITY FRAMEWORK IS AN ORM (OBJECT RELATIONAL MAPPER)

FEATURES:
    QUERYING
    CHANGE TRACKING
    SAVING
    CONCURRENCY
    TRANSACTIONS
    CACHING
    BUILT-IN CONVENTIONS
    MIGRATIONS -> GENERATE DATABASE BY COMMAND ENTITIES IN DE C# CODE

INSTALL:
    WE NEED TO INSTALL DE LIBRARY FROM DE NUGET GALLERY
    . Microsoft.EntityFrameworkCore
    . Microsoft.EntityFrameworkCore.SqlServer (Or search the provider database)

LATER:
    . Create DataContext class inherit from DbContext
    . Set the DbSet for the tables
    . Set connection string
    . Inject the connection string in Stratup.cs

FOR USE MIGRATIONS:
    . Must install the dotnet-ef tools, search in the webpage dotnet.org
    . Install de package Microsoft.EntityFrameworkCore.Design

CREATE THE CS FILES FOR MIGRATIONS
    . run the command "dotnet ef migrations add InitialCreate -o Data/Migrations"
    . With this command run the migrations "dotnet ef database update"


HOW TO ADD GIT TO THE SOLUTION:
    . You must be in the root folder project.
    . git init  -> initialize de repository on my local machine for the project
    . dotnet new gitignore -> For create gitignore file
    . git commit -m "initial git project"
    . git remote add origin https://github.com/OscarJulianGil/TestApiDotnet.git
