using CustomerService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.ApplicationCore.Entities
{
    public class Query
    {
        public class CustomersList : IRequest<List<Customer>>
        {
            public class Handler : IRequestHandler<CustomersList, List<Customer>>
            {
                private readonly DatabaseContext _context;

                public Handler(DatabaseContext context)
                {
                    _context = context;
                }
                public async Task<List<Customer>> Handle(CustomersList request, CancellationToken cancellationToken)
                {
                    var clientes = await _context.Customers.ToListAsync();
                    return clientes;

                }
            }

        }
    }
}
