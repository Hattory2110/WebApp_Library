using WebApp_Library.Shared.Classes;

namespace WebApp_Library.UI.Services;

public interface IBookService
{
    public Task AddAsync(Book book);

    public Task DeleteAsync(Guid lsz);

    public Task<Book> GetAsync(Guid lsz);

    public Task<List<Book>> GetAllAsync();

    public Task UpdateAsync(Book newBook);
}