using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          if ( MainClass.isValidUser(txtUsername.Text,txtPass.Text)== false)
            {
                MessageBox.Show("Korisnicko ime ili lozinka su neispravni!");
                return;
                    
            }
            this.Hide();
            frmMain fm = new frmMain();
            fm.ShowDialog();
        }
    }
}
