# BaconReUs - WPF 3 Tier

Este projeto é uma aplicação simples em WPF e C# para gerir encomendas da pizzaria Bacon're Us.

A aplicação permite:

- Inserir encomendas;
- Listar encomendas;
- Editar encomendas;
- Anular encomendas;
- Ver o total faturado;
- Ver a quantidade de encomendas ativas.

O projeto usa estrutura 3 Tier:

- Interface: janela WPF;
- BLL: regras de negócio;
- DAL: repositório com `List<Encomenda>`;
- Model: classe `Encomenda`.

Não usa SQLite.
Não usa JSON.
Não usa ficheiros.

Os dados ficam apenas em memória durante a execução do programa.

## Como abrir

1. Abrir o Visual Studio.
2. Escolher **Open a project or solution**.
3. Abrir o ficheiro `BaconreUs.csproj`.
4. Clicar em **Run**.

## Preços usados

- Pizza Bacon: 10 euros
- Pizza Tofu: 9 euros
