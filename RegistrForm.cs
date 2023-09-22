using MD5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MD5window
{
    public partial class RegistrForm : Form
    {
        public RegistrForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || 
                textBox3.Text =="" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "" ||
                textBox7.Text == "")
            {
                MessageBox.Show("Не все данные заполнены!!!");
                return;
            }

            if (textBox6.Text != textBox7.Text)
            {
                MessageBox.Show("Пароли не совпадают!!!");
                return;
            }


            string strToHash = textBox1.Text + " " + textBox2.Text + " " +
                textBox3.Text + " " + textBox4.Text + " " +
                textBox5.Text + " " + textBox6.Text;

            MD5Class mD5 = new MD5Class();
            string strToFile = textBox1.Text + " " + textBox2.Text + " " +
                textBox3.Text + " " + textBox4.Text + " " +
                textBox5.Text + " " + mD5.HashMD5( new StringBuilder( strToHash)) + "\n";



            File.AppendAllText("users.txt", strToFile);

            TextForm textForm = new TextForm();
            textForm.Show();
            this.Visible = false;
        }

        private void RegistrForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
