using CustomerService.Infrastructure;
using CustomerService.ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace CustomerService.ApplicationCore
{
    public class UpdCustomer
    {
        public class Upd : IRequest
        {
            public string numeroDocumento { get; set; }
            public string tipoDocumento { get; set; }
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public string direccion { get; set; }
            public string telefono { get; set; }
            public string email { get; set; }

        }
        public class Handler : IRequestHandler<Upd>
        {
            public readonly DatabaseContext _context;
            public Handler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Upd request, CancellationToken cancellationToken)
            {
                var customer = new Customer
                {
                    tipoDocumento = request.tipoDocumento,
                    numeroDocumento = request.numeroDocumento,
                    nombres = request.nombres,
                    apellidos = request.apellidos,
                    direccion = request.direccion,
                    telefono = request.telefono,
                    email = request.email
                };

                _context.Customers.Update(customer);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se puedo actualizar el cliente");

            }
        }
    }
}
