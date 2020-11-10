using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Del_na_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void delenie(string a)
        {
            bool proverka = int.TryParse(a, out int rez);
            if (proverka==true)
            {
                int num = 0;
                string chislo = a;

                while (num==0)
                {
                    char[] del = new char[chislo.Length];
                    del = chislo.ToCharArray();

                    int sum = 0;

                    for (int i = 0; i < del.Length; i++)
                    {
                        sum += int.Parse(del[i].ToString());
                    }

                    if (sum>9)
                    {
                        chislo = sum.ToString();
                    }
                    else
                    {
                        if (sum==3 || sum==6 || sum==9)
                        {
                            num = 1;
                            MessageBox.Show("Число делится на 3");
                        }
                        else
                        {
                            num = 1;
                            MessageBox.Show("Число НЕ делится на 3");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delenie(textBox1.Text);
        }
    }
}
