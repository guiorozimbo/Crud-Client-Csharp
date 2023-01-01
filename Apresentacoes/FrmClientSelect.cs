using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using ObejtoTransferencia;

namespace Apresentacoes
{
    public partial class FrmClientSelect : Form
    {
        public FrmClientSelect()
        {
            InitializeComponent();
            dataGridViewPrincipal.AutoGenerateColumns = false;
        }

        private void FrmClientSelect_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.");
                return;
            }
           
            Cliente clientSelect = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(ScreenAction.Alterar,clientSelect);
            DialogResult result= frmClienteCadastrar.ShowDialog();
            if(result== DialogResult.Yes) {
                AtualizarGrid();
                
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dataGridViewPrincipal.SelectedRows.Count==0){
                MessageBox.Show("Nenhum cliente selecionado.");
                return;
            }
            DialogResult dialogResult=MessageBox.Show("Tem certeza?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult== DialogResult.No)
            {
                return;
            }
            Cliente clientSelect = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);
            ClienteNegocios clienteNegocios = new ClienteNegocios();
           string retorno= clienteNegocios.Excluir(clientSelect);
            try
            {
                int IdCliente = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente excluído com sucesso","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizarGrid();
            }
            catch 
            {
                MessageBox.Show("Não foi possivel excluir. Detalhes: " + retorno,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)

        {
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.");
                return;
            }

            Cliente clientSelect = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(ScreenAction.Consultar,clientSelect);
            frmClienteCadastrar.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
          AtualizarGrid();
        }
        private void AtualizarGrid()
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();

            ClienteColecao clienteColecao = new ClienteColecao();
            clienteColecao = clienteNegocios.ConsultarPorNome(textDigite.Text);

            dataGridViewPrincipal.DataSource = null;
            dataGridViewPrincipal.DataSource = clienteColecao;

            dataGridViewPrincipal.Update();
            dataGridViewPrincipal.Refresh();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(ScreenAction.Inserir,null);
            DialogResult dialogResult= frmClienteCadastrar.ShowDialog();
            
            if(dialogResult == DialogResult.Yes)
            {
                AtualizarGrid();
            }

        }
    }
}
