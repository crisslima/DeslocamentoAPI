using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Carros.Queries
{
    public class GetCarroQuery : IRequest<List<Carro>>
    {

    }

    public class GetCarroQueryHandler :
        IRequestHandler<GetCarroQuery, List<Carro>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarroQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Carro>> Handle(
            GetCarroQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCarro =
                _unitOfWork.GetRepository<Carro>();

            var carro = await repositoryCarro
                .GetAll()
                .ToListAsync(cancellationToken);

            return carro;
        }
    }
}