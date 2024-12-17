using WebApp_Library.Classes;

namespace WebApp_Library.Services;

public interface IBookService
{
    Task AddAsync(Book book);

    Task DeleteAsync(Guid lsz);

    Task<Book> GetAsync(Guid lsz);

    Task<List<Book>> GetAllAsync();

    Task UpdateAsync(Book newBook);
}