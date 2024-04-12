namespace GroentenWinkel.Api.Models
{
  public class Winkel
  {
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Adres { get; set; }
    public int Post {  get; set; }
    public string Gemeente { get; set; }
    public string Tel {  get; set; }
    public string? Manager { get; set; }

  }
}
