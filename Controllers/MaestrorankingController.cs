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
    public class MaestrorankingController : ControllerBase
    {
        private readonly grdbContext _context;

        public MaestrorankingController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Maestroranking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maestroranking>>> GetMaestroranking()
        {
            return await _context.Maestroranking.ToListAsync();
        }

        // GET: api/Maestroranking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maestroranking>> GetMaestroranking(int id)
        {
            var maestroranking = await _context.Maestroranking.FindAsync(id);

            if (maestroranking == null)
            {
                return NotFound();
            }

            return maestroranking;
        }

        // PUT: api/Maestroranking/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaestroranking(int id, Maestroranking maestroranking)
        {
            if (id != maestroranking.Rankingid)
            {
                return BadRequest();
            }

            _context.Entry(maestroranking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestrorankingExists(id))
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

        // POST: api/Maestroranking
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Maestroranking>> PostMaestroranking(Maestroranking maestroranking)
        {
            _context.Maestroranking.Add(maestroranking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaestroranking", new { id = maestroranking.Rankingid }, maestroranking);
        }

        // DELETE: api/Maestroranking/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Maestroranking>> DeleteMaestroranking(int id)
        {
            var maestroranking = await _context.Maestroranking.FindAsync(id);
            if (maestroranking == null)
            {
                return NotFound();
            }

            _context.Maestroranking.Remove(maestroranking);
            await _context.SaveChangesAsync();

            return maestroranking;
        }

        private bool MaestrorankingExists(int id)
        {
            return _context.Maestroranking.Any(e => e.Rankingid == id);
        }
    }
}
