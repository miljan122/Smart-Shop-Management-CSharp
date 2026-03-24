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
    public partial class frmProductView : Form
    {
        public frmProductView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = @"SELECT 
                       proID, 
                       ImeProizvoda, 
                       b.ImeBrenda AS Brend, 
                       c.ImeBoje AS Boja, 
                       Ram, 
                       Memorija, 
                       Cena
                   FROM tblProduct p
                   INNER JOIN tblColor c ON c.BojaID = p.colorID
                   INNER JOIN tblBrand b ON b.brandID = p.brandID
                   WHERE ImeProizvoda LIKE '%" + txtSearch.Text + "%'";

            ListBox lb = new ListBox(); // Napravi prazni ListBox da zadovolji LoadData
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvIme);
            lb.Items.Add(dgvBrande);
            lb.Items.Add(dgvColor);
            lb.Items.Add(dgvRam);
            lb.Items.Add(dgvStorage);
            lb.Items.Add(dgvPrice);

            MainClass.LoadData(qry, guna2DataGridView1, lb);

            // Mapiranje kolona po DataPropertyName (opciono, ali čini kod sigurnijim)
            dgvID.DataPropertyName = "proID";
            dgvIme.DataPropertyName = "ImeProizvoda";
            dgvBrande.DataPropertyName = "Brend";
            dgvColor.DataPropertyName = "Boja";
            dgvRam.DataPropertyName = "Ram";
            dgvStorage.DataPropertyName = "Memorija";
            dgvPrice.DataPropertyName = "Cena";

            dgvID.Visible = false;
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmProductAdd fa = new frmProductAdd();
            fa.ShowDialog();
            GetData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmProductAdd());
            GetData();
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmProductAdd fma = new frmProductAdd();
                fma.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
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
                    string qry = "Delete from tblProduct where proID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;


                    guna2MessageDialog1.Show("Uspesno izbrisano.....");
                    GetData();
                }



            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
