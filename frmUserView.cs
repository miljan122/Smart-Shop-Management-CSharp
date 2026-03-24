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
    public partial class frmUserView : Form
    {
        public frmUserView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * from tblUser1 where Ime like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvIme);
            lb.Items.Add(dgvKorisnicko);
            lb.Items.Add(dgvPass);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvEmail);
           
           
           


            MainClass.LoadData(qry, guna2DataGridView1, lb);



        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            GetData();
            guna2DataGridView1.DataBindingComplete += guna2DataGridView1_DataBindingComplete;




        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd());
            GetData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            guna2DataGridView1.Columns["dgvSno"].DisplayIndex = 0;
            guna2DataGridView1.Columns["dgvIme"].DisplayIndex = 1;
            guna2DataGridView1.Columns["dgvKorisnicko"].DisplayIndex = 2;
            guna2DataGridView1.Columns["dgvPass"].DisplayIndex = 3;
            guna2DataGridView1.Columns["dgvPhone"].DisplayIndex = 4;
            guna2DataGridView1.Columns["dgvEmail"].DisplayIndex = 5;
          
            guna2DataGridView1.Columns["dgvEdit"].DisplayIndex = 6;
            guna2DataGridView1.Columns["dgvDel"].DisplayIndex = 7;
        }


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmUserAdd fma = new frmUserAdd();
                fma.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                fma.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvIme"].Value);
                fma.txtUname.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvKorisnicko"].Value);
                fma.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPhone"].Value);
                fma.txtEmail.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvEmail"].Value);
                fma.txtPass.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPass"].Value);
                fma.ShowDialog();

                GetData();
            }

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("Da li ste sigurni da zelite da izbrisete?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from tblUser1 where userID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;


                    guna2MessageDialog1.Show("Uspesno izbrisano.....");
                    GetData();
                }



            }
        }
    }
}
    

