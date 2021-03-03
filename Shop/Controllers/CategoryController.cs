using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

//Endpoint => URL
//http://localhost:5000
//https://localhost:5001
//para chegar no controller tem que colocar a Route
[Route("categories")] //chega no controller
public class CategoryController : ControllerBase
{
    //https://localhost:5001/categories
    [HttpGet]
    [Route("")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route("{id:int}")]  //chega no metodo com restrição de rota
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }
    [HttpPost]
    [Route("")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Post(
        [FromBody] Category model,
        [FromServices] DataContext context //Usando o DataContext
    )

    {
        // Verifica se os dados são válidos
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        context.Categories.Add(model); //Adicionando Categoria no Banco virtual
        await context.SaveChangesAsync();
        return Ok(model);
    }

    [HttpPut]
    [Route("{ind:int}")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model)
    {
        // Verifica se o ID informado é o mesmo do modelo
        if (id != model.Id)
            return NotFound(new { message = "Categoria não encontrada" });

        // Verifica se os dados são válidos
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(model);
    }

    [HttpDelete]
    [Route("{ind:int}")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Delete()
    {
        return Ok();
    }
}