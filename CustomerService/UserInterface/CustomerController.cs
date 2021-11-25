using CustomerService.ApplicationCore;
using CustomerService.ApplicationCore.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.UserInterface
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{numeroDocumento}/{tipoDocumento}")]
        public async Task<ActionResult<Customer>> GetCustomer(string numeroDocumento, string tipoDocumento)
        {
            return await _mediator.Send(new QueryFilter.CustomerById { tipoDocumento = tipoDocumento, numeroDocumento = numeroDocumento });
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return await _mediator.Send(new Query.CustomersList());
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NewCustomer.Run data)
        {
            return await _mediator.Send(data);
        }
        [HttpDelete("{numeroDocumento}/{tipoDocumento}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(string numeroDocumento, string tipoDocumento)
        {
            return await _mediator.Send(new DelCustomer.CustomerById { tipoDocumento = tipoDocumento, numeroDocumento = numeroDocumento });
        }
        [HttpPut]
        public async Task<ActionResult<Unit>> UpdateCustomer(UpdCustomer.Upd data)
        {
            return await _mediator.Send(data);
        }

    }
}
