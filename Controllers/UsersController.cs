using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;
namespace gestao_livraria.Controllers;

public class UsersController : BaseController<Users>
{
    // Simulação de um banco de dados em memória
    private static List<Users> list = new List<Users>([
        new Users(1, "João Silva"),
        new Users(2, "Maria Oliveira"),
        new Users(3, "Carlos Pereira")
    ]);

    /**
     * GET: api/usuarios
     * Retorna todos os usuários cadastrados.
     */
    [HttpGet]
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
    public override ActionResult GetAll()
    {
        return Ok(list);
    }

    /**
     * GET: api/usuarios/{id}
     * Retorna um usuário específico pelo ID.
     */
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
    public override ActionResult Create(Users find)
    {
        find = new Users(list.Count + 1, find.Name);
        list.Add(find);
        return CreatedAtAction(nameof(GetById), new { id = find.Id }, find);
    }

    /**
     * PUT: api/usuarios/{id}
     * Atualiza um usuário existente.
     */
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Update([FromRoute] int id, Users find)
    {
        var existingFind = list.Find(u => u.Id == id);
        if (existingFind == null)
            return NotFound(message);

        existingFind.Name = find.Name;
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