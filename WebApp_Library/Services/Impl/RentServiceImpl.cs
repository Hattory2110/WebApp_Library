using WebApp_Library.Classes;
using WebApp_Library.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Library.Services.Impl;

public class RentServiceImpl : IRentService
{
    private LibraryContext _context;
    private ILogger<RentServiceImpl> _logger;

    public RentServiceImpl(ILogger<RentServiceImpl> logger, LibraryContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task AddAsync(Rent rent)
    {
        _logger.LogInformation("Rent to add: {@Rent}", rent);

        await _context.AddAsync(rent);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid lsz)
    {
        var rent = await GetAsync(lsz);

        if (rent is null)
        {
            throw new KeyNotFoundException("Rent not found");
        }
        
        _context.Remove(rent);
        await _context.SaveChangesAsync();
    }

    public async Task<Rent> GetAsync(Guid lsz)
    {
        return await _context.FindAsync<Rent>(lsz);
    }

    public async Task<List<Rent>> GetAllAsync()
    {
        _logger.LogInformation("All rent retrieved");
        return await _context.Rents.ToListAsync();
    }

    public async Task UpdateAsync(Rent newRent)
    {
        var existingRent = await GetAsync(newRent.Osz);

        existingRent.LSz = newRent.LSz;
        existingRent.RentDate = newRent.RentDate;
        existingRent.VisszahozásDate = newRent.VisszahozásDate;
        
        await _context.SaveChangesAsync();
    }
}