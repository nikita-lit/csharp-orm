using Microsoft.AspNetCore.Mvc;
using orm.Data;
using orm.Models;

namespace orm.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Product> GetProducts() => _context.Products.ToList();

    [HttpPost]
    public List<Product> PostProduct([FromBody] Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return _context.Products.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();
        return product;
    }

    [HttpDelete("{id}")]
    public List<Product> DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return _context.Products.ToList();
        _context.Products.Remove(product);
        _context.SaveChanges();
        return _context.Products.ToList();
    }

    [HttpPut("{id}")]
    public ActionResult<List<Product>> PutProduct(int id, [FromBody] Product updatedProduct)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();
        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        product.Image = updatedProduct.Image;
        product.Active = updatedProduct.Active;
        product.Stock = updatedProduct.Stock;
        product.CategoryId = updatedProduct.CategoryId;
        _context.Products.Update(product);
        _context.SaveChanges();
        return Ok(_context.Products);
    }
}
