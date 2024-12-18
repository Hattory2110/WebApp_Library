using System.Net.Http.Json;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.UI.Services.Impl;

public class BookServiceImpl : IBookService
{
    private readonly HttpClient _httpClient;
    
    public BookServiceImpl(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task AddAsync(Book book)
    {
        await _httpClient.PostAsJsonAsync("books", book);
    }

    public async Task DeleteAsync(Guid lsz)
    {
        await _httpClient.DeleteAsync($"book/{lsz}");
    }

    public async Task<Book> GetAsync(Guid lsz)
    {
        return await _httpClient.GetFromJsonAsync<Book>($"book/{lsz}");
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Book>>("books");
    }

    public async Task UpdateAsync(Book newBook)
    {
        await _httpClient.PutAsJsonAsync<Book>($"book/{newBook.LSz}", newBook);
    }
}