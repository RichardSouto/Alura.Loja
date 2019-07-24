using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente()
            {
                Nome = "Richard",
                Endereco = new Endereco()
                {
                    Numero = 12,
                    Logradouro = "Avenida River",
                    Complemento = "Fundos",
                    Bairro = "Ponte Alta",
                    Cidade = "Guarulhos",
                    Estado = "São Paulo"
                }

            };

            using (var context = new LojaContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }


        }

        private static void PopulandoPromocao()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocao = new Promocao();
            promocao.Descricao = "Páscoa Feliz";
            promocao.DataInicio = DateTime.Now;
            promocao.DataTermino = DateTime.Now.AddMonths(3);

            promocao.IncluirProduto(p1);
            promocao.IncluirProduto(p2);
            promocao.IncluirProduto(p3);

            using (var context = new LojaContext())
            {
                context.Promocoes.Add(promocao);
                context.SaveChanges();
            }
        }

        private static void TesteCompraXProduto()
        {
            //Comprar paes franceses
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.4;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);

                contexto.SaveChanges();
            }
        }

        private static void AtualizarProduto()
        {
            //Incluir um produto para ter um de exemplo na utilização
            GravarUsandoEntity();
            RecuperarProdutos();

            //Atualizar Produto
            using (var contexto = new ProdutoDAOEntity())
            {
                Produto produto = contexto.Produtos().First();
                produto.Nome = $"{produto.Nome} Editado!";
                contexto.Atualizar(produto);
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach (var item in produtos)
                {
                    repo.Remover(item);
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine($"{produtos.Count()} produto(s) encontrado(s) na lista.");
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAOEntity())
            {
                repo.Adicionar(p);
            }
        }
    }
}
