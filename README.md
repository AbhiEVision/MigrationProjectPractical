# Migration Project

Asp.Net Core CRUD Operations using Admin Template.

## How to Run
1. Download or Clone the Project.
2. Create database, sql file are attached in project.
3. Update the update connection string in app settings according to your PC.
4. Run your Project.

<br/>

* Old SDK : `` .Net CORE 2.2 ``
* New SDK : `` .Net CORE 6.0 ``

<br/>

## Problems while Migrating Project

* I am start with the upgrading the packages.
* after that I get the error in support of SDK.
* So for that I upgrade the SDK version to 6.0
* later on I have change the program.cs file to latest version. ( combining the startup and program file) 
* later on I configure the EF registration using .AddDbContext in program file.
* now everything working fine which are migrated!
