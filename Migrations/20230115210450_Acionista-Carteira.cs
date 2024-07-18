using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeValores.Migrations
{
    public partial class AcionistaCarteira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acao",
                columns: table => new
                {
                    AcaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cotacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarteiraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acao", x => x.AcaoId);
                    table.ForeignKey(
                        name: "FK_Acao_Carteiras_CarteiraId",
                        column: x => x.CarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acao_CarteiraId",
                table: "Acao",
                column: "CarteiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acao");
        }
    }
}
