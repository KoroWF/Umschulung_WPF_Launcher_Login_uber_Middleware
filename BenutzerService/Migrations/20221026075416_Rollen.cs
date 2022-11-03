using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class Rollen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROLLEN",
                columns: table => new
                {
                    ROLLE_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ROLLE_NAME = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLLEN", x => x.ROLLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "NutzerRolle",
                columns: table => new
                {
                    nutzerId = table.Column<int>(type: "INTEGER", nullable: false),
                    rollenrolleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutzerRolle", x => new { x.nutzerId, x.rollenrolleId });
                    table.ForeignKey(
                        name: "FK_NutzerRolle_NUTZER_nutzerId",
                        column: x => x.nutzerId,
                        principalTable: "NUTZER",
                        principalColumn: "NUTZER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutzerRolle_ROLLEN_rollenrolleId",
                        column: x => x.rollenrolleId,
                        principalTable: "ROLLEN",
                        principalColumn: "ROLLE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NutzerRolle_rollenrolleId",
                table: "NutzerRolle",
                column: "rollenrolleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutzerRolle");

            migrationBuilder.DropTable(
                name: "ROLLEN");
        }
    }
}
