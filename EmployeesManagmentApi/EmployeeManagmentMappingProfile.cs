using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Models;

namespace EmployeesManagmentApi
{
    public class EmployeeManagmentMappingProfile : Profile
    {
        public EmployeeManagmentMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<Employee, EmployeeWithDepartmentsDto>();             
            CreateMap<CreateAllocationDto, Allocation>();
                

            
                //.ForMember()
        }
    }
}
