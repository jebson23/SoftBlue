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

using System.Drawing;

namespace SoftBlue.Views
{
    public delegate void ButtonArgFunction(object sender, EventArgs e);

    public partial class AlunoViewForm : Form
    {
        private List<Aluno> alunos = new List<Aluno>();
        public AlunoViewForm()
        {
            InitializeComponent();
        }

        private void SetInGrid(List<Aluno> alunos)
        {
            this.alunos = alunos;

            foreach (Aluno aluno in alunos)
            {
                dataGridView1.Rows.Add(new object[] {
                    aluno.Codigo,
                    aluno.Nome,
                    aluno.Endereco,
                    aluno.Email,
                    "Editar",
                    "Deletar"
                });
            }
        }

            //this.dataGridView1.Refresh();
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            this.SetInGrid(AlunoController.GetAll());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            NovoAlunoForm novoAluno = new NovoAlunoForm();
            novoAluno.Show();
        }

        private Aluno SearchForCode (int codigo)
        {
            return this.alunos.Find(aluno => aluno.Codigo == codigo);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            //  aluno.Codigo,    => 0
            //  aluno.Nome,      => 1
            //  aluno.Endereco,  => 2
            //  aluno.Email,     => 3
            //  "Editar",        => 4
            //  "Deletar"        => 5
            int Codigo;
            Aluno aluno;
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                DataGridViewCellCollection collection = row.Cells;
                Codigo = Convert.ToInt32(collection[0].Value);
                aluno = this.SearchForCode(Codigo);
            } catch (Exception error)
            {
                MessageBox.Show("Não foi possível selecionar este item\n\n"+ error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (aluno == null) return;

            switch (e.ColumnIndex)
            {
                // editar
                case 4:
                    MessageBox.Show("Editar: " + aluno.Codigo.ToString());
                    break;
                case 5:
                    MessageBox.Show("Apagar: " + aluno.Codigo.ToString());
                    break;
            }
            return;
        }
    }
}
