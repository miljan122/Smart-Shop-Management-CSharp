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
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }
      public   int id = 0;
        private  void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                qry = "Insert into tblUser1 Values (@Ime,@KorisnickoIme,@Lozinka,@Telefon,@Email)";
            }

            else
            {
                qry = "Update tblUser1 set Ime = @Ime,KorisnickoIme = @KorisnickoIme,Lozinka = @Lozinka,Telefon = @Telefon, Email = @Email where userID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Ime", txtName.Text);
            ht.Add("@KorisnickoIme", txtUname.Text);
            ht.Add("@Lozinka", txtPass.Text);
            ht.Add("@Telefon", txtPhone.Text);
            ht.Add("@Email", txtEmail.Text);


            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Uspesno sacuvano.....");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }

        }
    


        private void frmUserAdd_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
