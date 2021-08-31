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
    public partial class InstrutorEncontradoForm : Form
    {
        public InstrutorEncontradoForm(Instrutor instrutor)
        {
            InitializeComponent();
            this.Show();
            this.SetInGrid(instrutor);
        }

        private void SetInGrid(Instrutor instrutor)
        {
            dataGridView1.Rows.Add(new object[] {
                instrutor.Codigo,
                instrutor.Nome,
                instrutor.Telefone,
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
