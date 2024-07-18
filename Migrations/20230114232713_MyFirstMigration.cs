using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeValores.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acionistas",
                columns: table => new
                {
                    AcionistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Renda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Patrimonio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acionistas", x => x.AcionistaId);
                });

            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    CarteiraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcionistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.CarteiraId);
                    table.ForeignKey(
                        name: "FK_Carteiras_Acionistas_AcionistaId",
                        column: x => x.AcionistaId,
                        principalTable: "Acionistas",
                        principalColumn: "AcionistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_AcionistaId",
                table: "Carteiras",
                column: "AcionistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carteiras");

            migrationBuilder.DropTable(
                name: "Acionistas");
        }
    }
}
