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
        { 1, ("Aardappelen", 0.95, "kg") },
        { 2, ( "Avocado", 2.69, "stuk") },
        {3, ( "Bloemkool", 1.93, "stuk")},
        {4, ( "Brocoli", 1.29, "stuk") },
        {5, ("Champignons", 0.89, "250g")},
        {6, ("Chinese kool", 1.59, "stuk")},
        {7, ("Groene kool", 1.69, "stuk")},
        {8, ("Knolselder", 1.29, "stuk")},
        {9,("Komkommer", 2.49, "stuk")},
        {10,("Kropsla", 1.69, "stuk")},
        {11, ("Paprika", 0.89, "net")},
        {12, ("Prei", 2.99, "bundel") },
        {13, ("Princessenbonen", 1, "250g") },
        {14, ("Rapen", 0.99, "bundel")},
        {15, ("Rode kool", 1.39, "stuk")},
        {16, ("Sla iceberg", 1.49, "stuk")},
        {17, ("Spinazie vers", 1.89, "300g")},
        {18, ("Sjalot", 0.99, "500g")},
        {19, ("Spruiten", 1.86, "kg")},
        {20, ("Trostomaat", 2.99, "500g")},
        {21, ("Ui", 0.89, "kg")},
        {22, ("Witloof 1ste keus", 1.49, "700g")},
        {23, ("Wortelen", 2.59, "kg")},
        {24, ("Courgetten", 1.5, "stuk")}
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
