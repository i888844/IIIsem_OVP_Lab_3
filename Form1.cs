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
        private int i = 0;
        private int j = 0;
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
                i = 0;
                j = 0;
                columnsFromForm2 = form2.Columns;
                stringsFromForm2 = form2.Strings;
                matrix = new int[columnsFromForm2, stringsFromForm2];
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                for (int column = 0; column < columnsFromForm2; column++)
                {
                    dataGridView1.Columns.Add($"Column{column + 1}", $"Column{column + 1}");
                }
                for (int row = 0; row < stringsFromForm2; row++)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.CreateCells(dataGridView1);
                    for (int column = 0; column < columnsFromForm2; column++)
                    {
                        dataGridViewRow.Cells[column].Value = matrix[column, row];
                    }
                    dataGridView1.Rows.Add(dataGridViewRow);
                }
                i = 0;
                j = 0;
                label2.Text = $"[{i}][{j}]";
            }
        }

        private void ProcessMatrix()
        {
            int sum = 0;
            int count = 0;
            int max = int.MinValue;
            StringBuilder matrixStringBuilder = new StringBuilder();
            for (int row = 0; row < stringsFromForm2; row++)
            {
                for (int column = 0; column < columnsFromForm2; column++)
                {
                    matrixStringBuilder.Append(matrix[column, row]);
                    if (column < columnsFromForm2 - 1)
                    {
                        matrixStringBuilder.Append("   ");
                    }
                }
                matrixStringBuilder.AppendLine();
            }
            label3.Text = matrixStringBuilder.ToString();
            for (int row = 0; row < stringsFromForm2; row++)
            {
                for (int column = 0; column < columnsFromForm2; column++)
                {
                    sum += matrix[column, row];
                    count++;
                    if (matrix[column, row] > max)
                    {
                        max = matrix[column, row];
                    }
                }
            }
            double average = (double)sum / count;
            int sumLessThanAverage = 0;
            for (int row = 0; row < stringsFromForm2; row++)
            {
                for (int column = 0; column < columnsFromForm2; column++)
                {
                    if (matrix[column, row] < average)
                    {
                        sumLessThanAverage += matrix[column, row];
                    }
                }
            }
            if (sumLessThanAverage > 0)
            {
                for (int row = 0; row < stringsFromForm2; row++)
                {
                    for (int column = 0; column < columnsFromForm2; column++)
                    {
                        matrix[column, row] /= max;
                        dataGridView1[column, row].Value = matrix[column, row].ToString();
                    }
                }
            }
            matrixStringBuilder.AppendLine($"Среднее арифметическое: {average}");
            matrixStringBuilder.AppendLine($"Максимальное значение: {max}");
            matrixStringBuilder.AppendLine($"Сумма элементов меньше среднего арифметического: {sumLessThanAverage}");
            label3.Text = matrixStringBuilder.ToString();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int cellValue))
            {
                matrix[i, j] = cellValue;
                dataGridView1[i, j].Value = cellValue.ToString();
            }
            textBox1.Clear();
            if (++i >= columnsFromForm2)
            {
                i = 0;
                if (++j >= stringsFromForm2)
                {
                    ProcessMatrix();
                }
            }
            label2.Text = $"[{i}][{j}]";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 0;
            j = 0;
            columnsFromForm2 = 0;
            stringsFromForm2 = 0;
            matrix = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            label2.Text = $"[{i}][{j}]";
        }
    }
}
