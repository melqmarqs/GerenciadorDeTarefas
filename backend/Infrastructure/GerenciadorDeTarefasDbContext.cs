using Domain.Enums;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GerenciadorDeTarefasDbContext : DbContext
    {
        public GerenciadorDeTarefasDbContext(DbContextOptions<GerenciadorDeTarefasDbContext> options)
            : base(options) { }

        public DbSet<TarefaDbModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefaDbModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).HasMaxLength(70).IsRequired();
                entity.Property(e => e.Descricao).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Prioridade).HasConversion<int>();
                entity.Property(e => e.Status).HasConversion<int>();
            });
        }
    }
}
