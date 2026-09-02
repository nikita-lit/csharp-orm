using Microsoft.AspNetCore.Mvc;
using orm.Data;
using orm.Models;

namespace orm.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Person> GetPersons()
    {
        return _context.Persons.ToList();
    }

    [HttpPost]
    public List<Person> PostPerson([FromBody] Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return _context.Persons.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Person> GetPerson(int id)
    {
        var person = _context.Persons.Find(id);
        if (person == null) return NotFound();
        return person;
    }

    [HttpDelete("{id}")]
    public List<Person> DeletePerson(int id)
    {
        var person = _context.Persons.Find(id);
        if (person == null) return _context.Persons.ToList();
        _context.Persons.Remove(person);
        _context.SaveChanges();
        return _context.Persons.ToList();
    }

    [HttpPut("{id}")]
    public ActionResult<List<Person>> PutPerson(int id, [FromBody] Person updatedPerson)
    {
        var person = _context.Persons.Find(id);
        if (person == null) return NotFound();
        person.PersonCode = updatedPerson.PersonCode;
        person.FirstName = updatedPerson.FirstName;
        person.LastName = updatedPerson.LastName;
        person.Phone = updatedPerson.Phone;
        person.Address = updatedPerson.Address;
        person.Password = updatedPerson.Password;
        person.Admin = updatedPerson.Admin;
        _context.Persons.Update(person);
        _context.SaveChanges();
        return Ok(_context.Persons);
    }
}
