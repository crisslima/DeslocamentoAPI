using DeslocamentoApp.Domain.Entities;
using DeslocamentoApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApp.Application.Deslocamentos.Commands.CriarDeslocamento
{
    public class CriarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public long CarroId { get; set; }
        public long ClienteId { get; set; }
        public long CondutorId { get; set; }
        public decimal QuilometragemInicial { get; set; }
    }

    public class CriarDeslocamentoCommandHandler :
        IRequestHandler<CriarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(
            CriarDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var deslocamentoInserir = new Deslocamento(
                 request.CarroId,
                 request.ClienteId,
                 request.CondutorId,
                 request.QuilometragemInicial);

            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamento>();

            repositoryDeslocamento.Add(deslocamentoInserir);

            await _unitOfWork.CommitAsync();

            return deslocamentoInserir;
        }
    }
}
