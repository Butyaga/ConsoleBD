using Abstract;
using System.ComponentModel.DataAnnotations;

namespace EFStorage.Model
{
    public class Employee(string name, DateOnly birthDay, int sex) : IEmployee
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = name;
        
        public DateOnly BirthDay { get; set; } = birthDay;
        
        public int Sex { get; set; } = sex;
    }
}
