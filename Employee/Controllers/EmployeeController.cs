using Employee.Model;
using Employee.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] EmployeeRequest model)
        {
            var response = employeeService.CreateEmployee(model);

            if (response == null)
                return BadRequest(new { message = "Invalid Request Object" });

            return Ok(response);
        }

        [HttpPost("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var response = employeeService.GetEmployee(id);

            if (response == null)
                return BadRequest(new { message = "Invalid Request Object" });

            return Ok(response.Employee);
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            var response = employeeService.GetEmployees();

            if (response == null)
                return BadRequest(new { message = "Invalid Request Object" });

            return Ok(response);
        }

        [HttpPost("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeUpdateRequest model)
        {
            var response = employeeService.UpdateEmployee(id, model);

            if (response == null)
                return BadRequest(new { message = "Invalid Request Object" });

            return Ok(response);
        }
    }
}
