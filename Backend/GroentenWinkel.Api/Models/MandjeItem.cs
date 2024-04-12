namespace GroentenWinkel.Api.Models
{
  public class MandjeItem
  {
    public int Id { get; set; }
    public Winkel Winkel { get; set; }
    public Groente Groente { get; set; }
    public double Stuk { get; set; }
    public double Prijs {  get; set; }
    public double TotaalPrijs { get; set; }

  }
}
