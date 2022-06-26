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
    public interface IEmployeesManagmentService
    {
        void Delete(int id);
        void Update(int id, UpdateEmployeeDto dto);
        EmployeeDto GetById(int id);

        IEnumerable<EmployeeDto> GetAll();

        int Create(CreateEmployeeDto dto);
    }
    public class EmployeesManagmentService : IEmployeesManagmentService
    {
        private readonly EmployeesManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeesManagmentService> _logger;

        public EmployeesManagmentService(EmployeesManagmentDbContext dbContext, IMapper mapper, ILogger<EmployeesManagmentService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public EmployeeDto GetById(int id )
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);

            if (employee is null) throw new NotFoundException("Employee not found");

            var result = _mapper.Map<EmployeeDto>(employee);
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

        
    }
}
