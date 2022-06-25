using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagmentApi.Services
{
    public interface IEmployeesManagmentService
    {
        EmployeeDto GetById(int id);

        IEnumerable<EmployeeDto> GetAll();

        int Create(CreateEmployeeDto dto);
    }
    public class EmployeesManagmentService
    {
        private readonly EmployeesManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeesManagmentService(EmployeesManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }
        public EmployeeDto GetById(int id )
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);

            if (employee is null) return null;

            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _dbContext
                .Employees
                .ToList();

            var employeesDtos = _mapper.Map<List<EmployeeDto>>(employees);

            return employeesDtos;
        }

        public int Create(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return employee.Id;
        }
    }
}
