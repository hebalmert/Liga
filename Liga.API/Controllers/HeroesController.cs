using Liga.API.Data;
using Liga.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Liga.API.Controllers
{
    [Route("api/heroes")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var dato = await _context.Heroes
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (dato == null)
            {
                return NotFound();
            }
            return Ok(dato);
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetAsync()
        {
            List<Hero> datos = await _context.Heroes.ToListAsync();

            return Ok(datos);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Hero hero)
        {
            try
            {
                _context.Add(hero);
                await _context.SaveChangesAsync();
                return Ok(hero);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Registro con el Mismo Valor");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Hero hero)
        {
            try
            {
                _context.Update(hero);
                await _context.SaveChangesAsync();
                return Ok(hero);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Registro con el Mismo Valor");
                }
                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var dato = await _context.Heroes.FindAsync(id);
            if (dato == null)
            {
                return NotFound();
            }
            _context.Remove(dato);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
