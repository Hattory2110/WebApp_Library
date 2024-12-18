using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Library.Shared.Classes;

public class Rent
{
    [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Osz { get; set; }
    
    
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid LSz { get; set; }

    DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
    
    [Required]
    [Range(typeof(DateOnly), "2024-12-18", "2000-12-31")]
    public DateOnly RentDate { get; set; }
    
    [Required]
    [Range(typeof(DateOnly), "1990-01-01", "2000-12-31")]
    public DateOnly ReturnDate { get; set; }
}