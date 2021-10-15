# Silly String Factory

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
* _anime.js_


## Description
This web application will allow users to add and remove engineers and machines independantly. they can also associate machines and engineers based on their qualifications to operate the machines.


### Technology Requirements

* [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* A text editor like [VS Code](https://code.visualstudio.com/)

## Setup/Installation Requirements

* _Clone this repository to your desktop_
* _Open in text editor_
* _Create appsettings.json in /Factory/ directory_
* _Copy this code into appsettings.json, replacing YOUR_PASSWORD with your MySQL password:_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=charles_weber;uid=root;pwd=YOUR_PASSWORD;"
  }
}
```
* _open new terminal and run SQL_

        $ mysql -uroot -p{your_password})
* _open MySQL Workbench_
* _In terminal, navigate into SillyStringFactory.Solution/Factory/ and enter the command below to install necessary packages_

        $ dotnet restore
* _enter this command to build the program_

       $ dotnet build
* _enter command to build your database_

        $ dotnet ef database update,
* _check MySql Workbench to make sure the Factory database has been built (named charles_weber)_
* _enter the command below to view program in your browser_

        $ dotnet run

  

## Known Bugs

* _NA_

## License
_[GPL](https://opensource.org/licenses/gpl-license)_

## Contact Information

charlesweber@gmail.com

## Photos
Photo by <a href="https://unsplash.com/@gareth_david?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText">Gareth David</a> on <a href="https://unsplash.com/s/photos/steel?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText">Unsplash</a>
  