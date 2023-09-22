using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MD5;

namespace MD5window
{
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextForm textForm = new TextForm();

            MD5Class mD5 = new MD5Class();

            string[] users = File.ReadAllLines("users.txt");

            

            foreach (string user in users)
            {
                string[] words = user.Split(' ');

                if (words[4] == textBox1.Text)
                {
                    string str = words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4] + " " + textBox2.Text;

                    if (mD5.HashMD5(new StringBuilder( str)) == words[5])
                    {

                        textForm.Show();

                        this.Visible = false;
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль неверны!!!");
                        return;
                    }
                }
            }

            MessageBox.Show("Логин или пароль неверны!!!");



        }

        private void AuthorizeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
