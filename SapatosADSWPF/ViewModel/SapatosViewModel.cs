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
    public class SapatosViewModel
    {

        public ObservableCollection<Sapato> Sapatos { get; set; }
        public ObservableCollection<Sapato> SapatosFiltered { get; set; }

        public Sapato SapatoSelecionado { get; set; }

        private SapatosModel context { get; set; }


        public SapatosViewModel()
        {
            this.context = new SapatosModel();

            this.Sapatos = new ObservableCollection<Sapato>(context.Sapatos.Include("Modelo"));

            if (SapatosFiltered is null)
            {

                this.SapatosFiltered = new ObservableCollection<Sapato>();
                this.SapatosFiltered = Sapatos;
            }

            Salvar();


        }

        public void filterList(String TxtTamanho)
        {
            // Not Working but I'm still thinking on what to do
            SapatosFiltered = Sapatos;

            if (!String.IsNullOrEmpty(TxtTamanho))
            {

                int TamanhoInt = Convert.ToInt32(TxtTamanho);

                SapatosFiltered = new ObservableCollection<Sapato>(
                    from sapato in SapatosFiltered
                    where sapato.Tamanho == TamanhoInt
                    select sapato);


            
            } 

            this.SapatosFiltered = SapatosFiltered;
            


        }
        public void Salvar()
        {
            this.context.SaveChanges();
        }
        public void Adicionar()
        {
            Sapato sapato = new SapatosADS.Model.Sapato();
            
            this.Sapatos.Add(sapato);
            this.context.Sapatos.Add(sapato);
            this.SapatoSelecionado = sapato;

        }

        public void Remover()
        {
            Sapato sapato = new SapatosADS.Model.Sapato();

            this.Sapatos.Remove(sapato);


        }




    }
}
