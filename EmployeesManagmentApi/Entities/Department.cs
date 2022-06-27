namespace EmployeesManagmentApi.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Location { get; set; }
        public int AllocationId { get; set; }
        public virtual Allocation Allocation { get; set; }
    }
}
