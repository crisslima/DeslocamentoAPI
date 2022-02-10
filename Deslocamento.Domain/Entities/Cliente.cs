namespace DeslocamentoApp.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;
        }
        
        private Cliente()
        {

        }

        public string Cpf { get; private set;}

        public string Nome { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos => _deslocamentos.AsReadOnly();

        private readonly List<Deslocamento> _deslocamentos = new();
    }
}
