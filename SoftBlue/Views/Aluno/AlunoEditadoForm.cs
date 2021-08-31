using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftBlue.Models;

namespace SoftBlue.Views
{
    public partial class AlunoEditadoForm : Form
    {
        public AlunoEditadoForm(Aluno aluno)
        {
            InitializeComponent();
            this.SetInGrid(aluno);
        }
        private void SetInGrid(Aluno aluno)
        {
            dataGridView1.Rows.Add(new object[] {
                aluno.Codigo,
                aluno.Nome,
                aluno.Endereco,
                aluno.Email
            });

            this.dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
