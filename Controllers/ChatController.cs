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
    public class ChatController : ControllerBase
    {
        private readonly grdbContext _context;

        public ChatController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Chat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChat()
        {
            return await _context.Chat.ToListAsync();
        }

        // GET: api/Chat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var chat = await _context.Chat.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        [HttpGet("bytecnico/{tecnico}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatByTecnico(int tecnico)
        {
            var chat = await _context.Chat.Where(x => x.Tecnicoid == tecnico).ToListAsync();

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        [HttpGet("bycliente/{cliente}")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatByCliente(int cliente)
        {
            var chat = await _context.Chat.Where(x => x.Clienteid == cliente).ToListAsync();

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        [HttpGet("{clienteid}/{tecnicoid}")]
        public async Task<ActionResult<Chat>> GetChatByClienteAndTenico(int clienteid, int tecnicoid)
        {
            var chat = await _context.Chat.SingleOrDefaultAsync(x => x.Clienteid == clienteid && x.Tecnicoid == tecnicoid);

            if (chat == null)
            {
                return null;
            }

            return chat;
        }

        // PUT: api/Chat/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(int id, Chat chat)
        {
            if (id != chat.Chatid)
            {
                return BadRequest();
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // POST: api/Chat
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
            _context.Chat.Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.Chatid }, chat);
        }

        // DELETE: api/Chat/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chat>> DeleteChat(int id)
        {
            var chat = await _context.Chat.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chat.Remove(chat);
            await _context.SaveChangesAsync();

            return chat;
        }

        private bool ChatExists(int id)
        {
            return _context.Chat.Any(e => e.Chatid == id);
        }
    }
}
