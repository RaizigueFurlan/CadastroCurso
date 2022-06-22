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
using System.Windows.Shapes;
using ProjetoEscola.Models;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Interaction logic for ListagemCurso.xaml
    /// </summary>
    public partial class ListagemCurso : Window
    {
        public ListagemCurso()
        {
            InitializeComponent();
            Loaded += ListagemCurso_Loaded;
        }

        public void ListagemCurso_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new CursoDAO();
                List<Curso> listarCursos = dao.List();

                dataGridCurso.ItemsSource = listarCursos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha na listagem");
            }
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelecionado = dataGridCurso.SelectedItem as Curso;
            var resultado = MessageBox.Show($"Deseja realmente excluir \"{cursoSelecionado.NomeCurso}\" dos registros?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);


            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new CursoDAO();
                    dao.Delete(cursoSelecionado);

                    MessageBox.Show("Registro Removido com Sucesso!", "PDS - 2022", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                CarregarListagem();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelect = dataGridCurso.SelectedItem as Curso;
            var form = new CadastroCurso(cursoSelect);
            form.ShowDialog();
        }
    }
}
