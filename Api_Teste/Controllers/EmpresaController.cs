using Api_Teste.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private static List<Empresa> empresas = new List<Empresa>();

        // GET: api/Empresa
        [HttpGet]
        public ActionResult<List<Empresa>> Get()
        {
            return Ok(empresas);
        }

        // GET api/Empresa/5
        [HttpGet("{id}")]
        public ActionResult<Empresa> Get(int id)
        {
            var empresa = empresas.FirstOrDefault(e => e.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        // POST api/Empresa
        [HttpPost]
        public ActionResult<Empresa> Post([FromBody] Empresa novaEmpresa)
        {
            if (ModelState.IsValid)
            {
                if (empresas.Any(e => e.Id == novaEmpresa.Id))
                {
                    ModelState.AddModelError("", "Já existe uma empresa com o mesmo ID.");
                    return BadRequest(ModelState);
                }
                if (empresas.Any(e => e.Cnpj == novaEmpresa.Cnpj))
                {
                    ModelState.AddModelError("", "Já existe uma empresa com o mesmo CNPJ.");
                    return BadRequest(ModelState);
                }
                empresas.Add(novaEmpresa);
                return CreatedAtAction(nameof(Get), new { id = novaEmpresa.Id }, novaEmpresa);
            }
            return BadRequest(ModelState);
        }

        // PUT api/Empresa/5
        [HttpPut("{id}")]
        public ActionResult<Empresa> Put(int id, [FromBody] Empresa empresaAtualizada)
        {
            if (ModelState.IsValid)
            {
                var empresaExistente = empresas.FirstOrDefault(e => e.Id == id);
                if (empresaExistente == null)
                {
                    return NotFound();
                }
                empresaExistente.Nome = empresaAtualizada.Nome;
                empresaExistente.Cnpj = empresaAtualizada.Cnpj;
                // Atualizar outras propriedades conforme necessário
                return Ok(empresaExistente);
            }
            return BadRequest(ModelState);
        }

        // DELETE api/Empresa/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var empresa = empresas.FirstOrDefault(e => e.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }
            empresas.Remove(empresa);
            return NoContent();
        }
    }
}
