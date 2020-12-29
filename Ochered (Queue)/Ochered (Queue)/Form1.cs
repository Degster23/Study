using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Ochered__Queue_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton3.Checked = false;
        }

        Queue<int> chisla = new Queue<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                bool success = int.TryParse(textBox1.Text, out int number);
                if (success == true)
                {
                    chisla.Enqueue(number);
                    textBox1.Clear();

                    richTextBox1.Clear();
                    int[] maschis = new int[chisla.Count];
                    chisla.CopyTo(maschis, 0);
                    for (int i = 0; i < (maschis.Length); i++)
                    {
                        richTextBox1.Text += (i + 1) + ". " + maschis[i].ToString() + Environment.NewLine;
                    }
                    radioButton3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Некорректный ввод!");
                }
            }

            if (radioButton3.Checked == true)
            {
                string del = "";

                bool prov1 = int.TryParse(textBox1.Text, out int result1);

                DialogResult yes = MessageBox.Show("Вы уверены, что хотите удалить данный элемент", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);

                if (yes == DialogResult.Yes)
                {
                    if (prov1 == true)
                    {
                        if ((result1 > 0) & (result1 <= chisla.Count))
                        {
                            DialogResult res = MessageBox.Show("Сохранить удаляемые элементы?", "Выбор", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (res == DialogResult.Yes)
                            {
                                int i = 0;
                                while (i != int.Parse(textBox1.Text))
                                {
                                    del += chisla.Dequeue().ToString() + Environment.NewLine;
                                    i++;
                                }

                                SaveFileDialog sf = new SaveFileDialog();

                                sf.Filter = "Текстовый файл (*.txt)|*.txt";
                                sf.FilterIndex = 1;
                                sf.RestoreDirectory = true;

                                if (sf.ShowDialog() == DialogResult.Cancel) return;

                                string filename = sf.FileName;
                                File.WriteAllText(filename, del);
                                MessageBox.Show("Файл сохранен");
                            }
                            else
                            {
                                int i1 = 0;
                                while (i1 != int.Parse(textBox1.Text))
                                {
                                    del += chisla.Dequeue().ToString() + Environment.NewLine;
                                    i1++;
                                }
                                richTextBox1.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Данный элемент отстутствует!");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод!");
                        return;
                    }
                    textBox1.Clear();
                }


                richTextBox1.Clear();
                int[] maschis = new int[chisla.Count];
                chisla.CopyTo(maschis, 0);
                for (int i = 0; i < (maschis.Length); i++)
                {
                    richTextBox1.Text += (i + 1) + ". " + maschis[i].ToString() + Environment.NewLine;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Введите число";
            label1.Visible = true;

            textBox1.Visible = true;

            button1.Text = "Добавить";
            button1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Введите номер элемента";
            label1.Visible = true;

            textBox1.Visible = true;

            button1.Text = "Удалить";
            button1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.Cancel) return;

            using (StreamReader sr = new StreamReader(file.FileName, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    bool success = int.TryParse(line, out int num);
                    if (success == true)
                    {
                        chisla.Enqueue(num);

                        richTextBox1.Clear();
                        int[] maschis = new int[chisla.Count];
                        chisla.CopyTo(maschis, 0);
                        for (int i = 0; i < (maschis.Length); i++)
                        {
                            richTextBox1.Text += (i + 1) + ". " + maschis[i].ToString() + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chisla.Count > 0)
            {
                DialogResult yes = MessageBox.Show("Вы действительно хотите очистить очередь?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (yes == DialogResult.Yes)
                {
                    DialogResult sohr = MessageBox.Show("Сохранить удаляемые элементы?", "Выбор", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                    if (sohr == DialogResult.Yes)
                    {
                        SaveFileDialog sf = new SaveFileDialog();

                        sf.Filter = "Текстовый файл (*.txt)|*.txt";
                        sf.FilterIndex = 1;
                        sf.RestoreDirectory = true;

                        if (sf.ShowDialog() == DialogResult.Cancel) return;

                        string filename = sf.FileName;
                        File.WriteAllText(filename, richTextBox1.Text);
                        MessageBox.Show("Файл сохранен");

                        richTextBox1.Clear();
                        chisla.Clear();
                    }
                    else
                    {
                        richTextBox1.Clear();
                        chisla.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Очередь пуста!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chisla.Count > 0)
            {
                SaveFileDialog sf = new SaveFileDialog();

                sf.Filter = "Текстовый файл (*.txt)|*.txt";
                sf.FilterIndex = 1;
                sf.RestoreDirectory = true;

                if (sf.ShowDialog() == DialogResult.Cancel) return;

                string filename = sf.FileName;
                File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("Файл сохранен");
            }
            else
            {
                MessageBox.Show("Очередь пуста!!!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            // запуск поиска и ввод только цифр
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
            // механизм поиска
            timer1.Stop();
            timer1.Enabled = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;

            string num1 = textBox2.Text;
            string num2;
            int vhod;

            Queue<int> chisla2 = new Queue<int>(chisla);

            for (int i = 0; i < chisla.Count; i++)
            {
                num2 = chisla2.Dequeue().ToString();
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
            Queue<int> sort = new Queue<int>();
            Queue<int> chisla1 = new Queue<int>(chisla);
            int i = 1;
            int znach = 0;

            while (sort.Count < chisla.Count)
            {
                if (i == 1)
                {
                    znach = int.MaxValue;
                    for (int a = 0; a < chisla1.Count; a++)
                    {
                        if (chisla1.Peek() < znach)
                        {
                            znach = chisla1.Peek();
                        }
                        chisla1.Enqueue(chisla1.Dequeue());
                    }
                    i = 2;
                }
                else if (i == 2)
                {
                    for (int a = 0; a < chisla1.Count; a++)
                    {
                        if (chisla1.Peek() == znach)
                        {
                            sort.Enqueue(chisla1.Dequeue());
                        }
                        if (chisla1.Count != 0)
                        {
                            chisla1.Enqueue(chisla1.Dequeue());
                        }
                    }
                    i = 1;
                }
            }

            richTextBox1.Clear();
            chisla = sort;
            int num = 1;
            foreach (int sr in chisla)
            {
                richTextBox1.Text += (num) + ". " + sr.ToString() + Environment.NewLine;
                num++;
            }
        }

        private void sort_bm()
        {
            Queue<int> sort = new Queue<int>();
            Queue<int> chisla1 = new Queue<int>(chisla);
            int i = 1;
            int znach = 0;

            while (sort.Count < chisla.Count)
            {
                if (i == 1)
                {
                    znach = int.MinValue;
                    for (int a = 0; a < chisla1.Count; a++)
                    {
                        if (chisla1.Peek() > znach)
                        {
                            znach = chisla1.Peek();
                        }
                        chisla1.Enqueue(chisla1.Dequeue());
                    }
                    i = 2;
                }
                else if (i == 2)
                {
                    for (int a = 0; a < chisla1.Count; a++)
                    {
                        if (chisla1.Peek() == znach)
                        {
                            sort.Enqueue(chisla1.Dequeue());
                        }
                        if (chisla1.Count != 0)
                        {
                            chisla1.Enqueue(chisla1.Dequeue());
                        }
                    }
                    i = 1;
                }
            }

            richTextBox1.Clear();
            chisla = sort;
            int num = 1;
            foreach (int sr in chisla)
            {
                richTextBox1.Text += (num) + ". " + sr.ToString() + Environment.NewLine;
                num++;
            }
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
    }
}
