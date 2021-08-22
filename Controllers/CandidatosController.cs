using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apresentacao.Models;
using apresentacao.Servicos;

namespace apresentacao.Controllers
{
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly DbContexto _context;

        public CandidatosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Candidatos
        [HttpGet]
        [Route("/candidatos")]
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Candidatos.Include(c => c.Vaga);
            return StatusCode(200, await dbContexto.ToListAsync());
        }

        
        
        
        [HttpPost]
        [Route("/candidatos/{id}")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Dtanascimento,Email,Cep,Logadouro,Numero,Bairro,Cidade,Estado,Telefone,VagaId")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return StatusCode(200, nameof(Index));
            }
            else
            {
                return StatusCode(406);
            }
        }

        
        [HttpPut]
        [Route("/vagas/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Dtanascimento,Email,Cep,Logadouro,Numero,Bairro,Cidade,Estado,Telefone,VagaId")] Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return StatusCode(200, candidato);
        }

                
        [HttpDelete]
        [Route("/vagas/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
