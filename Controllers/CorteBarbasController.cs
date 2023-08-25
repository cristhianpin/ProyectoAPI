using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectodawa.Data;
using proyectodawa.Models;

namespace ProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorteBarbasController : ControllerBase
    {
        private readonly ProyectoContext _context;

        public CorteBarbasController(ProyectoContext context)
        {
            _context = context;
        }

        // GET: api/CorteBarbas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorteBarba>>> GetCorteBarbas()
        {
          if (_context.CorteBarbas == null)
          {
              return NotFound();
          }
            return await _context.CorteBarbas.ToListAsync();
        }

        // GET: api/CorteBarbas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CorteBarba>> GetCorteBarba(int id)
        {
          if (_context.CorteBarbas == null)
          {
              return NotFound();
          }
            var corteBarba = await _context.CorteBarbas.FindAsync(id);

            if (corteBarba == null)
            {
                return NotFound();
            }

            return corteBarba;
        }

        // PUT: api/CorteBarbas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorteBarba(int id, CorteBarba corteBarba)
        {
            if (id != corteBarba.IdCortebarba)
            {
                return BadRequest();
            }

            _context.Entry(corteBarba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorteBarbaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CorteBarbas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CorteBarba>> PostCorteBarba(CorteBarba corteBarba)
        {
          if (_context.CorteBarbas == null)
          {
              return Problem("Entity set 'ProyectoContext.CorteBarbas'  is null.");
          }
            _context.CorteBarbas.Add(corteBarba);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CorteBarbaExists(corteBarba.IdCortebarba))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCorteBarba", new { id = corteBarba.IdCortebarba }, corteBarba);
        }

        // DELETE: api/CorteBarbas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorteBarba(int id)
        {
            if (_context.CorteBarbas == null)
            {
                return NotFound();
            }
            var corteBarba = await _context.CorteBarbas.FindAsync(id);
            if (corteBarba == null)
            {
                return NotFound();
            }

            _context.CorteBarbas.Remove(corteBarba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorteBarbaExists(int id)
        {
            return (_context.CorteBarbas?.Any(e => e.IdCortebarba == id)).GetValueOrDefault();
        }
    }
}
