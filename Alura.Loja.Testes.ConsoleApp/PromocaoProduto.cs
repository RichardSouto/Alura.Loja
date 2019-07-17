using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class PromocaoProduto
    {
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }
        public int PromocaoID { get; set; }
        public Promocao Promocao { get; set; }
    }
}
