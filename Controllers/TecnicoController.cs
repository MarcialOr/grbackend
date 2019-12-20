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
    public class TecnicoController : ControllerBase
    {
        private readonly grdbContext _context;

        public TecnicoController(grdbContext context)
        {
            _context = context;
        }

        // GET: api/Tecnico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tecnico>>> GetTecnico()
        {
            return await _context.Tecnico.ToListAsync();
        }

        // GET: api/Tecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tecnico>> GetTecnico(int id)
        {
            var tecnico = await _context.Tecnico.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound();
            }

            return tecnico;
        }

        [HttpGet("bycategoria/{categoria}")]
        public async Task<ActionResult<IEnumerable<Tecnico>>> GetTecnicoByCategoria(int categoria)
        {
            var tecnico = await _context.Tecnico.Where(x => x.Categoriaid == categoria).ToListAsync();

            if (tecnico == null)
            {
                return NotFound();
            }

            return tecnico;
        }

        [HttpGet("bycorreo/{correo}/{password}")]
        public async Task<ActionResult<Tecnico>> GetUsuarioByUserName(string correo, string password)
        {
            var tecnico = await _context.Tecnico.SingleOrDefaultAsync(x => x.Correo == correo && x.Clave == password);

            if (tecnico == null)
            {
                return null;
            }

            return tecnico;
        }


        
        [HttpGet("bycorreo/{nombre}")]
        public async Task<ActionResult<Tecnico>> GetUsuarioByUserName(string nombre)
        {
            var tecnico = await _context.Tecnico.SingleOrDefaultAsync(x => x.Nombre == nombre);

            if (tecnico == null)
            {
                return null;
            }

            return tecnico; 
        }
        

        // PUT: api/Tecnico/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnico(int id, Tecnico tecnico)
        {
            if (id != tecnico.Tecnicoid)
            {
                return BadRequest();
            }

            _context.Entry(tecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
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

        // POST: api/Tecnico
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Tecnico>> PostTecnico(Tecnico tecnico)
        {
            var t = await _context.Tecnico.SingleOrDefaultAsync(x => x.Correo == tecnico.Correo); 
            if(t != null){
                return NotFound();
            }else {
                _context.Tecnico.Add(tecnico);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTecnico", new { id = tecnico.Tecnicoid }, tecnico);
            }
            
        }

        // DELETE: api/Tecnico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tecnico>> DeleteTecnico(int id)
        {
            var tecnico = await _context.Tecnico.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            _context.Tecnico.Remove(tecnico);
            await _context.SaveChangesAsync();

            return tecnico;
        }

        private bool TecnicoExists(int id)
        {
            return _context.Tecnico.Any(e => e.Tecnicoid == id);
        }
    }
}
