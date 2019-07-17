using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Promocao
    {
        public string Descricao { get; internal set; }
        public object DataInicio { get; internal set; }
        public DateTime DataTermino { get; internal set; }
        public IList<Produto> Produtos { get; internal set; }
    }
}