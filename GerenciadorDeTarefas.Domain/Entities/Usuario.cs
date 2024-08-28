using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        [JsonIgnore]
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
