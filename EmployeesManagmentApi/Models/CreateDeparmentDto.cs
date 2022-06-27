using System.ComponentModel.DataAnnotations;

namespace EmployeesManagmentApi.Models
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
