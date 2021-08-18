using API.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Services
{
    public interface IBooksService
    {
        List<BookMongoResponse> GetBooks();

        int AddBook(Book book);

        Book GetBooksFromSql(int id);
    }
}
