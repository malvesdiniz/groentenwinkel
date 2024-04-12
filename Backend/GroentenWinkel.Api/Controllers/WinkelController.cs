using GroentenWinkel.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace GroentenWinkel.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WinkelController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      int i = 1;
      return Ok(new List<Winkel>
      {
        new Winkel
        {
          Id = i++,
          Naam = "De fruitmand",
          Adres = "steenstraat 34",
          Post = 8000,
          Gemeente = "Brugge",
          Tel = "050342218",
          Manager = "Francine Lapoule"
        },
        new Winkel
        {
          Id = i++,
          Naam = "Jos & Anneke",
          Adres = "visserijstraat 1",
          Post = 8400,
          Gemeente = "Oostende",
          Tel = "059463689",
          Manager = "Jos Leman",
        },
        new Winkel
        {
          Id = i++,
          Naam = "Groene vingers",
          Adres = "hoogstraat 10",
          Post = 9000,
          Gemeente = "Gent",
          Tel = "091342218",
        },
        new Winkel
        {
          Id = i++,
          Naam = "De buurtwinkel",
          Adres = "die laene 22",
          Post = 2000,
          Gemeente = "Antwerpen",
          Tel = "0230342218",
          Manager = "Bert Simoens"
        }
      });
    }


  }
}
