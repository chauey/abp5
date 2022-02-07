Web Application Development Tutorial - Part 2: The Book List Page
https://docs.abp.io/en/abp/latest/Tutorials/Part-2?UI=NG&DB=EF

1. Localization
   - ...Domain.Shared/Localization/Abp/en.json
   ```json
   {
     "Culture": "en",
     "Texts": {
       "Menu:Home": "Home",
       "Welcome": "Welcome",
       "LongWelcomeMessage": "Welcome to the application. This is a startup project based on the ABP framework. For more information, visit abp.io.",
       "Menu:BookStore": "Book Store",
       "Menu:Books": "Books",
       "Actions": "Actions",
       "Close": "Close",
       "Delete": "Delete",
       "Edit": "Edit",
       "PublishDate": "Publish date",
       "NewBook": "New book",
       "Name": "Name",
       "Type": "Type",
       "Price": "Price",
       "CreationTime": "Creation time",
       "AreYouSure": "Are you sure?",
       "AreYouSureToDelete": "Are you sure you want to delete this item?",
       "Enum:BookType:0": "Undefined",
       "Enum:BookType:1": "Adventure",
       "Enum:BookType:2": "Biography",
       "Enum:BookType:3": "Dystopia",
       "Enum:BookType:4": "Fantastic",
       "Enum:BookType:5": "Horror",
       "Enum:BookType:6": "Science",
       "Enum:BookType:7": "Science fiction",
       "Enum:BookType:8": "Poetry"
     }
   }
   ```
   <!-- 1. Install NPM packages -->
1. Create a Books Page

   - `cd angular`
   - `ng generate module book --module app --routing --route books`

   1. BookModule
        - `/src/app/book/book.module.ts`
        ```ts
        import { NgModule } from "@angular/core";
        import { SharedModule } from "../shared/shared.module";
        import { BookRoutingModule } from "./book-routing.module";
        import { BookComponent } from "./book.component";

        @NgModule({
            declarations: [BookComponent],
            imports: [BookRoutingModule, SharedModule],
        })
        export class BookModule {}
        ```

   1. Routing
      - `src/app/app-routing.module.ts`
      ```typescript
      const routes: Routes = [
        // other route definitions...
        {
          path: "books",
          loadChildren: () =>
            import("./book/book.module").then((m) => m.BookModule),
        },
      ];
      ```
      - `src/app/route.provider.ts`
      ```ts
      function configureRoutes(routes: RoutesService) {
        return () => {
          routes.add([
            {
              path: "/",
              name: "::Menu:Home",
              iconClass: "fas fa-home",
              order: 1,
              layout: eLayoutType.application,
            },
            {
              path: "/book-store",
              name: "::Menu:BookStore",
              iconClass: "fas fa-book",
              order: 2,
              layout: eLayoutType.application,
            },
            {
              path: "/books",
              name: "::Menu:Books",
              parentName: "::Menu:BookStore",
              layout: eLayoutType.application,
            },
          ]);
        };
      }
      ```
   1. Service Proxy Generation
      - run `...HttpApi.Host`
      - in angular folder, run `abp generate-proxy -t ng` (will output to /src/app/proxy/books)
   1. BookComponent

      - open `/src/app/book/book.component.ts` and replace w

      ```ts
      import { ListService, PagedResultDto } from "@abp/ng.core";
      import { Component, OnInit } from "@angular/core";
      import { BookService, BookDto } from "@proxy/books";

      @Component({
        selector: "app-book",
        templateUrl: "./book.component.html",
        styleUrls: ["./book.component.scss"],
        providers: [ListService],
      })
      export class BookComponent implements OnInit {
        book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;

        constructor(
          public readonly list: ListService,
          private bookService: BookService
        ) {}

        ngOnInit() {
          const bookStreamCreator = (query) => this.bookService.getList(query);

          this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
            this.book = response;
          });
        }
      }
      ```

      - open `/src/app/book/book.component.html` and replace w

      ```html
      <div class="card">
        <div class="card-header">
          <div class="row">
            <div class="col col-md-6">
              <h5 class="card-title">{{ '::Menu:Books' | abpLocalization }}</h5>
            </div>
            <div class="text-right col col-md-6"></div>
          </div>
        </div>
        <div class="card-body">
          <ngx-datatable
            [rows]="book.items"
            [count]="book.totalCount"
            [list]="list"
            default
          >
            <ngx-datatable-column
              [name]="'::Name' | abpLocalization"
              prop="name"
            ></ngx-datatable-column>
            <ngx-datatable-column
              [name]="'::Type' | abpLocalization"
              prop="type"
            >
              <ng-template let-row="row" ngx-datatable-cell-template>
                {{ '::Enum:BookType:' + row.type | abpLocalization }}
              </ng-template>
            </ngx-datatable-column>
            <ngx-datatable-column
              [name]="'::PublishDate' | abpLocalization"
              prop="publishDate"
            >
              <ng-template let-row="row" ngx-datatable-cell-template>
                {{ row.publishDate | date }}
              </ng-template>
            </ngx-datatable-column>
            <ngx-datatable-column
              [name]="'::Price' | abpLocalization"
              prop="price"
            >
              <ng-template let-row="row" ngx-datatable-cell-template>
                {{ row.price | currency }}
              </ng-template>
            </ngx-datatable-column>
          </ngx-datatable>
        </div>
      </div>
      ```
