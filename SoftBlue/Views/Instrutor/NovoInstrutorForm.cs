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
    public partial class NovoInstrutorForm : Form
    {
        public NovoInstrutorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instrutor instrutor = new Instrutor
            {
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            InstrutorInseridoForm instrutorInserido = new InstrutorInseridoForm(InstrutorController.Insert(instrutor));

            this.Dispose();
        }
    }
}
