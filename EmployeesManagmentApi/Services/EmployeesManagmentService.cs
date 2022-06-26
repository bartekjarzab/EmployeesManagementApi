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
        bool Delete(int id);
        bool Update(int id, UpdateEmployeeDto dto);
        EmployeeDto GetById(int id);

        IEnumerable<EmployeeDto> GetAll();

        int Create(CreateEmployeeDto dto);
    }
    public class EmployeesManagmentService : IEmployeesManagmentService
    {
        private readonly EmployeesManagmentDbContext _dbContext;
        private readonly IMapper _mapper;

     
        public EmployeesManagmentService(EmployeesManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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


        public bool Update(int id, UpdateEmployeeDto dto)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);

            if (employee is null) return false;
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Age = dto.Age;
            employee.ContactNumber = dto.ContactNumber;

            _dbContext.SaveChanges();

            return true;

        }

        public bool Delete(int id)
        {
            var employee = _dbContext
               .Employees
               .FirstOrDefault(r => r.Id == id);

            if (employee is null) return false;

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return true;
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
