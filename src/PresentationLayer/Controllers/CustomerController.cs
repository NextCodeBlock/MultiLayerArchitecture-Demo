using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Commands.AddUpdate;
using MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Queries.GetAll;
using MultiLayerArchitectureDemo.BusinessLogicLayer.Features.Customers.Queries.GetById;
using MultiLayerArchitectureDemo.DataAccessLayer.Entity;
using System.Threading;

namespace MultiLayerArchitectureDemo.PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseApiController<CustomerController>
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get all customer list.");
            return Ok(await _mediator.Send(new GetAllCustomersQuery(), HttpContext.RequestAborted));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Get customer by id: {id}.", id);
            var customer = await _mediator.Send(new GetByIdCustomerQuery { CustomerId = id }, HttpContext.RequestAborted);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUpdateCustomerCommand command)
        {
            _logger.LogInformation("Customer added or updated.");
            return Ok(await _mediator.Send(command, HttpContext.RequestAborted));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Customer by id: {id} is deleted.", id);
            return Ok(await _mediator.Send(new DeleteCustomerCommand { CustomerId = id }, HttpContext.RequestAborted));
        }
    }
}