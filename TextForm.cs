using MD5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MD5window
{
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }

        string fileText = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            fileText = System.IO.File.ReadAllText(filename);
            textBox2.Text = fileText;

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
       
        }

        private void TextForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MD5Class mD5Class = new MD5Class();
            textBox3.Text = mD5Class.HashMD5(new StringBuilder(textBox1.Text));
            textBox4.Text = mD5Class.HashMD5(new StringBuilder(textBox2.Text));
            if (textBox3.Text == textBox4.Text)
            {
                MessageBox.Show("Тексты одинаковые!");
            }
            else
            {
                MessageBox.Show("Тексты различны!");
            }
        }
    }
}
