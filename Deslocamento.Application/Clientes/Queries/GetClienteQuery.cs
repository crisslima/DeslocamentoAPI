using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Clientes.Queries
{
    public class GetClienteQuery : IRequest<List<Cliente>>
    {

    }

    public class GetClienteQueryHandler :
        IRequestHandler<GetClienteQuery, List<Cliente>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClienteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Cliente>> Handle(
            GetClienteQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            var cliente = await repositoryCliente
                .GetAll()
                .ToListAsync(cancellationToken);

            return cliente;
        }
    }
}