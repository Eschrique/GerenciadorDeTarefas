using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Application.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TarefaService(ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
        {
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateTarefaAsync(Tarefa tarefa)
        {
            tarefa.Validate();

            var usuario = await _usuarioRepository.GetByIdAsync(tarefa.UsuarioId);
            if (usuario == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            await _tarefaRepository.AddAsync(tarefa);
        }

        public async Task UpdateTarefaAsync(Tarefa tarefa)
        {
            tarefa.Validate();

            var tarefaExistente = await _tarefaRepository.GetByIdAsync(tarefa.Id);
            if (tarefaExistente == null)
            {
                throw new ArgumentException("Tarefa não encontrada.");
            }

            if (tarefa.UsuarioId != tarefaExistente.UsuarioId)
            {
                var usuario = await _usuarioRepository.GetByIdAsync(tarefa.UsuarioId);
                if (usuario == null)
                {
                    throw new ArgumentException("Usuário não encontrado.");
                }
            }

            await _tarefaRepository.UpdateAsync(tarefa);
        }

        public async Task DeleteTarefaAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID da tarefa é inválido.");
            }

            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
            {
                throw new ArgumentException("Tarefa não encontrada.");
            }

            await _tarefaRepository.DeleteAsync(id);
        }

        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID da tarefa é inválido.");
            }

            var tarefa = await _tarefaRepository.GetByIdAsync(id);
            if (tarefa == null)
            {
                throw new ArgumentException("Tarefa não encontrada.");
            }

            return tarefa;
        }
    }
}
