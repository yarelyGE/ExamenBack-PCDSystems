using System.ComponentModel.DataAnnotations;

namespace examenBack.Controllers.Model
{
    public class Movie
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public DateTime ReleaseYear { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public TimeSpan Duration { get; set; }

        public int FKDirector { get; set; }
    }
}
