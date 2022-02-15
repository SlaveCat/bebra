using bebra.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bebra.Controllers
{
    [Route("student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        DataContext db;
        public StudentController(DataContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            Student student = await db.students.FirstOrDefaultAsync();
            if (student == null)
                return NotFound();
            return await db.students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student student = await db.students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
                return NotFound();
            return new ObjectResult(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            if (student == null)
                return BadRequest();
            db.students.Add(student);
            await db.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> Put(Student student)
        {
            if (student == null)
                return BadRequest();
            if (!db.students.Any(x => x.Id == student.Id))
                return NotFound();
            db.Update(student);
            await db.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            Student student = db.students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();
            db.students.Remove(student);
            await db.SaveChangesAsync();
            return Ok(student);
        }
    }
}
