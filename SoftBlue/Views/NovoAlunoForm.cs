using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftBlue.Views;
using SoftBlue.Models;
using SoftBlue.Controller;

namespace SoftBlue.Views
{
    public partial class NovoAlunoForm : Form
    {
        public NovoAlunoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno
            {
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Email = txtEmail.Text
            };

            AlunoInseridoView alunoInserido = new AlunoInseridoView(AlunoController.Insert(aluno));

            this.Dispose();
        }
    }
}
