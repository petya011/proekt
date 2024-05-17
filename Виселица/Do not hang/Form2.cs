using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_not_hang
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Do_not_hang.Program.name = textBox1.Text;
                textBox1.Text = "";
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
        }
    }
}
