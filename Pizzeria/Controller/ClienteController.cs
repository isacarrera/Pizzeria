using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteBusiness _business;

    public ClienteController(ClienteBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _business.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _business.GetByIdAsync(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClienteDto dto)
    {
        await _business.CreateAsync(dto);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ClienteDto dto)
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
