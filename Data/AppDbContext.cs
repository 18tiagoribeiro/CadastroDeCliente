using CadastroClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientesAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Cliente> Clientes { get; set; }
	}
}
