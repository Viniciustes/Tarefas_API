
using Microsoft.EntityFrameworkCore;

namespace Tarefas_API.Models
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().HasKey(x => x.Id);
        }
    }
}