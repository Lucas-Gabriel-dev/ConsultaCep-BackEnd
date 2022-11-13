using ConsultaCep.src.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCep.src.Context
{
    public class CepContext : DbContext
    {
        public CepContext(DbContextOptions<CepContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Cep> Ceps { get; set; }
    }
}