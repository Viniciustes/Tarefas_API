using System.Collections.Generic;
using System.Linq;

namespace Tarefas_API.Models
{
    public class BDInicial
    {
        public static void Inicializar(in TarefaContext context)
        {
            if (context.Tarefas.Any()) return;

            var tarefas = new List<Tarefa>
                {
                    new Tarefa ("Tarefa 1"),
                    new Tarefa ("Tarefa 2"),
                    new Tarefa ("Tarefa 3"),
                    new Tarefa ("Tarefa 4")
                };

            context.Tarefas.AddRangeAsync(tarefas);

            context.SaveChangesAsync();
        }
    }
}