using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задание_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton3.Enabled = false;
        }

        Stack<int> stek = new Stack<int>();

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text!=null)
                {
                    stek.Push(int.Parse(textBox1.Text));
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Не введено значение!!!", "Ошибка");
                }
            }

            if (radioButton2.Checked == true)
            {
                Random rnd = new Random();
                stek.Push(rnd.Next(0, 1000));
            }

            if (radioButton3.Checked == true)
            {
                if (textBox1.Text != null)
                {
                    int n = int.Parse(textBox1.Text);
                    if (n <= stek.Count)
                    {
                        DialogResult rez = MessageBox.Show("Вы действительно хотите удалить "+n+" элемент?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        if (rez == DialogResult.Yes)
                        {
                            DialogResult rez2 = MessageBox.Show("Сохранить удаляемые элементы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (rez2 == DialogResult.Yes)
                            {
                                saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    string[] mas1 = new string[stek.Count];
                                    for (int i1 = 0; i1 <= (n - 1); i1++)
                                    {
                                        mas1[i1] = stek.Pop().ToString();
                                    }
                                    string filename = saveFileDialog1.FileName;
                                    File.WriteAllLines(filename, mas1);
                                    MessageBox.Show("Файл сохранен");
                                }
                            }
                            else if (rez2 == DialogResult.No)
                            {
                                for (int i1 = 0; i1 <= (n - 1); i1++)
                                {
                                    stek.Pop();
                                }
                            }
                        }
                    }
                    else if (n > stek.Count)
                    {
                        MessageBox.Show("Введенное значение превышает размерность стека!!!", "Ошибка ввода");
                    }
                }
                else
                {
                    MessageBox.Show("Не введено значение!!!", "Ошибка");
                }
            }
            textBox1.Clear();
            pokaz();
        }

        private void pokaz()
        {
            richTextBox1.Clear();
            int numer = 1;
            foreach (int z in stek)
            {
                richTextBox1.Text += numer + ". " + z.ToString() + Environment.NewLine;
                numer++;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult rez2 = MessageBox.Show("Вывести элементы в файл?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (rez2 == DialogResult.Yes)
            {
                saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] mas1 = new string[stek.Count];
                    Stack<int> stek2 = new Stack<int>(stek);
                    int[] mas2 = new int[stek.Count];
                    for (int i = (stek.Count-1); i>=0; i--)
                    {
                        mas2[i] = stek2.Pop();
                    }
                    
                    for (int i1 = 0; i1 < mas2.Length; i1++)
                    {
                        mas1[i1] = (i1+1)+". "+mas2[i1].ToString();
                    }
                    string filename = saveFileDialog1.FileName;
                    File.WriteAllLines(filename, mas1);
                    MessageBox.Show("Файл сохранен");
                } 
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "Добавить";
            label1.Text = "Введите число";
            button4.Visible = true;
            textBox1.Enabled = true;

            textBox1.Visible = true;
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "Рандом";
            button4.Visible = false;
            textBox1.Enabled = false;

            textBox1.Visible = false;
            label1.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "Удалить";
            label1.Text = "Введите номер";
            button4.Visible = false;
            textBox1.Enabled = true;

            textBox1.Visible = true;
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult rez = MessageBox.Show("Вы действительно хотите очистить стек?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (rez == DialogResult.Yes)
            {
                DialogResult rez2 = MessageBox.Show("Сохранить удаляемые элементы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (rez2 == DialogResult.Yes)
                {
                    saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        int stekcount = stek.Count;
                        string[] mas1 = new string[stekcount];
                        for (int i1 = 0; i1 < stekcount; i1++)
                        {
                            mas1[i1] = stek.Pop().ToString();
                        }
                        string filename = saveFileDialog1.FileName;
                        File.WriteAllLines(filename, mas1);
                        MessageBox.Show("Файл сохранен");
                    }
                }
                else if (rez2 == DialogResult.No)
                {
                    stek.Clear();
                }
            }
            pokaz();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int stekcount = stek.Count;
                string filename = openFileDialog1.FileName;
                int count = File.ReadAllLines(filename).Length;
                string[] _lines = new string[count];
                _lines = File.ReadAllLines(filename);
                _lines = _lines.Where(n => !string.IsNullOrEmpty(n)).ToArray();

                bool y = false;

                for (int ii = 0; ii < _lines.Length; ii++)
                {
                    y = int.TryParse(_lines[ii], out int gde);
                    stek.Push(gde);              
                }
            }
            pokaz();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.ForeColor = Color.Black;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = "Строка поиска";
            textBox2.ForeColor = Color.Gray;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 127 && number != 8)
            {
                e.Handled = true;
            }
            else
            {
                timer1.Stop();
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;

            string num1 = textBox2.Text;
            string num2;
            int vhod;

            Stack<int> stek2 = new Stack<int>(stek);

            for (int i = 0; i < stek.Count; i++)
            {
                num2 = stek2.Pop().ToString();
                vhod = num2.IndexOf(num1);
                int index;
                if (vhod == 0)
                {
                    index = richTextBox1.Find(" " + num2);
                    richTextBox1.Select(index + 1, num1.Length);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                }
            }
        }

        int i = 2;

        private void sort_mb()
        {
            Stack<int> stek1 = new Stack<int>(stek);
            Stack<int> stek2 = new Stack<int>();
            Stack<int> sort = new Stack<int>();
            int znach = int.MaxValue;
            int k = 1;

            while (sort.Count < stek.Count)
            {
                int count1 = stek1.Count;
                int count2 = stek2.Count;

                if (k == 1)
                {
                    znach = int.MinValue;

                    for (int i1 = 0; i1 < count1; i1++)
                    {
                        if (stek1.Peek() > znach)
                        {
                            znach = stek1.Peek();
                        }
                        stek2.Push(stek1.Pop());
                    }
                    k = 2;
                }
                else if (k == 2)
                {
                    for (int i2 = 0; i2 < count2; i2++)
                    {
                        if (stek2.Peek() == znach)
                        {
                            sort.Push(stek2.Pop());
                        }
                        else
                        {
                            stek1.Push(stek2.Pop());
                        }
                    }
                    k = 1;
                }
            }
            stek = sort;
            pokaz();
        }

        private void sort_bm()
        {
            Stack<int> stek1 = new Stack<int>(stek);
            Stack<int> stek2 = new Stack<int>();
            Stack<int> sort = new Stack<int>();
            int znach = int.MaxValue;
            int k = 1;

            while (sort.Count < stek.Count)
            {
                int count1 = stek1.Count;
                int count2 = stek2.Count;

                if (k == 1)
                {
                    znach = int.MaxValue;

                    for (int i1 = 0; i1 < count1; i1++)
                    {
                        if (stek1.Peek() < znach)
                        {
                            znach = stek1.Peek();
                        }
                        stek2.Push(stek1.Pop());
                    }
                    k = 2;
                }
                else if (k == 2)
                {
                    for (int i2 = 0; i2 < count2; i2++)
                    {
                        if (stek2.Peek() == znach)
                        {
                            sort.Push(stek2.Pop());
                        }
                        else
                        {
                            stek1.Push(stek2.Pop());
                        }
                    }
                    k = 1;
                }
            }
            stek = sort;
            pokaz();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i % 2 == 0)
            {
                button5.BackgroundImage = Properties.Resources.меньше_больше;
                sort_mb();
            }
            else
            {
                button5.BackgroundImage = Properties.Resources.больше_меньше;
                sort_bm();
            }
            i++;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 127 && number != 8)
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length < 2)
            {
                radioButton3.Enabled = false;
            }
            else
            {
                radioButton3.Enabled = true;
            }
        }
    }
}
