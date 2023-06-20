using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin.Domain
{
    public class Turma
    {
        [Key]
        public int id { get; set; }
        public int ano { get; set; }


    }
}
