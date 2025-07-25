using Entity.Dto;
using System.Data;
public class ClienteBusiness
{
    private readonly ClienteData _data;

    public ClienteBusiness(ClienteData data)
    {
        _data = data;
    }

    public Task<List<ClienteDto>> GetAllAsync() => _data.GetAllAsync();

    public Task<ClienteDto?> GetByIdAsync(int id) => _data.GetByIdAsync(id);

    public Task CreateAsync(ClienteDto dto) => _data.CreateAsync(dto);
    public Task UpdateAsync(ClienteDto dto) => _data.UpdateAsync(dto);

    public Task DeleteAsync(int id) => _data.DeleteAsync(id);

}
