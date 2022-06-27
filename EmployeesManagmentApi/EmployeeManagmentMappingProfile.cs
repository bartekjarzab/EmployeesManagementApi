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

            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<CreateAllocationDto, Allocation>();
                

            
                //.ForMember()
        }
    }
}
