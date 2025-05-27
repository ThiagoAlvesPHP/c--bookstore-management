namespace gestao_livraria.Models;

public class Users
{
    public int Id { get; private set; }
    public string? Name { get; set; }

    public Users(string? name)
    {
        Name = name;
    }

    internal Users(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}