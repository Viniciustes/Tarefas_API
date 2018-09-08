namespace Tarefas_API.Models
{
    public class Tarefa
    {
        public Tarefa(string nome, bool finalizada = false)
        {
            Nome = nome;
            Finalizada = finalizada;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public bool Finalizada { get; set; }

        public Tarefa Editar(Tarefa entity)
        {
            Nome = entity.Nome;
            Finalizada = entity.Finalizada;

            return this;
        }
    }
}