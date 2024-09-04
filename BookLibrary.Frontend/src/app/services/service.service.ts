import { Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  //url = 'https://localhost:7268/api/Books'
  url = 'https://simple-books-api.glitch.me/books';

  constructor() { }

  async getAllBooks (): Promise<Book[]> {
    const data = await fetch(this.url);
    return (await data.json()) ?? [];
  }
}
