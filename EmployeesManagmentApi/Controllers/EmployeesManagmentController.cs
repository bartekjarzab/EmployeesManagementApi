using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagmentApi.Controllers
{
    [Route("api/employees")]
    public class EmployeesManagmentController : ControllerBase
    {
        private readonly EmployeesManagmentDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeesManagmentController(EmployeesManagmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employees = _dbContext
                .Employees 
                .ToList();
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }
        [HttpGet("{id}")]

        public ActionResult<EmployeeDto> Get([FromRoute] int id)
        {
            var employee = _dbContext
                .Employees
                .FirstOrDefault(r => r.Id == id);
            if(employee is null)
            {
                return NotFound();
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
    }

    
}
