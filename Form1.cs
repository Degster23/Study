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
	    MessageBox.Show("");
        }

        public int proverka(string a)
        {
            int schet = 0;
            bool p = double.TryParse(a, out double result);
            if (p==true)
            {
                //int i2 = 0;
                double result2 = result;
                while (result>0)
                {
                    //MessageBox.Show(i2++.ToString());
                    result2 = result;
                    for (int i = 0; i < a.Length; i++)
                    {
                        double res = result2 % 10;
                        //MessageBox.Show(res.ToString());
                        if (res == 3)
                        {
                            schet++;
                        }
                        result2 = result2 - res;
                        result2 = result2 / 10;
                    }
                    result--;
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
