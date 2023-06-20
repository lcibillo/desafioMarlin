using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin
{
    public class Aluno
    {
        [Key]
        public int idAluno { get; set; }
        public long Cpf { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }


    }
}
