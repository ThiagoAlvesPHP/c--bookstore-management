using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestao_livraria.Controllers;

public class GendersController : BaseController<Genders>
{
    // Simulação de um banco de dados em memória
    private static List<Genders> list = new List<Genders>([
        new Genders(1, "Ficção"),
        new Genders(2, "Ação"),
        new Genders(3, "Romance"),
        new Genders(4, "Drama")
    ]);

    /**
     * GET: api/usuarios
     * Retorna todos os usuários cadastrados.
     */
    [HttpGet]
    [ProducesResponseType(typeof(Genders), StatusCodes.Status200OK)]
    public override ActionResult GetAll()
    {
        return Ok(list);
    }

    /**
     * GET: api/usuarios/{id}
     * Retorna um usuário específico pelo ID.
     */
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Genders), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override ActionResult GetById([FromRoute] int id)
    {
        var find = list.Find(u => u.Id == id);
        if (find == null)
            return NotFound(message);

        return Ok(find);
    }

    /**
     * POST: api/usuarios
     * Cria um novo usuário.
     */
    [HttpPost]
    [ProducesResponseType(typeof(Genders), StatusCodes.Status200OK)]
    public override ActionResult Create(Genders find)
    {
        find = new Genders(list.Count + 1, find.Title);
        list.Add(find);
        return CreatedAtAction(nameof(GetById), new { id = find.Id }, find);
    }

    /**
     * PUT: api/usuarios/{id}
     * Atualiza um usuário existente.
     */
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Genders), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Update([FromRoute] int id, Genders find)
    {
        var existingFind = list.Find(u => u.Id == id);
        if (existingFind == null)
            return NotFound(message);

        existingFind.Title = find.Title;
        return Ok(existingFind);
    }

    /**
     * DELETE: api/usuarios/{id}
     * Exclui um usuário existente.
     */
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Delete([FromRoute] int id)
    {
        var find = list.Find(u => u.Id == id);
        if (find == null)
            return NotFound(message);

        list.Remove(find);
        return Ok("Usuário excluído com sucesso.");
    }
}