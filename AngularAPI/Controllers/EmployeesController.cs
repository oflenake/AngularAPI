using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using AngularAPI.Contracts;
using AngularAPI.Entities.Extensions;
using AngularAPI.Entities.Models;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class EmployeesController : ControllerBase
    {
        #region Fields
        private string _component;
        private string _process;
        private string _message;
        private readonly ILoggerManager _loggerManager;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IRepositoryWrapper _repowrap;
        #endregion

        #region Constructor
        /// <summary>
        /// Inject the logger and repository parameter services inside the constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repowrap"></param>
        public EmployeesController(ILoggerManager loggerManager, ILogger<EmployeesController> logger, IRepositoryWrapper repowrap)
        {
            _loggerManager = loggerManager;
            _logger = logger;
            _repowrap = repowrap;

            _component = "EmployeesController";
            _process = "EmployeesController";
            _message = string.Format($" Initializing component: '{_component}' using its constructor '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
        }
        #endregion

        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            _process = "GetAllEmployeesAsync";
            _message = string.Format($"{_component} {_process} action method invoked. Processing task '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
            _logger.LogInformation($"{_message}.");

            return await _repowrap.EmployeeRepository.GetAllAsyncData();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIDAsync([FromRoute] int id)
        {
            _process = "GetEmployeeByIDAsync";
            _message = string.Format($"{_component} {_process} action method invoked. Processing task '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
            _logger.LogInformation($"{_message}.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _repowrap.EmployeeRepository.GetByIDAsyncData(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeUpdateAsync([FromRoute] int id, [FromBody] Employee employee)
        {
            _process = "PutEmployeeUpdateAsync";
            _message = string.Format($"{_component} {_process} action method invoked. Processing task '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
            _logger.LogInformation($"{_message}.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            //_repowrap.EmployeeRepository.PutUpdateBaseData(employee).State = EntityState.Modified;
            _repowrap.EmployeeRepository.PutUpdateBaseData(employee);

            try
            {
                await _repowrap.EmployeeRepository.SaveAsyncBaseData();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new ApplicationException();
                }
            }

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            _process = "EmployeeExists";
            _message = string.Format($"{_component} {_process} action method invoked. Processing task '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
            _logger.LogInformation($"{_message}.");

            throw new NotImplementedException();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployeeCreateAsync([FromBody] Employee employee)
        {
            _process = "PostEmployeeCreateAsync";
            _message = string.Format($"{_component} {_process} action method invoked. Processing task '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
            _logger.LogInformation($"{_message}.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repowrap.EmployeeRepository.PostCreateBaseData(employee);
            await _repowrap.EmployeeRepository.SaveAsyncBaseData();

            return CreatedAtAction("GetEmployee", new { id = employee.ID }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeByIDAsync([FromRoute] int id)
        {
            _process = "DeleteEmployeeByIDAsync";
            _message = string.Format($"{_component} {_process} action method invoked. Processing task '{_component}.{_process}'");

            _loggerManager.LogInfo($"{_message}.");
            _logger.LogInformation($"{_message}.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _repowrap.EmployeeRepository.GetByIDAsyncData(id);

            if (employee == null)
            {
                return NotFound();
            }

            _repowrap.EmployeeRepository.DeleteByIDBaseData(employee);
            await _repowrap.EmployeeRepository.SaveAsyncBaseData();

            return Ok(employee);
        }

        //private bool EmployeeExists(int id)
        //{
        //    return _repowrap.EmployeeRepository.GetByIDAsyncData(e => e.ID.Equals(id));
        //}
    }
}
