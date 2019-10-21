using SapatosADSWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SapatosADSWPF.View
{
    /// <summary>
    /// Lógica interna para VendasWindow.xaml
    /// </summary>
    public partial class VendasWindow : Window
    {

        public VendasViewModel VendasViewModel { get; set; }
        public VendasWindow()
        {
            InitializeComponent();
            this.VendasViewModel = new VendasViewModel();
            DataContext = this.VendasViewModel;
        }

        private void AdicionarCarrinho_Click(object sender, RoutedEventArgs e)
        {
            VendasViewModel.Adicionar();
            dataGridSapatos.ItemsSource = VendasViewModel.Carrinho.Sapatos;
            PessoasDataGrid.IsEnabled = false;

        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            VendasViewModel.Remover();
            dataGridSapatos.ItemsSource = VendasViewModel.Carrinho.Sapatos;
            
        }

        private void FinalizarCompra_Click(object sender, RoutedEventArgs e)
        {
            VendasViewModel.Salvar();
            this.Close();
        }

        private void CancelarCompra_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
