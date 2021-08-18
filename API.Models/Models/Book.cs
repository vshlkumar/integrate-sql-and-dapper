using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace API.Models.Models
{
    public class Book
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public class BookMongoResponse
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
