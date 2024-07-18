using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaDeValores.Migrations
{
    public partial class AcionistaCorretora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corretora",
                columns: table => new
                {
                    CorretoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PossuiOutrasCorretoras = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corretora", x => x.CorretoraId);
                });

            migrationBuilder.CreateTable(
                name: "CarteiraCorretora",
                columns: table => new
                {
                    CarteirasCarteiraId = table.Column<int>(type: "int", nullable: false),
                    CorretoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraCorretora", x => new { x.CarteirasCarteiraId, x.CorretoraId });
                    table.ForeignKey(
                        name: "FK_CarteiraCorretora_Carteiras_CarteirasCarteiraId",
                        column: x => x.CarteirasCarteiraId,
                        principalTable: "Carteiras",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarteiraCorretora_Corretora_CorretoraId",
                        column: x => x.CorretoraId,
                        principalTable: "Corretora",
                        principalColumn: "CorretoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteiraCorretora_CorretoraId",
                table: "CarteiraCorretora",
                column: "CorretoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteiraCorretora");

            migrationBuilder.DropTable(
                name: "Corretora");
        }
    }
}
