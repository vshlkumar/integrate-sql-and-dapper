using APIApplication.Infrastructure.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
    public class MongoDatabase
    {

        public IMongoDatabase GetDbClient(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            return mongoClient.GetDatabase(databaseName);
        }
    }
}
