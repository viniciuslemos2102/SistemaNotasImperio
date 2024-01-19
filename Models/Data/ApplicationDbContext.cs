using Microsoft.EntityFrameworkCore;

namespace SistemaNotasImperio.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-466P3UV;Database=ImperioMvc;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
    }
}
