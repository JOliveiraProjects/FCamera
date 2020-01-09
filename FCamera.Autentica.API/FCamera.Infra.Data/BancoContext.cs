using FCamera.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCamera.Infra.Data
{
    public class BancoContext : DbContext
    {
        public DbSet<AutenticaModel> Autentica { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
