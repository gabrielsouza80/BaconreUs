# Explicação do Projeto BaconreUs

## 1. O que é este projeto?

Este projeto é uma aplicação simples para registar encomendas de pizzas. A pizzaria vende apenas dois tipos de pizza: Bacon e Tofu.

Para a entrega, o projeto pode ser apresentado como `BaconReUs_WPF_3Tier`, porque usa WPF e está organizado em camadas.

Na aplicação, o utilizador escreve o telefone do cliente, o NIF, a quantidade de pizzas Bacon e a quantidade de pizzas Tofu. Depois pode guardar a encomenda, editar uma encomenda já existente, anular uma encomenda e ver a lista de encomendas.

A aplicação também mostra duas informações dinâmicas: o total faturado e a quantidade de encomendas ativas.

## 2. Alteração pedida pelo professor

Inicialmente o enunciado mencionava SQLite, mas o professor indicou para esquecer SQLite.

Por isso, esta versão da aplicação não usa SQLite, não usa JSON e não usa ficheiros.

JSON também não foi usado porque não era necessário para a prova e iria complicar a explicação.

Em vez disso, a aplicação usa uma `List<Encomenda>` em memória. Esta lista funciona como um armazenamento temporário durante a execução do programa.

Esta solução foi escolhida para manter o projeto simples, conforme a orientação dada pelo professor.

Isto significa que as encomendas ficam disponíveis enquanto a aplicação está aberta. Quando o programa fecha, os dados desaparecem, porque não estamos a usar base de dados nem ficheiro.

Mesmo sem SQLite, a estrutura 3 Tier continua a existir.

## 3. O que é WPF?

WPF é a tecnologia usada para criar a parte visual da aplicação em Windows.

Neste projeto, WPF é usado para criar a janela, os botões, as caixas de texto, a tabela e a zona de resumo.

Os valores monetários são apresentados em euros no formato português, por exemplo `624,00 €`.

## 4. O que é C#?

C# é a linguagem de programação usada para escrever as instruções do programa.

É com C# que o programa sabe o que deve acontecer quando o utilizador clica em Guardar, Nova ou Anular.

## 5. O que é uma List em memória?

Uma `List<Encomenda>` é uma lista dentro do próprio programa.

Pode ser imaginada como uma folha temporária onde o programa escreve as encomendas enquanto está aberto.

Como esta lista está apenas em memória, ela não grava os dados no disco. Por isso, quando a aplicação fecha, a lista é apagada.

## 6. O que significa 3 Tier neste projeto?

O projeto continua dividido em camadas para ficar organizado e fácil de explicar.

- Interface:
  É a parte visual, onde o utilizador escreve os dados e clica nos botões. Fica em `MainWindow.xaml` e `MainWindow.xaml.cs`.

- Service:
  É a parte que verifica os dados, calcula os valores e organiza as ações. Fica em `BLL/EncomendaService.cs`.

- Repository:
  É a parte que guarda as encomendas numa lista. Fica em `DAL/EncomendaRepository.cs`.

- Model:
  É a classe que representa uma encomenda. Fica em `Models/Encomenda.cs`.

Uma analogia simples:

- A interface é como o balcão da pizzaria.
- O service é como o funcionário que verifica o pedido e calcula o preço.
- O repository é como uma folha temporária onde as encomendas são anotadas enquanto a pizzaria está aberta.
- O model é como a ficha da encomenda, com telefone, NIF, quantidades, total e estado.

## Palavras simples de programação

- `class`: é como um molde para organizar informações e ações.
- `public`: significa que aquela parte pode ser usada por outras partes do programa.
- `private`: significa que aquela parte só pode ser usada dentro do próprio arquivo/classe.
- `static`: significa que aquela informação pertence à classe e continua igual para todos os objetos daquela classe.
- `readonly`: significa que a variável não deve trocar para outra lista depois de criada.
- `void`: significa que aquela ação faz alguma coisa, mas não devolve um resultado.
- `string`: é um texto, como telefone ou NIF.
- `int`: é um número inteiro, como a quantidade de pizzas.
- `decimal`: é um número usado para dinheiro, porque aceita casas decimais.
- `bool`: é um valor verdadeiro ou falso.
- `List`: é uma lista com vários itens.
- `método`: é uma ação que o programa sabe fazer.
- `objeto`: é uma coisa criada a partir de uma classe.
- `propriedade`: é uma informação guardada dentro de um objeto.
- `construtor`: é uma parte da classe que corre quando o objeto é criado.

## 7. Explicação dos arquivos

### App.xaml

#### Para que serve este arquivo?

Este arquivo diz ao WPF qual é a primeira janela que deve abrir quando a aplicação começa.

#### Explicação das partes principais

- [LOCALIZADOR: App.xaml | COM-001]
  Mostra que este arquivo configura o início da aplicação WPF.

