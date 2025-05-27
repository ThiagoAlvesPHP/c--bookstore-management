using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;
namespace gestao_livraria.Controllers;

public class UsersController : BaseController<Users>
{
    // Simulação de um banco de dados em memória
    private static List<Users> users = new List<Users>();

    /**
     * GET: api/usuarios
     * Retorna todos os usuários cadastrados.
     */
    [HttpGet]
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
    public override ActionResult GetAll()
    {
        return Ok(users);
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
        var user = users.Find(u => u.Id == id);
        if (user == null)
            return NotFound(message);

        return Ok(user);
    }

    /**
     * POST: api/usuarios
     * Cria um novo usuário.
     */
    [HttpPost]
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
    public override ActionResult Create(Users newUser)
    {
        newUser = new Users(users.Count + 1, newUser.Name);
        users.Add(newUser);
        return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
    }

    /**
     * PUT: api/usuarios/{id}
     * Atualiza um usuário existente.
     */
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Users), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public override IActionResult Update([FromRoute] int id, Users user)
    {
        var existingUser = users.Find(u => u.Id == id);
        if (existingUser == null)
            return NotFound(message);

        existingUser.Name = user.Name;
        return Ok(existingUser);
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
        var user = users.Find(u => u.Id == id);
        if (user == null)
            return NotFound(message);

        users.Remove(user);
        return Ok("Usuário excluído com sucesso.");
    }
}