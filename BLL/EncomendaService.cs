using System;
using System.Collections.Generic;
using System.Linq;
using BaconreUs.DAL;
using BaconreUs.Models;

namespace BaconreUs.BLL
{
    // [LOCALIZADOR: EncomendaService.cs | COM-001] Esta classe é a camada de regras de negócio das encomendas.
    public class EncomendaService
    {
        // [LOCALIZADOR: EncomendaService.cs | COM-002] Este valor é o preço fixo de uma pizza Bacon.
        private const decimal PrecoBacon = 10m;

        // [LOCALIZADOR: EncomendaService.cs | COM-003] Este valor é o preço fixo de uma pizza Tofu.
        private const decimal PrecoTofu = 9m;

        // [LOCALIZADOR: EncomendaService.cs | COM-004] O repository é usado para guardar e procurar encomendas sem misturar isso com as regras de negócio.
        private readonly EncomendaRepository _repository = new EncomendaRepository();

        // [LOCALIZADOR: EncomendaService.cs | COM-005] Este método devolve todas as encomendas guardadas.
        public List<Encomenda> Listar()
        {
            return _repository.Listar();
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-006] Este método valida, calcula o total e depois insere uma encomenda nova.
        public void Inserir(Encomenda encomenda)
        {
            // [LOCALIZADOR: EncomendaService.cs | COM-007] Antes de guardar, o programa confirma se os dados obrigatórios estão corretos.
            Validar(encomenda);

            // [LOCALIZADOR: EncomendaService.cs | COM-008] O total é calculado antes de a encomenda ser guardada na lista.
            CalcularTotal(encomenda);

            // [LOCALIZADOR: EncomendaService.cs | COM-009] Depois da validação e do cálculo, a encomenda é enviada para a camada de dados.
            _repository.Inserir(encomenda);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-010] Este método valida, recalcula o total e edita uma encomenda existente.
        public void Editar(Encomenda encomenda)
        {
            Validar(encomenda);
            CalcularTotal(encomenda);
            _repository.Editar(encomenda);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-011] Este método pede à camada de dados para marcar uma encomenda como anulada.
        public void Anular(int id)
        {
            _repository.Anular(id);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-012] Este método calcula quanto dinheiro foi faturado nas encomendas não anuladas.
        public decimal TotalFaturado()
        {
            // [LOCALIZADOR: EncomendaService.cs | COM-013] Where escolhe só as encomendas ativas e Sum soma os totais dessas encomendas.
            return _repository.Listar()
                .Where(e => !e.Anulada)
                .Sum(e => e.Total);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-014] Este método conta quantas encomendas ainda estão ativas.
        public int TotalEncomendasAtivas()
        {
            // [LOCALIZADOR: EncomendaService.cs | COM-015] Count conta apenas as encomendas que não foram anuladas.
            return _repository.Listar()
                .Count(e => !e.Anulada);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-016] Este método contém as validações simples antes de guardar ou editar.
        private void Validar(Encomenda encomenda)
        {
            // [LOCALIZADOR: EncomendaService.cs | COM-017] O telefone é obrigatório porque identifica o contacto do cliente.
            if (string.IsNullOrWhiteSpace(encomenda.Telefone))
                throw new Exception("O contacto telefónico é obrigatório.");

            // [LOCALIZADOR: EncomendaService.cs | COM-018] O NIF é obrigatório porque a prova pede contribuinte/NIF.
            if (string.IsNullOrWhiteSpace(encomenda.Nif))
                throw new Exception("O contribuinte/NIF é obrigatório para emitir fatura.");

            // [LOCALIZADOR: EncomendaService.cs | COM-019] A encomenda precisa ter pelo menos uma pizza, Bacon ou Tofu.
            if (encomenda.QuantidadeBacon == 0 && encomenda.QuantidadeTofu == 0)
                throw new Exception("A encomenda tem de ter pelo menos uma pizza Bacon ou Tofu.");
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-020] Este método calcula o preço total da encomenda.
        private void CalcularTotal(Encomenda encomenda)
        {
            // [LOCALIZADOR: EncomendaService.cs | COM-021] O total é a quantidade de Bacon vezes 10 euros mais a quantidade de Tofu vezes 9 euros.
            encomenda.Total =
                encomenda.QuantidadeBacon * PrecoBacon +
                encomenda.QuantidadeTofu * PrecoTofu;
        }
    }
}
