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
    public interface IDepartmentService
    {
        void Delete(int id);
        void Update(int id, UpdateDepartmentDto dto);
        IEnumerable<DepartmentDto> GetAll();
        int Create(CreateDepartmentDto dto);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly EmployeesManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(EmployeesManagmentDbContext dbContext, IMapper mapper, ILogger<DepartmentService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Update(int id, UpdateDepartmentDto dto)
        {
            var department = _dbContext
                .Departments
                .FirstOrDefault(r => r.Id == id);

            if (department is null) throw new NotFoundException("Department not found");

            department.Name = dto.Name;
            department.Location = dto.Location;
           

            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            _logger.LogWarning($"Department with id: {id} Delete action invoked");

            var department = _dbContext
               .Departments
               .FirstOrDefault(r => r.Id == id);

            if (department is null) throw new NotFoundException("Department not found");

            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();

        }
        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _dbContext
                .Departments
                .ToList();

            var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);

            return departmentDtos;
        }

        

        public int Create(CreateDepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();

            return department.Id;
        }
    }
}
