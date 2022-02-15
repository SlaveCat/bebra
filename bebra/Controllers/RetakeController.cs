using bebra.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bebra.Controllers
{
    [Route("retake")]
    [ApiController]
    public class RetakeController: ControllerBase
    {
        DataContext db;
        public RetakeController(DataContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Retake>>> Get()
        {
            Retake retake = await db.retakes.FirstOrDefaultAsync();
            if (retake == null)
                return NotFound();
            return await db.retakes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Retake>> Get(int id)
        {
            Retake retake = await db.retakes.FirstOrDefaultAsync(x => x.id == id);
            if (retake == null)
                return NotFound();
            return new ObjectResult(retake);
        }

        [HttpPost]
        public async Task<ActionResult<Retake>> Post(Retake retake)
        {
            if (retake == null)
                return BadRequest();
            db.retakes.Add(retake);
            await db.SaveChangesAsync();
            return Ok(retake);
        }

        [HttpPut]
        public async Task<ActionResult<Retake>> Put(Retake retake)
        {
            if (retake == null)
                return BadRequest();
            if (!db.retakes.Any(x => x.id == retake.id))
                return NotFound();
            db.Update(retake);
            await db.SaveChangesAsync();
            return Ok(retake);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Retake>> Delete(int id)
        {
            Retake retake = db.retakes.FirstOrDefault(x => x.id == id);
            if (retake == null)
                return NotFound();
            db.retakes.Remove(retake);
            await db.SaveChangesAsync();
            return Ok(retake);
        }
    }
}
