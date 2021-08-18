using API.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Repository
{
    public interface IBooksRepository
    {
        List<BookMongoResponse> GetBooks();

        int AddBooks(Book book);
        Book GetBookFromSql(int id);
    }
}
