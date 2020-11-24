using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tablica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool p = double.TryParse(textBox1.Text, out double rez);
            bool p2 = double.TryParse(textBox3.Text, out double rez2);


            if (p == true & p2 == true)
            {
                textBox2.Clear();
                for (int i = 0; i <= rez2; i++)
                {
                    textBox2.Text += rez + " x " + i + " = " + (rez * i) + Environment.NewLine;
                }
                textBox1.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Некорректный ввод!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                textBox1.Clear();
                textBox3.Clear();
            }
        }
    }
}
