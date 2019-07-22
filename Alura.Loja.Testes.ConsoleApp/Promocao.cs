using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Promocao
    {
        public int Id { get; internal set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataTermino { get; internal set; }
        public IList<PromocaoProduto> Produtos { get; internal set; }

        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        internal void IncluirProduto(Produto produto)
        {
            this.Produtos.Add(new PromocaoProduto() { Produto = produto });
        }
    }
}