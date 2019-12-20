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
    public class ChatDetalleController : ControllerBase
    {
        private readonly grdbContext _context;

        public ChatDetalleController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/ChatDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chatdetalle>>> GetChatdetalle()
        {
            return await _context.Chatdetalle.ToListAsync();
        }

        [HttpGet("bychatid/{chatid}")]
        public async Task<ActionResult<IEnumerable<Chatdetalle>>> GetChatdetalleByChatId( int chatid)
        {
            var chatdetalle = await _context.Chatdetalle.Where(x => x.Chatid == chatid).ToListAsync();

            if (chatdetalle == null)
            {
                return null;
            }

            return chatdetalle;
        }

        // GET: api/ChatDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chatdetalle>> GetChatdetalle(int id)
        {
            var chatdetalle = await _context.Chatdetalle.FindAsync(id);

            if (chatdetalle == null)
            {
                return NotFound();
            }

            return chatdetalle;
        }

        // PUT: api/ChatDetalle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatdetalle(int id, Chatdetalle chatdetalle)
        {
            if (id != chatdetalle.Chatdetalleid)
            {
                return BadRequest();
            }

            _context.Entry(chatdetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatdetalleExists(id))
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

        // POST: api/ChatDetalle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Chatdetalle>> PostChatdetalle(Chatdetalle chatdetalle)
        {
            _context.Chatdetalle.Add(chatdetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatdetalle", new { id = chatdetalle.Chatdetalleid }, chatdetalle);
        }

        // DELETE: api/ChatDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chatdetalle>> DeleteChatdetalle(int id)
        {
            var chatdetalle = await _context.Chatdetalle.FindAsync(id);
            if (chatdetalle == null)
            {
                return NotFound();
            }

            _context.Chatdetalle.Remove(chatdetalle);
            await _context.SaveChangesAsync();

            return chatdetalle;
        }

        private bool ChatdetalleExists(int id)
        {
            return _context.Chatdetalle.Any(e => e.Chatdetalleid == id);
        }
    }
}
