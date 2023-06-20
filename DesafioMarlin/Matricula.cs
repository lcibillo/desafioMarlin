using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin
{
    public class Matricula
    {
        [Key] 
        public int Id { get; set; }
        public Aluno aluno { get;}
        public Turma turma { get;}


    }
}
