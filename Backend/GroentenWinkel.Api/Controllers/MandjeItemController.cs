using GroentenWinkel.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroentenWinkel.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MandjeItemController : ControllerBase
  {
    private static List<MandjeItem> MandjeItems = new List<MandjeItem>();
    private static double Totaal = 0;
    private static string Munt = "EUR";


    [HttpGet("totaal")]
    public IActionResult GetTotaal()
    {
      return base.Ok(Totaal);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(MandjeItems);

    [HttpGet("munt")]
    public IActionResult GetMunt() => Ok(Munt);


    [HttpPost]
    public IActionResult AddItem(MandjeItem mandjeItem)
    {
      double converter = 1;
      if (Munt == "USD") converter = 0.92;
      

      if (ModelState.IsValid)
      {
        mandjeItem.Prijs = Math.Round(mandjeItem.Prijs*converter, 2);
        mandjeItem.TotaalPrijs = Math.Round(mandjeItem.TotaalPrijs * converter, 2);
      
        MandjeItem? item = MandjeItems.Find(m => m.Winkel.Naam == mandjeItem.Winkel.Naam && m.Groente.Naam == mandjeItem.Groente.Naam);
        if (item == null)
        {
          
          MandjeItems.Add(mandjeItem);
          Totaal = Math.Round(Totaal + mandjeItem.TotaalPrijs, 2);
        }
        else
        {
          item.Stuk += mandjeItem.Stuk;
          item.TotaalPrijs += mandjeItem.TotaalPrijs;
          Totaal = Math.Round(Totaal + mandjeItem.TotaalPrijs, 2);
        }
        return Ok(MandjeItems);
      }
      return base.BadRequest(ModelState);
    }

    [HttpPut("changeMunt")]
    public IActionResult ChangeCoin()
    {
      if (Munt == "USD")
      {
        Munt = "EUR";
        foreach(var item in MandjeItems.ToList())
        {
          item.Prijs = Math.Round(item.Prijs * 0.92, 2);
          item.TotaalPrijs = Math.Round(item.TotaalPrijs * 0.92, 2);
          Totaal = Math.Round(Totaal * 0.92, 2);
        }
      } else
      {
        Munt = "USD";
        foreach (var item in MandjeItems.ToList())
        {
          item.Prijs = Math.Round(item.Prijs / 0.92, 2);
          item.TotaalPrijs = Math.Round(item.TotaalPrijs / 0.92, 2);
          Totaal = Math.Round(Totaal / 0.92, 2);
        }
      }
      return base.Ok(MandjeItems);

    }
  }
}
