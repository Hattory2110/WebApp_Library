using WebApp_Library.Shared.Classes;

namespace WebApp_Library.UI.Services;

public interface IReaderService
{
    Task AddAsync(Reader reader);

    Task DeleteAsync(Guid osz);

    Task<Reader> GetAsync(Guid osz);

    Task<List<Reader>> GetAllAsync();

    Task UpdateAsync(Reader newReader);
}