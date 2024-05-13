using UserWebApi.Models.BookModels.Entities;

namespace UserWebApi.Models.UserModels.Entities;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public DateOnly? Birthdate { get; set; }
    public List<Book>? Books { get; set; }
}