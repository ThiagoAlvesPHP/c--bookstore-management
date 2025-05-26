using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestao_livraria.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private string message = "Livro não encontrado";

    // Simulação de um banco de dados em memória
    private static List<Books> books = new List<Books>();

    [HttpGet]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Books>> GetAll()
    {
        return Ok(books);
    }

    // GET: api/livros/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public ActionResult<Books> GetById([FromRoute] int id)
    {
        var livro = books.Find(l => l.Id == id);
        if (livro == null)
            return NotFound(message);

        return Ok(livro);
    }

    // POST: api/livros
    [HttpPost]
    public ActionResult<Books> Create(Books newBook)
    {
        newBook = new Books(books.Count + 1, newBook.Titulo, newBook.Autor, newBook.Genero, newBook.Preco, newBook.QuantidadeEstoque);
        books.Add(newBook);
        return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
    }

    // PUT: api/livros/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] int id, Books book)
    {
        var livro = books.Find(l => l.Id == id);
        if (livro == null)
            return NotFound(message);

        livro.Titulo = book.Titulo;
        livro.Autor = book.Autor;
        livro.Genero = book.Genero;
        livro.Preco = book.Preco;
        livro.QuantidadeEstoque = book.QuantidadeEstoque;

        return NoContent();
    }

    // DELETE: api/livros/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Books), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        var livro = books.Find(l => l.Id == id);
        if (livro == null)
            return NotFound(message);

        books.Remove(livro);
        return NoContent();
    }
}