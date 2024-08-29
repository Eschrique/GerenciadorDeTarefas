using GerenciadorDeTarefas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);  // Adicione este método
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
