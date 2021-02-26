using Microsoft.AspNetCore.Mvc;

//Endpoint => URL
//http://localhost:5000
//https://localhost:5001
//para chegar no controller tem que colocar a Route
[Route("categories")] //chega no controller
public class CategoryController : ControllerBase
{
    //https://localhost:5001/categories
    [Route("")]  //chega no metodo
    public string MeuMetodo()
    {
        return "Ola mundo!";
    }
}