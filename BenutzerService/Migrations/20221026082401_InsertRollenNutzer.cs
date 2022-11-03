using BenutzerService.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class InsertRollenNutzer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new DatenbankContext())
            {
                var user = db.NutzerListe.Where(n => n.nutzerId == 1).Include(n => n.rollen).First();
                var rolleAdmin = db.Rollen.Where(n => n.rolleId == 1).Include(n => n.nutzer).First();
                if (user != null & rolleAdmin != null)
                {
                    user.rollen.Add(rolleAdmin);
                    rolleAdmin.nutzer.Add(user);
                }
                db.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
