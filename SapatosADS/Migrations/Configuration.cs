namespace SapatosADS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using SapatosADS.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<SapatosADS.SapatosModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SapatosADS.SapatosModel context)
        {

            IList<Modelo> modelos = new List<Modelo>();

            modelos.Add(new Modelo() { Id = 1, Nome = "Teste 1" });
            modelos.Add(new Modelo() { Id = 2, Nome = "Teste 2" });
            modelos.Add(new Modelo() { Id = 3, Nome = "Teste 3" });
            modelos.Add(new Modelo() { Id = 4, Nome = "Teste 4" });
            modelos.Add(new Modelo() { Id = 5, Nome = "Teste 5" });


            IList<Sapato> sapatos = new List<Sapato>();

            sapatos.Add(new Sapato() { Id = 1, Modelo = modelos[0], Material = "Tecido", Cadarco = true, Cor = "Amarelo", Preco = 98, Tamanho = 37 });
            sapatos.Add(new Sapato() { Id = 2, Modelo = modelos[1], Material = "Algodão", Cadarco = false, Cor = "Azul", Preco = 110, Tamanho = 42 });
            sapatos.Add(new Sapato() { Id = 3, Modelo = modelos[1], Material = "Tecido", Cadarco = false, Cor = "Branco", Preco = 180, Tamanho = 39 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });
            sapatos.Add(new Sapato() { Id = 4, Modelo = modelos[3], Material = "Poliester", Cadarco = true, Cor = "Verde", Preco = 89, Tamanho = 44 });


            IList<PessoaFisica> pessoasFisica = new List<PessoaFisica>();

            pessoasFisica.Add(new PessoaFisica() { Id = 1, Nome = "Cliente 1", Endereco = "Rua teste00000", Cpf = "0000000000", DataNascimento = DateTime.Today.AddYears(-28) });
            pessoasFisica.Add(new PessoaFisica() { Id = 1, Nome = "Cliente 2", Endereco = "Rua teste00000, 1001", Cpf = "00000000000", DataNascimento = DateTime.Today.AddYears(-32) });
            pessoasFisica.Add(new PessoaFisica() { Id = 1, Nome = "Cliente 3", Endereco = "Rua teste00000", Cpf = "000000000", DataNascimento = DateTime.Today.AddYears(-56) });


            IList<PessoaJuridica> pessoasJuridica = new List<PessoaJuridica>();

            pessoasJuridica.Add(new PessoaJuridica() { Id = 1, Nome = "Juridica 1", Endereco = "Rua teste00000, 121", RazaoSocial = "Razao Social teste 007", Cnpj = "00001222323232789" });
            pessoasJuridica.Add(new PessoaJuridica() { Id = 2, Nome = "Juridica 2", Endereco = "Rua teste00000, 121", RazaoSocial = "Razao Social teste 007", Cnpj = "0000123456789" });
            pessoasJuridica.Add(new PessoaJuridica() { Id = 3, Nome = "Juridica 3", Endereco = "Rua teste00000, 121", RazaoSocial = "Razao Social teste 007", Cnpj = "0000987654321" });

            IList<Venda> vendas = new List<Venda>();

            IList<Sapato> listaSapatosVenda1 = new List<Sapato>() { sapatos[0], sapatos[1] };
            IList<Sapato> listaSapatosVenda2 = new List<Sapato>() { sapatos[0], sapatos[1], sapatos[2], sapatos[3] };

            vendas.Add(new Venda() { Id = 1, QtdItems = 2, Preco = 209.10M, DataVenda = DateTime.Now.AddDays(-2), Pessoa = pessoasFisica[1], Sapatos = listaSapatosVenda1 });
            vendas.Add(new Venda() { Id = 2, QtdItems = 4, Preco = 488.90M, DataVenda = DateTime.Now.AddDays(-1), Pessoa = pessoasJuridica[2], Sapatos = listaSapatosVenda2 });

            foreach (Modelo modelo in modelos)
                context.Modelos.AddOrUpdate(modelo);

            foreach (Sapato sapato in sapatos)
                context.Sapatos.AddOrUpdate(sapato);

            foreach (PessoaFisica pessoaFisica in pessoasFisica)
                context.Pessoas.AddOrUpdate(pessoaFisica);

            foreach (PessoaJuridica pessoaJuridica in pessoasJuridica)
                context.Pessoas.AddOrUpdate(pessoaJuridica);

            foreach (Venda venda in vendas)
                context.Vendas.AddOrUpdate(venda);

        }
    }
}
