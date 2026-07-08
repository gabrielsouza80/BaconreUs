namespace BaconreUs.Models
{
    // [LOCALIZADOR: Encomenda.cs | COM-001] A classe usa campos privados e propriedades públicas para manter encapsulamento e permitir o Binding do WPF.
    public class Encomenda
    {
        private int _id;
        private string _telefone = "";
        private string _nif = "";
        private int _quantidadeBacon;
        private int _quantidadeTofu;
        private decimal _total;
        private bool _anulada;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public string Nif
        {
            get { return _nif; }
            set { _nif = value; }
        }

        public int QuantidadeBacon
        {
            get { return _quantidadeBacon; }
            set { _quantidadeBacon = value; }
        }

        public int QuantidadeTofu
        {
            get { return _quantidadeTofu; }
            set { _quantidadeTofu = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public bool Anulada
        {
            get { return _anulada; }
            set { _anulada = value; }
        }

        // [LOCALIZADOR: Encomenda.cs | COM-002] Mostra na tabela se a encomenda está ativa ou anulada.
        public string Estado
        {
            get { return Anulada ? "Anulada" : "Ativa"; }
        }
    }
}
