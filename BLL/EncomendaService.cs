using System;
using System.Collections.Generic;
using System.Linq;
using BaconreUs.DAL;
using BaconreUs.Models;

namespace BaconreUs.BLL
{
    // [LOCALIZADOR: EncomendaService.cs | COM-001] Camada BLL: valida os dados, calcula valores e chama o Repository.
    public class EncomendaService
    {
        private const decimal PrecoBacon = 10m;
        private const decimal PrecoTofu = 9m;

        private readonly EncomendaRepository _repository = new EncomendaRepository();

        // [LOCALIZADOR: EncomendaService.cs | COM-002] Devolve todas as encomendas guardadas no Repository.
        public List<Encomenda> Listar()
        {
            return _repository.Listar();
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-003] Valida, calcula o total e insere uma nova encomenda.
        public void Inserir(Encomenda encomenda)
        {
            Validar(encomenda);
            CalcularTotal(encomenda);
            _repository.Inserir(encomenda);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-004] Valida, recalcula o total e edita uma encomenda existente.
        public void Editar(Encomenda encomenda)
        {
            Validar(encomenda);
            CalcularTotal(encomenda);
            _repository.Editar(encomenda);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-005] Pede ao Repository para marcar uma encomenda como anulada.
        public void Anular(int id)
        {
            _repository.Anular(id);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-006] Soma apenas o valor das encomendas ativas.
        public decimal TotalFaturado()
        {
            return _repository.Listar()
                .Where(e => !e.Anulada)
                .Sum(e => e.Total);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-007] Conta apenas as encomendas que não foram anuladas.
        public int TotalEncomendasAtivas()
        {
            return _repository.Listar()
                .Count(e => !e.Anulada);
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-008] Garante que a encomenda tem os dados obrigatórios.
        private void Validar(Encomenda encomenda)
        {
            if (string.IsNullOrWhiteSpace(encomenda.Telefone))
                throw new Exception("O contacto telefónico é obrigatório.");

            if (string.IsNullOrWhiteSpace(encomenda.Nif))
                throw new Exception("O contribuinte/NIF é obrigatório para emitir fatura.");

            if (encomenda.QuantidadeBacon == 0 && encomenda.QuantidadeTofu == 0)
                throw new Exception("A encomenda tem de ter pelo menos uma pizza Bacon ou Tofu.");
        }

        // [LOCALIZADOR: EncomendaService.cs | COM-009] Calcula o total usando os preços fixos das pizzas Bacon e Tofu.
        private void CalcularTotal(Encomenda encomenda)
        {
            encomenda.Total =
                encomenda.QuantidadeBacon * PrecoBacon +
                encomenda.QuantidadeTofu * PrecoTofu;
        }
    }
}
