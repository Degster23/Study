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

        string[] mas = new string[1];

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text!=null)
                {
                    int razmer = mas.Length;
                    mas[mas.Length-1] = textBox1.Text;

                    Array.Resize(ref mas, razmer+1);
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
                mas[mas.Length-1] = rnd.Next(0, 1000).ToString();

                int razmer = mas.Length;
                Array.Resize(ref mas, razmer+1);
                
                textBox1.Clear();
            }

            if (radioButton3.Checked == true)
            {
                if (textBox1.Text != null)
                {
                    int n = int.Parse(textBox1.Text);
                    if (n <= mas.Length)
                    {
                        DialogResult rez = MessageBox.Show("Вы действительно хотите удалить "+n+" элемент?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        if (rez == DialogResult.Yes)
                        {
                            DialogResult rez2 = MessageBox.Show("Сохранить удаляемый элемент?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            if (rez2 == DialogResult.Yes)
                            {
                                saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    string filename = saveFileDialog1.FileName;
                                    string[] mas2 = new string[1];
                                    mas2[0] = mas[n - 1];
                                    
                                    File.WriteAllLines(filename, mas2);
                                    MessageBox.Show("Файл сохранен");

                                    mas[n - 1] = null;
                                    for (int i = (n - 1); i < (mas.Length - 1); i++)
                                    {
                                        mas[i] = mas[i + 1];
                                    }
                                    int razmer = mas.Length;
                                    Array.Resize(ref mas, razmer - 1);
                                }
                            }
                            else if (rez2 == DialogResult.No)
                            {
                                mas[n - 1] = null;
                                for (int i = (n - 1); i < (mas.Length - 1); i++)
                                {
                                    mas[i] = mas[i + 1];
                                }
                                int razmer = mas.Length;
                                Array.Resize(ref mas, razmer - 1);
                            }
                        }
                    }
                    else if (n > mas.Length)
                    {
                        MessageBox.Show("Введенное значение превышает размерность массива!!!", "Ошибка ввода");
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
            foreach (string z in mas)
            {
                if (z != null)
                {
                    richTextBox1.Text += numer + ". " + z.ToString() + Environment.NewLine;
                    numer++;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                File.WriteAllLines(filename, mas);
                MessageBox.Show("Файл сохранен");
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
            DialogResult rez = MessageBox.Show("Вы действительно хотите очистить массив?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (rez == DialogResult.Yes)
            {
                DialogResult rez2 = MessageBox.Show("Сохранить удаляемые элементы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (rez2 == DialogResult.Yes)
                {
                    saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filename = saveFileDialog1.FileName;
                        File.WriteAllLines(filename, mas);
                        MessageBox.Show("Файл сохранен");
                        Array.Clear(mas, 0, mas.Length);
                        Array.Resize(ref mas, 1);
                    }
                }
                else if (rez2 == DialogResult.No)
                {
                    Array.Clear(mas, 0, mas.Length);
                    Array.Resize(ref mas, 1);
                }
            }
            pokaz();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                int count = File.ReadAllLines(filename).Length;
                DialogResult rez2 = MessageBox.Show("Сохранить существующие элементы?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (rez2 == DialogResult.Yes)
                {
                    int len = mas.Length;
                    Array.Resize(ref mas, len+count);

                    string[] mas2 = new string[count];
                    mas2 = File.ReadAllLines(filename);
                    mas2 = mas2.Where(n => !string.IsNullOrEmpty(n)).ToArray();
                    int o = 0;

                    mas = mas.Union(mas2).ToArray();

                    int len2 = mas.Length;
                    Array.Resize(ref mas, len2 + 1);
                }
                else if (rez2 == DialogResult.No)
                {
                    Array.Clear(mas, 0, mas.Length);
                    Array.Resize(ref mas, count);

                    mas = File.ReadAllLines(filename);
                    mas = mas.Where(n => !string.IsNullOrEmpty(n)).ToArray();
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

            for (int i = 0; i < mas.Length-1; i++)
            {
                num2 = mas[i].ToString();
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
            int[] masiv = new int[mas.Length];
            int[] sort = new int[mas.Length];

            for (int i = 0; i < mas.Length-1; i++)
            {
                masiv[i] = int.Parse(mas[i]);
            }

            int znach = int.MaxValue;
            int id = 0;
            for (int i = 0; i < sort.Length; i++)
            {
                for (int i2 = 0; i2 < masiv.Length; i2++)
                {
                    if (masiv[i2]<znach && masiv[i2]!=0)
                    {
                        znach = masiv[i2];
                        id = i2;
                    }
                }
                masiv[id] = 0;
                sort[i] = znach;
                znach = int.MaxValue;
            }

            for (int i = 0; i < mas.Length - 1; i++)
            {
                mas[i] = sort[i].ToString();
            }

            pokaz();
        }

        private void sort_bm()
        {
            int[] masiv = new int[mas.Length];
            int[] sort = new int[mas.Length];

            for (int i = 0; i < mas.Length - 1; i++)
            {
                masiv[i] = int.Parse(mas[i]);
            }

            int znach = int.MinValue;
            int id = 0;
            for (int i = 0; i < sort.Length; i++)
            {
                for (int i2 = 0; i2 < masiv.Length; i2++)
                {
                    if (masiv[i2] > znach && masiv[i2] != 0)
                    {
                        znach = masiv[i2];
                        id = i2;
                    }
                }
                masiv[id] = 0;
                sort[i] = znach;
                znach = int.MinValue;
            }

            for (int i = 0; i < mas.Length - 1; i++)
            {
                mas[i] = sort[i].ToString();
            }

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
