import { Component } from '@angular/core';
import { BookDetailComponent } from '../book-detail/book-detail.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BookDetailComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
