using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CreateUsuarioAsync(Usuario usuario)
        {
            ValidateUsuario(usuario);
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(usuario.Email);
            if (usuarioExistente != null)
            {
                throw new ArgumentException("Já existe um usuário com esse e-mail.");
            }

            await _usuarioRepository.AddAsync(usuario); // Substitua CreateAsync por AddAsync se necessário
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID do usuário é inválido.");
            }
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            ValidateUsuario(usuario);
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(usuario.Id);
            if (usuarioExistente == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            var usuarioExistenteComEmail = await _usuarioRepository.GetByEmailAsync(usuario.Email);
            if (usuarioExistenteComEmail != null && usuarioExistenteComEmail.Id != usuario.Id)
            {
                throw new ArgumentException("Já existe um usuário com esse e-mail.");
            }

            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID do usuário é inválido.");
            }

            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            await _usuarioRepository.DeleteAsync(id);
        }

        private void ValidateUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentException("O usuário não pode ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Nome))
            {
                throw new ArgumentException("O nome do usuário é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Email) || !IsValidEmail(usuario.Email))
            {
                throw new ArgumentException("O e-mail do usuário é inválido.");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
