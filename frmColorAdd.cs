using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class frmColorAdd : Form
    {
        public frmColorAdd()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void frmColorAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into tblColor Values (@ImeBoje)";
            }

            else
            {
                qry = "Update tblColor set ImeBoje = @ImeBoje where BojaID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@ImeBoje", txtColor.Text);



            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Uspesno sacuvano.....");
                id = 0;
                txtColor.Text = "";
                txtColor.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
