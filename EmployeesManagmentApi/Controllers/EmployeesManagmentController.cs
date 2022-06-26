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
    [ApiController]
    public class EmployeesManagmentController : ControllerBase
    {
        private readonly IEmployeesManagmentService  _employeesManagmentService;
        public EmployeesManagmentController(IEmployeesManagmentService employeesManagmentService)
        {
            _employeesManagmentService = employeesManagmentService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateEmployeeDto dto, [FromRoute]int id)
        {
           _employeesManagmentService.Update(id, dto);

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
             _employeesManagmentService.Delete(id);
   
            return NotFound();
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
                    
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            var id = _employeesManagmentService.Create(dto);

            return Created($"/api/employees/{id}", null);
        }
    }
}
