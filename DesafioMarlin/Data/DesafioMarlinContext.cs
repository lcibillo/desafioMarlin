using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioMarlin.Domain;

namespace DesafioMarlin.Data
{
    public class DesafioMarlinContext : DbContext
    {
        public DesafioMarlinContext (DbContextOptions<DesafioMarlinContext> options)
            : base(options)
        {
        }
        public DbSet<Aluno> Aluno { get; set; } = default!;

        public DbSet<Turma>? Turma { get; set; }

        public DbSet<Matricula>? Matricula { get; set; }
    }
}
