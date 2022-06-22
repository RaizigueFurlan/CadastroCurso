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
using MySql.Data.MySqlClient;
using ProjetoEscola.Database;
using ProjetoEscola.Models;

namespace ProjetoEscola.Views
{
    /// <summary>
    /// Interaction logic for CadastroCurso.xaml
    /// </summary>
    public partial class CadastroCurso : Window
    {
        private Curso _curso = new Curso();
        public CadastroCurso()
        {
            InitializeComponent();
            //Loaded += CadastroCurso_Loaded;
        }

        public CadastroCurso(Curso curso)
        {
            InitializeComponent();
            Loaded += CadastroCurso_Loaded;
            _curso = curso;
        }

        private void CadastroCurso_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeCurso.Text = _curso.NomeCurso;
            txtCargaHoraria.Text = _curso.CargaHoraria;
            txtDescricaoCurso.Text = _curso.Descricao;
            cbTurno.Text = _curso.Turno;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _curso.NomeCurso = txtNomeCurso.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Descricao = txtDescricaoCurso.Text;
            _curso.Turno = cbTurno.Text;

            try
            {
                var dao = new CursoDAO();
                if (_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Registro atualizado com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //ListagemCurso listagem = new ListagemCurso();
            //listagem.ShowDialog();

            txtCargaHoraria.Clear();
            txtDescricaoCurso.Clear();
            txtNomeCurso.Clear();
            cbTurno.SelectedIndex = -1;
        }
    }
}