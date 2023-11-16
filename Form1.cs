using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab._3
{
    public partial class Form1 : Form
    {
        private int columnsFromForm2;
        private int stringsFromForm2;
        private int[,] matrix;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы действительно хотите закрыть программу?",
                "Подтверждение",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (Form2 inputDialog = new Form2())
            {
                inputDialog.ButtonClicked += Form2_ButtonClicked;
                inputDialog.ShowDialog();
            }
        }
        private void Form2_ButtonClicked(object sender, EventArgs e)
        {
            if (sender is Form2 form2)
            {
                columnsFromForm2 = form2.Columns;
                stringsFromForm2 = form2.Strings;
                matrix = new int[columnsFromForm2, stringsFromForm2];
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                for (int i = 0; i < columnsFromForm2; i++)
                {
                    dataGridView1.Columns.Add($"Column{i + 1}", $"Column{i + 1}");
                }
                for (int j = 0; j < stringsFromForm2; j++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    for (int i = 0; i < columnsFromForm2; i++)
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = matrix[i, j] });
                    }
                    dataGridView1.Rows.Add(row);
                }
            }
        }
    }
}
