using CrudComEntitySwagger.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudComEntitySwagger.Context
{
    public class PessoaContext:DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options)
            : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(c =>
            {
                c.ToTable("Pessoas");
                c.HasKey(p => p.Id);

            });
        }
    }
}