- [LOCALIZADOR: App.xaml | COM-002]
  Explica que `StartupUri="MainWindow.xaml"` abre a janela principal primeiro.

- [LOCALIZADOR: App.xaml | COM-003]
  Mostra onde poderiam ficar estilos ou recursos visuais comuns, caso o projeto precisasse.

### App.xaml.cs

#### Para que serve este arquivo?

Este arquivo representa a aplicação WPF no lado do C#.

#### Explicação das partes principais

- [LOCALIZADOR: App.xaml.cs | COM-001]
  Mostra a classe principal da aplicação.

- [LOCALIZADOR: App.xaml.cs | COM-002]
  Explica que a classe está vazia porque o projeto é simples e não precisa de código especial no arranque.

### MainWindow.xaml

#### Para que serve este arquivo?

Este arquivo cria a parte visual da janela principal. Aqui ficam os textos, caixas, botões, tabela e resumo.

#### Explicação das partes principais

- [LOCALIZADOR: MainWindow.xaml | COM-001]
  Mostra que esta é a janela principal da aplicação.

- [LOCALIZADOR: MainWindow.xaml | COM-002] até [LOCALIZADOR: MainWindow.xaml | COM-008]
  Explicam a organização visual da janela. O `Grid` divide a tela em zonas: título, formulário, tabela e resumo.

- [LOCALIZADOR: MainWindow.xaml | COM-009] até [LOCALIZADOR: MainWindow.xaml | COM-016]
  Explicam os campos onde o utilizador escreve telefone, NIF, quantidade de Bacon e quantidade de Tofu.

- [LOCALIZADOR: MainWindow.xaml | COM-017] até [LOCALIZADOR: MainWindow.xaml | COM-021]
  Explicam os botões Nova, Guardar e Anular, e o texto com os preços das pizzas.

- [LOCALIZADOR: MainWindow.xaml | COM-022] até [LOCALIZADOR: MainWindow.xaml | COM-030]
  Explicam a tabela de encomendas. Cada coluna mostra uma parte da encomenda: Id, telefone, NIF, quantidades, total em euros e estado.

- [LOCALIZADOR: MainWindow.xaml | COM-031] e [LOCALIZADOR: MainWindow.xaml | COM-032]
  Explicam a zona do resumo, onde aparecem o total faturado e a quantidade de encomendas ativas.

### MainWindow.xaml.cs

#### Para que serve este arquivo?

Este arquivo controla os acontecimentos da janela. Por exemplo, quando o utilizador clica num botão, é este arquivo que responde.

#### Explicação das partes principais

- [LOCALIZADOR: MainWindow.xaml.cs | COM-001]
  Mostra a classe que controla a janela principal.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-002] e [LOCALIZADOR: MainWindow.xaml.cs | COM-003]
  Explicam duas variáveis importantes: `_service`, que chama as regras de negócio, e `_idEmEdicao`, que sabe se estamos a criar ou editar.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-004] até [LOCALIZADOR: MainWindow.xaml.cs | COM-007]
  Explicam o arranque da janela: cria os elementos visuais, define formato português para euros e carrega a lista.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-008] até [LOCALIZADOR: MainWindow.xaml.cs | COM-014]
  Explicam o botão Guardar. O programa lê os campos, cria uma encomenda, decide se deve inserir ou editar, limpa o formulário e atualiza a tabela.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-015] até [LOCALIZADOR: MainWindow.xaml.cs | COM-018]
  Explicam o botão Anular. O programa confirma se existe uma encomenda selecionada e muda o estado dela para anulada.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-019] e [LOCALIZADOR: MainWindow.xaml.cs | COM-020]
  Explicam o botão Nova, que limpa os campos.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-021] até [LOCALIZADOR: MainWindow.xaml.cs | COM-023]
  Explicam o que acontece quando o utilizador seleciona uma linha da tabela: os dados aparecem no formulário para edição.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-024] até [LOCALIZADOR: MainWindow.xaml.cs | COM-026]
  Explicam como a tabela e o resumo são atualizados.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-027]
  Explica como o formulário é limpo.

- [LOCALIZADOR: MainWindow.xaml.cs | COM-028] até [LOCALIZADOR: MainWindow.xaml.cs | COM-030]
  Explicam como o programa transforma o texto das quantidades em números inteiros válidos.

### Models/Encomenda.cs

#### Para que serve este arquivo?

Este arquivo define o que é uma encomenda dentro do programa.

#### Explicação das partes principais

- [LOCALIZADOR: Encomenda.cs | COM-001]
  Explica que a classe `Encomenda` é o molde dos dados da encomenda.

- [LOCALIZADOR: Encomenda.cs | COM-002] até [LOCALIZADOR: Encomenda.cs | COM-008]
  Explicam cada informação guardada: Id, telefone, NIF, quantidade Bacon, quantidade Tofu, total e se está anulada.

