using System;

namespace AceiteDigitalApp.Domain.Entities
{
    public class Assinatura : BaseEntity
    {
        public Assinatura()
        {
            DataHoraRegistro = DateTime.Now;
        }

        public long DocumentoSignatarioId { get; private set; }

        public bool Assinado { get; private set; }

        public DateTime DataHoraRegistro { get; private set; }

        public bool Aceito { get; private set; }

        public DocumentoSignatario DocumentoSignatario { get; private set; }

        public void Assinar()
        {
            Aceito = true;
        }

        public void RecusarAssinatura()
        {
            Aceito = false;
        }
    }
}
