using EmployeesManagmentApi.Entities;
using System;
using System.Collections.Generic;

namespace EmployeesManagmentApi.Models
{
    public class EmployeeWithDepartmentsDto
    {
      

        public EmployeeWithDepartmentsDto(EmployeeDto employee, List<string> departmentsName)
        {
            Employee = employee;
            DepartmentsName = departmentsName;
        }

        public EmployeeDto Employee { get; set; }

        public List<String> DepartmentsName { get; set; }
    }
}
