using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebApplication3.Data.Mep;
using WebApplication3.Model;

namespace WebApplication3.Data
{
    public class CarrosDBContext : DbContext
    {
        public CarrosDBContext (DbContextOptions<CarrosDBContext> options) : base(options)
        {
            
        
        }  
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Carro> Carros{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CarroMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
