﻿using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; internal set; }
        public IList<PromocaoProduto> Promocoes { get; set; }
        public IList<Compra> Compras { get; internal set; }

        public override string ToString()
        {
            return $"Produto: {this.Id}, {this.Nome}, {this.Categoria}, {this.PrecoUnitario}";
        }
    }
}