using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Deslocamentos.Queries
{
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {
        ///public string Titulo { get; set; }
    }

    public class GetDeslocamentosQueryHandler :
        IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamento>> Handle(
            GetDeslocamentosQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            var deslocamentos = await repositoryDeslocamento
                .GetAll()
            //    .Where(d => d.Titulo.Contains(request.Titulo))
                .ToListAsync(cancellationToken);

            return deslocamentos;
        }
    }
}