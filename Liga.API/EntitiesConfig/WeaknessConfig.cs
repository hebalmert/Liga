using Liga.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Liga.API.EntitiesConfig
{
    public class WeaknessConfig : IEntityTypeConfiguration<Weakness>
    {
        public void Configure(EntityTypeBuilder<Weakness> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex("Weak").IsUnique();
            builder.Property(e => e.Weak).HasMaxLength(100);
            //Evitar el borrado en cascada
            builder.HasOne(e => e.Hero).WithMany(c => c.Weaknesses).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
