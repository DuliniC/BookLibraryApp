using BookLibrary.Backend.Data;
using BookLibrary.Backend.DTO;
using BookLibrary.Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        public BooksController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks() 
        { 
            if(_dbcontext.Books == null)
            {
                return NotFound();
            }

            return await _dbcontext.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _dbcontext.Books.FindAsync(id);

            if (book == null) { 
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> SaveBook([FromBody] BookAddDTO bookAddData)
        {
            var book = new Book
            {
                Title = bookAddData.Title,
                Author = bookAddData.Author,
                Genre = bookAddData.Genre,
                PublishedYear = bookAddData.PublishedYear,
                Description = bookAddData.Description
            };
            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, BookUpdateDTO bookUpdateData)
        {

            var book = await _dbcontext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Title = bookUpdateData.Title;
            book.Author = bookUpdateData.Author;
            book.Genre = bookUpdateData.Genre;
            book.PublishedYear = bookUpdateData.PublishedYear;

            _dbcontext.Books.Update(book);
            _dbcontext.SaveChanges();

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _dbcontext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();

            return Ok();
        }

    }
}
