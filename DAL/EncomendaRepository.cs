using System.Collections.Generic;
using System.Linq;
using BaconreUs.Models;

namespace BaconreUs.DAL
{
    // [LOCALIZADOR: EncomendaRepository.cs | COM-001] Esta classe é a camada de dados e guarda as encomendas numa lista em memória.
    public class EncomendaRepository
    {
        // [LOCALIZADOR: EncomendaRepository.cs | COM-002] Esta lista guarda as encomendas enquanto o programa está aberto.
        private static readonly List<Encomenda> Encomendas = new List<Encomenda>();

        // [LOCALIZADOR: EncomendaRepository.cs | COM-003] Este número ajuda a criar um Id diferente para cada nova encomenda.
        private static int ProximoId = 1;

        // [LOCALIZADOR: EncomendaRepository.cs | COM-004] Este método devolve as encomendas guardadas, mostrando as mais recentes primeiro.
        public List<Encomenda> Listar()
        {
            // [LOCALIZADOR: EncomendaRepository.cs | COM-005] ToList cria uma cópia da lista para a interface poder mostrar os dados.
            return Encomendas
                .OrderByDescending(encomenda => encomenda.Id)
                .ToList();
        }

        // [LOCALIZADOR: EncomendaRepository.cs | COM-006] Este método adiciona uma encomenda nova à lista em memória.
        public void Inserir(Encomenda encomenda)
        {
            // [LOCALIZADOR: EncomendaRepository.cs | COM-007] A encomenda recebe um Id automático para poder ser identificada depois.
            encomenda.Id = ProximoId;

            // [LOCALIZADOR: EncomendaRepository.cs | COM-008] O próximo Id aumenta para a próxima encomenda não repetir o mesmo número.
            ProximoId++;

            // [LOCALIZADOR: EncomendaRepository.cs | COM-009] A encomenda começa como ativa, porque ainda não foi anulada.
            encomenda.Anulada = false;

            // [LOCALIZADOR: EncomendaRepository.cs | COM-010] Add coloca a encomenda dentro da lista em memória.
            Encomendas.Add(encomenda);
        }

        // [LOCALIZADOR: EncomendaRepository.cs | COM-011] Este método altera os dados de uma encomenda que já existe na lista.
        public void Editar(Encomenda encomenda)
        {
            // [LOCALIZADOR: EncomendaRepository.cs | COM-012] FirstOrDefault procura a encomenda pelo Id e ignora encomendas anuladas.
            var encomendaExistente = Encomendas
                .FirstOrDefault(item => item.Id == encomenda.Id && !item.Anulada);

            // [LOCALIZADOR: EncomendaRepository.cs | COM-013] Se a encomenda não existir ou estiver anulada, o método termina sem alterar nada.
            if (encomendaExistente == null)
                return;

            // [LOCALIZADOR: EncomendaRepository.cs | COM-014] Estas linhas copiam os novos dados para a encomenda que já estava na lista.
            encomendaExistente.Telefone = encomenda.Telefone;
            encomendaExistente.Nif = encomenda.Nif;
            encomendaExistente.QuantidadeBacon = encomenda.QuantidadeBacon;
            encomendaExistente.QuantidadeTofu = encomenda.QuantidadeTofu;
            encomendaExistente.Total = encomenda.Total;
        }

        // [LOCALIZADOR: EncomendaRepository.cs | COM-015] Este método anula uma encomenda sem a remover da lista.
        public void Anular(int id)
        {
            // [LOCALIZADOR: EncomendaRepository.cs | COM-016] O programa procura a encomenda pelo Id recebido.
            var encomenda = Encomendas.FirstOrDefault(item => item.Id == id);

            // [LOCALIZADOR: EncomendaRepository.cs | COM-017] Se encontrar a encomenda, muda o estado para anulada.
            if (encomenda != null)
                encomenda.Anulada = true;
        }
    }
}
