using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apresentacao.Models;
using apresentacao.Servicos;

namespace apresentacao.Controller
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
        [Route("/candidatos")]
        
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Dtanascimento,Estadocivil,Email,Cep,Logadouro,Numero,Bairro,Cidade,Estado,telcontato,VagaId")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return StatusCode(202, await _context.Candidatos.ToListAsync());
            }
            
            bool cpfExiste = (await _context.Candidatos.Where(v => v.Cpf == candidato.Cpf).CountAsync()) > 0; 
            if(cpfExiste)
            {

                return StatusCode(200, new { Mensagem = "CADASTRADO COM SUCESSO." });
            }
           
            else
            {
                return StatusCode(406, new { Mensagem = "CPF JÁ ESTÁ CADASTRADO." });
            }

                    
        }

                
        [HttpPut]
        [Route("/candidatos/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Dtanascimento,Estadocivil,Email,Cep,Logadouro,Numero,Bairro,Cidade,Estado,telcontato,VagaId")] Candidato candidato)
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
    

        
        // POST: Candidatos/Delete/5
        [HttpDelete, ActionName("Delete")]
        [Route("/candidatos/{id}")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return StatusCode(200, candidato); 
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
    

