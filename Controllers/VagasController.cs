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
    [Route("[controller]")]
    public class VagasController : ControllerBase
    {
        private readonly DbContexto _context;

        public VagasController(DbContexto context)
        {
            _context = context;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Vagas;
            return StatusCode(200, await dbContexto.ToListAsync());
        }

                
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Cargo")] Vaga vaga)
        {
           
            _context.Add(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(201, vaga);
                
        }

             

        
        [HttpDelete, ActionName("Delete")]
        
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


