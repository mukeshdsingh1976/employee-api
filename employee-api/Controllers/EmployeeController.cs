using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _service.GetById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _service.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();

            _service.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetById(id);
            if (existing == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }

        [HttpGet("Name/{name}")]
        [ProducesResponseType(type: typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByName(string name)
        {
            var employee = _service.GetByName(name);
            if (employee == null) return NotFound();
            return Ok(employee);
        }
	}
}
