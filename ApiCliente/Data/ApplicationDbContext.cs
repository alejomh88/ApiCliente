using ApiCliente.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Agregar modelos aquí
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
