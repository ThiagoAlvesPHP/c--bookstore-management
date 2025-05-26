namespace gestao_livraria.Models;

public class Books
{
    public int Id { get; private set; }
    public string? Titulo { get; set; }
    public string? Autor { get; set; }
    public string? Genero { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }

    public Books(string? titulo, string? autor, string? genero, decimal preco, int quantidadeEstoque)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
    }

    internal Books(int id, string? titulo, string? autor, string? genero, decimal preco, int quantidadeEstoque)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
    }
}