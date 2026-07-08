# Explicação do Projeto BaconReUs_WPF_3Tier

## 1. O que é este projeto?

Este projeto é uma aplicação simples em WPF e C# para gerir encomendas da pizzaria Bacon're Us.

A pizzaria vende dois tipos de pizza:

- Bacon
- Tofu

O utilizador pode inserir encomendas, listar encomendas, editar encomendas, anular encomendas e ver um resumo com o total faturado e o número de encomendas ativas.

## 2. Alteração indicada pelo professor

Inicialmente o enunciado mencionava SQLite, mas o professor indicou para esquecer SQLite.

Por isso, o projeto:

- não usa SQLite;
- não usa JSON;
- não usa ficheiros para guardar encomendas.

As encomendas ficam numa `List<Encomenda>` em memória. Isto significa que os dados existem enquanto o programa está aberto. Quando o programa fecha, os dados são perdidos.

Esta escolha mantém o projeto mais simples e mais fácil de explicar.

## 3. Estrutura 3 Tier

O projeto mantém uma estrutura em camadas:

- Interface:
  Fica em `MainWindow.xaml` e `MainWindow.xaml.cs`. É a parte visual da aplicação.

- BLL / Service:
  Fica em `BLL/EncomendaService.cs`. Valida os dados, calcula totais e chama o Repository.

- DAL / Repository:
  Fica em `DAL/EncomendaRepository.cs`. Guarda, lista, edita e anula encomendas numa lista em memória.

- Model:
  Fica em `Models/Encomenda.cs`. Representa os dados de uma encomenda.

Analogia simples:

- A Interface é o balcão da pizzaria.
- O Service é o funcionário que verifica o pedido.
- O Repository é uma folha temporária onde as encomendas ficam apontadas.
- O Model é a ficha de cada encomenda.

## 4. Palavras importantes

- `class`: é um molde para organizar dados e ações.
- `string`: é texto.
- `int`: é um número inteiro.
- `decimal`: é usado para valores com casas decimais, como dinheiro.
- `bool`: é verdadeiro ou falso.
- `List`: é uma lista de vários itens.
- `método`: é uma ação que o programa executa.
- `propriedade`: é uma informação guardada numa classe.

## 5. Explicação dos arquivos

### App.xaml

#### Para que serve?

Define o arranque da aplicação WPF.

#### Localizador principal

- [LOCALIZADOR: App.xaml | COM-001]
  Indica que a aplicação começa pela janela `MainWindow`.

### App.xaml.cs

#### Para que serve?

Representa a aplicação WPF no lado do C#.

#### Localizador principal

- [LOCALIZADOR: App.xaml.cs | COM-001]
  Mostra a classe principal da aplicação.

### MainWindow.xaml

#### Para que serve?

Cria a parte visual da janela principal: campos, botões, tabela e resumo.

#### Localizadores principais

- [LOCALIZADOR: MainWindow.xaml | COM-001]
  Janela principal da aplicação.

- [LOCALIZADOR: MainWindow.xaml | COM-002]
  Formulário onde o utilizador escreve telefone, NIF e quantidades.

- [LOCALIZADOR: MainWindow.xaml | COM-003]
  Botões principais: Nova, Guardar e Anular.

- [LOCALIZADOR: MainWindow.xaml | COM-004]
  Tabela onde aparecem as encomendas guardadas.

- [LOCALIZADOR: MainWindow.xaml | COM-005]
  Resumo final com total faturado e encomendas ativas.

### MainWindow.xaml.cs

#### Para que serve?

Controla as ações da janela. Quando o utilizador clica num botão ou seleciona uma linha da tabela, este arquivo responde.

#### Localizadores principais

- [LOCALIZADOR: MainWindow.xaml.cs | COM-001]
  Mostra que esta classe pertence à Interface WPF e chama o Service.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-002]
  Inicia a janela, define o formato português para euros e carrega a lista.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-003]
  Guarda uma encomenda nova ou edita uma encomenda selecionada.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-004]
  Anula uma encomenda selecionada sem a apagar.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-005]
  Limpa o formulário para criar uma nova encomenda.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-006]
  Carrega os dados da linha selecionada para o formulário, permitindo edição.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-007]
  Atualiza a tabela e o resumo.

### Models/Encomenda.cs

#### Para que serve?

Representa uma encomenda no programa.

#### Localizadores principais

- [LOCALIZADOR: Encomenda.cs | COM-001]
  Mostra que a classe `Encomenda` é o Model da aplicação.

- [LOCALIZADOR: Encomenda.cs | COM-002]
  Mostra o texto do estado da encomenda: `Ativa` ou `Anulada`.

### BLL/EncomendaService.cs

