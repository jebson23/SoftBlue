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
    public partial class InstrutorViewForm : Form
    {
        List<Instrutor> instrutores = new List<Instrutor>();
        public InstrutorViewForm()
        {
            InitializeComponent();
        }

        private void SetInGrid(List<Instrutor> instrutores)
        {
            this.instrutores = instrutores;

            foreach (Instrutor instrutor in instrutores)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    instrutor.Codigo,
                    instrutor.Nome,
                    instrutor.Telefone,
                    "Editar",
                    "Deletar"
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.SetInGrid(InstrutorController.GetAll());
        }
    }
}
