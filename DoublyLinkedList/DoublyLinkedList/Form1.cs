using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoublyLinkedList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            textBox2.Text = "Строка поиска";
            textBox2.ForeColor = Color.Gray;
            radioButton2.Enabled = false;
        }

        LinkedList<int> numbers = new LinkedList<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            bool rez = int.TryParse(textBox1.Text, out int result);

            if (rez == true)
            {
                // добавить
                if (radioButton1.Checked == true)
                {
                    if (numbers.Count == 0)
                    {
                        numbers.AddFirst(result);
                        textBox1.Clear();
                        otobrazit();
                    }
                    else
                    {
                        if (numbers.Count > 0)
                        {
                            richTextBox1.Clear();
                            numbers.AddLast(result);
                            textBox1.Clear();
                            otobrazit();
                        }
                    }
                }

                // удалить
                if (radioButton2.Checked == true)
                {
                    List<int> listik = new List<int>();
                    listik.AddRange(numbers);
                    DialogResult otvet = MessageBox.Show("Сохранить удаляемые данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    if (otvet == DialogResult.Yes)
                    {
                        SaveFileDialog sfd1 = new SaveFileDialog();
                        sfd1.Filter = "Текстовый файл (*.txt)|*.txt";
                        if (sfd1.ShowDialog() == DialogResult.Cancel) return;
                        string filename = sfd1.FileName;
                        File.WriteAllText(filename, listik[int.Parse(textBox1.Text) - 1].ToString());
                        MessageBox.Show("Файл сохранен");
                    }

                    if (numbers.Count == 0)
                    {
                        MessageBox.Show("Элементы отсутствуют!!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        if (int.Parse(textBox1.Text) > numbers.Count || int.Parse(textBox1.Text) <= 0)
                        {
                            MessageBox.Show("Данный элемент отсутствует в списке", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        else
                        {
                            richTextBox1.Clear();
                            listik.RemoveAt(int.Parse(textBox1.Text) - 1);
                            textBox1.Clear();
                            numbers.Clear();
                            for (int i = 0; i < listik.Count; i++)
                            {
                                if (i == 0)
                                {
                                    numbers.AddFirst(listik[0]);
                                }
                                else
                                {
                                    numbers.AddLast(listik[i]);
                                }
                            }
                            otobrazit();
                        }
                    }
                }
            }
        }

        private void otobrazit()
        {
            richTextBox1.Clear();
            int[] chisla = new int[numbers.Count];
            numbers.CopyTo(chisla, 0);
            for (int i = 0; i < numbers.Count; i++)
            {
                richTextBox1.Text += (i + 1) + ". " + chisla[i] + Environment.NewLine;
            }
            radioButton2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // добавление
            label1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            label1.Text = "Введите число";

            button1.Text = "Добавить";
            button2.Text = "Очистить";
            button3.Text = "Вывести в файл";
            button4.Text = "Добавить из файла";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // удаление
            label1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            label1.Text = "Введите номер элемента";

            button1.Text = "Удалить";
            button2.Text = "Очистить";
            button3.Text = "Вывести в файл";
            button4.Text = "Добавить из файла";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // добавить из файла
            DialogResult vopros = MessageBox.Show("Сохранить искодные данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (vopros==DialogResult.No)
            {
                numbers.Clear();
                richTextBox1.Clear();
            }
            
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.Cancel) return;
            string filename = file.FileName;
            string[] fileText = File.ReadAllLines(filename);

            int[] chisla1 = new int[fileText.Length];

            for (int i = 0; i < fileText.Length; i++)
            {
                bool parsed = int.TryParse(fileText[i], out int res);
                if (parsed==true)
                {
                    chisla1[i] = int.Parse(res.ToString());
                }
            }

            for (int i = 0; i<fileText.Length; i++)
            {
                if (numbers.Count==0)
                {
                    numbers.AddFirst(chisla1[i]);
                }
                else
                {
                    numbers.AddLast(chisla1[i]);
                }
            }
            otobrazit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> listik = new List<int>();
            listik.AddRange(numbers);
            string[] masivchik = new string[listik.Count];
            for (int i = 0; i < listik.Count; i++)
            {
                masivchik[i] = listik[i].ToString();
            }

            DialogResult otvet = MessageBox.Show("Сохранить удаляемые данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (otvet == DialogResult.Yes)
            {
                SaveFileDialog sfd1 = new SaveFileDialog();
                sfd1.Filter = "Текстовый файл (*.txt)|*.txt";
                if (sfd1.ShowDialog() == DialogResult.Cancel) return;
                string filename = sfd1.FileName;
                File.WriteAllLines(filename, masivchik);
                MessageBox.Show("Файл сохранен");
                numbers.Clear();
                richTextBox1.Clear();
                textBox1.Clear();
            }
            if (otvet == DialogResult.No)
            {
                numbers.Clear();
                richTextBox1.Clear();
                textBox1.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> listik = new List<int>();
            listik.AddRange(numbers);
            string[] masivchik = new string[listik.Count];
            for (int i = 0; i < listik.Count; i++)
            {
                masivchik[i] = listik[i].ToString();
            }

            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.Filter = "Текстовый файл (*.txt)|*.txt";
            if (sfd1.ShowDialog() == DialogResult.Cancel) return;
            string filename = sfd1.FileName;
            File.WriteAllLines(filename, masivchik);
            MessageBox.Show("Файл сохранен");
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
            int por = -1;

            var item = numbers.First;
            while (item != null)
            {
                por++;
                num2 = item.Value.ToString();
                vhod = num2.IndexOf(num1);
                int index;
                if (vhod==0)
                {
                    index = richTextBox1.Find(" "+num2);
                    richTextBox1.Select(index+1, num1.Length);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                }
                item = item.Next;
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

        int i = 2;

        private void sort_mb()
        {
            LinkedListNode<int> sort;
            for (int j = 0; j < numbers.Count; j++) 
            {
                for (sort = numbers.First; sort != null; sort = sort.Next)
                {
                    if (sort.Next != null)
                    {
                        int temp2 = sort.Next.Value;
                        int temp = sort.Value;
                        if (sort.Value > sort.Next.Value) 
                        { 
                            sort.Value = temp2; 
                            sort.Next.Value = temp; 
                        }
                    }
                }
            }
            otobrazit();
        }

        private void sort_bm()
        {
            LinkedListNode<int> sort;
            for (int j = 0; j < numbers.Count; j++)
            {
                for (sort = numbers.First; sort != null; sort = sort.Next)
                {
                    if (sort.Next != null)
                    {
                        int temp2 = sort.Next.Value;
                        int temp = sort.Value;
                        if (sort.Value < sort.Next.Value)
                        {
                            sort.Value = temp2;
                            sort.Next.Value = temp;
                        }
                    }
                }
            }
            otobrazit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i%2==0)
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
