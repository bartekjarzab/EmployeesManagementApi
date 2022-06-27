using System.Collections.Generic;

namespace EmployeesManagmentApi.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string ContactNumber { get; set; }
        //public int AllocationId { get; set; }
        public virtual List<Allocation> Allocations { get; set; }
        //  public int DeparmentId { get; set; }
    }
}
