using System.Collections.Generic;
using System.Linq;
using BaconreUs.Models;

namespace BaconreUs.DAL
{
    // [LOCALIZADOR: EncomendaRepository.cs | COM-001] Camada DAL: guarda e procura encomendas numa lista em memória.
    public class EncomendaRepository
    {
        // [LOCALIZADOR: EncomendaRepository.cs | COM-002] Esta lista é temporária: os dados desaparecem quando a aplicação fecha.
        private static readonly List<Encomenda> Encomendas = new List<Encomenda>();

        private static int ProximoId = 1;

        // [LOCALIZADOR: EncomendaRepository.cs | COM-003] Lista as encomendas mais recentes primeiro.
        public List<Encomenda> Listar()
        {
            return Encomendas
                .OrderByDescending(encomenda => encomenda.Id)
                .ToList();
        }

        // [LOCALIZADOR: EncomendaRepository.cs | COM-004] Adiciona uma nova encomenda à lista em memória.
        public void Inserir(Encomenda encomenda)
        {
            encomenda.Id = ProximoId;
            ProximoId++;
            encomenda.Anulada = false;

            Encomendas.Add(encomenda);
        }

        // [LOCALIZADOR: EncomendaRepository.cs | COM-005] Altera uma encomenda ativa já existente.
        public void Editar(Encomenda encomenda)
        {
            var encomendaExistente = Encomendas
                .FirstOrDefault(item => item.Id == encomenda.Id && !item.Anulada);

            if (encomendaExistente == null)
                return;

            encomendaExistente.Telefone = encomenda.Telefone;
            encomendaExistente.Nif = encomenda.Nif;
            encomendaExistente.QuantidadeBacon = encomenda.QuantidadeBacon;
            encomendaExistente.QuantidadeTofu = encomenda.QuantidadeTofu;
            encomendaExistente.Total = encomenda.Total;
        }

        // [LOCALIZADOR: EncomendaRepository.cs | COM-006] Anula a encomenda sem apagar da lista.
        public void Anular(int id)
        {
            var encomenda = Encomendas.FirstOrDefault(item => item.Id == id);

            if (encomenda != null)
                encomenda.Anulada = true;
        }
    }
}
