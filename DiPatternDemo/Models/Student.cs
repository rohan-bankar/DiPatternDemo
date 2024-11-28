using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiPatternDemo.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int Studid { get; set; }
        [Required]
        public string? StudName { get; set; }
        [Required]
        public string? StudDepartment { get; set; }
        [Required]
        public int StudPercentage { get; set; }
    }
}
