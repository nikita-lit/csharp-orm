using Microsoft.AspNetCore.Mvc;
using orm.Data;
using orm.Models;

namespace orm.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Category> GetCategories() => _context.Categories.ToList();

    [HttpPost]
    public List<Category> PostCategory([FromBody] Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return _context.Categories.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Category> GetCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null) return NotFound();
        return category;
    }

    [HttpDelete("{id}")]
    public List<Category> DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null) return _context.Categories.ToList();
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return _context.Categories.ToList();
    }

    [HttpPut("{id}")]
    public ActionResult<List<Category>> PutCategory(int id, [FromBody] Category updatedCategory)
    {
        var category = _context.Categories.Find(id);
        if (category == null) return NotFound();
        category.Name = updatedCategory.Name;
        _context.Categories.Update(category);
        _context.SaveChanges();
        return Ok(_context.Categories);
    }
}
