Getting Started - Create New Project
https://abp.io/get-started

Getting Started Tutorial
https://docs.abp.io/en/abp/latest/Getting-Started-Setup-Environment?UI=NG&DB=EF&Tiered=No

Web Application Development Tutorial
https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=NG&DB=EF

## Prerequisite

- install nodejs
- install VS Code
- install Visual Studio
install abp?

## Create DB (1st time)

- cd aspnet-core
- cd Dna.Abp.DbMigrator
- dotnet run

OR

- Open aspnet-core/Dna.Abp.Sln
- set Dna.Abp.DbMigrator as StartUp Project and press F5

## Run Backend WEB API REST Server

- open aspnet-core/Dna.Abp.Sln
- set Dna.Abp.HttpApi.Host as StartUp Project and press F5
- navigate to https://localhost:44360/swagger/index.html (optional)

## Run Frontend Angular website

- cd angular
- npm i (only 1st time)
- npm start
- navigate to http://localhost:519/
  - username: admin
  - password: 1q2w3E\*

## Angular/.NET/EF Tutorial for adding Book/Authors

- [Part 1: Creating the server side](/docs/01-creating-the-server-side)
- [Part 2: The book list page](/docs/02-the-book-list-page)
- [Part 3: Creating, updating and deleting books](/docs/03-creating-updating-and-deleting-books)
- [Part 4: Integration tests](/docs/04-integration-tests)
- [Part 5: Authorization](/docs/0)
- [Part 6: Authors: Domain layer](/docs/0)
- [Part 7: Authors: Database Integration](/docs/0)
- [Part 8: Authors: Application Layer](/docs/0)
- [Part 9: Authors: User Interface](/docs/0)
- [Part 10: Book to Author Relation](/docs/0)
