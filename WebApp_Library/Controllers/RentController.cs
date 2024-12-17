using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp_Library.Shared.Classes;
using WebApp_Library.Services;

namespace WebApp_Library.Controllers;

[ApiController]
[Route("rent")]
public class RentController : ControllerBase
{
    private IRentService _rentService;

    public RentController(IRentService rentService)
    {
        _rentService = rentService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Rent rent)
    {
        var existingRent = await _rentService.GetAsync(rent.LSz);

        if (existingRent is not null)
        {
            return Conflict();
        }

        await _rentService.AddAsync(rent);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var rent = await _rentService.GetAsync(id);

        if (rent is null)
        {
            return NotFound();
        }

        await _rentService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Rent>> Get(Guid id)
    {
        var rent = await _rentService.GetAsync(id);
    
        if (rent is null)
        {
            return NotFound();
        }
    
        return Ok(rent);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Rent>>> Get()
    {
        return Ok(await _rentService.GetAllAsync());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Rent newRent)
    {
        if (id != newRent.LSz)
        {
            return BadRequest();
        }

        var existingRent = await _rentService.GetAsync(id);

        if (existingRent is null)
        {
            return NotFound();
        }

        await _rentService.UpdateAsync(newRent);

        return Ok();
    }
}