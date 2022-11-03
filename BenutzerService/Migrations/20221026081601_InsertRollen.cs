using BenutzerService.DB;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenutzerService.Migrations
{
    public partial class InsertRollen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new DatenbankContext())
            {
                //var user = db.NutzerListe.Find(1);
                var rolleAdmin = new Model.Rolle() { rolleName = "admin" };
                //if (user != null)
                //{
                //    user.rollen.Add(rolleAdmin);
                //    rolleAdmin.nutzer.Add(user);
                //}
                db.Rollen.Add(rolleAdmin);
                db.Rollen.Add(new Model.Rolle() { rolleName = "gast" });
                db.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
