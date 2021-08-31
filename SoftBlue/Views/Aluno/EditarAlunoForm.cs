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
using SoftBlue.Controller;

namespace SoftBlue.Views
{
    public partial class EditarAlunoForm : Form
    {
        private Aluno aluno;
        public EditarAlunoForm(Aluno aluno)
        {
            InitializeComponent();
            this.aluno = aluno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "") this.aluno.Nome = txtNome.Text;
            if (txtEndereco.Text != "") this.aluno.Endereco = txtEndereco.Text;
            if (txtEmail.Text != "") this.aluno.Email = txtEmail.Text;

            int atualizou = AlunoController.Update(this.aluno);

            if (atualizou == 1) {
                AlunoEditadoForm alunoAtualizado = new AlunoEditadoForm(this.aluno);
                alunoAtualizado.Show();
            }
            else MessageBox.Show("Não foi possivel atualizar o aluno.");
            this.Dispose();
        }
    }
}
