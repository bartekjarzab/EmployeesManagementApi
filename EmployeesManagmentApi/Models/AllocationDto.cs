using System.Collections.Generic;

namespace EmployeesManagmentApi.Models
{
    public class AllocationDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        //public List <DepartmentDto> Deparments { get; set; }

    }
}
