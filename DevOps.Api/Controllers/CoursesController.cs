using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevOps.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context) => _context = context;

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _context.Course;
        }

        // GET: api/Courses/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _context.Course.SingleOrDefaultAsync(c => c.CourseId == id);

            if (result == null)
                return NotFound($"No course found for id: {id}");

           return Ok(result);
        }
        
        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.Department.AddAsync(new Department
            {
                Name = "ECE",
                DepartmentId = 1,
                Budget = 3000000,
                Administrator = 1,
                StartDate = DateTime.Now                
            });

            try
            {
               await _context.Course.AddAsync(course);
                await _context.SaveChangesAsync();
                return StatusCode(201, "Course created successfuly");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