- [LOCALIZADOR: Encomenda.cs | COM-009]
  Explica a propriedade `Estado`, que mostra "Ativa" ou "Anulada" na tabela.

### BLL/EncomendaService.cs

#### Para que serve este arquivo?

Este arquivo é a camada Service. Ele valida os dados, calcula valores e chama o Repository.

#### Explicação das partes principais

- [LOCALIZADOR: EncomendaService.cs | COM-001]
  Mostra que esta classe representa as regras de negócio.

- [LOCALIZADOR: EncomendaService.cs | COM-002] e [LOCALIZADOR: EncomendaService.cs | COM-003]
  Explicam os preços fixos das pizzas: Bacon custa 10 euros e Tofu custa 9 euros.

- [LOCALIZADOR: EncomendaService.cs | COM-004]
  Explica que o `EncomendaRepository` é usado para guardar e procurar encomendas sem misturar isso com as regras.

- [LOCALIZADOR: EncomendaService.cs | COM-005]
  Explica o método que lista as encomendas.

- [LOCALIZADOR: EncomendaService.cs | COM-006] até [LOCALIZADOR: EncomendaService.cs | COM-010]
  Explicam como inserir e editar: primeiro valida, depois calcula o total, depois guarda.

- [LOCALIZADOR: EncomendaService.cs | COM-011]
  Explica como a encomenda é anulada.

- [LOCALIZADOR: EncomendaService.cs | COM-012] até [LOCALIZADOR: EncomendaService.cs | COM-015]
  Explicam os cálculos do resumo: total faturado e quantidade de encomendas ativas.

- [LOCALIZADOR: EncomendaService.cs | COM-016] até [LOCALIZADOR: EncomendaService.cs | COM-019]
  Explicam as validações: telefone obrigatório, NIF obrigatório e pelo menos uma pizza.

- [LOCALIZADOR: EncomendaService.cs | COM-020] e [LOCALIZADOR: EncomendaService.cs | COM-021]
  Explicam o cálculo do total da encomenda.

### DAL/EncomendaRepository.cs

#### Para que serve este arquivo?

Este arquivo é a camada Repository. Ele guarda, lista, edita e anula encomendas usando uma `List<Encomenda>`.

#### Explicação das partes principais

- [LOCALIZADOR: EncomendaRepository.cs | COM-001]
  Explica que esta classe é a camada de dados em memória.

- [LOCALIZADOR: EncomendaRepository.cs | COM-002]
  Explica que a lista guarda dados enquanto o programa está aberto.

- [LOCALIZADOR: EncomendaRepository.cs | COM-003]
  Explica o número usado para criar o próximo Id automático.

- [LOCALIZADOR: EncomendaRepository.cs | COM-004] e [LOCALIZADOR: EncomendaRepository.cs | COM-005]
  Explicam a listagem das encomendas.

- [LOCALIZADOR: EncomendaRepository.cs | COM-006] até [LOCALIZADOR: EncomendaRepository.cs | COM-010]
  Explicam a inserção de uma encomenda nova na lista.

- [LOCALIZADOR: EncomendaRepository.cs | COM-011] até [LOCALIZADOR: EncomendaRepository.cs | COM-014]
  Explicam a edição de uma encomenda existente.

- [LOCALIZADOR: EncomendaRepository.cs | COM-015] até [LOCALIZADOR: EncomendaRepository.cs | COM-017]
  Explicam a anulação. A encomenda não é apagada; apenas fica com `Anulada = true`.

### BaconreUs.csproj

#### Para que serve este arquivo?

Este arquivo configura o projeto para o Visual Studio e para o .NET.

#### Explicação das partes principais

- [LOCALIZADOR: BaconreUs.csproj | COM-001]
  Explica que este arquivo controla a compilação do projeto.

- [LOCALIZADOR: BaconreUs.csproj | COM-002] até [LOCALIZADOR: BaconreUs.csproj | COM-006]
  Explicam que o projeto é uma aplicação WPF para Windows, feita em .NET 8.

- [LOCALIZADOR: BaconreUs.csproj | COM-007]
  Explica que o projeto não usa pacotes externos, porque não usa SQLite nem JSON.

## Como explicar ao professor

Professor, este projeto é uma aplicação WPF feita em C#. Ela serve para registar encomendas da pizzaria Bacon're Us. A pizzaria vende dois tipos de pizza: Bacon e Tofu.

Inicialmente o enunciado mencionava SQLite, mas depois foi indicado para esquecer SQLite. Por isso, nesta versão, a aplicação não usa base de dados, não usa JSON e não usa ficheiros. Ela guarda as encomendas numa `List<Encomenda>` em memória.

