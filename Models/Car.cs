namespace AutoShowroom.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public DateTime AssemblyDate { get; set; }
    public DateTime ImportDate { get; set; }
    public string Manufacturer { get; set; }
    public string CountryOfOrigin { get; set; }
}