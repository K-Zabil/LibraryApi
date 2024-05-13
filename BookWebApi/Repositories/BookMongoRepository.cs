using BookWebApi.Models.BookModels.Entities;
using BookWebApi.Repositories.Base;
using MongoDB.Driver;

namespace BookWebApi.Repositories;

public class BookMongoRepository : IBookMongoRepository
{
    private const string mongoDbConnectionoString = "mongodb://localhost:27017";
    private MongoClient client = new MongoClient(mongoDbConnectionoString);
    public List<Book> GetBooksByUserId(int userId)
    {
        var productsDb = client.GetDatabase("BooksDb");
        var booksCollection = productsDb.GetCollection<Book>("Books");
        var queryableCollection = booksCollection.AsQueryable();
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
        var books = queryableCollection.Where(books => books.UsersId.Contains(userId));
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        return books.ToList();
    }
}
