using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            return await _context.Questions.ToListAsync();
        }
        [HttpGet("GetQuestionsByQuizid")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionByQuizId(int QuizId)
        {
            if (_context.Questions == null)
                return NotFound();
            var questions = _context.Questions.AsNoTracking().AsQueryable().Where(q=>q.quizid == QuizId);
            questions = questions.Include(i => i.Responses);
            return Ok(questions);
        }
        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("New")]
        public async Task<ActionResult<Question>> PostQuestion(QuestionDto qDto)
        {
          if (_context.Questions == null)
          {
              return Problem("Entity set 'AppDbContext.Questions'  is null.");
          }
            var question = new Question()
            {
                description = qDto.description,
                quizid = qDto.quizid
            };
            var result = _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            foreach (var dtoRes in qDto.Responses)
            {
                var res = new Response()
                {
                    description = dtoRes.description,
                    isok = dtoRes.isok,
                    questionId = question.id
                };
                _context.Responses.Add(res);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.id }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
