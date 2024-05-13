using BookWebApi.Models.BookModels.Entities;
using BookWebApi.Models.BookModels.ViewModels;
using BookWebApi.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IBookMongoRepository bookMongoRepository;
    public BookController(IBookMongoRepository bookMongoRepository)
    {
        this.bookMongoRepository = bookMongoRepository;
    }

    [HttpGet]
    [Route("api/[controller]")]
    public List<BookViewModel> GetByUser(int userId)
    {
        List<BookViewModel> bookViewModels  = new List<BookViewModel>();
        List<Book> books = new List<Book>();
        try
        {
            books = bookMongoRepository.GetBooksByUserId(userId);
        }
        catch (Exception ex)
        {
            bookViewModels.Add(new BookViewModel { Name = ex.Message });
            return bookViewModels;
        }
        bookViewModels = books.Select(book => new BookViewModel
        {
            Name = book.Name,
            Author = book.Author,
            Pages = book.Pages,
            Tags = book.Tags
        }).ToList();
        return bookViewModels;
    }
}