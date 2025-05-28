using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestao_livraria.Controllers;

public class BooksController : BaseController<Books>
{
    // Simulação de um banco de dados em memória
    private static List<Books> list = new List<Books>([
        new Books(1, "O Senhor dos Anéis", "J.R.R. Tolkien", "Fantasia", 49.90, 10),
        new Books(2, "Harry Potter e a Pedra Filosofal", "J.K. Rowling", "Fantasia", 59.90, 5),
        new Books(3, "O Hobbit", "J.R.R. Tolkien", "Fantasia", 19.90, 10)
    ]);

    /**
     * GET: api/livros
     * Retorna todos os livros cadastrados.
     */
    [HttpGet]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    public override ActionResult GetAll()
    {
        return Ok(list);
    }

    /**
     * GET: api/livros/{id}
     * Retorna um livro específico pelo ID.
    */
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override ActionResult GetById([FromRoute] int id)
    {
        var find = list.Find(l => l.Id == id);
        if (find == null)
            return NotFound(message);

        return Ok(find);
    }

    /**
     * POST: api/livros
     * Cria um novo livro.
     */
    [HttpPost]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    public override ActionResult Create(Books find)
    {
        find = new Books(list.Count + 1, find.Title, find.Author, find.Gender, find.Price, find.QuantityStock);
        list.Add(find);
        return CreatedAtAction(nameof(GetById), new { id = find.Id }, find);
    }

    /**
     * PUT: api/livros/{id}
     * Atualiza um livro existente.
     */
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Update([FromRoute] int id, Books find)
    {
        var existingFind = list.Find(l => l.Id == id);
        if (existingFind == null)
            return NotFound(message);

        existingFind.Title = find.Title;
        existingFind.Author = find.Author;
        existingFind.Gender = find.Gender;
        existingFind.Price = find.Price;
        existingFind.QuantityStock = find.QuantityStock;

        return NoContent();
    }

    /**
     * DELETE: api/livros/{id}
     * Exclui um livro pelo ID.
     */
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Delete([FromRoute] int id)
    {
        var find = list.Find(l => l.Id == id);
        if (find == null)
            return NotFound(message);

        list.Remove(find);
        return NoContent();
    }
}