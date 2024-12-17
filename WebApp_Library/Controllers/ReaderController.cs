using Microsoft.AspNetCore.Mvc;
using WebApp_Library.Classes;
using WebApp_Library.Services;

namespace WebApp_Library.Controllers;

[ApiController]
[Route("reader")]
public class ReaderController : ControllerBase
{
    private IReaderService _readerService;

    public ReaderController(IReaderService readerService)
    {
        _readerService = readerService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Reader reader)
    {
        var existingReader = await _readerService.GetAsync(reader.OSz);

        if (existingReader is not null)
        {
            return Conflict();
        }

        await _readerService.AddAsync(reader);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var reader = await _readerService.GetAsync(id);

        if (reader is null)
        {
            return NotFound();
        }

        await _readerService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Reader>> Get(Guid id)
    {
        var reader = await _readerService.GetAsync(id);
    
        if (reader is null)
        {
            return NotFound();
        }
    
        return Ok(reader);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Reader>>> Get()
    {
        return Ok(await _readerService.GetAllAsync());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Reader newReader)
    {
        if (id != newReader.OSz)
        {
            return BadRequest();
        }

        var existingReader = await _readerService.GetAsync(id);

        if (existingReader is null)
        {
            return NotFound();
        }

        await _readerService.UpdateAsync(newReader);

        return Ok();
    }
}