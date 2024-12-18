using Microsoft.EntityFrameworkCore;
using WebApp_Library.Contexts;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.Services.Impl;

public class BookServiceImpl : IBookService
{
    private LibraryContext _context;
    private ILogger<BookServiceImpl> _logger;
    
    public BookServiceImpl(ILogger<BookServiceImpl> logger, LibraryContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task AddAsync(Book book)
    {
        _logger.LogInformation("Book to add: {@Book}", book);

        await _context.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid lsz)
    {
        var book = await GetAsync(lsz);

        if (book is null)
        {
            throw new KeyNotFoundException("Book not found");
        }
        
        _context.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<Book> GetAsync(Guid lsz)
    {
        return await _context.FindAsync<Book>(lsz);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        _logger.LogInformation("All book retrieved");
        return await _context.Books.ToListAsync();
    }

    public async Task UpdateAsync(Book newBook)
    {
        var existingBook = await GetAsync(newBook.LSz);

        existingBook.LSz = newBook.LSz;
        existingBook.Title = newBook.Title;
        existingBook.Writer = newBook.Writer;
        existingBook.Publisher = newBook.Publisher;
        existingBook.Date = newBook.Date;
        
        await _context.SaveChangesAsync();
        
    }
}