using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    [Route("")]  //chega no metodo
    public string Post()
    {
        return "Post";
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