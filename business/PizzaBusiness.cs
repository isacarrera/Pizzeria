using Entity.Dto;

public class PizzaBusiness
{
    private readonly PizzaData _data;

    public PizzaBusiness(PizzaData data)
    {
        _data = data;
    }

    public Task<List<PizzaDto>> GetAllAsync() => _data.GetAllAsync();
    public Task<PizzaDto?> GetByIdAsync(int id) => _data.GetByIdAsync(id);
    public Task CreateAsync(PizzaDto dto) => _data.CreateAsync(dto);
     public Task UpdateAsync(PizzaDto dto) => _data.UpdateAsync(dto);

    public Task DeleteAsync(int id) => _data.DeleteAsync(id);

}
