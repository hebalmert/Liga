using Liga.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liga.API.EntitiesConfig
{
    public class HeroConfig : IEntityTypeConfiguration<Hero>
    {
        public void Configure(EntityTypeBuilder<Hero> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex("Name").IsUnique();
            builder.HasIndex("Power").IsUnique();
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Power).HasMaxLength(100);
            builder.Property(e => e.Url).HasMaxLength(300);
        }
    }
}
