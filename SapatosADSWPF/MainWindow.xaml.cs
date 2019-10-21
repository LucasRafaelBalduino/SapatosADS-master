using SapatosADSWPF.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SapatosADSWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SapatosMenu_Click(object sender, RoutedEventArgs e)
        {
            Window window = new SapatosWindow();
            window.ShowDialog();
        }

        private void VendasMenu_Click(object sender, RoutedEventArgs e)
        {
            Window window = new VendasWindow();
            window.ShowDialog();
        }

        private void ClientesMenu_Click(object sender, RoutedEventArgs e)
        {
            Window window = new ClientesWindow();
            window.ShowDialog();
        }

        private void VendasClientesMenu_Click(object sender, RoutedEventArgs e)
        {
            Window window = new VendasClientesWindow();
            window.ShowDialog();
        }
    }
}
