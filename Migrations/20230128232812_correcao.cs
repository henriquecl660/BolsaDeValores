using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeValores.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraCorretora_Corretora_CorretoraId",
                table: "CarteiraCorretora");

            migrationBuilder.RenameColumn(
                name: "CorretoraId",
                table: "CarteiraCorretora",
                newName: "CorretorasCorretoraId");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraCorretora_CorretoraId",
                table: "CarteiraCorretora",
                newName: "IX_CarteiraCorretora_CorretorasCorretoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraCorretora_Corretora_CorretorasCorretoraId",
                table: "CarteiraCorretora",
                column: "CorretorasCorretoraId",
                principalTable: "Corretora",
                principalColumn: "CorretoraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarteiraCorretora_Corretora_CorretorasCorretoraId",
                table: "CarteiraCorretora");

            migrationBuilder.RenameColumn(
                name: "CorretorasCorretoraId",
                table: "CarteiraCorretora",
                newName: "CorretoraId");

            migrationBuilder.RenameIndex(
                name: "IX_CarteiraCorretora_CorretorasCorretoraId",
                table: "CarteiraCorretora",
                newName: "IX_CarteiraCorretora_CorretoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarteiraCorretora_Corretora_CorretoraId",
                table: "CarteiraCorretora",
                column: "CorretoraId",
                principalTable: "Corretora",
                principalColumn: "CorretoraId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
