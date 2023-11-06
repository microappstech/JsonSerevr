using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Context;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sections>>> GetSections()
        {
          if (_context.Sections == null)
          {
              return NotFound();
          }
            return await _context.Sections.AsQueryable().Include(i=>i.Quizzes).ToListAsync();
        }

        // GET: api/Sections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sections>> GetSections(int id)
        {
          if (_context.Sections == null)
          {
              return NotFound();
          }
            var sections = await _context.Sections.FindAsync(id);

            if (sections == null)
            {
                return NotFound();
            }

            return sections;
        }

        // PUT: api/Sections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSections(int id, Sections sections)
        {
            if (id != sections.Id)
            {
                return BadRequest();
            }

            _context.Entry(sections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionsExists(id))
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

        // POST: api/Sections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sections>> PostSections(SectionsDto sDto)
        {
          if (_context.Sections == null)
          {
              return Problem("Entity set 'AppDbContext.Sections'  is null.");
          }
            var sections = new Sections()
            {
                Name = sDto.Name,
                Image = sDto.Image,
                CategoryId = sDto.CategoryId
            };
            _context.Sections.Add(sections);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return CreatedAtAction("GetSections", new { id = sections.Id }, sections);
        }

        // DELETE: api/Sections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSections(int id)
        {
            if (_context.Sections == null)
            {
                return NotFound();
            }
            var sections = await _context.Sections.FindAsync(id);
            if (sections == null)
            {
                return NotFound();
            }

            _context.Sections.Remove(sections);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionsExists(int id)
        {
            return (_context.Sections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
        [HttpGet("GetSectionsByCategory")]
        public async Task<IActionResult> GetSectionsByCategory(int idCate)
        {
            var sections = 
                _context.Sections.Where(i => i.CategoryId == idCate);
             sections = sections.Include(s => s.Quizzes);
            return Ok(sections);
        }
    }
}
