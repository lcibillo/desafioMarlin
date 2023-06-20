using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin.Domain
{
    public class Matricula
    {
        [Key]
        public int id { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }



    }
}
