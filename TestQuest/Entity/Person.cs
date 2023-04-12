using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TestQuest.Entity;
/// <summary>
/// Модель для владельца
/// </summary>
public class Person
{
    /// <summary>
    /// ID владельца
    /// </summary>
    public long? Id{ get; set; } = null;
    /// <summary>
    /// Имя владельца
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Отображаемое? имя владельца
    /// </summary>
    public string DisplayName { get; set; }
    /// <summary>
    /// Навыки владельца
    /// </summary>
    public List<Skill> Skills { get; set; } = new();



}