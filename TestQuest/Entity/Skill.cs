using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestQuest.Entity;

public class Skill
{
        
    [Key]
    [JsonIgnore]
    public long? Id{ get; set; } = null;

    [ForeignKey("Person")] 
    [JsonIgnore] 
    public long? PersonId { get; set; }
    
    [JsonIgnore]
    public Person? person{ get; set; }
    
    public string Name { get; set; }
    [Range(1,10)]
    public byte Level { get; set; }
    

}