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

            }
            return result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(proverka(textBox1.Text).ToString());
        }
    }
}