#### Para que serve?

É a camada de regras de negócio. Valida dados, calcula totais e envia as ações para o Repository.

#### Localizadores principais

- [LOCALIZADOR: EncomendaService.cs | COM-001]
  Identifica a camada BLL.

- [LOCALIZADOR: EncomendaService.cs | COM-002]
  Lista encomendas.

- [LOCALIZADOR: EncomendaService.cs | COM-003]
  Insere uma encomenda depois de validar e calcular o total.

- [LOCALIZADOR: EncomendaService.cs | COM-004]
  Edita uma encomenda depois de validar e recalcular o total.

- [LOCALIZADOR: EncomendaService.cs | COM-005]
  Anula uma encomenda.

- [LOCALIZADOR: EncomendaService.cs | COM-006]
  Calcula o total faturado usando apenas encomendas ativas.

- [LOCALIZADOR: EncomendaService.cs | COM-007]
  Conta apenas encomendas ativas.

- [LOCALIZADOR: EncomendaService.cs | COM-008]
  Valida telefone, NIF e quantidade de pizzas.

- [LOCALIZADOR: EncomendaService.cs | COM-009]
  Calcula o preço total da encomenda.

### DAL/EncomendaRepository.cs

#### Para que serve?

É a camada de dados. Neste projeto, ela não usa base de dados. Guarda as encomendas numa lista em memória.

#### Localizadores principais

- [LOCALIZADOR: EncomendaRepository.cs | COM-001]
  Identifica a camada DAL.

- [LOCALIZADOR: EncomendaRepository.cs | COM-002]
  Explica que a lista é temporária e desaparece ao fechar a aplicação.

- [LOCALIZADOR: EncomendaRepository.cs | COM-003]
  Lista as encomendas.

- [LOCALIZADOR: EncomendaRepository.cs | COM-004]
  Insere uma encomenda na lista.

- [LOCALIZADOR: EncomendaRepository.cs | COM-005]
  Edita uma encomenda ativa.

- [LOCALIZADOR: EncomendaRepository.cs | COM-006]
  Anula uma encomenda sem apagar da lista.

### BaconreUs.csproj

#### Para que serve?

Configura o projeto .NET/WPF.

#### Localizador principal

- [LOCALIZADOR: BaconreUs.csproj | COM-001]
  Mostra que o projeto é WPF simples e não usa pacotes externos.

## 6. Explicação dos botões

- Guardar:
  Insere uma nova encomenda ou guarda alterações de uma encomenda selecionada.

- Nova:
  Limpa os campos para criar uma nova encomenda.

- Anular:
  Muda a encomenda selecionada para `Anulada`. A encomenda continua na lista.

## 7. Como funciona a anulação

A anulação não apaga a encomenda.

O programa apenas muda a propriedade `Anulada` para `true`.

Assim, a encomenda continua visível na tabela, mas deixa de contar para:

- total faturado;
- quantidade de encomendas ativas.

## 8. Como funciona o total faturado

O total faturado soma apenas encomendas ativas.

As encomendas anuladas ficam fora do cálculo.

Os valores aparecem em euros no formato português, por exemplo:

`624,00 €`

## 9. Como explicar ao professor

Professor, este projeto é uma aplicação WPF feita em C# para gerir encomendas da pizzaria Bacon're Us.

A aplicação permite inserir, listar, editar e anular encomendas de pizzas Bacon e Tofu.

O projeto está organizado em camadas. A Interface é a janela WPF. A BLL valida os dados e calcula os totais. A DAL guarda as encomendas numa lista em memória. O Model representa os dados de uma encomenda.

O professor indicou para não usar SQLite, por isso o projeto não usa base de dados, JSON ou ficheiros. As encomendas ficam guardadas apenas enquanto o programa está aberto.

Quando uma encomenda é anulada, ela não é apagada. Apenas muda o estado para `Anulada`. O total faturado e a quantidade de encomendas ativas consideram apenas encomendas que não foram anuladas.

## 10. Checklist da prova

- [ ] O projeto compila sem erros
- [ ] A aplicação abre uma janela WPF
- [ ] Existe estrutura 3 Tier
- [ ] Não usa SQLite
- [ ] Não usa JSON
- [ ] Não usa ficheiros para guardar dados
- [ ] Usa `List<Encomenda>` em memória
- [ ] Permite inserir encomendas
- [ ] Permite listar encomendas
- [ ] Permite editar encomendas
- [ ] Permite anular encomendas
- [ ] A anulação não apaga a encomenda
- [ ] Mostra o total faturado em euros
- [ ] Mostra o número de encomendas ativas
- [ ] O código tem comentários simples nas partes principais
- [ ] Os comentários importantes têm localizadores
