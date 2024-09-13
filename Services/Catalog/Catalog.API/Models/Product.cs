namespace Catalog.API.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> Category { get; set; }
    public string Discription { get; set; }
    public decimal Price { get; set; }
    public string ImageFile { get; set; }
}