using BenutzerService.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Linq;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BenutzerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NutzerController : ControllerBase
    {
        // GET: <NutzerController>
        [HttpGet]
        public ActionResult<List<Nutzer>> Get()
        {
            using (var db = new DatenbankContext())
            {
                var users = db.NutzerListe
                    .Include(n => n.rollen)
                    .ToList();
                foreach (var user in users)
                {
                    foreach (var rolle in user.rollen)
                    {
                        rolle.nutzer.Clear();
                    };
                }

                return Ok(users);
            }
        }

        // GET <NutzerController>/5
        [HttpGet("{id}")]
        public ActionResult<Nutzer> Get(int id)
        {
            using (var db = new DatenbankContext())
            {
                //var users = db.NutzerListe.Where(n => n.nutzerId == id).Include(n => n.rollen).ToList();
                //.ThenInclude(r => r.nutzer)
                //if (users.Count > 0)
                //{
                var user = db.NutzerListe.Where(n => n.nutzerId == id)
                    .Include(n => n.rollen)
                    .FirstOrDefault();


                if (user != null)
                {
                    foreach (var rolle in user.rollen)
                    {
                        rolle.nutzer.Clear();
                    };
                    return Ok(user);
                }
            }

            return NotFound();
        }

        // POST <NutzerController>
        // Motify 
        // {"nutzerId":1,"uid":"admin","pwd":"geheim","name":null,"vorname":null,"rollen":[{"rolleId":1,"rolleName":"admin","nutzer":[]}],"tokens":[]}
        [HttpPost]
        public ActionResult<Nutzer> Post([FromBody] Nutzer value)
        {
            using (var db = new DatenbankContext())
            {
                // Nutzer aus DB suchen

                var user = db.NutzerListe.Where(n => n.nutzerId == value.nutzerId).Include(n => n.rollen).FirstOrDefault();
                //.ThenInclude(r => r.nutzer)

                if (user != null)
                {
                    // Rollen aus DB lesen
                    List<Rolle> rol = new List<Rolle>();
                    foreach (var item in value.rollen)
                    {
                        var rollen = db.Rollen.Where(r => r.rolleId == item.rolleId).ToList();
                        rol.AddRange(rollen);
                    }
                    value.rollen.Clear();
                    value.rollen.AddRange(rol.OrderBy(r => r.rolleId).ToList());

                    // Daten in DB Objekt übernehmen
                    db.Entry(user).CurrentValues.SetValues(value);

                    // Liste mit zu löschenden Rollen erstellen
                    List<Rolle> removeList = new List<Rolle>();
                    // Schleife über die bestehende Liste
                    foreach (var item in user.rollen)
                    {
                        var ro = value.rollen.Where(r => r.rolleId == item.rolleId).FirstOrDefault();
                        if (ro == null)
                            // Wenn Eintrag gelöscht werden soll auf Liste setzen.
                            removeList.Add(item);
                        else
                            // Wenn Eitrag bereits vorhanden von value Liste löschen
                            value.rollen.Remove(ro);
                    }
                    // Alle zu löschenden Einträge löschen
                    // user.rollen.RemoveRange(removeList); das geht leider nicht
                    foreach (var item in removeList)
                    {
                        user.rollen.Remove(item);
                    }
                    // Alle noch bestehenden neuen Einträge hinzufügen
                    user.rollen.AddRange(value.rollen);
                }
                else
                {
                    // Nutzer neu anlegen
                    value.nutzerId = 0;
                    // Rollen aus DB zuordnen
                    List<Rolle> rol = new List<Rolle>();
                    foreach (var item in value.rollen)
                    {
                        var rollen = db.Rollen.Where(r => r.rolleId == item.rolleId).ToList();
                        rol.AddRange(rollen);
                    }
                    value.rollen.Clear();
                    value.rollen.AddRange(rol);

                    db.NutzerListe.Add(value);
                }
                db.SaveChanges();

                return Ok(value);

            }

            //return NotFound();
        }

        //// PUT <NutzerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE <NutzerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new DatenbankContext())
            {
                // Nutzer aus DB suchen
                var user = db.NutzerListe
                   .Where(n => n.nutzerId == id)
                   .Include(n => n.rollen)
                   .Include(n => n.tokens)
                   .FirstOrDefault();

                if (user != null)
                {
                    db.Tokens.RemoveRange(user.tokens);
                    db.NutzerListe.Remove(user);

                    return Ok(db.SaveChanges());
                }
            }

            return NotFound(0);
        }
    }
}
