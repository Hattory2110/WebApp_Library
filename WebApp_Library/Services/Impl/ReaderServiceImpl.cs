using Microsoft.EntityFrameworkCore;
using WebApp_Library.Contexts;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.Services.Impl;

public class ReaderServiceImpl : IReaderService
{
    
    private LibraryContext _context;
    private ILogger<ReaderServiceImpl> _logger;

    public ReaderServiceImpl(LibraryContext context, ILogger<ReaderServiceImpl> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddAsync(Reader reader)
    {
        _logger.LogInformation("Reader to add: {@Reader}", reader);

        await _context.AddAsync(reader);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid osz)
    {
        var reader = await GetAsync(osz);

        if (reader is null)
        {
            throw new KeyNotFoundException("Reader not found");
        }
        
        _context.Remove(reader);
        await _context.SaveChangesAsync();
    }

    public async Task<Reader> GetAsync(Guid osz)
    {
        return await _context.FindAsync<Reader>(osz);
    }

    public async Task<List<Reader>> GetAllAsync()
    {
        _logger.LogInformation("All reader retrieved");
        return await _context.Readers.ToListAsync();
    }

    public async Task UpdateAsync(Reader newReader)
    {
        var existingReader = await GetAsync(newReader.OSz);

        existingReader.OSz = newReader.OSz;
        existingReader.Name = newReader.Name;
        existingReader.Address = newReader.Address;
        existingReader.BirthDate = newReader.BirthDate;
        
        await _context.SaveChangesAsync();
    }
}