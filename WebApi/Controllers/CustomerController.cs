using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.DAL.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly CustomerManager _customerManager;
        public CustomerController(CustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerAsync([FromRoute] long id)
        {
            Customer customer = await _customerManager.GetBySingleId(id);

            if (customer is null) 
            { 
                return NotFound("Клиента с данным Id не существует.");
            }

            return Ok(customer);
        }

        [HttpPost("")]   
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerCreateModel customerModel)
        {
            long id = await _customerManager.Insert(new Customer(customerModel));

            return Ok(id);
        }
    }
}