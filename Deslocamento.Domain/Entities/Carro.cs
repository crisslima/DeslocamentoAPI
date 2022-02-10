namespace DeslocamentoApp.Domain.Entities
{
    public class Carro : BaseEntity
    {   
        public Carro(string placa, string descricao)
        {
            this.Placa = placa;
            this.Descricao = descricao;
        }
        private Carro()
        {

        }

        public string Placa { get; private set;}

        public string Descricao { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();

        private readonly List<Deslocamento> _deslocamentos = new();
    }
}
