using SapatosADS.Model;
using SapatosADSWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica interna para SapatosWindow.xaml
    /// </summary>
    public partial class SapatosWindow : Window
    {

        public SapatosViewModel SapatosViewModel { get; set; }
        public SapatosWindow()
        {
            InitializeComponent();
            this.SapatosViewModel = new SapatosViewModel();
            DataContext = this.SapatosViewModel;
        }

        private void txtTamanho_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox t = (TextBox)sender;
            string filter = t.Text;

            SapatosViewModel.filterList(filter);

            dataGridSapatos.ItemsSource = SapatosViewModel.SapatosFiltered;
        }

        private void btnSalvar_(object sender, RoutedEventArgs e)
        {
            SapatosViewModel.Salvar();

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            SapatosViewModel.Adicionar();

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            SapatosViewModel.Remover();
        }
        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
