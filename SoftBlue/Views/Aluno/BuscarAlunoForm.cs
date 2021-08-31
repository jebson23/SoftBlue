using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftBlue.Views
{
    public partial class BuscarAlunoForm : Form
    {
        public BuscarAlunoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            AlunoViewForm alunoView = new AlunoViewForm(codigo);

            this.Dispose();
        }
    }
}
