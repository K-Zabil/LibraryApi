using System.Text.Json;
using UserWebApi.Models.BookModels.Entities;

namespace UserWebApi.Api;

public class BookApi
{
    private readonly HttpClient _httpClient;
    public async Task<List<Book>> GetBooksByUserIdFromBookApi(int userId)
    {
        List<Book> books = new List<Book>();
        try
        {
            string bookApiUrl = "http://bookwebapi.com/api/Book/GetByUser/" + userId;
            var response = await _httpClient.GetAsync(bookApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var booksJson = await response.Content.ReadAsStringAsync();
                books = JsonSerializer.Deserialize<List<Book>>(booksJson) ?? new List<Book>();
            }
            else
            {
                books.Add(new Book { Name = "Error occurred while fetching books." });
            }
        }
        catch (Exception ex)
        {
            books.Add(new Book { Name = ex.Message });
        }
        return books;
    }
}