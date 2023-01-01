using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacoes
{
    public partial class FrmMenu1 : Form
    {
        public FrmMenu1()
        {
            InitializeComponent();
        }

        private void FrmMenu1_Load(object sender, EventArgs e)
        {

        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            FrmClientSelect frmClientSelectfrm = new FrmClientSelect();
            frmClientSelectfrm.MdiParent= this;
            frmClientSelectfrm.Show();
        }
    }
}
