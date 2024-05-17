using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Do_not_hang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string text;
        public char[] word;
        public int inputMax;
        public int trueInput;
        public Stopwatch time;
        private void button1_Click(object sender, EventArgs e)
        {
            // Обнуляем все переменные 
            text = textBox1.Text;
            inputMax = 0;
            trueInput = 0;
            pictureBox1.Image = null;
            time = null;
            label1.Text = null;
            textBox1.Text = null;
            word = null;
            word = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                label1.Text += '.';
                word[i] = '.';
            }
            time = new Stopwatch();
            time.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                bool words = false;
                if (textBox2.Text.Length == 1) // Для одной буквы
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (textBox2.Text[0] == text[i])
                        {
                            words = true;
                            trueInput++;
                            word[i] = text[i];
                            label1.Text = null;
                        }
                    }
                    if (words == true)
                    {
                        for (int i = 0; i < text.Length; i++)
                            label1.Text += word[i];
                        if (trueInput == text.Length)
                        {
                            time.Stop();
                            MessageBox.Show("Победа");
                        }
                    }
                    else
                    {
                        inputMax++;
                        string hpbuff = inputMax.ToString() + ".png";
                        pictureBox1.Image = new Bitmap(hpbuff);
                        if (inputMax == 10)
                        {
                            time.Stop();
                            MessageBox.Show("Проигрыш");
                            label1.Text = null;
                            label1.Text = text;
                        }
                    }

                }
                else if (textBox2.Text.Length > 1) // Для полного ответа 
                {
                    time.Stop();
                    if (textBox2.Text == text)
                    {
                        label1.Text = null;
                        for (int i = 0; i < text.Length; i++)
                            label1.Text += text[i];
                        MessageBox.Show("Победа");
                    }
                    else
                    {
                        inputMax = 10;
                        string hpbuff = inputMax.ToString() + ".png";
                        pictureBox1.Image = new Bitmap(hpbuff);
                        MessageBox.Show("Проигрыш");
                        label1.Text = null;
                        label1.Text = text;
                    }
                }
                textBox2.Text = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inputMax < 10)
            {
                //Указываем путь для сохранения результата игры
                StreamWriter sw = new StreamWriter(File.Open("C:/Users/Polya/Desktop/data.txt", FileMode.Append));
                sw.WriteLine(Do_not_hang.Program.name + ",  " + time.Elapsed.TotalSeconds);
                sw.Close();
            }
            Close();
        }
    }
}
