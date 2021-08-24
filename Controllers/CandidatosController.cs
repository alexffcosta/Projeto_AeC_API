using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apresentacao.Models;
using apresentacao.Servicos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace apresentacao.Controllers
{
     // [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly DbContexto _context;

        public CandidatosController(DbContexto context)
        {
            _context = context;
        }

        // GET: api/Candidatos
        [HttpGet]
        [Route("/candidatos")]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
        {
            return await _context.Candidatos.ToListAsync();         
        }

        // GET: api/Candidatos/5
        [HttpGet]
        [Route("/candidatos/{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return candidato;
        }

        // PUT: api/Candidatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("/candidatos/{id}")]

        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            } catch (SqlException)
            {    
                return NoContent();

            } catch (DbUpdateException)
            {
                return NoContent();
            }

            return NoContent();
        }

        // POST: api/Candidatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/candidatos")]
        public async Task<ActionResult<Candidato>> Candidato([FromBody] Candidato candidato)
        {
            bool cpfExiste = (await _context.Candidatos.Where(v => v.Cpf == candidato.Cpf).CountAsync()) > 0;
            if (cpfExiste)
            {
                return StatusCode(200, new { Mensagem = "CPF JÁ ESTÁ CADASTRADO." });
            }
            else if(ModelState.IsValid)
            {
            _context.Add(candidato);
            await _context.SaveChangesAsync();
            return StatusCode(202, await _context.Candidatos.ToListAsync());
            }
            else
            {
                return StatusCode(406, new { Mensagem = "CPF NÃO CADASTRADO" });
            }
        }
        
        

        private ActionResult<Candidato> TextResult(string v)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Candidatos/5
        [HttpDelete]
        [Route("/candidatos/{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}