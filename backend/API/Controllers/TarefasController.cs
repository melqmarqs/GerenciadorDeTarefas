using API.Models;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefasController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetAll()
        {
            var tarefas = await _tarefaService.GetAllTarefasAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa?>> GetByIdAsync(int id)
        {
            var resp = await _tarefaService.GetTarefaByIdAsync(id);
            return resp != null ? Ok(resp) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Tarefa>> Create([FromBody] CreateTarefaDto dto)
        {
            var tarefa = await _tarefaService.CreateTarefaAsync(
                dto.Titulo,
                dto.Descricao,
                dto.Prioridade,
                dto.Status,
                DateOnly.Parse(DateTime.Now.ToString("yyyy-MM-dd")));

            return CreatedAtAction(nameof(GetAll), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarefa?>> UpdateTarefaAsync([FromBody] UpdateTarefaDto dto,[FromRoute] int id)
        {
            var domainTarefa = new Tarefa(
                dto.Titulo,
                dto.Descricao,
                dto.Prioridade,
                dto.Status)
                { Id = id };
            var resp = await _tarefaService.UpdateTarefaAsync(domainTarefa);
            return resp != null ? Ok(resp) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTarefaAsync(int id)
        {
            var success = await _tarefaService.DeleteTarefaAsync(id);
            return success ? Ok(true) : NotFound();
        }
    }
}
