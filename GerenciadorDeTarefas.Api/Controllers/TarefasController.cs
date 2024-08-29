using Microsoft.AspNetCore.Mvc;
using GerenciadorDeTarefas.Application.Services;
using GerenciadorDeTarefas.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefasController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova tarefa", Description = "Adiciona uma nova tarefa ao banco de dados.")]
        public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
        {
            try
            {
                await _tarefaService.CreateTarefaAsync(tarefa);
                return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma tarefa pelo ID", Description = "Recupera uma tarefa existente com base no ID fornecido.")]
        public async Task<IActionResult> Get(int id)
        {
            var tarefa = await _tarefaService.GetTarefaByIdAsync(id);
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

            try
            {
                await _tarefaService.UpdateTarefaAsync(tarefa);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma tarefa", Description = "Remove uma tarefa existente com base no ID fornecido.")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tarefaService.DeleteTarefaAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
