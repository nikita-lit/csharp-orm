using Microsoft.AspNetCore.Mvc;
using orm.Data;
using orm.Models;

namespace orm.Controllers;

[Route("[controller]")]
[ApiController]
public class CartProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CartProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<CartProduct> GetCartProducts() => _context.CartProducts.ToList();

    [HttpPost]
    public List<CartProduct> PostCartProduct([FromBody] CartProduct cartProduct)
    {
        _context.CartProducts.Add(cartProduct);
        _context.SaveChanges();
        return _context.CartProducts.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<CartProduct> GetCartProduct(int id)
    {
        var cartProduct = _context.CartProducts.Find(id);
        if (cartProduct == null) return NotFound();
        return cartProduct;
    }

    [HttpDelete("{id}")]
    public List<CartProduct> DeleteCartProduct(int id)
    {
        var cartProduct = _context.CartProducts.Find(id);
        if (cartProduct == null) return _context.CartProducts.ToList();
        _context.CartProducts.Remove(cartProduct);
        _context.SaveChanges();
        return _context.CartProducts.ToList();
    }

    [HttpPut("{id}")]
    public ActionResult<List<CartProduct>> PutCartProduct(int id, [FromBody] CartProduct updatedCartProduct)
    {
        var cartProduct = _context.CartProducts.Find(id);
        if (cartProduct == null) return NotFound();
        cartProduct.ProductId = updatedCartProduct.ProductId;
        cartProduct.Quantity = updatedCartProduct.Quantity;
        _context.CartProducts.Update(cartProduct);
        _context.SaveChanges();
        return Ok(_context.CartProducts);
    }
}
