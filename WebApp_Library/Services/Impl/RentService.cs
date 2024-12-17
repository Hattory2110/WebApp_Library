using WebApp_Library.Classes;
using WebApp_Library.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Library.Services.Impl;

public class RentService : IRentService
{
    private LibraryContext _context;
    private ILogger<RentService> _logger;

    public RentService(ILogger<RentService> logger, LibraryContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task AddAsync(Rent rent)
    {
        _logger.LogInformation("Olvaso to add: {@Kölcsönzes}", rent);

        await _context.AddAsync(rent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var rent = await GetAsync(id);

        if (rent is null)
        {
            throw new KeyNotFoundException("Olvaso not found");
        }
        
        _context.Remove(rent);
        await _context.SaveChangesAsync();
    }

    public async Task<Rent> GetAsync(Guid id)
    {
        return await _context.FindAsync<Rent>(id);
    }

    public async Task<List<Rent>> GetAllAsync()
    {
        _logger.LogInformation("All rent retrieved");
        return await _context.Rent.ToListAsync();
    }

    public async Task UpdateAsync(Rent newRent)
    {
        var existingRent = await GetAsync(newRent.Osz);

        existingRent.Lsz = newRent.Lsz;
        existingRent.RentDate = newRent.RentDate;
        existingRent.VisszahozásDate = newRent.VisszahozásDate;
        
        await _context.SaveChangesAsync();
    }
}