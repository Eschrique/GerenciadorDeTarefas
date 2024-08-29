using GerenciadorDeTarefas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa?> GetByIdAsync(int id); // Permite valor nulo
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task AddAsync(Tarefa tarefa);
        Task UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
    }
}
