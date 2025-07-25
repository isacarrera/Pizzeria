using Entity.Context;
using Entity.Dto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

public class PizzaData
{
    private readonly ApplicationDbContext _context;

    public PizzaData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PizzaDto>> GetAllAsync()
    {
        return await _context.Pizza
            .Select(p => new PizzaDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio
            }).ToListAsync();
    }

    public async Task<PizzaDto?> GetByIdAsync(int id)
    {
        return await _context.Pizza
            .Where(p => p.Id == id)
            .Select(p => new PizzaDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio
            }).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(PizzaDto dto)
    {
        var pizza = new Pizza
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio
        };

        _context.Pizza.Add(pizza);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(PizzaDto dto)
    {
        var pizza = await _context.Pizza.FindAsync(dto.Id);
        if (pizza != null)
        {
            pizza.Nombre = dto.Nombre;
            pizza.Precio = dto.Precio;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var pizza = await _context.Pizza.FindAsync(id);
        if (pizza != null)
        {
            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();
        }
    }



}
