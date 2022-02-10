using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApp.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {
        public Deslocamento(long carroId, long clienteId, long condutorId, decimal quilometragemInicial)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            CondutorId = condutorId;
            QuilometragemInicial = quilometragemInicial;
            DataHoraInicio = DateTime.Now;
        }
        public Deslocamento()
        {
        }
        public long CarroId { get; private set; }
        public long ClienteId { get; private set; }
        public long CondutorId { get; private set; }
        public DateTime DataHoraInicio { get; private set; }
        public decimal QuilometragemInicial { get; private set; }
        public string Observacao { get; private set; }
        public DateTime? DataHoraFim { get; private set; }
        public decimal QuilometragemFinal { get; private set; }
        public Carro Carro { get; private set; }
        public Cliente Cliente { get; private set; }
        public Condutor Condutor { get; private set; }

        public void EncerrarDeslocamento(string observacao, decimal quilometragemfinal)
        {
            DataHoraFim = DateTime.Now;
            QuilometragemFinal = quilometragemfinal;
            Observacao = observacao;
            
        }
    }
}
