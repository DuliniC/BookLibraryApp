import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Book } from '../models/book';

@Component({
  selector: 'app-book-detail',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './book-detail.component.html',
  styleUrl: './book-detail.component.css',
})
export class BookDetailComponent {
  @Input() Book!: Book;
}
