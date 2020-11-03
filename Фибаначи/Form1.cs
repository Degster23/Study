using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Фибаначи
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string fibanachi(string a)
        {
            double[] fib = new double[int.Parse(a)];
            fib[0] = 1;
            if (fib.Length>1) fib[1] = 1;
            for (int i=2; i < int.Parse(a); i++)
            {
                fib[i] = fib[i - 2] + fib[i - 1];
            }
            string itog = "";
            for (int i=0; i<fib.Length; i++)
            {
                itog = itog + " " + fib[i].ToString();
            }
            return itog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = fibanachi(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
