using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Carros.Commands.CriarCarro
{
    public class CriarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }
       
        public string Descricao { get; set; }
    }

    public class CriarCarroCommandHandler : IRequestHandler<CriarCarroCommand,Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(
            CriarCarroCommand request,
            CancellationToken cancellationToken)
        {
            var carroInserir = new Carro(request.Placa, request.Descricao);

            var repositoryCarro =
                _unitOfWork.GetRepository<Domain.Entities.Carro>();

            repositoryCarro.Add(carroInserir);

            await _unitOfWork.CommitAsync();

            return carroInserir;
        }
    }
}
