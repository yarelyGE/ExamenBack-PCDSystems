using System.ComponentModel.DataAnnotations;

namespace examenBack.Controllers.Model
{
    public class Director
    {
        [Key]
        public int id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Nationality { get; set; }

        public int Ager { get; set; }

        public bool Active { get; set; }
    }
}