using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookWebApi.Models.BookModels.Entities;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public int Pages { get; set; }
    public List<string>? Tags { get; set; }
    public List<int>? UsersId { get; set; }
}