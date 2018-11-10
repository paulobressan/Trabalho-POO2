using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.dao;
using WpfApp.model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProdutoDAO _produtoDAO;
        public MainWindow()
        {
            InitializeComponent();
            _produtoDAO = new ProdutoDAO();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListarProdutos();
            ControleBtn(true);
        }

        private void ListarProdutos()
        {
            var produtos = _produtoDAO.Listar();
            gridLista.ItemsSource = produtos;
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            ControleBtn(false);
            AtivarInativarTxt(true);
            txtNome.Focus();
        }

        private void AtivarInativarTxt(bool status)
        {
            txtNome.IsEnabled = status;
            txtDescricao.IsEnabled = status;
            txtQuantidade.IsEnabled = status;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ControleBtn(true);
            _produtoDAO.Inserir(new Produto(txtNome.Text, txtDescricao.Text, Convert.ToInt16(txtQuantidade.Text)));
            ListarProdutos();
            LimparCampos();
            txtNome.Focus();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtQuantidade.Clear();
        }

        private void ControleBtn(bool status)
        {
            btnNovo.IsEnabled = status;
            btnSalvar.IsEnabled = !status;
        }
    }
}
