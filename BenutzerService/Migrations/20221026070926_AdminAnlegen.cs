using BenutzerService.DB;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class AdminAnlegen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new DatenbankContext())
            {
                db.NutzerListe.Add(new Model.Nutzer() { uid="admin", pwd="geheim"});
                db.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
