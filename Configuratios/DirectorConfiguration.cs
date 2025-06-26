using examenBack.Controllers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examenBack.Configuratios
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable(nameof(Director));
            builder.HasData(new List<Director>()
            {
                new()
                {
                    id = 5,
                    Name = "Alfred Hitchcock",
                    Nationality = "British",
                    Ager = 80,
                    Active = false
                },
                new()
                {
                    id = 6,
                    Name = "Frank Darabont",
                    Nationality = "French-American",
                    Ager = 65,
                    Active = true
                }
            });
        }
    }
}