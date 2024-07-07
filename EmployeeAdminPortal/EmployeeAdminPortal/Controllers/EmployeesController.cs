using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //IActinoResult Https yapılarında kullanılır httpget , put , update ,delete
            
            //var allEmployees = dbContext.Employees.ToList();
            //return Ok(allEmployees); //200 //404 //500
            return Ok(dbContext.Employees.ToList());
        
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetEmployeesById(Guid id) 
        {

            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);

        }

        [HttpPost]

        public IActionResult AddEmployee(AddEmployeeDto addEmpployeeDto)
        {

            var employeeEntity = new Employee()
            {
                Name = addEmpployeeDto.Name,
                Email = addEmpployeeDto.Email,
                Phone = addEmpployeeDto.Phone,
                Salary = addEmpployeeDto.Salary,
                };
           
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);

        }

        [HttpPut]
        [Route("{id:guid}")]
        
        public IActionResult UpdateEmployee(Guid id , UpdateEmployeeDto updateEmployeeDto )
        {

            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
           
            dbContext.SaveChanges();
            return Ok(employee);

            //return Ok();
 

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }
    }
  }

