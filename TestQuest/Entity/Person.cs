using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TestQuest.Entity;

public class Person
{
    [Key]
    public long? Id{ get; set; } = null;
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public List<Skill> Skills { get; set; } = new();

    public Person()
    {
        Skills = new List<Skill>();
    }

}