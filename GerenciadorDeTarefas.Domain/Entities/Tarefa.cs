using System;
using System.Text.Json.Serialization;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataConclusao { get; set; }
        public int UsuarioId { get; set; }
        
        [JsonIgnore]
        public Usuario Usuario { get; set; } = new Usuario();
    }
}
