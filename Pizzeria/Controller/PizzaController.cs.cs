using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaBusiness _business;

    public PizzaController(PizzaBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<ActionResult<List<PizzaDto>>> GetAll()
        => Ok(await _business.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<PizzaDto>> GetById(int id)
    {
        var pizza = await _business.GetByIdAsync(id);
        return pizza == null ? NotFound() : Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PizzaDto dto)
    {
        await _business.CreateAsync(dto);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PizzaDto dto)
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
