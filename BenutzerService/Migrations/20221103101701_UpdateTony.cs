using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class UpdateTony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ADMIN",
                table: "NUTZER",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ADMIN",
                table: "NUTZER");
        }
    }
}
