using Entity.Context;
using Entity.Dto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

public class ClienteData
{
    private readonly ApplicationDbContext _context;

    public ClienteData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClienteDto>> GetAllAsync()
    {
        return await _context.Cliente
            .Select(c => new ClienteDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Telefono = c.Telefono
            }).ToListAsync();
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        return await _context.Cliente
            .Where(c => c.Id == id)
            .Select(c => new ClienteDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Telefono = c.Telefono
            }).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(ClienteDto dto)
    {
        var cliente = new Cliente
        {
            Nombre = dto.Nombre,
            Telefono = dto.Telefono
        };

        _context.Cliente.Add(cliente);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(ClienteDto dto)
    {
        var cliente = await _context.Cliente.FindAsync(dto.Id);
        if (cliente != null)
        {
            cliente.Nombre = dto.Nombre;
            cliente.Telefono = dto.Telefono;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await _context.Cliente.FindAsync(id);
        if (cliente != null)
        {
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }

}
