using AutoMapper;
using EmployeesManagmentApi.Entities;
using EmployeesManagmentApi.Services;
using EmployeesManagmentApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagmentApi.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateDepartmentDto dto, [FromRoute] int id)
        {
            _departmentService.Update(id, dto);

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _departmentService.Delete(id);

            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDto>> GetAll()
        {
            var departmentDtos = _departmentService.GetAll();

            return Ok(departmentDtos);
        }
        [HttpPost]
        public ActionResult CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            var id = _departmentService.Create(dto);

            return Created($"/api/department/{id}", null);
        }




        //public ActionResult<AllocationDto> Get([FromRoute] int employeeID, [FromRoute] )
    }
}
