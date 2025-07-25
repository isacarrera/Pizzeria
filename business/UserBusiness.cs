using Entity.Dto;

public class UserBusiness
{
    private readonly UserData _data;

    public UserBusiness(UserData data)
    {
        _data = data;
    }

    public Task<List<UserDto>> GetAllAsync() => _data.GetAllAsync();
    public Task<UserDto?> GetByIdAsync(int id) => _data.GetByIdAsync(id);
    public Task CreateAsync(UserDto dto) => _data.CreateAsync(dto);
    public Task UpdateAsync(UserDto dto) => _data.UpdateAsync(dto);
    public Task DeleteAsync(int id) => _data.DeleteAsync(id);

    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await _data.LoginAsync(dto.Usuario, dto.Contrasena);
        if (user == null) return null;

        return new LoginResponseDto
        {
            Id = user.Id,
            Usuario = user.Usuario,
            Rol = user.Rol.Nombre
        };
    }

}
