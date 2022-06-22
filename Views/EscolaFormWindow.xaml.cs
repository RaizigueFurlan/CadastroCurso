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
    /// Lógica interna para CadastroEscola.xaml
    /// </summary>
    public partial class CadastroEscola : Window
    {
        private Escola _escola = new Escola();

        public CadastroEscola()
        {
            InitializeComponent();
            Loaded += CadastroEscola_Loaded;
        }

        public CadastroEscola(Escola escola)
        {
            InitializeComponent();
            Loaded += CadastroEscola_Loaded;
            _escola = escola;
        }

        private void CadastroEscola_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeFantasia.Text = _escola.NomeFantasia;
            txtCnpj.Text = _escola.Cnpj;
            txtRazaoSocial.Text = _escola.RazaoSocial;
            txtInscricaoEst.Text = _escola.InscricaoEst;
            txtNomeResp.Text = _escola.NomeResp;
            txtTelefoneResp.Text = _escola.TelefoneResp;
            txtTelefoneEscola.Text = _escola.TelefoneEscola;
            txtEmail.Text = _escola.Email;
            txtRua.Text = _escola.Rua;
            txtNumero.Text = _escola.Numero.ToString();
            txtBairro.Text = _escola.Bairro;
            txtComplemento.Text = _escola.Complemento;
            txtCep.Text = _escola.Cep;
            txtCidade.Text = _escola.Cidade;
            cbEstado.Text = _escola.Estado;
            dpDataCriacao.SelectedDate = _escola.DataCriacao;
            if (_escola.Tipo == "Publica")
            {
                rdPublica.IsChecked = true;
            }
            else
            {
                rdPrivada.IsChecked = true;
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _escola.NomeFantasia = txtNomeFantasia.Text;
            _escola.Cnpj = txtCnpj.Text;
            _escola.RazaoSocial = txtRazaoSocial.Text;
            _escola.InscricaoEst = txtInscricaoEst.Text;
            _escola.NomeResp = txtNomeResp.Text;
            _escola.TelefoneResp = txtTelefoneResp.Text;
            _escola.TelefoneEscola = txtTelefoneEscola.Text;
            _escola.Email = txtEmail.Text;
            _escola.Rua = txtRua.Text;
            _escola.Numero = Convert.ToInt32(txtNumero.Text);
            _escola.Bairro = txtBairro.Text;
            _escola.Complemento = txtComplemento.Text;
            _escola.Cep = txtCep.Text;
            _escola.Cidade = txtCidade.Text;
            _escola.Estado = cbEstado.Text;
            _escola.DataCriacao = dpDataCriacao.SelectedDate;
            bool rdTipo = rdPublica.IsChecked == true;
            _escola.SetTipo(rdTipo);
            try
            {
                var dao = new EscolaDAO();
                if (_escola.Id > 0)
                {
                    dao.Update(_escola);
                    MessageBox.Show("Registro inserido com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    dao.Insert(_escola);
                    MessageBox.Show("Registro atualizado com sucesso!", "PDS - 2º Bimestre", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtNomeFantasia.Clear();
            txtCnpj.Clear();
            txtRazaoSocial.Clear();
            txtInscricaoEst.Clear();
            txtNomeResp.Clear();
            txtTelefoneResp.Clear();
            txtTelefoneEscola.Clear();
            txtEmail.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            cbEstado.SelectedIndex = -1;
            dpDataCriacao.SelectedDate = null;
            rdPrivada.IsChecked = false;
            rdPublica.IsChecked = false;

            //ListagemEscola listagem = new ListagemEscola();
            //listagem.ShowDialog();
        }

        private void txtComplemento_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}