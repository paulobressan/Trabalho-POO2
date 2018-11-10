using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.model;

namespace WpfApp.dao
{
    public class ProdutoDAO
    {
        private readonly Contexto _contexto;
        public ProdutoDAO()
        {
            _contexto = new Contexto();
        }
        public List<Produto> Listar()
        {
            try
            {
                return _contexto.Produtos.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao listar produtos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                throw;
            }
        }

        public Produto Inserir(Produto produto)
        {
            try
            {
                var novoProduto = _contexto.Produtos.Add(produto);
                _contexto.SaveChanges();
                MessageBox.Show("Produto cadastrado com sucesso!", "Erro", MessageBoxButton.OK, MessageBoxImage.Information);
                return novoProduto;
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao cadastrar produto!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                throw;
            }

        }
    }
}