Na tela principal, o utilizador escreve o telefone, o NIF e a quantidade de cada pizza. Depois clica em Guardar. A encomenda fica guardada temporariamente na lista enquanto o programa está aberto.

O projeto continua dividido em camadas. A primeira camada é a Interface, onde ficam os botões, campos e tabela. A segunda camada é o Service, onde o programa valida os dados e calcula o total. A terceira camada é o Repository, onde as encomendas são guardadas numa lista. O Model representa os dados de uma encomenda.

A aplicação também mostra uma tabela com as encomendas e uma área de resumo, onde aparece o total faturado e o número de encomendas ativas.

A anulação não apaga a encomenda da lista. Ela apenas muda o estado da encomenda para anulada. O total faturado e a quantidade de encomendas ativas só consideram encomendas que não estão anuladas.

Quando o programa fecha, os dados desaparecem, porque a lista está apenas em memória.

## Explicação dos botões da aplicação

- Guardar
  Quando o utilizador clica em Guardar, o programa lê os dados do formulário. Se for uma encomenda nova, insere na lista. Se o utilizador selecionou uma encomenda da tabela, o botão guarda a edição dessa encomenda.

- Nova
  Quando o utilizador clica em Nova, o programa limpa os campos e prepara a tela para escrever uma nova encomenda.

- Anular
  Quando o utilizador seleciona uma encomenda e clica em Anular, o programa muda o estado dessa encomenda para anulada. Ela continua na lista, mas deixa de contar como encomenda ativa e deixa de entrar no total faturado.

- Atualizar/Listar
  Não existe um botão separado com esse nome. A lista é atualizada automaticamente quando o programa abre, quando guarda uma encomenda e quando anula uma encomenda.

## Explicação do armazenamento em memória

1. Onde as encomendas são guardadas.

As encomendas são guardadas no arquivo `DAL/EncomendaRepository.cs`, dentro de uma `List<Encomenda>`.

2. O que é a lista.

A lista é uma coleção de encomendas. Cada encomenda é um objeto da classe `Encomenda`.

3. Que campos existem numa encomenda.

- `Id`
- `Telefone`
- `Nif`
- `QuantidadeBacon`
- `QuantidadeTofu`
- `Total`
- `Anulada`
- `Estado`

4. O que significa cada campo.

- `Id`: número único de cada encomenda.
- `Telefone`: contacto telefónico do cliente.
- `Nif`: contribuinte do cliente.
- `QuantidadeBacon`: quantidade de pizzas Bacon.
- `QuantidadeTofu`: quantidade de pizzas Tofu.
- `Total`: preço total da encomenda.
- `Anulada`: indica se a encomenda foi anulada. `false` significa ativa. `true` significa anulada.
- `Estado`: texto que mostra "Ativa" ou "Anulada" na tabela.

5. Como o programa insere uma encomenda.

O utilizador escreve os dados e clica em Guardar. O `MainWindow.xaml.cs` cria uma `Encomenda`. O `EncomendaService.cs` valida os dados e calcula o total. Depois o `EncomendaRepository.cs` adiciona a encomenda à lista com `Add`.

6. Como o programa edita uma encomenda.

O utilizador seleciona uma linha da tabela. Os dados aparecem no formulário. Depois o utilizador altera os valores e clica em Guardar. O programa usa o `Id` da encomenda para encontrar o item na lista e copia os novos dados para ele.

7. Como o programa anula uma encomenda.

O utilizador seleciona uma encomenda e clica em Anular. O programa encontra a encomenda na lista e muda `Anulada` para `true`. A encomenda não é apagada.

8. Como o programa calcula o total faturado.

O programa lista as encomendas, escolhe apenas as que não estão anuladas e soma o campo `Total`.

9. Como o programa calcula a quantidade de encomendas ativas.

O programa lista as encomendas e conta apenas as que não estão anuladas.

## Checklist da prova

- [ ] O projeto abre no Visual Studio
- [ ] O projeto compila sem erros
- [ ] A aplicação abre uma janela WPF
- [ ] Existe estrutura em 3 Tier
- [ ] Não usa SQLite
- [ ] Não usa JSON
- [ ] Não usa ficheiros para guardar encomendas
- [ ] Usa `List<Encomenda>` em memória
- [ ] Permite inserir encomendas
- [ ] Permite listar encomendas
- [ ] Permite editar encomendas
- [ ] Permite anular encomendas
- [ ] A anulação não apaga a encomenda
- [ ] Mostra o total faturado apenas com encomendas ativas
- [ ] Mostra o número de encomendas ativas
- [ ] O código está comentado em português
- [ ] Os comentários têm localizadores
- [ ] Existe o documento EXPLICACAO_CODIGO.md
- [ ] O documento explica o projeto para iniciantes
- [ ] O documento tem uma explicação pronta para apresentar ao professor
