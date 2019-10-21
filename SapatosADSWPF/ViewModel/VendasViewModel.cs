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
    public class VendasViewModel
    {

        public ObservableCollection<Sapato> Sapatos { get; set; }
        public ObservableCollection<Pessoa> Clientes { get; set; }
        public Sapato SapatoSelecionado { get; set; }
        public Pessoa ClienteSelecionado { get; set; }
        public Venda Carrinho { get; set; }
        private SapatosModel context { get; set; }

        public VendasViewModel()
        {
            context = new SapatosModel();

            // Recuperando lista de Pessoas e Sapatos da base
            this.Sapatos = new ObservableCollection<Sapato>(context.Sapatos.Include("Modelo").ToList());

            this.Clientes = new ObservableCollection<Pessoa>(context.Pessoas.ToList());

            this.SapatoSelecionado = context.Sapatos.FirstOrDefault();
            this.ClienteSelecionado = context.Pessoas.FirstOrDefault();


            if(this.Carrinho is null)
            {
                this.Carrinho = new Venda();

                this.Carrinho.Sapatos = new ObservableCollection<Sapato>();
            }
            

        }

        public void Adicionar()
        {
            
            // Como o Sapatos é um observable nao precisa adicionar manualmente
            this.Carrinho.Sapatos.Add(SapatoSelecionado);

            this.Carrinho.Pessoa = this.ClienteSelecionado;


        }

        public void Remover()
        {
            this.Carrinho.Sapatos.Remove(SapatoSelecionado);
        }

        public void Salvar()
        {

            this.Carrinho.DataVenda = DateTime.Now;

            this.Carrinho.QtdItems = this.Carrinho.Sapatos.Count;

            Decimal precoVenda = 0M;

            foreach (var item in Carrinho.Sapatos)
            {
                precoVenda += item.Preco;
            }

            this.Carrinho.Preco = precoVenda;

            this.context.Vendas.Add(Carrinho);
            this.context.SaveChanges();
        }

    }
}
