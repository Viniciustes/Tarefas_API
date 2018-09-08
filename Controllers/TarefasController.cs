using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarefas_API.Models;

namespace Tarefas_API.Controllers
{
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaContext _context;

        public TarefasController(TarefaContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Tarefas.FindAsync(id);

            _context.Tarefas.Remove(entity ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tarefa tarefa)
        {
            if (tarefa == null || tarefa.Id == 0)
                BadRequest();

            var _tarefa = await _context.Tarefas.FindAsync(id);

            if (_tarefa == null)
                NotFound();

            _tarefa.Editar(tarefa);

            _context.Tarefas.Update(_tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
                BadRequest();

            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetById", new { id = tarefa.Id }, tarefa);
        }

        [HttpGet]
        public async Task<IList<Tarefa>> GetAll()
        {
            return await _context.Tarefas.ToAsyncEnumerable().ToList();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _context.Tarefas.FindAsync(id);

            if (value == null)
                NotFound();

            return Ok(value);
        }
    }
}