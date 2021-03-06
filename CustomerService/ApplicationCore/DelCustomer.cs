using CustomerService.ApplicationCore.Entities;
using CustomerService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.ApplicationCore
{
    public class DelCustomer
    {

        public class CustomerById : IRequest<Customer>
        {
            public string numeroDocumento { get; set; }
            public string tipoDocumento { get; set; }
        }
        public class Handler : IRequestHandler<CustomerById, Customer>
        {
            private readonly DatabaseContext _context;
            public Handler(DatabaseContext context)
            {
                _context = context;
            }

            public async Task<Customer> Handle(CustomerById request, CancellationToken cancellationToken)
            {
                var cliente = await _context.Customers.Where(x => x.tipoDocumento == request.tipoDocumento && x.numeroDocumento == request.numeroDocumento).FirstOrDefaultAsync();
                if (cliente == null)
                {
                    throw new Exception("No se encontro Cliente");
                }
                _context.Customers.Attach(cliente);
                _context.Customers.Remove(cliente);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return null;
                }
                throw new Exception("No se eliminar el cliente " + cliente.nombres + " " + cliente.apellidos);
            }
        }
    }
}
