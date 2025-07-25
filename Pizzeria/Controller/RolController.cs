using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RolController : ControllerBase
{
    private readonly RolBusiness _business;

    public RolController(RolBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _business.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var rol = await _business.GetByIdAsync(id);
        return rol is null ? NotFound() : Ok(rol);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RolDto dto)
    {
        await _business.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RolDto dto)
    {
        await _business.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _business.DeleteAsync(id);
        return Ok();
    }
}
