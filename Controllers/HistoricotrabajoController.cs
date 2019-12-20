using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using grbackend.Models;

namespace grbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricotrabajoController : ControllerBase
    {
        private readonly grdbContext _context;

        public HistoricotrabajoController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Historicotrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historicotrabajo>>> GetHistoricotrabajo()
        {
            return await _context.Historicotrabajo.ToListAsync();
        }

        [HttpGet("bytecnico/{tecnico}")]
        public async Task<ActionResult<IEnumerable<Historicotrabajo>>> GetHistoricotrabajoByTecnico(int tecnico)
        {
            var historicotrabajo = await _context.Historicotrabajo.Where(x => x.Tecnicoid == tecnico).ToListAsync();

            if (historicotrabajo == null)
            {
                return NotFound();
            }

            return historicotrabajo;
        }

        [HttpGet("bycliente/{cliente}")]
        public async Task<ActionResult<IEnumerable<Historicotrabajo>>> GetHistoricotrabajoByCliente(int cliente)
        {
            var historicotrabajo = await _context.Historicotrabajo.Where(x => x.Clienteid == cliente).ToListAsync();

            if (historicotrabajo == null)
            {
                return NotFound();
            }

            return historicotrabajo;
        }
        // GET: api/Historicotrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historicotrabajo>> GetHistoricotrabajo(int id)
        {
            var historicotrabajo = await _context.Historicotrabajo.FindAsync(id);

            if (historicotrabajo == null)
            {
                return NotFound();
            }

            return historicotrabajo;
        }

        // PUT: api/Historicotrabajo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoricotrabajo(int id, Historicotrabajo historicotrabajo)
        {
            if (id != historicotrabajo.Historicoid)
            {
                return BadRequest();
            }

            _context.Entry(historicotrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricotrabajoExists(id))
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

        // POST: api/Historicotrabajo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Historicotrabajo>> PostHistoricotrabajo(Historicotrabajo historicotrabajo)
        {
            _context.Historicotrabajo.Add(historicotrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoricotrabajo", new { id = historicotrabajo.Historicoid }, historicotrabajo);
        }

        // DELETE: api/Historicotrabajo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Historicotrabajo>> DeleteHistoricotrabajo(int id)
        {
            var historicotrabajo = await _context.Historicotrabajo.FindAsync(id);
            if (historicotrabajo == null)
            {
                return NotFound();
            }

            _context.Historicotrabajo.Remove(historicotrabajo);
            await _context.SaveChangesAsync();

            return historicotrabajo;
        }

        private bool HistoricotrabajoExists(int id)
        {
            return _context.Historicotrabajo.Any(e => e.Historicoid == id);
        }
    }
}
