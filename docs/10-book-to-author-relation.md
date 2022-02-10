Web Application Development Tutorial - Part 10: Book to Author Relation
https://docs.abp.io/en/abp/latest/Tutorials/Part-10?UI=NG&DB=EF

## Database & Data Migration
`Drop-Database` in the Package Manager Console (...EntityFrameworkCore selected as default project)

1. Add New EF Core Migration
    - `dotnet ef migrations add Added_AuthorId_To_Book`


If you are using Visual Studio, you may want to use Add-Migration Added_AuthorId_To_Book -c BookStoreMigrationsDbContext and Update-Database -c BookStoreMigrationsDbContext commands in the Package Manager Console (PMC). In this case, ensure that Dna.Abp.HttpApi.Host is the startup project and Dna.Abp.EntityFrameworkCore is the Default Project in PMC.

...DbMigrator, right click -> Debug -> Start Without Debugging

    - update `.cs`

    ```cs
    ```