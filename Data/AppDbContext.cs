using CadastroClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientesAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.DataNascimento)
                .HasColumnType("date"); // Garante que o campo no banco seja apenas "date"
        }
    }

}
