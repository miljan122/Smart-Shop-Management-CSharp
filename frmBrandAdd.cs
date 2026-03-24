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
using System.Xml.Linq;

namespace SmartShop1
{
    public partial class frmBrandAdd : Form
    {
        public frmBrandAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into tblBrand Values (@ImeBrenda)";
            }

            else
            {
                qry = "Update tblBrand set ImeBrenda = @ImeBrenda where brandID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@ImeBrenda", txtBrand.Text);
          


            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Uspesno sacuvano.....");
                id = 0;
                txtBrand.Text = "";
                txtBrand.Focus();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
