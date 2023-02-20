# BostonOptics (E-Commerce)
A sample N-layered .NET Core Project demonstrating Clean Architecture and the Generic Repository Pattern.

## Migrations

## Infrastructure
Firstly,set the project "Web" as startup project.
Secondly, choose Infrastructure on Package Manager Console.

```
Add-Migration InitialCreate -context ShopContext -o Data/Migrations 
Update-Database -context ShopContext
```
## Packages Installed

### Infrastructure
```
Install-Package Microsoft.EntityFrameworkCore -v 6.0.14
Install-Package Microsoft.EntityFrameworkCore.Tools -v 6.0.14
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 6.0.8
```
### ApplicationCore
```
Install-Package Ardalis.Specification -v 6.1.0
```

## Useful Links
### Documentation
https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/ 
### Github 
https://github.com/dotnet-architecture/eShopOnWeb
### E-book
https://aka.ms/webappebook

