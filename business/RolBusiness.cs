using Data;
using Entity.Dto;

public class RolBusiness
{
    private readonly RolData _data;

    public RolBusiness(RolData data)
    {
        _data = data;
    }

    public Task<List<RolDto>> GetAllAsync() => _data.GetAllAsync();
    public Task<RolDto?> GetByIdAsync(int id) => _data.GetByIdAsync(id);
    public Task CreateAsync(RolDto dto) => _data.CreateAsync(dto);
    public Task UpdateAsync(RolDto dto) => _data.UpdateAsync(dto);
    public Task DeleteAsync(int id) => _data.DeleteAsync(id);
}
