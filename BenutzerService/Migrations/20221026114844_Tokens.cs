using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class Tokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TOKENS",
                columns: table => new
                {
                    TOKEN = table.Column<string>(type: "TEXT", nullable: false),
                    ERSTELLT = table.Column<DateTime>(type: "TEXT", nullable: false),
                    USED = table.Column<DateTime>(type: "TEXT", nullable: false),
                    nutzerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOKENS", x => x.TOKEN);
                    table.ForeignKey(
                        name: "FK_TOKENS_NUTZER_nutzerId",
                        column: x => x.nutzerId,
                        principalTable: "NUTZER",
                        principalColumn: "NUTZER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TOKENS_nutzerId",
                table: "TOKENS",
                column: "nutzerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TOKENS");
        }
    }
}
