using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Clientes.Commands.CriarCliente
{
    public class CriarClienteCommand : IRequest<Cliente>
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }
    }

    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(
            CriarClienteCommand request,
            CancellationToken cancellationToken)
        {
            var clienteInserir = new Cliente(request.Cpf, request.Nome);

            var repositoryCliente =
                _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(clienteInserir);

            await _unitOfWork.CommitAsync();

            return clienteInserir;
        }
    }
}
