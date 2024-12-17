using WebApp_Library.Classes;

namespace WebApp_Library.Services;

public interface IReaderService
{
    Task AddAsync(Reader reader);

    Task DeleteAsync(Guid osz);

    Task<Reader> GetAsync(Guid osz);

    Task<List<Reader>> GetAllAsync();

    Task UpdateAsync(Reader newReader);
}