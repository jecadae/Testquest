using Microsoft.EntityFrameworkCore;
using TestQuest.Entity;

namespace TestQuest;


/// <summary>
/// Логика взаимодействия
/// </summary>
public class PersonRepository 
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    private readonly AppDbContext _context;  
    
    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <returns>Массив пользователей</returns>
    public async Task<Person[]> GetPersonsAsync()
    {
        return await _context.Persons.Include(x =>x.Skills).ToArrayAsync(); 
    }
    /// <summary>
    /// Получить одного пользователя
    /// </summary>
    /// <param name="id">ID пользователя</param>
    /// <returns>Сущность пользователя</returns>
    public async Task<Person> GetPersonAsync(long id)
    {
        return await _context.Persons.Include(x=> x.Skills).SingleOrDefaultAsync(x=> x.Id == id); 
    }

    /// <summary>
    /// Создает нового пользователя
    /// </summary>
    /// <param name="person">Сущность создоваемого пользователя </param>
    public async void CreatePersonAsync(Person person)
    {
        var result = _context.Persons.Add(person);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Изменение данных существующего пользователя
    /// </summary>
    /// <param name="id">ID пользователя</param>
    /// <param name="person">Новые данные</param>
    /// <returns>true если пользователь был изменен, false если он не был найден</returns>
    public async Task<bool> UpdatePersonAsync(long id,Person person)
    {
        var result = _context.Persons.Include(x=> x.Skills).SingleOrDefaultAsync(x=> x.Id == id);
        
        if (result == null)
        {
            return false;
        }
        
        result.Result.Skills = person.Skills;
        result.Result.Name = person.Name;
        result.Result.DisplayName = person.DisplayName;
        await _context.SaveChangesAsync();

        return true;
    }
    
    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id">ID удаляемого пользователя</param>
    /// <returns>>true если пользователь был удален, false если он не был найден</returns>
    public async Task<bool> RemovePersonAsync(long id)
    {
        var result = _context.Persons.Include(x=> x.Skills).SingleOrDefaultAsync(x=> x.Id == id);
        if (result == null)
        {
            return false;
        }

        _context.Remove(result.Result);
        await _context.SaveChangesAsync();
        return true;
    }



}