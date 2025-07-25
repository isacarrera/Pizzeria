using Entity.Model;
using Microsoft.EntityFrameworkCore; 

namespace Entity.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define aquí tus DbSet, por ejemplo:
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pizza>()
               .Property(p => p.Precio)
               .HasPrecision(10, 2);
        }
    }
}
