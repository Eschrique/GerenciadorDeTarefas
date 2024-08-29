using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Infrastructure.Data
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            return await _context.Tarefas
                .Include(t => t.Usuario) // Inclui o usuário associado
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas
                .Include(t => t.Usuario) // Inclui o usuário associado
                .ToListAsync();
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            tarefa.Validate(); // Valida a tarefa
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            tarefa.Validate(); // Valida a tarefa
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
