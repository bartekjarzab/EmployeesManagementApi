using EmployeesManagmentApi.Models;
using EmployeesManagmentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagmentApi.Controllers
{
    [Route("api/employees/{employeeId}/allocation")]
    [ApiController]
    public class AllocationController : Controller
    {
        private readonly IAllocationService _alocationService;

        [HttpPost]
        public ActionResult Post([FromRoute]int employeeId, [FromBody] CreateAllocationDto dto)
        {
            var newAllocationId = _alocationService.Create(employeeId, dto);

            return Created($"api/employees/{employeeId}/allocation/{newAllocationId}", null);

        }
        public AllocationController(IAllocationService allocationService)
        {
            _alocationService = allocationService;
        }


    }
}
