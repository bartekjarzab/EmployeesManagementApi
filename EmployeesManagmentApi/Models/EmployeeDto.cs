using System.Collections.Generic;

namespace EmployeesManagmentApi.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string ContactNumber { get; set; }
        

        public List<AllocationDto> Allocations { get; set; }
    }
}
