using gestao_livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestao_livraria.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseController<Model> : ControllerBase where Model : class
{
    public string message = "Recurso não encontrado";

    public abstract ActionResult GetAll();

    public abstract ActionResult GetById([FromRoute] int id);

    public abstract ActionResult Create([FromBody] Model newEntity);

    public abstract IActionResult Update([FromRoute] int id, [FromBody] Model entity);

    public abstract IActionResult Delete([FromRoute] int id);
}
