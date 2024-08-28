using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.Web.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public bool Concluida { get; set; }
    }
}
