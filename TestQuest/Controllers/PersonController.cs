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
    
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    private readonly PersonRepository _personRepository;

    public PersonController(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    /// <summary>
    /// Получить список всех пользователей
    /// </summary>
    /// <returns>Массив пользователей</returns>
    [HttpGet]
    [Route("persons")]
    public async Task<Person[]> GetPersonsListAsync()
    {
        return await _personRepository.GetPersonsAsync();
    }
    /// <summary>
    /// Получить пользователей
    /// </summary>
    /// <param name="id">ID пользователя</param>
    /// <returns>Сущность пользователя, иначе NotFound </returns>
    [HttpGet]
    [Route("person/{id}")]
    public async Task<IActionResult> SearchPersonAsync(long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        Person result = await _personRepository.GetPersonAsync(id);
        
        if (result == null)
        {
            return StatusCode(404,"Cущность не найдена в системе.");
        }
        return Ok(result);
    }
    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="request">Сущность пользователя</param>
    /// <returns> Response 200 если получилось создать</returns>
    [HttpPost]
    [Route("person")]
    public async Task<IActionResult> AddPersonAsync(Person request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        request.Id = null;
        _personRepository.CreatePersonAsync(request);
        return Ok();
    }
    /// <summary>
    /// Изменение данных существующего пользователя
    /// </summary>
    /// <param name="id">ID пользователя</param>
    /// <param name="person">Новые данные</param>
    /// <returns>Response 200 если пользователь был изменен, 404 если он не был найден</returns>
    [HttpPut]
    [Route("person/{id}")]
    public async Task<IActionResult> PutPersonAsync(long id,Person request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result =await _personRepository.UpdatePersonAsync(id, request);
        
        if (result == false)
        {
            return StatusCode(404,"Cущность не найдена в системе.");
        }
        
        return Ok();
    }
    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id">ID удаляемого пользователя</param>
    /// <returns>>Code 200  если пользователь был удален, 404 если он не был найден</returns>
    [HttpDelete]
    [Route("person/{id}")]
    public async Task<IActionResult> DeletePersonAsync([Required] long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        bool result = await _personRepository.RemovePersonAsync(id);

        if (result == false)
        {
            return StatusCode(404, "Cущность не найдена в системе.");
        }

        return Ok();
    }

}