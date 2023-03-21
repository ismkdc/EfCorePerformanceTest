using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons;

[Table("persons")]
public class Person
{
    [Key]
    public int id { get; set; }
    
    [MaxLength(50)]
    public string name { get; set; }
    
    [MaxLength(50)]
    public string surname { get; set; }

}