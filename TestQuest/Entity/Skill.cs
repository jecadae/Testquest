using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestQuest.Entity;
/// <summary>
/// Модель навыка
/// </summary>
public class Skill
{
    /// <summary>
    /// ID навыка
    /// </summary>
    [JsonIgnore]
    public long? Id{ get; set; } = null;
    
    /// <summary>
    /// ID владельца навыка
    /// </summary>
    [ForeignKey("Person")] 
    [JsonIgnore] 
    public long? PersonId { get; set; }
    /// <summary>
    /// Ссылка на владельца
    /// </summary>
    [JsonIgnore]
    public Person? person{ get; set; }
    
    /// <summary>
    /// Название навыка
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Уровень навыка
    /// </summary>
    [Range(1,10)]
    public byte Level { get; set; }
    

}