using MD5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5window
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void buttonRegistre_Click(object sender, EventArgs e)
        {

            RegistrForm registrForm = new RegistrForm();
            registrForm.Show();
            this.Visible = false;
        }

        private void buttonAutorize_Click(object sender, EventArgs e)
        {
            AuthorizeForm authorizeForm = new AuthorizeForm();
            authorizeForm.Show();
            this.Visible = false;
        }
    }
}
