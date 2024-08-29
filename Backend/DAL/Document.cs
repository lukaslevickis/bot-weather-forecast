using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.DAL
{
    public abstract class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
