using Microsoft.EntityFrameworkCore;
using WebApp_Library.Classes;

namespace WebApp_Library.Contexts;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Book> Books { get; set; }
    
    public virtual DbSet<Rent> Rents { get; set; }
    
    // public virtual DbSet<Olvaso> Olvasok { get; set; }
    //
    // public virtual DbSet<Person> People { get; set; }
}