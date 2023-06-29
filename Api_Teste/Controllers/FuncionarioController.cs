using Api_Teste.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>();

        // GET: api/Funcionario
        [HttpGet]
        public ActionResult<List<Funcionario>> Get()
        {
            return Ok(funcionarios);
        }

        // GET api/Funcionario/5
        [HttpGet("{id}")]
        public ActionResult<Funcionario> Get(int id)
        {
            var funcionario = funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        // POST api/Funcionario
        [HttpPost]
        public ActionResult<Funcionario> Post([FromBody] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                if (funcionarios.Any(f => f.Id == funcionario.Id))
                {
                    ModelState.AddModelError("", "Já existe um funcionário com o mesmo ID.");
                    return BadRequest(ModelState);
                }
                if (funcionarios.Any(f => f.EmpresaId == funcionario.EmpresaId))
                {
                    ModelState.AddModelError("", "Já existe um funcionário nesta empresa.");
                    return BadRequest(ModelState);
                }
                if (funcionarios.Any(f => f.DepartamentoId == funcionario.DepartamentoId))
                {
                    ModelState.AddModelError("Atenção", "Já existe este departamento ligado a esse funcionário.");
                    return BadRequest(ModelState);
                }
                funcionarios.Add(funcionario);
                return CreatedAtAction(nameof(Get), new { id = funcionario.Id }, funcionario);
            }
            return BadRequest(ModelState);
        }

        // PUT api/Funcionario/5
        [HttpPut("{id}")]
        public ActionResult<Funcionario> Put(int id, [FromBody] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var funcionarioExistente = funcionarios.FirstOrDefault(f => f.Id == id);
                if (funcionarioExistente == null)
                {
                    return NotFound();
                }
                funcionarioExistente.Nome = funcionario.Nome;
                funcionarioExistente.DepartamentoId = funcionario.DepartamentoId;
                // Atualizar outras propriedades conforme necessário
                return Ok(funcionarioExistente);
            }
            return BadRequest(ModelState);
        }

        // DELETE api/Funcionario/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var funcionario = funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            funcionarios.Remove(funcionario);
            return NoContent();
        }
    }
}
