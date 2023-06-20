using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioMarlin.Data;
using System.Net;
using DesafioMarlin.Domain;

namespace DesafioMarlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly DesafioMarlinContext _context;

        public MatriculaController(DesafioMarlinContext context)
        {
            _context = context;
        }

        // GET: api/Matricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
        {
            if (_context.Matricula == null)
            {
                return NotFound();
            }
            return await _context.Matricula.ToListAsync();
        }

        // GET: api/Matricula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> GetMatricula(int id)
        {
            if (_context.Matricula == null)
            {
                return NotFound();
            }
            var matricula = await _context.Matricula.FindAsync(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // PUT: api/Matricula/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatricula(int id, Matricula matricula)
        {
            if (id != matricula.id)
            {
                return BadRequest();
            }

            _context.Entry(matricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
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

        // POST: api/Matricula
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {
            if (_context.Matricula == null)
            {
                return Problem("Entity set 'DesafioMarlinContext.Matricula'  is null.");
            }
            var alunoEncontrado = await _context.Aluno.FindAsync(matricula.AlunoId);
            var turmaEncontrada = await _context.Turma.FindAsync(matricula.TurmaId);

            var aluno = _context.Aluno.Find(matricula.AlunoId);

            var matriculasEncontradas = from m in _context.Matricula
                                        where m.AlunoId.Equals(aluno.idAluno)
                                        select m;
            var matriculasIguais = from m in matriculasEncontradas where m.TurmaId.Equals(matricula.TurmaId) select m;

            if (matriculasIguais.Count() != 0)
            {
                Response.StatusCode = 400;
                return Content("Aluno Já matriculado na turma");
            }

            if (alunoEncontrado == null || turmaEncontrada == null)
            {
                return NotFound();
            }
            var qtdAlunosTurma = _context.Matricula.Count(t => t.TurmaId == matricula.TurmaId);
            var qtdMaximaAlunosTurma = 5;

            if (qtdAlunosTurma > qtdMaximaAlunosTurma)
            {
                return Content("Total máximo de alunos atigingido");
            }

            _context.Matricula.Add(matricula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatricula", new { matricula.id }, matricula);
        }

        // DELETE: api/Matricula/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            if (_context.Matricula == null)
            {
                return NotFound();
            }
            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatriculaExists(int id)
        {
            return (_context.Matricula?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
