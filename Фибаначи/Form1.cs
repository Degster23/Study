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
            int kol = int.Parse(a) + 1;
            double[] fib = new double[kol];
            fib[1] = 1;
            for (int i=2; i<kol; i++)
            {
                fib[i] = fib[i - 2] + fib[i - 1];
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fibanachi(textBox1.Text);
        }
    }
}
