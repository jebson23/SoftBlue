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
    public partial class EditarInstrutorForm : Form
    {
        private Instrutor instrutor;

        public EditarInstrutorForm(Instrutor instrutor)
        {
            InitializeComponent();
            this.instrutor = instrutor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "") this.instrutor.Nome = txtNome.Text;
            if (txtTelefone.Text != "") this.instrutor.Telefone = txtTelefone.Text;

            int atualizou = InstrutorController.Update(this.instrutor);

            if (atualizou == 1)
            {
                InstrutorEditadoForm instrutorAtualizado = new InstrutorEditadoForm(this.instrutor);
                instrutorAtualizado.Show();
            }
            else MessageBox.Show("Não foi possivel atualizar o aluno.");
            this.Dispose();
        }
    }
}
