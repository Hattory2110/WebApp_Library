using System.Net.Http.Json;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.UI.Services.Impl;

public class RentServiceImpl : IRentService
{
    private readonly HttpClient _httpClient;
    
    public RentServiceImpl(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task AddAsync(Rent rent)
    {
        await _httpClient.PostAsJsonAsync("rent", rent);
    }

    public async Task DeleteAsync(Guid lsz)
    {
        await _httpClient.DeleteAsync($"rent/{lsz}");
    }

    public async Task<Rent> GetAsync(Guid lsz)
    {
        return await _httpClient.GetFromJsonAsync<Rent>($"rent/{lsz}");
    }

    public async Task<List<Rent>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Rent>>("rents");
    }

    public async Task UpdateAsync(Rent newRent)
    {
        await _httpClient.PutAsJsonAsync<Rent>($"rent/{newRent.LSz}", newRent);
    }
}