using API.Models.Models;
using API.Models.Repository;
using API.Models.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public List<BookMongoResponse> GetBooks()
        {
            return _booksRepository.GetBooks();
        }

        public int AddBook(Book book)
        {
            return _booksRepository.AddBooks(book);
        }

        public Book GetBooksFromSql(int id)
        {
            return _booksRepository.GetBookFromSql(id);
        }
    }
}
