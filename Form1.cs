using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gde_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int proverka(string a)
        {
            int schet = 0;
            bool p = double.TryParse(a, out double result);
            if (p==true)
            {
                for (int i=0; i<a.Length; i++)
                {
                    int res = result % 10;
                    MessageBox.Show(res.ToString());
                    if (res==3)
                    {
                        schet++;
                    }
                    result = result / 10;
                }
            }
            else
            {
                MessageBox.Show("Не число!!!");
            }
            return schet;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Троек в числе: "+proverka(textBox1.Text).ToString());
        }
    }
}
