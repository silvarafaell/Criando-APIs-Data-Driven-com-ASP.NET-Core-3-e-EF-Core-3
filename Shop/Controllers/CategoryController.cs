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
    public string Get()
    {
        return "Get";
    }

    [HttpGet]
    [Route("{id:int}")]  //chega no metodo com restrição de rota
    public string GetById(int id)
    {
        return "Get" + id.ToString();
    }
    [HttpPost]
    [Route("")]  //chega no metodo
    public Category Post([FromBody] Category model)
    {
        return model;
    }

    [HttpPut]
    [Route("")]  //chega no metodo
    public string Put()
    {
        return "Put";
    }

    [HttpDelete]
    [Route("")]  //chega no metodo
    public string Delete()
    {
        return "Delete";
    }
}