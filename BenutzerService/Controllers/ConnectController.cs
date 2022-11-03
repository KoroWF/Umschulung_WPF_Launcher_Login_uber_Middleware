using BenutzerService.DB;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net.Http;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BenutzerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConnectController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">{"uid":"admin" ,"pwd":"geheim"}</param>
        /// <returns></returns>
        // POST api/<ConnectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] LoginDaten value)
        {
            using (var db = new DatenbankContext())
            {
                // user lesen
                var user = db.NutzerListe.Where(n => n.uid == value.uid & n.pwd == value.pwd).FirstOrDefault();

                if (user != null)
                {
                    JWT jwt = new JWT()
                    {
                        tooken = Guid.NewGuid().ToString(),
                        userName = user.fullName,
                        admin = user.admin,
                        userAname = user.vorname,
                        userNname = user.name,
                        IDname = user.uid
                    };

                    // Token in Datenbank schreiben
                    var time = DateTime.Now;
                    user.tokens.Add(new Token() { nutzer = user, token = jwt.tooken, erstellt = time, used = time });
                    db.SaveChanges();

                    string jsJwt = JsonSerializer.Serialize(jwt);
                    HttpContext.Response.Headers.Add("Authorization", jsJwt);
                    return Ok(true);
                }
            }

            return NotFound(false);
        }

    }
}
