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
    private static string Munt = "EUR";


    [HttpGet("totaal")]
    public IActionResult GetTotaal()
    {
      double totaal = MandjeItems.Sum(i => i.TotaalPrijs);
      return base.Ok(totaal);
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
          mandjeItem.Id = MandjeItems.Count + 1;
          MandjeItems.Add(mandjeItem);
          
        }
        else
        {
          item.Stuk += mandjeItem.Stuk;
          item.TotaalPrijs += mandjeItem.TotaalPrijs;
        }
        return Ok(MandjeItems);
      }
      return base.BadRequest(ModelState);
    }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
    {
        var item = MandjeItems.Find(i=> i.Id == id);
        if (item != null)
        {
            MandjeItems.Remove(item);
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
        }
      } else
      {
        Munt = "USD";
        foreach (var item in MandjeItems.ToList())
        {
          item.Prijs = Math.Round(item.Prijs / 0.92, 2);
          item.TotaalPrijs = Math.Round(item.TotaalPrijs / 0.92, 2);
        }
      }
      return base.Ok(MandjeItems);

    }
  }
}
