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
            this.BackColor = Color.FromArgb(237, 238, 233);
            button1.BackColor = Color.FromArgb(115, 131, 145);
            button1.ForeColor = Color.White;
            button2.BackColor = Color.FromArgb(115, 131, 145);
            button2.ForeColor = Color.White;
            textBox1.BackColor = Color.FromArgb(195, 217, 185);
            textBox2.BackColor = Color.FromArgb(195, 217, 185);
            textBox3.BackColor = Color.FromArgb(195, 217, 185);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
            textBox1.BackColor = Color.LightGreen;
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
            textBox2.BackColor = Color.LightGreen;
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
                textBox1.BackColor = Color.LightSalmon;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckPassword(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "A jelszó hibás");
                textBox2.BackColor = Color.LightSalmon;
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
            return string.Equals(user, "admin", StringComparison.InvariantCultureIgnoreCase);
        }

        private bool CheckPassword(string jelszo) 
        {
            return string.Equals(jelszo, "asd123", StringComparison.InvariantCultureIgnoreCase);
        }

        private bool CheckId(string id)
        {
            return !string.IsNullOrEmpty(id);
        }

        
    }
}
