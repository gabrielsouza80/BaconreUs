using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using BaconreUs.BLL;
using BaconreUs.Models;

namespace BaconreUs
{
    // [LOCALIZADOR: MainWindow.xaml.cs | COM-001] Classe da interface WPF; recebe os dados do utilizador e chama a camada Service.
    public partial class MainWindow : Window
    {
        private readonly EncomendaService _service = new EncomendaService();
        private int? _idEmEdicao = null;

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-002] Inicia a janela, define o formato português para euros e carrega a lista.
        public MainWindow()
        {
            InitializeComponent();

            CultureInfo.CurrentCulture = new CultureInfo("pt-PT");
            CultureInfo.CurrentUICulture = new CultureInfo("pt-PT");
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            AtualizarLista();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-003] Guarda uma nova encomenda ou edita uma encomenda ativa selecionada.
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgEncomendas.SelectedItem is Encomenda selecionada && selecionada.Anulada)
                {
                    MessageBox.Show("Não é possível editar uma encomenda anulada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var encomenda = new Encomenda
                {
                    Id = _idEmEdicao ?? 0,
                    Telefone = txtTelefone.Text.Trim(),
                    Nif = txtNif.Text.Trim(),
                    QuantidadeBacon = LerInteiro(txtQtdBacon.Text),
                    QuantidadeTofu = LerInteiro(txtQtdTofu.Text)
                };

                if (_idEmEdicao == null)
                {
                    _service.Inserir(encomenda);
                    MessageBox.Show("Encomenda inserida com sucesso.");
                }
                else
                {
                    _service.Editar(encomenda);
                    MessageBox.Show("Encomenda editada com sucesso.");
                }

                LimparFormulario();
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-004] Anula a encomenda selecionada sem a apagar da lista.
        private void Anular_Click(object sender, RoutedEventArgs e)
        {
            if (dgEncomendas.SelectedItem is not Encomenda encomenda)
            {
                MessageBox.Show("Selecione uma encomenda para anular.");
                return;
            }

            if (encomenda.Anulada)
            {
                MessageBox.Show("Esta encomenda já está anulada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            _service.Anular(encomenda.Id);
            LimparFormulario();
            AtualizarLista();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-005] Limpa o formulário para começar uma nova encomenda.
        private void Nova_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-006] Quando uma linha é selecionada, coloca os dados no formulário.
        private void DgEncomendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgEncomendas.SelectedItem is not Encomenda encomenda)
                return;

            _idEmEdicao = encomenda.Id;
            txtTelefone.Text = encomenda.Telefone;
            txtNif.Text = encomenda.Nif;
            txtQtdBacon.Text = encomenda.QuantidadeBacon.ToString();
            txtQtdTofu.Text = encomenda.QuantidadeTofu.ToString();
        }

        // [LOCALIZADOR: MainWindow.xaml.cs | COM-007] Atualiza a tabela e o resumo com total faturado e encomendas ativas.
        private void AtualizarLista()
        {
            dgEncomendas.ItemsSource = _service.Listar();

            txtResumo.Text =
                $"Total de vendas faturado: {_service.TotalFaturado():C} | " +
                $"Quantidade de encomendas ativas: {_service.TotalEncomendasAtivas()}";
        }

        private void LimparFormulario()
        {
            _idEmEdicao = null;
            txtTelefone.Text = "";
            txtNif.Text = "";
            txtQtdBacon.Text = "0";
            txtQtdTofu.Text = "0";
            dgEncomendas.SelectedItem = null;
        }

        private int LerInteiro(string texto)
        {
            if (!int.TryParse(texto, out int valor) || valor < 0)
                throw new Exception("As quantidades devem ser números inteiros positivos ou zero.");

            return valor;
        }
    }
}
