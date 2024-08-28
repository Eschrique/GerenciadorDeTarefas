namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public bool Concluida { get; set; }
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
    }
}
