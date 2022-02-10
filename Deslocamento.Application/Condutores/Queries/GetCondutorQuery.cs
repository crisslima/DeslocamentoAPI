using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Condutores.Queries
{
    public class GetCondutorQuery : IRequest<List<Condutor>>
    {

    }

    public class GetCondutorQueryHandler :
        IRequestHandler<GetCondutorQuery, List<Condutor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Condutor>> Handle(
            GetCondutorQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            var condutor = await repositoryCondutor
                .GetAll()
                .ToListAsync(cancellationToken);

            return condutor;
        }
    }
}