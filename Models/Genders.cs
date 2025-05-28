namespace gestao_livraria.Models;

public class Genders
{
    public int Id { get; private set; }
    public string? Title { get; set; }

    public Genders(string? title)
    {
        Title = title;
    }

    internal Genders(int id, string? title)
    {
        Id = id;
        Title = title;
    }
}