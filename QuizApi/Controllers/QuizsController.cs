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
    public class QuizsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Quizs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        {
            if (_context.Quizzes == null)
            {
                return NotFound();
            }
            var quizes = _context.Quizzes.AsQueryable().Include(q=>q.Questions);
            quizes.Include(i => i.Questions);
            return Ok(quizes);
            return await Task.FromResult(quizes.ToList());

        }
        [HttpGet("GetQuizzes{sectionId}")]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzesBySectionId(int sectionId)
        {
            if (_context.Quizzes == null)
            {
                return NotFound();
            }
            var quizes = _context.Quizzes.Where(i=>i.SectionId==sectionId).AsQueryable();
            quizes = quizes.Include(i => i.Questions);
            return Ok(quizes);
            return await Task.FromResult(quizes.ToList());

        }

        // GET: api/Quizs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int id)
        {
          if (_context.Quizzes == null)
          {
              return NotFound();
          }
            var quiz = await _context.Quizzes.FindAsync(id);
                        

            if (quiz == null)
            {
                return NotFound();
            }

            return quiz;
        }

        // PUT: api/Quizs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(int id, Quiz quiz)
        {
            if (id != quiz.id)
            {
                return BadRequest();
            }

            _context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizExists(id))
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

        // POST: api/Quizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostQuiz")]
        public async Task<ActionResult<Quiz>> PostQuiz(QuizDto quizDto)
        {
            if (_context.Quizzes == null)
            {
                return Problem("Entity set 'AppDbContext.Quizzes'  is null.");
            }
            var quiz = new Quiz()
            {
                name = quizDto.name,
                Image = quizDto.Image,
                description = quizDto.description,
                SectionId = quizDto.SectionId
            };
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.id }, quiz);
        }

        // POST: api/Quizs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostListQuiz")]
        public async Task<ActionResult<List<Quiz>>> PostListQuiz(QuizDto[] quizDto)
        {
            if (_context.Quizzes == null)
            {
                return Problem("Entity set 'AppDbContext.Quizzes' is null.");
            }
            foreach(var qz in quizDto)
            {

                var quiz = new Quiz()
                {
                    name = qz.name,
                    Image = qz.Image,
                    description = qz.description,
                    SectionId = qz.SectionId
                };
                _context.Quizzes.Add(quiz);
            }
            await _context.SaveChangesAsync();

            return Ok("Created");
        }


        // DELETE: api/Quizs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            if (_context.Quizzes == null)
            {
                return NotFound();
            }
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizExists(int id)
        {
            return (_context.Quizzes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
