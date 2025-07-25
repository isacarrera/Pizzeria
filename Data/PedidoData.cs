using Entity.Context;
using Entity.Dto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

public class PedidoData
{
    private readonly ApplicationDbContext _context;

    public PedidoData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PedidoDTO>> GetAllAsync()
    {
        return await _context.Pedido
            .Select(p => new PedidoDTO
            {
                Id = p.Id,
                ClienteId = p.ClienteId,
                PizzaId = p.PizzaId,
                FechaPedido = p.FechaPedido,
                Estado = p.Estado
            }).ToListAsync();
    }

    public async Task<PedidoDTO?> GetByIdAsync(int id)
    {
        return await _context.Pedido
            .Where(p => p.Id == id)
            .Select(p => new PedidoDTO
            {
                Id = p.Id,
                ClienteId = p.ClienteId,
                PizzaId = p.PizzaId,
                FechaPedido = p.FechaPedido,
                Estado = p.Estado
            }).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(PedidoDTO dto)
    {
        var pedido = new Pedido
        {
            ClienteId = dto.ClienteId,
            PizzaId = dto.PizzaId,
            FechaPedido = dto.FechaPedido,
            Estado = dto.Estado
        };

        _context.Pedido.Add(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PedidoDTO dto)
    {
        var pedido = await _context.Pedido.FindAsync(dto.Id);
        if (pedido == null) return;

        pedido.ClienteId = dto.ClienteId;
        pedido.PizzaId = dto.PizzaId;
        pedido.FechaPedido = dto.FechaPedido;
        pedido.Estado = dto.Estado;

        _context.Pedido.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pedido = await _context.Pedido.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
