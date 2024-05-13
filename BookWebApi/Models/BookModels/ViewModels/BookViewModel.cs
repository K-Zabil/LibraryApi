namespace BookWebApi.Models.BookModels.ViewModels;

public class BookViewModel
{
    public string? Name { get; set; }
    public string? Author { get; set; }
    public int Pages { get; set; }
    public List<string>? Tags { get; set; }
}