using API.Models.Models;
using API.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NewAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : BaseController
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        /// <summary>
        /// Get the Books
        /// </summary>
        /// <returns></returns>
        [HttpGet("getbooksfrommongo")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public IActionResult GetBooksFromMongo()
        {
            var books = _booksService.GetBooks();
            if(books != null && books.Any())
                return Ok(books);

            return BadRequest("No book found");
        }

        /// <summary>
        /// Add new Book
        /// </summary>
        /// <returns></returns>
        [HttpPost("addbook")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult AddBook([FromBody] Book book) 
        {
            var books = _booksService.AddBook(book);
            if (books > 0)
                return Ok(books);

            return BadRequest("Please try after some time");
        }

        /// <summary>
        /// Get the book from sql server based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getbooksfromsql")]
        [ProducesResponseType(typeof(Book), 200)]
        public IActionResult GetBooksFromSql([FromQuery] int id)
        {
            var book = _booksService.GetBooksFromSql(id);
            if (book != null)
                return Ok(book);

            return BadRequest("Book not found");
        }
    }
}
