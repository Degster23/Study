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
            bool p = Int32.TryParse(a, out int result);
            if (p==true)
            {
                int schet = 0;
                for (int i=0; i<5; i++)
                {
                    double res = result % 10;
                    if (res==3)
                    {
                        schet++;
                    }

                    MessageBox.Show(res.ToString());
                }
            }
            else
            {
                MessageBox.Show("Не число!!!");
            }
            return result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(proverka(textBox1.Text).ToString());
        }
    }
}
