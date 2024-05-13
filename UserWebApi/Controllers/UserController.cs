namespace UserWebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using UserWebApi.Api;
using UserWebApi.Models.BookModels.Entities;
using UserWebApi.Models.UserModels.Entities;
using UserWebApi.Repositories.Base;

[ApiController]
public class UserController : ControllerBase
{
    private readonly BookApi bookApi;
    private readonly IUserMsSqlRepository userMsSqlRepository;
    public UserController(IUserMsSqlRepository userMsSqlRepository, BookApi bookApi)
    {
        this.userMsSqlRepository = userMsSqlRepository;
        this.bookApi = bookApi;
    }

    [HttpGet]
    [Route("api/[controller]/[action]")]
    public async Task<User> Details(int id)
    {
        User? user;
        List<Book> userBooks = await bookApi.GetBooksByUserIdFromBookApi(id);
        try
        {
            user = await userMsSqlRepository.GetUserByIdAsync(id);
            
        }
        catch (Exception ex)
        {
            return new User{
                Username = ex.Message,
            };
        }
        return user ?? new User();
    }
}
