namespace BaconreUs.Models
{
    // [LOCALIZADOR: Encomenda.cs | COM-001] Model da aplicação: representa uma encomenda de pizzas.
    public class Encomenda
    {
        public int Id { get; set; }
        public string Telefone { get; set; } = "";
        public string Nif { get; set; } = "";
        public int QuantidadeBacon { get; set; }
        public int QuantidadeTofu { get; set; }
        public decimal Total { get; set; }
        public bool Anulada { get; set; }

        // [LOCALIZADOR: Encomenda.cs | COM-002] Mostra na tabela se a encomenda está ativa ou anulada.
        public string Estado => Anulada ? "Anulada" : "Ativa";
    }
}
