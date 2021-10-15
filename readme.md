# Silly String factory

A Factory organizing application designed to keep track of Machines and engineers licensed to use them.

### by Charlie Weber

## Technologies Used

* _C#_
* _ASP.NET Core MVC_
* _.NET 5_
* _NuGet_
* _Microsoft.EntityFrameworkCore_
* _Dotnet EntityFramework Tool_
* _Microsoft.EntityFrameworkCore.Design_


## Description
This web application will allow users to add and remove engineers and machines independantly. they can also associate machines and engineers based on their qualifications to operate the machines.


### Technology Requirements

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* A text editor like [VS Code](https://code.visualstudio.com/)

## Setup/Installation Requirements

* _Clone this repository to your desktop_
* _Open in text editor_
* _Create appsettings.json in /Registrar/ directory_
* _Copy this code into appsettings.json, replacing YOUR_PASSWORD with your MySQL password:_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=DATABASE_NAME;uid=root;pwd=YOUR_PASSWORD;"
  }
}
```
* _open new terminal and run SQL 

        $ mysql -uroot -p{your_password})_
* _open MySQL Workbench_
* _In terminal, navigate into SillyStringFactory.Solution/Factory/ and enter the command below to install necessary packages_

        $ dotnet restore
* _enter this command to build the program

       $ dotnet build to build program_
* _enter command to build your database_

        $ dotnet ef database update,
* _check MySql Workbench to make sure the registrars database has been built_
* _enter command $ dotnet run, to view program in your browser_

  

## Known Bugs

* _NA_

## License
_[GPL](https://opensource.org/licenses/gpl-license)_

## Contact Information