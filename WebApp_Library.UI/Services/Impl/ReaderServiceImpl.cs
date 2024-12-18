using System.Net.Http.Json;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.UI.Services.Impl;

public class ReaderServiceImpl : IReaderService
{
    
    private readonly HttpClient _httpClient;
    
    public ReaderServiceImpl(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddAsync(Reader reader)
    {
        await _httpClient.PostAsJsonAsync("reader", reader);
    }

    public async Task DeleteAsync(Guid osz)
    {
        await _httpClient.DeleteAsync($"reader/{osz}");
    }

    public async Task<Reader> GetAsync(Guid osz)
    {
        return await _httpClient.GetFromJsonAsync<Reader>($"reader/{osz}");
    }

    public async Task<List<Reader>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Reader>>("readers");
    }

    public async Task UpdateAsync(Reader newReader)
    {
        await _httpClient.PutAsJsonAsync<Reader>($"reader/{newReader.OSz}", newReader);
    }
}