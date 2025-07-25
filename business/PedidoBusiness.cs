using Entity.Dto;


public class PedidoBusiness
{
    private readonly PedidoData _data;

    public PedidoBusiness(PedidoData data)
    {
        _data = data;
    }

    public Task<List<PedidoDTO>> GetAllAsync() => _data.GetAllAsync();

    public Task<PedidoDTO?> GetByIdAsync(int id) => _data.GetByIdAsync(id);

    public Task CreateAsync(PedidoDTO dto) => _data.CreateAsync(dto);

    public Task UpdateAsync(PedidoDTO dto) => _data.UpdateAsync(dto);

    public Task DeleteAsync(int id) => _data.DeleteAsync(id);
}
