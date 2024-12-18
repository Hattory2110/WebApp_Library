using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using WebApp_Library.Contexts;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.Test;

public sealed class BookServiceUnitTests : IAsyncDisposable
{
    private readonly LibraryContext _context;


    public BookServiceUnitTests()
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

    [Fact]
    public async Task IT_AddAsync_ContainsOneBook()
    {
        // Arrange
        var bookService = new BookService(NullLogger<BookService>.Instance, _context);

        await bookService.AddAsync(new Book
        {
            Title = "IT",
            Writer = "Stephen King",
            Publisher = "Európa Könyvkiadó",
            ReleaseDate = 1995
        });

        // Act
        var book = await bookService.GetAllAsync();

        // Assert
        Assert.Single(book);
    }

    [Fact]
    public async Task The_Shining_AddAsync_ContainsOneBook()
    {
        // Arrange
        var bookService = new BookService(NullLogger<BookService>.Instance, _context);

        await bookService.AddAsync(new Book
        {
            Title = "The Shining",
            Writer = "Stephen King",
            Publisher = "Európa Könyvkiadó",
            ReleaseDate = 1986
        });

        // Act
        var book = await bookService.GetAllAsync();

        // Assert
        Assert.Single(book);
    }
}