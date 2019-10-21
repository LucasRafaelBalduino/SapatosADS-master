using SapatosADS.Model;
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
    /// Lógica interna para VendasClientesWindow.xaml
    /// </summary>
    public partial class VendasClientesWindow : Window
    {
        public VendasClientesViewModel VendasClientesViewModel { get; set; }

        public VendasClientesWindow()
        {
            InitializeComponent();
            this.VendasClientesViewModel = new VendasClientesViewModel();
            DataContext = this.VendasClientesViewModel;

            // cmbClientes.ItemsSource = typeof(Cliente)
        }

        private void dataGridVendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox obj = sender as ComboBox;

            Pessoa cliente = null;

            int clientid = 0;
 
            if(obj.SelectedItem.GetType().Name == "PessoaFisica")
            {
                
                cliente = new PessoaFisica();
                
                cliente = (PessoaFisica) obj.SelectedItem;
                clientid = cliente.Id;
            } else if(obj.SelectedItem.GetType().Name == "PessoaJuridica")
            {
                cliente = new PessoaJuridica();
                cliente = (PessoaJuridica)obj.SelectedItem;
                clientid = cliente.Id;
            }


            VendasClientesViewModel.filterListSapatos(clientid);
            dataGridVendas.ItemsSource = VendasClientesViewModel.VendasFiltered;
        }
    }
}
