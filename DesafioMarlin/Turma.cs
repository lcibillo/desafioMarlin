using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin
{
    public class Turma
    {
        [Key]
        public int id { get; set; }
        public int ano { get; set; }

    }
}
