using API.Data.SqlConstants;
using API.Models.Models;
using API.Models.Repository;
using APIApplication.Infrastructure.Models;
using Dapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Data;

namespace API.Data.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IMongoDatabase _mongoDb;
        private readonly ConnectionStrings _connectionStrings;
        private readonly IConnection _connection;
        private readonly string _bookCollectionName;
        public BooksRepository(ConnectionStrings connectionStrings, MongoDatabase mongoDatabase, IConnection connection)
        {
            _connection = connection; //for sql connection
            _connectionStrings = connectionStrings;
            _mongoDb = mongoDatabase.GetDbClient(_connectionStrings.LocalMongoDb.FullConnectionString,
                connectionStrings.LocalMongoDb.Name); //for mongodb connection
            _bookCollectionName = _connectionStrings.LocalMongoDb.BookCollectionName;
        }

        public List<BookMongoResponse> GetBooks()
        {            
            return _mongoDb.GetCollection<BookMongoResponse>(_bookCollectionName).AsQueryable().ToList();
        }

        public int AddBooks(Book book)
        {
            using (var connection = _connection.GetSqlConnection(_connectionStrings.SqlDatabase.ConnectionString))
            {
                var insertCount = connection.Execute(BooksSqlConstants.ADD_BOOK, new { Name=book.Name,Title=book.Title }, commandType: CommandType.Text);
                return insertCount;
            }
        }

        public Book GetBookFromSql(int id)
        {
            using (var connection = _connection.GetSqlConnection(_connectionStrings.SqlDatabase.ConnectionString))
            {
                return connection.QuerySingleOrDefault<Book>(BooksSqlConstants.GET_BOOK, new { id = id }, commandType: CommandType.Text);
            }
        } 
    }    
}
