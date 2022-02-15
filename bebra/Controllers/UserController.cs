using bebra.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bebra.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext db;
        public UserController(DataContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            User user = await db.users.FirstOrDefaultAsync();
            if (user == null)
                return NotFound();
            return await db.users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
                return BadRequest();
            db.users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
                return BadRequest();
            if (!db.users.Any(x => x.Id == user.Id))
                return NotFound();
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            db.users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
