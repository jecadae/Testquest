using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestQuest.Entity;

namespace TestQuest.Controllers;
[ApiController]
[Route("api/v1/")]
public class PersonController: ControllerBase
{
    private readonly AppDbContext _context;

    public PersonController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [Route("persons")]
    public Person[] GetPersons()
    {
        return _context.Persons.Include(x =>x.Skills).ToArray();
    }
    
    [HttpGet]
    [Route("person/{id}")]
    public async Task<IActionResult> SearchPerson(long id)
    {
        var result = _context.Persons.Include(x=> x.Skills).SingleOrDefaultAsync(x=> x.Id == id);
        if (result == null)
        {
            return StatusCode(404,"Cущность не найдена в системе.");
        }
        return Ok(result.Result);
    }
    
    [HttpPost]
    [Route("person")]
    public async Task<IActionResult> AddPerson(Person request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        request.Id = null;
        var result = _context.Persons.Add(request);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut]
    [Route("person/{id}")]
    public async Task<IActionResult> PutPerson([Required]long id,[Required]Person request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = _context.Persons.Include(x=> x.Skills).SingleOrDefaultAsync(x=> x.Id == id);
        
        if (result == null)
        {
            return StatusCode(404,"Cущность не найдена в системе.");
        }

        result.Result.Skills = request.Skills;
        result.Result.Name = request.Name;
        result.Result.DisplayName = request.DisplayName;
        _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("person/{id}")]
    public async Task<IActionResult> RemovePerson([Required] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = _context.Persons.Include(x=> x.Skills).SingleOrDefaultAsync(x=> x.Id == id);;
        Console.WriteLine($"{result.Result.DisplayName}");
        
        if (result == null)
        {
            return StatusCode(404, "Cущность не найдена в системе.");
        }

        _context.Remove(result.Result);
        _context.SaveChangesAsync();
        return Ok();
    }

}