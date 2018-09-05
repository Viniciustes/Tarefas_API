
using Microsoft.EntityFrameworkCore;

namespace Tarefas_API.Models
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) { }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}