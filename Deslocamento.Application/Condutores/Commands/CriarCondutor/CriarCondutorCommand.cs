using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Condutores.Commands.CriarCondutor
{
    public class CriarCondutorCommand : IRequest<Condutor> 
    {
        public string Nome { get; set; }

        public string Email { get; set; }
    }

    public class CriarCondutorCommandHandler : IRequestHandler<CriarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(
            CriarCondutorCommand request,
            CancellationToken cancellationToken)
        {
            var condutorInserir = new Condutor(request.Nome, request.Email);

            var repositoryCondutor =
                _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInserir);

            await _unitOfWork.CommitAsync();

            return condutorInserir;
        }
    }
}
