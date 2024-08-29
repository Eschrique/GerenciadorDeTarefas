using System;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty; 
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataConclusao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
            {
                throw new ArgumentException("Título da tarefa é obrigatório.");
            }

            if (UsuarioId <= 0)
            {
                throw new ArgumentException("ID do usuário é obrigatório.");
            }
        }
    }
}
