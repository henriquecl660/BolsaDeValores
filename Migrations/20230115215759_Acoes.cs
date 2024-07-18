using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeValores.Migrations
{
    public partial class Acoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acao_Carteiras_CarteiraId",
                table: "Acao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acao",
                table: "Acao");

            migrationBuilder.RenameTable(
                name: "Acao",
                newName: "Acoes");

            migrationBuilder.RenameIndex(
                name: "IX_Acao_CarteiraId",
                table: "Acoes",
                newName: "IX_Acoes_CarteiraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acoes",
                table: "Acoes",
                column: "AcaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_Carteiras_CarteiraId",
                table: "Acoes",
                column: "CarteiraId",
                principalTable: "Carteiras",
                principalColumn: "CarteiraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_Carteiras_CarteiraId",
                table: "Acoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acoes",
                table: "Acoes");

            migrationBuilder.RenameTable(
                name: "Acoes",
                newName: "Acao");

            migrationBuilder.RenameIndex(
                name: "IX_Acoes_CarteiraId",
                table: "Acao",
                newName: "IX_Acao_CarteiraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acao",
                table: "Acao",
                column: "AcaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acao_Carteiras_CarteiraId",
                table: "Acao",
                column: "CarteiraId",
                principalTable: "Carteiras",
                principalColumn: "CarteiraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
