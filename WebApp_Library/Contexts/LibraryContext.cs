using Microsoft.EntityFrameworkCore;
using WebApp_Library.Classes;

namespace WebApp_Library.Contexts;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }
    
    // public virtual DbSet<Könyv> Könyv { get; set; }
    
    public virtual DbSet<Rent> Rent { get; set; }
    
    // public virtual DbSet<Olvaso> Olvasok { get; set; }
    //
    // public virtual DbSet<Person> People { get; set; }
}