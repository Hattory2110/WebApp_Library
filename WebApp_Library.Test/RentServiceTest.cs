using Microsoft.EntityFrameworkCore;
using WebApp_Library.Contexts;

namespace WebApp_Library.Test;

public class RentServiceTest : IAsyncDisposable
{
    private readonly LibraryContext _context;

    public RentServiceUnitTests()
    {
        var contextOptions = new DbContextOptionsBuilder<LibraryContext>()
            .UseInMemoryDatabase("LibraryDBTests")
            .Options;

        _context = new LibraryContext(contextOptions);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.SaveChanges();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}