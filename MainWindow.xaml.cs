using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using BaconreUs.BLL;
using BaconreUs.Models;

namespace BaconreUs
{
    // [LOCALIZADOR: MainWindow.xaml.cs | COM-001] Esta classe controla a janela principal e responde aos cliques nos botões.
    public partial class MainWindow : Window
    {
        // [LOCALIZADOR: MainWindow.xaml.cs | COM-002] Este objeto chama a camada de regras de negócio para listar, guardar, editar e anular encomendas.
        private readonly EncomendaService _service = new EncomendaService();

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-003] Esta variável guarda o Id da encomenda que está a ser editada; quando está null, significa que é uma encomenda nova.
        private int? _idEmEdicao = null;

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-004] O construtor é executado quando a janela abre.
        public MainWindow()
        {
            // [LOCALIZADOR: MainWindow.xaml.cs | COM-005] InitializeComponent cria na memória todos os botões, caixas de texto e tabela definidos no XAML.
            InitializeComponent();

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-006] Estas linhas usam o formato português para mostrar valores em euros, como 624,00 €.
            CultureInfo.CurrentCulture = new CultureInfo("pt-PT");
            CultureInfo.CurrentUICulture = new CultureInfo("pt-PT");
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-007] Quando a janela abre, a tabela é carregada com as encomendas guardadas na lista em memória.
            AtualizarLista();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-008] Este método corre quando o utilizador clica no botão Guardar.
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // [LOCALIZADOR: MainWindow.xaml.cs | COM-009] Aqui o programa cria um objeto Encomenda com os dados escritos no formulário.
                var encomenda = new Encomenda
                {
                    // [LOCALIZADOR: MainWindow.xaml.cs | COM-010] Se estiver a editar, usa o Id existente; se for nova encomenda, usa zero.
                    Id = _idEmEdicao ?? 0,
                    Telefone = txtTelefone.Text.Trim(),
                    Nif = txtNif.Text.Trim(),
                    QuantidadeBacon = LerInteiro(txtQtdBacon.Text),
                    QuantidadeTofu = LerInteiro(txtQtdTofu.Text)
                };

                // [LOCALIZADOR: MainWindow.xaml.cs | COM-011] Se não existe Id em edição, o programa insere uma encomenda nova.
                if (_idEmEdicao == null)
                {
                    _service.Inserir(encomenda);
                    MessageBox.Show("Encomenda inserida com sucesso.");
                }
                else
                {
                    // [LOCALIZADOR: MainWindow.xaml.cs | COM-012] Se existe Id em edição, o programa altera a encomenda selecionada.
                    _service.Editar(encomenda);
                    MessageBox.Show("Encomenda editada com sucesso.");
                }

                // [LOCALIZADOR: MainWindow.xaml.cs | COM-013] Depois de guardar, o formulário é limpo e a tabela é atualizada.
                LimparFormulario();
                AtualizarLista();
            }
            catch (Exception ex)
            {
                // [LOCALIZADOR: MainWindow.xaml.cs | COM-014] Se houver erro de validação, a mensagem aparece ao utilizador.
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-015] Este método corre quando o utilizador clica no botão Anular.
        private void Anular_Click(object sender, RoutedEventArgs e)
        {
            // [LOCALIZADOR: MainWindow.xaml.cs | COM-016] Antes de anular, o programa confirma se existe uma encomenda selecionada na tabela.
            if (dgEncomendas.SelectedItem is not Encomenda encomenda)
            {
                MessageBox.Show("Selecione uma encomenda para anular.");
                return;
            }

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-017] Esta linha pede à camada de regras para anular a encomenda escolhida.
            _service.Anular(encomenda.Id);

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-018] Depois de anular, o formulário é limpo e os dados da tela são atualizados.
            LimparFormulario();
            AtualizarLista();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-019] Este método corre quando o utilizador clica no botão Nova.
        private void Nova_Click(object sender, RoutedEventArgs e)
        {
            // [LOCALIZADOR: MainWindow.xaml.cs | COM-020] Limpa os campos para o utilizador poder escrever outra encomenda.
            LimparFormulario();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-021] Este método corre quando o utilizador escolhe uma linha da tabela.
        private void DgEncomendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // [LOCALIZADOR: MainWindow.xaml.cs | COM-022] Se nenhuma encomenda estiver selecionada, o método termina sem fazer nada.
            if (dgEncomendas.SelectedItem is not Encomenda encomenda)
                return;

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-023] Os dados da encomenda selecionada são colocados nos campos para poderem ser editados.
            _idEmEdicao = encomenda.Id;
            txtTelefone.Text = encomenda.Telefone;
            txtNif.Text = encomenda.Nif;
            txtQtdBacon.Text = encomenda.QuantidadeBacon.ToString();
            txtQtdTofu.Text = encomenda.QuantidadeTofu.ToString();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-024] Este método recarrega a tabela e o resumo mostrado no fundo da janela.
        private void AtualizarLista()
        {
            // [LOCALIZADOR: MainWindow.xaml.cs | COM-025] ItemsSource liga a lista de encomendas à tabela visual.
            dgEncomendas.ItemsSource = _service.Listar();

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-026] Este texto mostra o total faturado e a quantidade de encomendas ativas.
            txtResumo.Text =
                $"Total de vendas faturado: {_service.TotalFaturado():C} | " +
                $"Quantidade de encomendas ativas: {_service.TotalEncomendasAtivas()}";
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-027] Este método apaga os dados do formulário e tira a seleção da tabela.
        private void LimparFormulario()
        {
            _idEmEdicao = null;
            txtTelefone.Text = "";
            txtNif.Text = "";
            txtQtdBacon.Text = "0";
            txtQtdTofu.Text = "0";
            dgEncomendas.SelectedItem = null;
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-028] Este método transforma o texto escrito numa quantidade numérica válida.
        private int LerInteiro(string texto)
        {
            // [LOCALIZADOR: MainWindow.xaml.cs | COM-029] Se o texto não for número inteiro ou for negativo, o programa mostra erro.
            if (!int.TryParse(texto, out int valor) || valor < 0)
                throw new Exception("As quantidades devem ser números inteiros positivos ou zero.");

            // [LOCALIZADOR: MainWindow.xaml.cs | COM-030] Se o número for válido, ele é devolvido para ser usado na encomenda.
            return valor;
        }
    }
}
