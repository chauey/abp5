Web Application Development Tutorial - Part 3: Creating, updating and deleting books
https://docs.abp.io/en/abp/latest/Tutorials/Part-3?UI=NG&DB=EF

1. Update `/src/app/book/book.component.ts`

   ```ts
   import { ListService, PagedResultDto } from "@abp/ng.core";
   import { Component, OnInit } from "@angular/core";
   import { BookService, BookDto, bookTypeOptions } from "@proxy/books";
   import { FormGroup, FormBuilder, Validators } from "@angular/forms";
   import {
     NgbDateNativeAdapter,
     NgbDateAdapter,
   } from "@ng-bootstrap/ng-bootstrap";
   import { ConfirmationService, Confirmation } from "@abp/ng.theme.shared";

   @Component({
     selector: "app-book",
     templateUrl: "./book.component.html",
     styleUrls: ["./book.component.scss"],
     providers: [
       ListService,
       { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter },
     ],
   })
   export class BookComponent implements OnInit {
     book = { items: [], totalCount: 0 } as PagedResultDto<BookDto>;

     selectedBook = {} as BookDto;

     form: FormGroup;

     bookTypes = bookTypeOptions;

     isModalOpen = false;

     constructor(
       public readonly list: ListService,
       private bookService: BookService,
       private fb: FormBuilder,
       private confirmation: ConfirmationService
     ) {}

     ngOnInit() {
       const bookStreamCreator = (query) => this.bookService.getList(query);

       this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
         this.book = response;
       });
     }

     createBook() {
       this.selectedBook = {} as BookDto; // reset the selected book
       this.buildForm();
       this.isModalOpen = true;
     }

     editBook(id: string) {
       this.bookService.get(id).subscribe((book) => {
         this.selectedBook = book;
         this.buildForm();
         this.isModalOpen = true;
       });
     }

     buildForm() {
       this.form = this.fb.group({
         name: [this.selectedBook.name || "", Validators.required],
         type: [this.selectedBook.type || null, Validators.required],
         publishDate: [
           this.selectedBook.publishDate
             ? new Date(this.selectedBook.publishDate)
             : null,
           Validators.required,
         ],
         price: [this.selectedBook.price || null, Validators.required],
       });
     }

     save() {
       if (this.form.invalid) {
         return;
       }

       const request = this.selectedBook.id
         ? this.bookService.update(this.selectedBook.id, this.form.value)
         : this.bookService.create(this.form.value);

       request.subscribe(() => {
         this.isModalOpen = false;
         this.form.reset();
         this.list.get();
       });
     }

     delete(id: string) {
       this.confirmation
         .warn("::AreYouSureToDelete", "::AreYouSure")
         .subscribe((status) => {
           if (status === Confirmation.Status.confirm) {
             this.bookService.delete(id).subscribe(() => this.list.get());
           }
         });
     }
   }
   ```

1. Update `/src/app/book/book.component.html`

   ```html
   <div class="card">
     <div class="card-header">
       <div class="row">
         <div class="col col-md-6">
           <h5 class="card-title">{{ '::Menu:Books' | abpLocalization }}</h5>
         </div>
         <div class="text-right col col-md-6">
           <!-- "new book" button -->
           <div class="text-lg-right pt-2">
             <button
               id="create"
               class="btn btn-primary"
               type="button"
               (click)="createBook()"
             >
               <i class="fa fa-plus mr-1"></i>
               <span>{{ '::NewBook' | abpLocalization }}</span>
             </button>
           </div>
         </div>
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
           [name]="'::Actions' | abpLocalization"
           [maxWidth]="150"
           [sortable]="false"
         >
           <ng-template let-row="row" ngx-datatable-cell-template>
             <div ngbDropdown container="body" class="d-inline-block">
               <button
                 class="btn btn-primary btn-sm dropdown-toggle"
                 data-toggle="dropdown"
                 aria-haspopup="true"
                 ngbDropdownToggle
               >
                 <i class="fa fa-cog mr-1"></i>{{ '::Actions' | abpLocalization
                 }}
               </button>
               <div ngbDropdownMenu>
                 <button ngbDropdownItem (click)="editBook(row.id)">
                   {{ '::Edit' | abpLocalization }}
                 </button>
                 <!-- Delete button -->
                 <button ngbDropdownItem (click)="delete(row.id)">
                   {{ '::Delete' | abpLocalization }}
                 </button>
               </div>
             </div>
           </ng-template>
         </ngx-datatable-column>
         <ngx-datatable-column
           [name]="'::Name' | abpLocalization"
           prop="name"
         ></ngx-datatable-column>
         <ngx-datatable-column [name]="'::Type' | abpLocalization" prop="type">
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

   <!-- modal -->
   <abp-modal [(visible)]="isModalOpen">
     <ng-template #abpHeader>
       <h3>
         {{ (selectedBook.id ? '::Edit' : '::NewBook') | abpLocalization }}
       </h3>
     </ng-template>

     <ng-template #abpBody>
       <form [formGroup]="form" (ngSubmit)="save()">
         <div class="form-group">
           <label for="book-name">Name</label><span> * </span>
           <input
             type="text"
             id="book-name"
             class="form-control"
             formControlName="name"
             autofocus
           />
         </div>

         <div class="form-group">
           <label for="book-price">Price</label><span> * </span>
           <input
             type="number"
             id="book-price"
             class="form-control"
             formControlName="price"
           />
         </div>

         <div class="form-group">
           <label for="book-type">Type</label><span> * </span>
           <select class="form-control" id="book-type" formControlName="type">
             <option [ngValue]="null">Select a book type</option>
             <option [ngValue]="type.value" *ngFor="let type of bookTypes">
               {{ type.key }}
             </option>
           </select>
         </div>

         <div class="form-group">
           <label>Publish date</label><span> * </span>
           <input
             #datepicker="ngbDatepicker"
             class="form-control"
             name="datepicker"
             formControlName="publishDate"
             ngbDatepicker
             (click)="datepicker.toggle()"
           />
         </div>
       </form>
     </ng-template>

     <ng-template #abpFooter>
       <button type="button" class="btn btn-secondary" abpClose>
         {{ '::Close' | abpLocalization }}
       </button>

       <!-- save button-->
       <button
         class="btn btn-primary"
         (click)="save()"
         [disabled]="form.invalid"
       >
         <i class="fa fa-check mr-1"></i>
         {{ '::Save' | abpLocalization }}
       </button>
     </ng-template>
   </abp-modal>
   ```
