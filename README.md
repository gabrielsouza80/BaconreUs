# BaconReUs_WPF_3Tier

## Sobre o projeto

O BaconReUs_WPF_3Tier é uma aplicação simples em WPF e C# para gerir encomendas da pizzaria Bacon're Us.

A aplicação permite registar encomendas de pizzas Bacon e Tofu, consultar a lista de encomendas, editar dados, anular encomendas e ver um resumo com o total faturado e a quantidade de encomendas ativas.

## Funcionalidades

- Inserir encomendas
- Listar encomendas
- Editar encomendas
- Anular encomendas
- Mostrar total faturado
- Mostrar quantidade de encomendas ativas

## Tecnologias usadas

- C#
- WPF
- .NET 8
- `List<Encomenda>` em memória
- Estrutura 3 Tier

## Estrutura 3 Tier

- Interface: `MainWindow.xaml` e `MainWindow.xaml.cs`
- BLL / Service: `BLL/EncomendaService.cs`
- DAL / Repository: `DAL/EncomendaRepository.cs`
- Model: `Models/Encomenda.cs`

A Interface é a parte visual da aplicação.  
A BLL contém as regras de negócio, como validações e cálculo de totais.  
A DAL guarda e gere as encomendas numa lista em memória.  
O Model representa os dados de uma encomenda.

O arquivo `BaconReUs.sln` permite abrir a solução completa no Visual Studio.

Na classe `Encomenda`, os dados são guardados internamente em campos privados. As propriedades públicas continuam disponíveis para a interface WPF conseguir mostrar os dados na tabela.

## Armazenamento dos dados

Os dados são guardados numa `List<Encomenda>` em memória, dentro do Repository.

Este projeto:

- Não usa SQLite
- Não usa JSON
- Não usa ficheiros

Como os dados ficam apenas em memória, as encomendas desaparecem quando a aplicação é fechada.

## Como executar o projeto

Abre o terminal dentro da pasta onde está o ficheiro `BaconreUs.csproj` e executa:

```powershell
dotnet run --project .\BaconreUs.csproj
```

Este é o comando principal para abrir a aplicação.

Se quiseres apenas compilar antes de executar, usa:

```powershell
dotnet build .\BaconreUs.csproj
```

Também é possível compilar pela solução:

```powershell
dotnet build .\BaconReUs.sln
```

## Como usar a aplicação

1. Escrever o telefone do cliente.
2. Escrever o NIF.
3. Indicar a quantidade de pizzas Bacon.
4. Indicar a quantidade de pizzas Tofu.
5. Clicar em **Guardar**.
6. Selecionar uma encomenda na tabela para editar.
7. Clicar em **Anular** para anular uma encomenda.
8. Ver o total faturado e a quantidade de encomendas ativas no resumo.

As encomendas anuladas continuam visíveis na tabela, mas não entram no total faturado nem na contagem de encomendas ativas.

## Preços usados

- Pizza Bacon: 10 €
- Pizza Tofu: 9 €

## Observação importante

O professor indicou para não usar SQLite. Por isso, foi usada uma `List<Encomenda>` em memória para manter o projeto simples e fácil de explicar.

Também não foi usado JSON, porque não era necessário para os requisitos pedidos.

## Checklist

- [x] Projeto em WPF
- [x] Projeto em C#
- [x] Estrutura 3 Tier
- [x] Inserção de encomendas
- [x] Listagem de encomendas
- [x] Edição de encomendas
- [x] Anulação de encomendas
- [x] Total faturado em euros
- [x] Quantidade de encomendas ativas
- [x] Sem SQLite
- [x] Sem JSON
- [x] Sem ficheiros de armazenamento
