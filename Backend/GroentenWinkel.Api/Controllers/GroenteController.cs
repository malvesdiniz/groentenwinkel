using GroentenWinkel.Api.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GroentenWinkel.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GroenteController : Controller
  {
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      Dictionary<int, (string, double, string)> groentenData = new Dictionary<int, (string, double, string)>
      {
        { 1, ("aardappelen", 0.95, "kg") },
        { 2, ( "avocado", 2.69, "stuk") },
        {3, ( "avocado", 2.69, "stuk") },
        {4, ( "bloemkool", 1.93, "stuk")},
        {5, ( "brocoli", 1.29, "stuk") },
        {6, ("champignons", 0.89, "250g")},
        {7, ("chinese kool", 1.59, "stuk")},
        {8, ("groene kool", 1.69, "stuk")},
        {9, ("knolselder", 1.29, "stuk")},
        {10,("komkommer", 2.49, "stuk")},
        {11,("kropsla", 1.69, "stuk")},
        {12, ("paprika", 0.89, "net")},
        {13, ("prei", 2.99, "bundel") },
        {14, ("princessenbonen", 1, "250g") },
        {15, ("rapen", 0.99, "bundel")},
        {16, ("rode kool", 1.39, "stuk")},
        {17, ("sla iceberg", 1.49, "stuk")},
        {18, ("spinazie vers", 1.89, "300g")},
        {19, ("sjalot", 0.99, "500g")},
        {20, ("spruiten", 1.86, "kg")},
        {21, ("trostomaat", 2.99, "500g")},
        {22, ("ui", 0.89, "kg")},
        {23, ("witloof 1ste keus", 1.49, "700g")},
        {24, ("wortelen", 2.59, "kg")},
        {25, ("courgetten", 1.5, "stuk")}
      };

    List<Groente> AllGroente = new List<Groente>();

      foreach (var groente in groentenData)
      {
        AllGroente.Add(new Groente
        {
          Id = groente.Key,
          Naam = groente.Value.Item1,
          Prijs = groente.Value.Item2,
          Eenheid = groente.Value.Item3
        });
      }
      return Ok(AllGroente);
    }
  }
  }
