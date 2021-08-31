using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using SoftBlue.Models;
using SoftBlue;

namespace SoftBlue.Controller
{
    public delegate void ButtonClickEventHandler(string type, object sender, EventArgs e, object aluno, object StudentViewCreatorController);

    class StudentViewCreatorController
    {
        private Aluno aluno;
        private NewStudentDataView FormController;

        private TableLayoutPanel tableMain;
        private TableLayoutPanel tableAction;
        private TableLayoutPanel tableView;
        private Panel panel;

        public StudentViewCreatorController (Aluno aluno, object FormController)
        {
            this.aluno = aluno;
            this.FormController = FormController as NewStudentDataView;
        }

        private Button CreateButton(Image image, string type, ButtonClickEventHandler buttonClickEventHandler)
        {
            Button button = new Button();

            button.Anchor = AnchorStyles.None;
            button.BackgroundImage = image;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(12, 67);
            button.Margin = new Padding(0);
            button.Size = new Size(25, 25);
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler((object sender, EventArgs e) => buttonClickEventHandler(type, sender, e, this.aluno as object, this));

            return button;
        }

        private Label CreateLabel(string Text, AnchorStyles style)
        {
            // colocar como privado
            Label label = new Label();

            label.Anchor = style;
            label.AutoSize = true;
            label.Location = new Point(3, 9);
            label.Size = new Size(40, 13);
            label.Text = Text;

            return label;
        }

        private void CreateTableView()
        {
            this.tableView = new TableLayoutPanel();
            this.tableView.ColumnCount = 2;
            this.tableView.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            this.tableView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableView.Controls.Add(this.CreateLabel("Código", AnchorStyles.Left), 0, 0);
            this.tableView.Controls.Add(this.CreateLabel("Nome", AnchorStyles.Left), 0, 1);
            this.tableView.Controls.Add(this.CreateLabel("Endereco", AnchorStyles.Left), 0, 2);
            this.tableView.Controls.Add(this.CreateLabel("Email", AnchorStyles.Left), 0, 3);
            this.tableView.Controls.Add(this.CreateLabel(this.aluno.Codigo.ToString(), AnchorStyles.Left), 1, 0);
            this.tableView.Controls.Add(this.CreateLabel(this.aluno.Nome, AnchorStyles.Left), 1, 1);
            this.tableView.Controls.Add(this.CreateLabel(this.aluno.Endereco, AnchorStyles.Left), 1, 2);
            this.tableView.Controls.Add(this.CreateLabel(this.aluno.Email, AnchorStyles.Left), 1, 3);
            this.tableView.Dock = DockStyle.Fill;
            this.tableView.Location = new Point(0, 0);
            this.tableView.Margin = new Padding(0);
            this.tableView.Name = "tableLayoutPanel6";
            this.tableView.RowCount = 4;
            this.tableView.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableView.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableView.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableView.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableView.Size = new Size(734, 130);
            this.tableView.TabIndex = 1;
        }

        private void CreateTableAction()
        {
            this.tableAction = new TableLayoutPanel();

            this.tableAction.ColumnCount = 1;
            this.tableAction.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableAction.Controls.Add(this.CreateButton(global::SoftBlue.Properties.Resources.trash, "trash", this.FormController.ButtonClick), 0, 2); /// trash
            this.tableAction.Controls.Add(this.CreateButton(global::SoftBlue.Properties.Resources.eye__1_, "view", this.FormController.ButtonClick), 0, 1); // view
            this.tableAction.Dock = DockStyle.Fill;
            this.tableAction.Location = new Point(734, 0);
            this.tableAction.Margin = new Padding(0);
            this.tableAction.RowCount = 4;
            this.tableAction.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableAction.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableAction.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableAction.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableAction.Size = new Size(50, 130);
        }

        private void CreateMainTable()
        {
            this.tableMain = new TableLayoutPanel();

            this.tableMain.BackColor = Color.DimGray;
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            this.tableMain.Controls.Add(this.tableAction, 1, 0);
            this.tableMain.Controls.Add(this.tableView, 0, 0);
            this.tableMain.Dock = DockStyle.Fill;
            this.tableMain.Location = new Point(0, 10);
            this.tableMain.Margin = new Padding(0);
            this.tableMain.RowCount = 1;
            this.tableMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableMain.Size = new Size(784, 130);
            this.tableMain.TabIndex = 0;
        }

        private void CreatePanel()
        {
            this.panel = new Panel();

            this.panel.Controls.Add(this.tableMain);
            this.panel.Dock = DockStyle.Top;
            this.panel.Location = new Point(10, 0);
            this.panel.Padding = new Padding(0, 10, 0, 10);
            this.panel.Size = new Size(784, 150);
        }

        public StudentViewCreatorController Build()
        {
            this.CreateTableView();
            this.CreateTableAction();
            this.CreateMainTable();
            this.CreatePanel();

            return this;
        }

        public Panel GetPanel()
        {
            return this.panel;
        }
    }
}
