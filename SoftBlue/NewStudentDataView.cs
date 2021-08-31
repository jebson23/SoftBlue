using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SoftBlue.Controller;
using SoftBlue.Models;

namespace SoftBlue
{
    public partial class NewStudentDataView : Form
    {
        private List<Aluno> alunos;
        private List<StudentViewCreatorController> studentViewCreatorControllers = new List<StudentViewCreatorController>();         

        public NewStudentDataView()
        {
            InitializeComponent();
            this.comboBox1.Text = "Codigo";

            this.alunos = AlunoController.GetAll();
            foreach (Aluno aluno in this.alunos)
            {
                StudentViewCreatorController controller = new StudentViewCreatorController(aluno, this);

                controller.Build();

                this.panel2.Controls.Add(controller.GetPanel());
                this.studentViewCreatorControllers.Add(controller);
            }
        }

        private void ComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void TextBoxKeyDown(object sender, KeyPressEventArgs e)
        {
            switch (this.comboBox1.Text)
            {
                case "Codigo":
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                case "Aluno":
                case "Endereco":
                case "Email":
                    break;
            }
        }

        public void ButtonClick(string type, object sender, EventArgs e, object aluno, object StudentViewCreatorController)
        {
            MessageBox.Show(type + " codigo: " + (aluno as Aluno).Codigo.ToString());
        }
    }
}
