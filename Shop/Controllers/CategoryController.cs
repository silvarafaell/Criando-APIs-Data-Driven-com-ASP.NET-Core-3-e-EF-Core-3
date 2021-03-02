using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<List<Category>>> Post([FromBody] Category model)
    {
        return Ok(model);
    }

    [HttpPut]
    [Route("{ind:int}")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model)
    {
        if (model.Id == id)
            return Ok(model);

        return NotFound();
    }

    [HttpDelete]
    [Route("{ind:int}")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Delete()
    {
        return Ok();
    }
}