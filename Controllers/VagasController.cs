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
    public class VagasController : ControllerBase
    {
        private readonly DbContexto _context;

        public VagasController(DbContexto context)
        {
            _context = context;
        }

        // GET: Vagas
        [HttpGet]
        [Route("/vagas")]
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Vagas;
            return StatusCode(200, await dbContexto.ToListAsync());
        }

        


        [HttpPost]
        [Route("/vagas")]
        public async Task<IActionResult> Create([Bind("Id,Cargo")] Vaga vaga)
        {
            bool cargoExiste = (await _context.Vagas.Where(v => v.Cargo == vaga.Cargo).CountAsync()) > 0; 
           if(cargoExiste)
           {
                return StatusCode(406, new { Mensagem = "Este cargo já foi cadastrado" });
           }
            else if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return StatusCode(201, vaga);
            }
            else
            {
                return StatusCode(406);
            }
            
        }

       
        [HttpPut]
        [Route("/vagas/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cargo")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return StatusCode(406, vaga);
        }

                
        [HttpDelete]
        [Route("/vagas/{id}")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.Id == id);
        }
    }
}
