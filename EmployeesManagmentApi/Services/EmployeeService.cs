using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System;
using EmployeesManagmentApi.Exceptions;

namespace EmployeesManagmentApi.Services
{
    public interface IEmployeeService
    {
        void Delete(int id);
        void Update(int id, UpdateEmployeeDto dto);
        EmployeeDto GetById(int id);
        EmployeeWithDepartmentsDto GetByIdWithDepartments(int id);
        public void UpdateEmployeeDepartments(int id, List<int> departmentsId);
        public List<EmployeeWithDepartmentsDto> GetAllEmployeesWithDepartments();
        IEnumerable<EmployeeDto> GetAll();

        int Create(CreateEmployeeDto dto);
        public List<int> GetEmployeeDepartments(int employeeId);
        public List<String> getEmployeeDepartmentsName(List<int> departmentsIds);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeesManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(EmployeesManagmentDbContext dbContext, IMapper mapper, ILogger<EmployeeService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public EmployeeDto GetById(int id)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);

            if (employee is null) throw new NotFoundException("Employee not found");

            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }

        
        public EmployeeWithDepartmentsDto GetByIdWithDepartments(int id)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);
            
            var departmentsId = GetEmployeeDepartments(id);
            var departmentsName = getEmployeeDepartmentsName(departmentsId);

            if (employee is null) throw new NotFoundException("Employee not found");
            var mappedEmployee = _mapper.Map<EmployeeDto>(employee);

            var employeeWithDepartments = new EmployeeWithDepartmentsDto(mappedEmployee, departmentsName);

            var result = _mapper.Map<EmployeeWithDepartmentsDto>(employeeWithDepartments);
            return result;
        }


        public void Update(int id, UpdateEmployeeDto dto)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);

            if (employee is null) throw new NotFoundException("Employee not found");

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Age = dto.Age;
            employee.ContactNumber = dto.ContactNumber;

            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            _logger.LogWarning($"Employee with id: {id} Delete action invoked");

            var employee = _dbContext
               .Employees
               .FirstOrDefault(r => r.Id == id);

            if (employee is null) throw new NotFoundException("Employee not found");

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

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


        public List<int> GetEmployeeDepartments(int employeeId)
        {
            var result = _dbContext
                .Allocations
                .Where(r => r.EmployeeId == employeeId)
                .Select(r => r.DepartmentId);
            var resultList = result.ToList();
            return resultList;
        }

        public List<String> getEmployeeDepartmentsName(List<int> departmentsIds)
        {
            var result = _dbContext.Departments
                .Where(r => departmentsIds.Contains(r.Id))
                .Select(r => r.Name);

            return result.ToList();
        }

        public void UpdateEmployeeDepartments(int id, List<int> departmentsId)
        {
           foreach(var department in departmentsId)
            {
                var allocation = new Allocation(id, department);
                _dbContext.Allocations.Add(allocation);
            }
            _dbContext.SaveChanges();
            
        }
        public List<EmployeeWithDepartmentsDto> GetAllEmployeesWithDepartments()
        {
            var employees = GetAll();

            var employeesWithDepartments = new List<EmployeeWithDepartmentsDto>();

            foreach (var employee in employees)
            {
                var employeeDepartments = GetEmployeeDepartments(employee.Id);
                var employeeDepartmentsName = getEmployeeDepartmentsName(employeeDepartments);
                var mappedEmployee = _mapper.Map<EmployeeDto>(employee);
                employeesWithDepartments.Add(new EmployeeWithDepartmentsDto(mappedEmployee,employeeDepartmentsName));
            } 

            return employeesWithDepartments;
        }
    }
}
