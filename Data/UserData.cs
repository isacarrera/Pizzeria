using Entity.Context;
using Entity.Dto;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

public class UserData
{
    private readonly ApplicationDbContext _context;

    public UserData(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _context.User
            .Include(u => u.Rol)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Usuario = u.Usuario,
                Contraseña = u.Contraseña,
                RolId = u.RolId,
                RolNombre = u.Rol.Nombre
            })
            .ToListAsync();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        return await _context.User
            .Include(u => u.Rol)
            .Where(u => u.Id == id)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Usuario = u.Usuario,
                Contraseña = u.Contraseña,
                RolId = u.RolId,
                RolNombre = u.Rol.Nombre
            })
            .FirstOrDefaultAsync();
    }

    public async Task CreateAsync(UserDto dto)
    {
        var user = new User
        {
            Usuario = dto.Usuario,
            Contraseña = dto.Contraseña,
            RolId = dto.RolId
        };
        _context.User.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserDto dto)
    {
        var user = await _context.User.FindAsync(dto.Id);
        if (user != null)
        {
            user.Usuario = dto.Usuario;
            user.Contraseña = dto.Contraseña;
            user.RolId = dto.RolId;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user != null)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }


    public async Task<User?> LoginAsync(string usuario, string contrasena)
    {
        return await _context.User
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Usuario == usuario && u.Contraseña == contrasena);
    }



}
