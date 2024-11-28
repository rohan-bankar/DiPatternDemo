using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiPatternDemo.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int empid { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public decimal salary { get; set; }

    }
}
