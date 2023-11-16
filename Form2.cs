using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab._3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public event EventHandler ButtonClicked;
        public int Columns { get; private set; }
        public int Strings { get; private set; }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int columns = 0;
            int strings = 0;
            if (!(int.TryParse(textBox1.Text, out columns) && !string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("Ошибка в поле 'Кол-во колонок'");
                return;
            }
            if (!(int.TryParse(textBox2.Text, out strings) && !string.IsNullOrEmpty(textBox2.Text)))
            {
                MessageBox.Show("Ошибка в поле 'Кол-во строк'");
                return;
            }
            Columns = columns;
            Strings = strings;
            ButtonClicked?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
