using Microsoft.EntityFrameworkCore;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.Contexts;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Book> Books { get; set; }
    
    public virtual DbSet<Rent> Rents { get; set; }
    
    public virtual DbSet<Reader> Readers { get; set; }
}