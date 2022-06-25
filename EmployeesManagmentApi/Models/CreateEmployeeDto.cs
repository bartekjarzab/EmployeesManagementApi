using System.ComponentModel.DataAnnotations;

namespace EmployeesManagmentApi.Models
{
    public class CreateEmployeeDto
    {
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(3)]
        public string Age { get; set; }
        [Required]
        [MaxLength(9)]
        public string ContactNumber { get; set; }
    }
}
