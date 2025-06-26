using examenBack.Controllers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examenBack.Configuratios
{
    public class MoviesConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));

            builder.HasData(new List<Movie>()
                {
                    new() {
                        id = 1,
                        Name = "The Shawshank Redemption",
                        ReleaseYear = new DateTime(1994, 9, 23),
                        Gender = "Terror",
                        Duration = TimeSpan.FromMinutes(120),
                        FKDirector = 2}
                });
        }
    }
}
