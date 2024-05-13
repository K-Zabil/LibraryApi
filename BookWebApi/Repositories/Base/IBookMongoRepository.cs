using BookWebApi.Models.BookModels.Entities;

namespace BookWebApi.Repositories.Base;

public interface IBookMongoRepository
{
    List<Book> GetBooksByUserId(int userId);
}
