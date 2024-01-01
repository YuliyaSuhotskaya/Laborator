using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laborator.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JewelryGroups",
                columns: table => new
                {
                    JewelryGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryGroups", x => x.JewelryGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Jewelries",
                columns: table => new
                {
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JewelryGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewelries", x => x.JewelryId);
                    table.ForeignKey(
                        name: "FK_Jewelries_JewelryGroups_JewelryGroupId",
                        column: x => x.JewelryGroupId,
                        principalTable: "JewelryGroups",
                        principalColumn: "JewelryGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jewelries_JewelryGroupId",
                table: "Jewelries",
                column: "JewelryGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jewelries");

            migrationBuilder.DropTable(
                name: "JewelryGroups");
        }
    }
}
