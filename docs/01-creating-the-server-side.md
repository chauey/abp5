Web Application Development Tutorial - Part 1: Creating the Server Side
https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=NG&DB=EF

1. Create the `Book` Entity

- aspnet-core/src/Dna.Abp.Domain/Books/Book.cs

```cs
using System;

using Volo.Abp.Domain.Entities.Auditing;

namespace Dna.Abp.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
    }
}
```

1. `BookType` Enum
1. Add the `Book` Entity to the `DbContext`

- ...EntityFrameworkCore/EntityFrameworkCore/...DbContext.ts

```cs
public DbSet<Book> Books { get; set; }
```

1. Map the `Book` Entity to a Database Table

- ...EntityFrameworkCore/EntityFrameworkCore/...DbContext.ts `OnModelCreating(...)`

1. Add Database Migration
   - cd to `...EntityFrameworkCore` folder
   - `dotnet ef migrations add Created_Book_Entity`
   - `dotnet ef database update` (https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
   - OR
   - set `...HttpApi.Host` as startup project
   - set `...EntityFrameworkCore` as Default Project in PMC
   - `Add-Migration Created_Book_Entity -c BookStoreMigrationsDbContext`
   - `Update-Database -c BookStoreMigrationsDbContext`
1. Add Sample Seed Data (https://docs.abp.io/en/abp/latest/Data-Seeding)
   - `...Domain/Books/`
1. Update the Database

- ...DbMigrator, run this console app
