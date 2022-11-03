using BenutzerService.DB;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BenutzerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {

        // POST api/<ConnectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] JWT value)
        {
            using (var db = new DatenbankContext())
            {
                // user lesen
                var user = db.Tokens.Where(t => t.token == value.tooken & t.used >= DateTime.Now.AddMinutes(-2)).FirstOrDefault();

                if (user != null)
                {
                    return Ok(true);
                }
            }

            return NotFound(false);

        }

    }
}
