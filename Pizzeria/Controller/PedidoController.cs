using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoBusiness _business;

    public PedidoController(PedidoBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pedidos = await _business.GetAllAsync();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _business.GetByIdAsync(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PedidoDTO dto)
    {
        await _business.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PedidoDTO dto)
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
