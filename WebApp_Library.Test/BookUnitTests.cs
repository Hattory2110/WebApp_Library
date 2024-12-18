using System.ComponentModel.DataAnnotations;
using WebApp_Library.Shared.Classes;

namespace WebApp_Library.Test;

public class BookUnitTests
{
    [Fact]
    public void ValidTitle_BookValidation_IsValid()
    {
        // Arrange
        var book = new Book
        {
            Title = "IT",
            Writer = "Stephen King",
            Publisher = "Európa Könyvkiadó",
            ReleaseDate = 1995
        };

        // Act
        var results = new List<ValidationResult>();
        var context = new ValidationContext(book, null, null);
        var result = Validator.TryValidateObject(book, context, results, true);

        // Assert
        Assert.True(result);
        Assert.Empty(results);
    }
}