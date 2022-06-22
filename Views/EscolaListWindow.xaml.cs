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
using MySql.Data.MySqlClient;
using ProjetoEscola.Database;
using ProjetoEscola.Views;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EscolaListWindow : Window
    {
        public EscolaListWindow()
        {
            InitializeComponent();
        }

        private void btChamarCadastroEscola_Click(object sender, RoutedEventArgs e)
        {
            CadastroEscola cadastro = new CadastroEscola();
            cadastro.ShowDialog();
            //this.Close();
        }

        private void btChamarCadastroCurso_Click(object sender, RoutedEventArgs e)
        {
            CadastroCurso cadastro = new CadastroCurso();
            cadastro.ShowDialog();
            //this.Close();
        }

        private void btChamarListagemEscola_Click(object sender, RoutedEventArgs e)
        {
            ListEscola listagem = new ListEscola();
            listagem.ShowDialog();
        }

        private void btChamarListagemCurso_Click(object sender, RoutedEventArgs e)
        {
            ListagemCurso listagem = new ListagemCurso();
            listagem.ShowDialog();
        }
    }
}