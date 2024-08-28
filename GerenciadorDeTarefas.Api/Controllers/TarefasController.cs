using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Infrastructure.Data;
using GerenciadorDeTarefas.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciadorDeTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova tarefa", Description = "Adiciona uma nova tarefa ao banco de dados.")]
        public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest("Tarefa é obrigatória.");
            }

            if (tarefa.UsuarioId <= 0)
            {
                return BadRequest("UsuarioId é obrigatório.");
            }

            var usuario = await _context.Usuarios.FindAsync(tarefa.UsuarioId);
            if (usuario == null)
            {
                return BadRequest("Usuario não encontrado.");
            }

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma tarefa pelo ID", Description = "Recupera uma tarefa existente com base no ID fornecido.")]
        public async Task<IActionResult> Get(int id)
        {
            var tarefa = await _context.Tarefas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma tarefa", Description = "Atualiza os detalhes de uma tarefa existente.")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest("ID da tarefa não corresponde.");
            }

            var tarefaExistente = await _context.Tarefas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tarefaExistente == null)
            {
                return NotFound();
            }

            if (tarefa.UsuarioId != tarefaExistente.UsuarioId)
            {
                var usuario = await _context.Usuarios.FindAsync(tarefa.UsuarioId);
                if (usuario == null)
                {
                    return BadRequest("Usuario não encontrado.");
                }
            }

            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.UsuarioId = tarefa.UsuarioId;

            _context.Entry(tarefaExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma tarefa", Description = "Remove uma tarefa existente com base no ID fornecido.")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
