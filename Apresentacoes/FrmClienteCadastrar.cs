using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObejtoTransferencia;
using Negocios;

namespace Apresentacoes
{
    public partial class FrmClienteCadastrar : Form
    {
        ScreenAction Screenactionselect;
        public FrmClienteCadastrar(ScreenAction screenAction, Cliente cliente)
        {
            InitializeComponent();
            this.Screenactionselect = screenAction;
            if(screenAction== ScreenAction.Inserir)
            {
                this.Text = "Inserir Cliente";
            }
            else if(screenAction== ScreenAction.Alterar)
            {
                this.Text = "Alterar Cliente";
                textBoxCodigo.Text = cliente.IdCliente.ToString();
                textBoxNome.Text= cliente.nome.ToString();
                dateDataNascimento.Value = cliente.DataNascimento.ToLocalTime();
                if(cliente.Sexo == true)
                    radioButtonSexoMasc.Checked = true;
                else 
                    radioButtonSexoFem.Checked = true;
                textBoxLimiteCompra.Text=cliente.LimiteCompra.ToString(); 
                
            }
            else if(screenAction == ScreenAction.Consultar)
            {
                this.Text = "Consultar Cliente";

                textBoxCodigo.Text = cliente.IdCliente.ToString();
                textBoxNome.Text = cliente.nome.ToString();
                dateDataNascimento.Value = cliente.DataNascimento.ToLocalTime();
                if (cliente.Sexo == true)
                    radioButtonSexoMasc.Checked = true;
                else
                    radioButtonSexoFem.Checked = true;
                textBoxLimiteCompra.Text = cliente.LimiteCompra.ToString();

                textBoxNome.ReadOnly= true;
                textBoxNome.TabStop= false;

                dateDataNascimento.Enabled= false;
                
                radioButtonSexoMasc.Enabled= false; 
                radioButtonSexoFem.Enabled= false;

                textBoxLimiteCompra.ReadOnly= true;
                textBoxLimiteCompra.TabStop= false;

                buttonSalvar.Visible= false;
                buttonCancelar.Text= "Fechar";

                buttonCancelar.Focus();
            }
       
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if(Screenactionselect == ScreenAction.Inserir)
            {
                Cliente cliente= new Cliente();
                cliente.nome = textBoxNome.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                 

                if (radioButtonSexoMasc.Checked == true)
                    cliente.Sexo = true;
                else
                    cliente.Sexo = false;

                cliente.LimiteCompra=Convert.ToDecimal(textBoxLimiteCompra.Text);

                

                ClienteNegocios clienteNegocios= new ClienteNegocios();
                
               string retorno= clienteNegocios.Inserir(cliente);

                try
                {
                    int IdCliente = Convert.ToInt32(retorno);

                    MessageBox.Show("Cliente inserido com sucesso. Código: " + IdCliente.ToString());
                    this.DialogResult = DialogResult.Yes;
                }
                catch
                {
                    MessageBox.Show("Não foi possivel inserir. Detalhes: " + retorno, "Erro de inserir seus dados",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;

                }
            }
            else if(Screenactionselect == ScreenAction.Alterar)
                
            {
                Cliente cliente = new Cliente();
                cliente.nome = textBoxNome.Text;
                cliente.DataNascimento = dateDataNascimento.Value;

                cliente.IdCliente = Convert.ToInt32(textBoxCodigo.Text);

                if (radioButtonSexoMasc.Checked == true)
                    cliente.Sexo = true;
                else
                    cliente.Sexo = false;

                if (radioButtonSexoMasc.Checked == true)
                    cliente.Sexo = true;
                else
                    cliente.Sexo = false;

                cliente.LimiteCompra = Convert.ToDecimal(textBoxLimiteCompra.Text);

                ClienteNegocios clienteNegocios = new ClienteNegocios();

                string retorno = clienteNegocios.Alterar(cliente);

                try
                {
                    int IdCliente = Convert.ToInt32(retorno);

                    MessageBox.Show("Cliente alterado com sucesso. Código: " + IdCliente.ToString());
                    this.DialogResult = DialogResult.Yes;
                }
                catch
                {
                    MessageBox.Show("Não foi possivel alterar. Detalhes: " + retorno, "Erro de alterar seus dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;

                }
            }
        }

        private void dateDataNascimento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
