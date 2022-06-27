using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Exceptions;
using EmployeesManagmentApi.Models;
using System.Linq;

namespace EmployeesManagmentApi.Services
{

    public interface IAllocationService
    {
        int Create(int employeeId, CreateAllocationDto dto);
    }
    public class AllocationService : IAllocationService
    {
        private readonly EmployeesManagmentDbContext _context;
        private readonly IMapper _mapper;

        public AllocationService(EmployeesManagmentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public int Create(int employeeId, CreateAllocationDto dto)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);
            
            if (employee is null) throw new NotFoundException("Employee not found");

            var allocationEntity = _mapper.Map<Allocation>(dto);
            allocationEntity.EmployeeId = employeeId;
            allocationEntity.EmployeeId = employeeId;

            _context.Allocations.Add(allocationEntity);
            //_context.SaveChanges();

            return allocationEntity.Id;
         }
    }
}
