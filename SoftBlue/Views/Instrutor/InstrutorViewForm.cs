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

        public InstrutorViewForm(int codigo)
        {
            InitializeComponent();
            this.GetInstrutor(codigo);
        }

        private void GetInstrutor(int codigo)
        {
            this.instrutores = InstrutorController.GetAll();

            Instrutor instrutor = SearchForCode(codigo);

            InstrutorEncontradoForm instrutorEncontrado = new InstrutorEncontradoForm(instrutor);
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

        private Instrutor SearchForCode(int codigo)
        {
            return this.instrutores.Find(aluno => aluno.Codigo == codigo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.SetInGrid(InstrutorController.GetAll());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NovoInstrutorForm novoInstrutor = new NovoInstrutorForm();
            novoInstrutor.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int codigo = 0;
            Instrutor instrutor = null;
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                DataGridViewCellCollection collection = row.Cells;
                codigo = Convert.ToInt32(collection[0].Value);
                instrutor = this.SearchForCode(codigo);

            } catch(Exception error) { }

            if (instrutor == null) return;

            switch (e.ColumnIndex)
            {
                case 3:
                    EditarInstrutorForm editarInstrutor = new EditarInstrutorForm(instrutor);
                    editarInstrutor.Show();
                    break;

                case 4:
                    int retorno = InstrutorController.Delete(codigo);
                    if (retorno == 1)
                    {
                        MessageBox.Show(String.Format("O Instrutor {0} foi excluido com sucesso", instrutor.Nome));
                    }

                    else MessageBox.Show(String.Format("Não foi possível apagar o Instrutor {0}", instrutor.Nome));
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarInstrutorForm buscarInstrutor = new BuscarInstrutorForm();
            buscarInstrutor.Show();
        }
    }
}
