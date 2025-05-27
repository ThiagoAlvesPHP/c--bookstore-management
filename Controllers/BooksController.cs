using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestao_livraria.Controllers;

public class BooksController : BaseController<Books>
{
    // Simulação de um banco de dados em memória
    private static List<Books> books = new List<Books>();

    /**
     * GET: api/livros
     * Retorna todos os livros cadastrados.
     */
    [HttpGet]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    public override ActionResult GetAll()
    {
        return Ok(books);
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
        var livro = books.Find(l => l.Id == id);
        if (livro == null)
            return NotFound(message);

        return Ok(livro);
    }

    /**
     * POST: api/livros
     * Cria um novo livro.
     */
    [HttpPost]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    public override ActionResult Create(Books newBook)
    {
        newBook = new Books(books.Count + 1, newBook.Title, newBook.Author, newBook.Gender, newBook.Price, newBook.QuantityStock);
        books.Add(newBook);
        return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
    }

    /**
     * PUT: api/livros/{id}
     * Atualiza um livro existente.
     */
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Update([FromRoute] int id, Books book)
    {
        var livro = books.Find(l => l.Id == id);
        if (livro == null)
            return NotFound(message);

        livro.Title = book.Title;
        livro.Author = book.Author;
        livro.Gender = book.Gender;
        livro.Price = book.Price;
        livro.QuantityStock = book.QuantityStock;

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
        var livro = books.Find(l => l.Id == id);
        if (livro == null)
            return NotFound(message);

        books.Remove(livro);
        return NoContent();
    }
}