namespace EmployeesManagmentApi.Entities
{
    public class Allocation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }



        public Allocation(int EmployeeId, int DepartmentId)
        {
            this.EmployeeId = EmployeeId;
            this.DepartmentId = DepartmentId;
        }
    }
}
