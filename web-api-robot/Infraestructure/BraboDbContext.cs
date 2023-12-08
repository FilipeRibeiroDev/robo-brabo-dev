using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class BraboDbContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }

        public BraboDbContext(DbContextOptions options) : base(options) { }
    }
}
