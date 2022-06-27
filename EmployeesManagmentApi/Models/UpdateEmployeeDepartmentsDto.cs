using System.Collections.Generic;

namespace EmployeesManagmentApi.Models
{
    public class UpdateEmployeeDepartmentsDto
    {
        public int Id { get; set; }
        public List<int> Departments { get; set; }
    }
}
