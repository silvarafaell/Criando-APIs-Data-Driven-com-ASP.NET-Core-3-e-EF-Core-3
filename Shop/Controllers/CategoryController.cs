using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
    {
        //Busca todas as categorias
        var categories = await context.Categories.AsNoTracking().ToListAsync();
        return categories;
    }

    [HttpGet]
    [Route("{id:int}")]  //chega no metodo com restrição de rota
    public async Task<ActionResult<Category>> GetById(int id, [FromServices] DataContext context)
    {
        var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return category;
    }
    [HttpPost]
    [Route("")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Post([FromBody] Category model, [FromServices] DataContext context) //Usando o DataContext
    {
        try
        {
            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Categories.Add(model); //Adicionando Categoria no Banco virtual
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel criar a categoria" });
        }
    }

    [HttpPut]
    [Route("{ind:int}")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model, [FromServices] DataContext context)
    {
        try
        {
            // Verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Categoria não encontrada" });

            // Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Entry<Category>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Este registro já foi atualizado" });
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possivel atualizar a categoria" });
        }

    }

    [HttpDelete]
    [Route("{ind:int}")]  //chega no metodo
    public async Task<ActionResult<List<Category>>> Delete(int id, [FromServices] DataContext context)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new { message = "Categoria não encontrada" });

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return Ok(category);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possível remover a categoria" });
        }
    }
}