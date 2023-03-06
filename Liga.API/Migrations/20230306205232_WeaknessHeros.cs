using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liga.API.Migrations
{
    /// <inheritdoc />
    public partial class WeaknessHeros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weaknesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weaknesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weaknesses_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weaknesses_HeroId",
                table: "Weaknesses",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Weaknesses_Weak",
                table: "Weaknesses",
                column: "Weak",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weaknesses");
        }
    }
}
