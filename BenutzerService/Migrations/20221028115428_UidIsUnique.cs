using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class UidIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NUTZER_UID",
                table: "NUTZER",
                column: "UID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NUTZER_UID",
                table: "NUTZER");
        }
    }
}
