using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin.Domain
{
    public class Aluno
    {
        [Key]
        public int idAluno { get; set; }

        //[Index(IsUnique = true)]
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Matricula> Matricula { get; set; }

    }
}
