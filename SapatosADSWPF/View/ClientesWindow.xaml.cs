using SapatosADS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SapatosADSWPF.View
{
    /// <summary>
    /// Lógica interna para ClientesWindow.xaml
    /// </summary>
    public partial class ClientesWindow : Window
    {

        public ViewModel.ClientesViewModel ClientesViewModel { get; set; }

        public ClientesWindow()
        {
            InitializeComponent();

            this.ClientesViewModel = new ViewModel.ClientesViewModel();
            this.DataContext = this;
        }
        
        private void PessoasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pessoa pessoa = ClientesViewModel.ClienteSelecionado;
            UserControl page = PessoaViewFactory.VisualizarPessoa(pessoa);

            while (PessoaContent.Children.Count > 0)
            {
                PessoaContent.Children.RemoveAt(0);
            }

            if (page != null)
            {
                PessoaContent.Children.Add(page);
            }

        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            this.ClientesViewModel.Salvar();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Adicionar_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(AdicionarPF_Button))
            {
                this.ClientesViewModel.Adicionar("PessoaFisica");
            } else
            {
                this.ClientesViewModel.Adicionar("PessoaJuridica");
            }
        }

        private void Remover_Button_Click(object sender, RoutedEventArgs e)
        {
            this.ClientesViewModel.Remover();
        }

    }

    public class PessoaViewFactory
    {
        public static UserControl VisualizarPessoa(Pessoa pessoa)
        {

            if (pessoa is PessoaFisica)
            {
                var pg = new PessoaFisicaUC();
                pg.Pessoa = (PessoaFisica)pessoa;

                return pg;
            }
            else if (pessoa is PessoaJuridica)
            {
                var pg = new PessoaJuridicaUC();
                pg.Pessoa = (PessoaJuridica)pessoa;

                return pg;
            }

            return null;
        }
    }
}
