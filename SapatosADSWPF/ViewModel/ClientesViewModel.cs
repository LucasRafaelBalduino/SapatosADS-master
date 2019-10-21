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
    public class ClientesViewModel
    {
        public ObservableCollection<Pessoa> Clientes { get; set; }
        public Pessoa ClienteSelecionado { get; set; }
        private SapatosModel context { get; set; }

        public Boolean PodeRemover
        {
            get
            {
                return this.ClienteSelecionado != null;
            }
        }

        /* Constructor */
        public ClientesViewModel()
        {
            context = new SapatosModel();

            this.Clientes = new ObservableCollection<Pessoa>(context.Pessoas.ToList());
            this.ClienteSelecionado = context.Pessoas.FirstOrDefault();
        }

        public void Salvar()
        {
            this.context.SaveChanges();
        }

        public void Adicionar(String PessoaTipo)
        {
            Pessoa pessoa;

            if (PessoaTipo == "PessoaFisica")
            {
                pessoa = new PessoaFisica();
            } else
            {
                pessoa = new PessoaJuridica();
            }

            this.Clientes.Add(pessoa);
            this.context.Pessoas.Add(pessoa);
            this.ClienteSelecionado = pessoa;
        }

        public void Remover()
        {
            if (this.ClienteSelecionado.Id != 0)
            {
                this.context.Pessoas.Remove(this.ClienteSelecionado);
            }

            this.Clientes.Remove(this.ClienteSelecionado);
        }
    }
}
