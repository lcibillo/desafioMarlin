using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioMarlin.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DesafioMarlin.Domain;

namespace DesafioMarlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DesafioMarlinContext _context;

        public AlunoController(DesafioMarlinContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            if (_context.Aluno == null)
            {
                return NotFound();
            }
            return await _context.Aluno.ToListAsync();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound();
            }
            var aluno = _context.Aluno.Find(id);

            var matriculasEncontradas = from m in _context.Matricula
                                        where m.AlunoId.Equals(aluno.idAluno)
                                        select m;

            foreach (var item in matriculasEncontradas)
            {
                //var MEncontrada = _context.Matricula.Find(item.id);
                //aluno.Matricula.Add(MEncontrada);
            }

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.idAluno)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
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

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            if (_context.Aluno == null)
            {
                return Problem("Entity set 'DesafioMarlinContext.Aluno'  is null.");
            }

            var alunoEncontrado = from a in _context.Aluno
                                  where a.Cpf.Equals(aluno.Cpf)
                                  select a;

            if (alunoEncontrado.Count() != 0)
            {
                Response.StatusCode = 400;
                return Content("CPF já cadastrado");
            }
            IQueryable<DesafioMarlin.Domain.Turma> turmaEncontrada = Enumerable.Empty<DesafioMarlin.Domain.Turma>().AsQueryable();
            foreach (var item in aluno.Matricula)
            {
                turmaEncontrada = from t in _context.Turma
                                  where t.id.Equals(item.TurmaId)
                                  select t;
            }

            if (turmaEncontrada.Count() == 0)
            {
                Response.StatusCode = 400;
                return Content("Turma Não encontrada");
            }
            var qtdAlunosTurma = 0;
            var qtdMaximaAlunosTurma = 5;
            foreach (var item in aluno.Matricula)
            {
                qtdAlunosTurma = _context.Matricula.Count(t => t.TurmaId == item.TurmaId);
                if (qtdAlunosTurma > qtdMaximaAlunosTurma)
                {
                    return Content("Total máximo de alunos atigingido na turma " + item.TurmaId);
                }
            }

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.idAluno }, aluno);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound();
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.idAluno == id)).GetValueOrDefault();
        }
    }
}
