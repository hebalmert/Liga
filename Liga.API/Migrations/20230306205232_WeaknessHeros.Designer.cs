// <auto-generated />
using Liga.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Liga.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230306205232_WeaknessHeros")]
    partial class WeaknessHeros
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Liga.Shared.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Power")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Power")
                        .IsUnique();

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Liga.Shared.Entities.Weakness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("Weak")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.HasIndex("Weak")
                        .IsUnique();

                    b.ToTable("Weaknesses");
                });

            modelBuilder.Entity("Liga.Shared.Entities.Weakness", b =>
                {
                    b.HasOne("Liga.Shared.Entities.Hero", "Hero")
                        .WithMany("Weaknesses")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("Liga.Shared.Entities.Hero", b =>
                {
                    b.Navigation("Weaknesses");
                });
#pragma warning restore 612, 618
        }
    }
}
