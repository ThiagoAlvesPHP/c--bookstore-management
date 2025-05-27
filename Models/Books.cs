namespace gestao_livraria.Models;

public class Books
{
    public int Id { get; private set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Gender { get; set; }
    public decimal Price { get; set; }
    public int QuantityStock { get; set; }

    public Books(string? title, string? author, string? gender, decimal price, int quantitystock)
    {
        Title = title;
        Author = author;
        Gender = gender;
        Price = price;
        QuantityStock = quantitystock;
    }

    internal Books(int id, string? title, string? author, string? gender, decimal price, int quantitystock)
    {
        Id = id;
        Title = title;
        Author = author;
        Gender = gender;
        Price = price;
        QuantityStock = quantitystock;
    }
}