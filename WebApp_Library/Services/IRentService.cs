using WebApp_Library.Shared.Classes;

namespace WebApp_Library.Services;

public interface IRentService
{
    Task AddAsync(Rent rent);

    Task DeleteAsync(Guid id);

    Task<Rent> GetAsync(Guid id);

    Task<List<Rent>> GetAllAsync();

    Task UpdateAsync(Rent newRent);
}