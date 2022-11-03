using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NUTZER",
                columns: table => new
                {
                    NUTZER_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UID = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PWD = table.Column<string>(type: "TEXT", nullable: false),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 70, nullable: true),
                    VORNAME = table.Column<string>(type: "TEXT", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NUTZER", x => x.NUTZER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NUTZER");
        }
    }
}
