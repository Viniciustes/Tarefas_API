using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tarefas_API.Models;

namespace Tarefas_API.Controllers
{
    [Route("api/Tarefas")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefaContext _context;
        public TarefasController(TarefaContext context)
        {
            _context = context;

            if (!_context.Tarefas.Any())
            {
                _context.Add(new Tarefa { Nome = "Tarefa 1" });
                _context.Add(new Tarefa { Nome = "Tarefa 2" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IList<Tarefa> GetAll()
        {
            return _context.Tarefas.ToList();
        }

        [HttpGet("{id}", Name = "BuscarTarefa")]
        public IActionResult GetById(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            
            if (tarefa == null)
                NotFound();
            
            return Ok(tarefa);
        }
    }
}