using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Services;
using EmployeesManagmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagmentApi.Controllers
{
    [Route("api/employees")]
    public class EmployeesManagmentController : ControllerBase
    {
        private readonly IEmployeesManagmentService  _employeesManagmentService;
        public EmployeesManagmentController(IEmployeesManagmentService employeesManagmentService)
        {
            _employeesManagmentService = employeesManagmentService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll()
        {
            var employeeDtos = _employeesManagmentService.GetAll();

            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> Get([FromRoute] int id)
        {
            var employee = _employeesManagmentService.GetById(id);
            if(employee is null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _employeesManagmentService.Create(dto);

            return Created($"/api/employees/{id}", null);
        }
    }
}
