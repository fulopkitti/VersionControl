using DotNetNuke.UI.Skins.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kliens_alkalmazas
{
    public partial class authentication : Form
    {
        public authentication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox3, "");
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckUser(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "A felhaználó hibás");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckPassword(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "A jelszó hibás");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckId(textBox3.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Az Id nem lehet üres");
            }
        }

        private bool CheckUser(string user)
        {
            return string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase);
        }

        private bool CheckPassword(string jelszo) 
        {
            return string.Equals(jelszo, "asd123", StringComparison.OrdinalIgnoreCase);
        }

        private bool CheckId(string id)
        {
            return !string.IsNullOrEmpty(id);
        }
    }
}
