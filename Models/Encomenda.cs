namespace BaconreUs.Models
{
    // [LOCALIZADOR: Encomenda.cs | COM-001] Esta classe é o modelo da encomenda, ou seja, o molde dos dados que o programa guarda.
    public class Encomenda
    {
        // [LOCALIZADOR: Encomenda.cs | COM-002] Id é o número único que identifica cada encomenda na lista.
        public int Id { get; set; }

        // [LOCALIZADOR: Encomenda.cs | COM-003] Telefone guarda o contacto telefónico do cliente.
        public string Telefone { get; set; } = "";

        // [LOCALIZADOR: Encomenda.cs | COM-004] Nif guarda o contribuinte do cliente para a fatura.
        public string Nif { get; set; } = "";

        // [LOCALIZADOR: Encomenda.cs | COM-005] QuantidadeBacon guarda quantas pizzas Bacon foram pedidas.
        public int QuantidadeBacon { get; set; }

        // [LOCALIZADOR: Encomenda.cs | COM-006] QuantidadeTofu guarda quantas pizzas Tofu foram pedidas.
        public int QuantidadeTofu { get; set; }

        // [LOCALIZADOR: Encomenda.cs | COM-007] Total guarda o preço total da encomenda.
        public decimal Total { get; set; }

        // [LOCALIZADOR: Encomenda.cs | COM-008] Anulada indica se a encomenda foi cancelada; true significa anulada e false significa ativa.
        public bool Anulada { get; set; }

        // [LOCALIZADOR: Encomenda.cs | COM-009] Estado transforma o valor true/false numa palavra fácil de mostrar na tabela.
        public string Estado => Anulada ? "Anulada" : "Ativa";
    }
}
