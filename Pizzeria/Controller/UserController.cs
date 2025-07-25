using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserBusiness _business;

    public UserController(UserBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _business.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _business.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto dto)
    {
        await _business.CreateAsync(dto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserDto dto)
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

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto dto)
    {
        var result = await _business.LoginAsync(dto);
        if (result == null)
            return Unauthorized("Correo o contraseña incorrectos");

        return Ok(result);
    }
}
