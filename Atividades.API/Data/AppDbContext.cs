using System;
using Atividades.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividades.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<Atividade> Atividades { get; set; }
	}
}

