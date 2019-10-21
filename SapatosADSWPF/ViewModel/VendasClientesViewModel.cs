using SapatosADS;
using SapatosADS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapatosADSWPF.ViewModel
{
    public class VendasClientesViewModel
    {

        public ObservableCollection<Venda> Vendas { get; set; }
        
        public ObservableCollection<Pessoa> Clientes { get; set; }

        public ObservableCollection<Venda> VendasFiltered { get; set; }

        public Venda SelectedVenda { get; set; }

        private SapatosModel context { get; set; }


        public VendasClientesViewModel()
        {
            context = new SapatosModel();

            // Recupera lista do context e adicionar no objeto Venda
            Vendas = new ObservableCollection<Venda>(context.Vendas);


            
            Clientes = new ObservableCollection<Pessoa>(context.Pessoas);

            
            if (VendasFiltered is null)
            {
                // Usado para o filtro de sapatos, esta dando erro no método filter list.
                VendasFiltered = new ObservableCollection<Venda>();
            }

        }

        public void filterListSapatos(int id)
        {
            // Not Working but I'm still thinking on what to do
            VendasFiltered = Vendas;

            if (id != 0)
            {

                VendasFiltered = new ObservableCollection<Venda>(
                    from venda in VendasFiltered
                    where venda.Pessoa.Id == id
                    select venda);



            }

            this.VendasFiltered = VendasFiltered;



        }
    }
}
