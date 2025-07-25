using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    using Entity.Context;
    using Entity.Dto;
    using Entity.Model;
    using Microsoft.EntityFrameworkCore;

    public class RolData
    {
        private readonly ApplicationDbContext _context;

        public RolData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolDto>> GetAllAsync()
        {
            return await _context.Rol
                .Select(r => new RolDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                })
                .ToListAsync();
        }

        public async Task<RolDto?> GetByIdAsync(int id)
        {
            return await _context.Rol
                .Where(r => r.Id == id)
                .Select(r => new RolDto
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                })
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(RolDto dto)
        {
            var rol = new Rol { Nombre = dto.Nombre };
            _context.Rol.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RolDto dto)
        {
            var rol = await _context.Rol.FindAsync(dto.Id);
            if (rol != null)
            {
                rol.Nombre = dto.Nombre;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol != null)
            {
                _context.Rol.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }

}
