namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
