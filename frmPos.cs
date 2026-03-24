using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop1
{
    public partial class frmPos : Form
    {
        public frmPos()
        {
            InitializeComponent();
        }

        StringBuilder sb = new StringBuilder("");

        private void frmPos_Load(object sender, EventArgs e)
        {
            LoadBrands();

            string qry = @"Select max(Cena) 'Max' from tblProduct";
            DataTable dt = MainClass.GetData(qry);
            lblMax.Text = Convert.ToDouble(dt.Rows[0][0].ToString()).ToString("N0");

            TrackBar1.Maximum = Convert.ToInt32(dt.Rows[0][0].ToString()) / 2;
            TrackBar2.Maximum = Convert.ToInt32(dt.Rows[0][0].ToString());

            TrackBar2.Minimum = Convert.ToInt32(dt.Rows[0][0].ToString()) / 2;

            TrackBar2.Value = Convert.ToInt32(dt.Rows[0][0].ToString());

            LoadProduct();
            guna2DataGridView1.AllowUserToAddRows = false;


        }
        private void LoadBrands()
        {
            string qer = @"Select * from tblBrand";
            DataTable dt = MainClass.GetData(qer);

            foreach(DataRow row in dt.Rows)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = new Guna.UI2.WinForms.Guna2CheckBox();
                ck.AutoSize = true;
                ck.Text = row["ImeBrenda"].ToString();
                BrendPanel.Controls.Add(ck);

                ck.CheckStateChanged += new EventHandler(guna2CheckBox1_CheckedChanged);
            }
        }

        private void TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            lblMin.Text = Convert.ToDouble(TrackBar1.Value).ToString("N0");
            LoadProduct();
        }

        private void TrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            lblMax.Text = Convert.ToDouble(TrackBar2.Value).ToString("N0");
            LoadProduct();
        }

        private void LoadProduct()
        {
            flowLayoutPanel1.Controls.Clear();
            sb.Clear();


            sb.Append (@"Select * from tblProduct p 
               inner join tblColor c on c.BojaID = p.colorID 
               inner join tblBrand b on b.brandID = p.brandID 
               where ImeProizvoda like '%" + txtSearch.Text + "%' and Cena " +
                 " between " + Convert.ToDouble(lblMin.Text) + " and " + Convert.ToDouble(lblMax.Text)+ "");




            if(qry1 != "")
            {
                sb.Append("and Ram in(" + qry1 + ")");
            }

            if (qry2 != "")
            {
                sb.Append("and b.ImeBrenda in(" + qry2 + ")");
            }

            string qer = sb.ToString();

            DataTable dt = MainClass.GetData(qer);

            foreach(DataRow dr in dt.Rows)
            {
                Byte[] imagearry = (byte[])(dr["Slika"]);
                byte[] imagebythearray = imagearry;

                AddItems(dr["proID"].ToString(), dr["ImeProizvoda"].ToString() + "" + dr["Ram"].ToString() + " " + dr["Memorija"].ToString(), dr["Rejting"].ToString(), Image.FromStream(new MemoryStream(imagearry)), dr["Cena"].ToString(), dr["Trosak"].ToString());
            }
        }

        private void AddItems(string id, string name, string rate, Image pimage,string price, string cost)
        {
           
            var w = new ucProduct()
            {
                pName = name,
                pRateing =Convert.ToSingle(rate),
                pImage = pimage,
                pPrice = price,
                pCoast = cost,
                id = Convert.ToInt32(id)
            };

            flowLayoutPanel1.Controls.Add(w);
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["dgvProID"].Value) == wdg.id)
                    {
                        row.Cells["dgvQty"].Value = int.Parse(row.Cells["dgvQty"].Value.ToString()) + 1;
                        row.Cells["dgvAmount"].Value = (int.Parse(row.Cells["dgvQty"].Value.ToString())) * int.Parse(row.Cells["dgvPrice"].Value.ToString());
                        row.Cells["dgvCost"].Value = (int.Parse(row.Cells["dgvQty"].Value.ToString())) * double.Parse(wdg.pCoast);
                        GetTotal();
                        return;

                    }
                }

                guna2DataGridView1.Rows.Add(new object[] { 0, 0 ,wdg.id, wdg.pName, 1, wdg.pPrice, wdg.pCoast,  wdg.pPrice,  });
                GetTotal();
            };
        }

        private void GetTotal()
        {
            double tot = 0;
            txtGetTotal.Text = "00";

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                // Preskoči novi red
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["dgvAmount"].Value;
                if (cellValue != null && double.TryParse(cellValue.ToString(), out double amount))
                {
                    tot += amount;
                }
            }

            txtGetTotal.Text = tot.ToString("N0");
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;

            foreach(DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void txtRec_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double rec = 0;
            double.TryParse(txtGetTotal.Text, out amt);
            double.TryParse(txtRec.Text, out rec);

            double change = rec - amt;
            txtChange.Text = Math.Abs(change).ToString("N0");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            txtGetTotal.Text = "00";
            txtChange.Text = "00";
            txtRec.Text = "00";

            foreach(Control cc in BrendPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = new Guna.UI2.WinForms.Guna2CheckBox();
                ck.Checked = false;
            }

            foreach (Control cc in RamPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = new Guna.UI2.WinForms.Guna2CheckBox();
                ck.Checked = false;
            }

            TrackBar1.Value = 0;
            TrackBar2.Value = TrackBar2.Maximum;
            lblMin.Text = "0";
            lblMax.Text = TrackBar2.Maximum.ToString();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach(var item in flowLayoutPanel1.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.pName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void grp2_Click(object sender, EventArgs e)
        {

        }

        string qry1 = "";
        string qry2 = "";
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            qry1 = "";
            foreach(Control c in RamPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = (Guna.UI2.WinForms.Guna2CheckBox)c;
                if (ck.Checked)
                {
                    if(qry1 == "")
                    {
                        qry1 = "'" + ck.Text + "'";
                    }
                    else
                    {
                        qry1 += ",'" + ck.Text + "'";
                    }
                }
            }
            qry2 = "";
            foreach (Control c in BrendPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = (Guna.UI2.WinForms.Guna2CheckBox)c;
                if (ck.Checked)
                {
                    if (qry2 == "")
                    {
                        qry2 = "'" + ck.Text + "'";
                    }
                    else
                    {
                        qry2 += ",'" + ck.Text + "'";
                    }
                }
            }
            LoadProduct();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qryMain = "";
            string qryDetails = "";

            int r;

            qryMain = @"INSERT INTO tblMain (Datum, Ukupno, Primnjeno, Kusur)
            VALUES (@Datum,@Ukupno,@Primnjeno,@Kusur);
            SELECT SCOPE_IDENTITY()";


            SqlCommand cmd = new SqlCommand(qryMain,MainClass.con);
            cmd.Parameters.AddWithValue("@Datum",DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@Ukupno", Convert.ToDouble(txtGetTotal.Text));
            cmd.Parameters.AddWithValue("@Primnjeno", Convert.ToDouble(txtRec.Text));
            cmd.Parameters.AddWithValue("@Kusur", Convert.ToDouble(txtChange.Text));

            MainClass.con.Open();

            r = Convert.ToInt32(cmd.ExecuteScalar());

            if(r > 0)
            {
                qryDetails = @"INSERT INTO tblDetail (dmainID, proID, Kolicina, Cena, Trosak, Iznos)
               VALUES (@dmainID,@proID,@Kolicina,@Cena,@Trosak,@Iznos)";

                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    SqlCommand cmd2 = new SqlCommand(qryDetails,MainClass.con);
                    cmd2.Parameters.AddWithValue("@dmainID",r);
                    cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvProID"].Value));
                    cmd2.Parameters.AddWithValue("@Kolicina", Convert.ToInt32(row.Cells["dgvQty"].Value));
                    cmd2.Parameters.AddWithValue("@Cena", Convert.ToInt32(row.Cells["dgvPrice"].Value));
                    cmd2.Parameters.AddWithValue("@Trosak", Convert.ToInt32(row.Cells["dgvCost"].Value));
                    cmd2.Parameters.AddWithValue("@Iznos", Convert.ToInt32(row.Cells["dgvAmount"].Value));


                    cmd2.ExecuteScalar();


                }
            }
            MainClass.con.Close();
            guna2DataGridView1.Rows.Clear();
            txtGetTotal.Text = "00";
            txtChange.Text = "00";
            txtRec.Text = "00";

            foreach (Control cc in BrendPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = new Guna.UI2.WinForms.Guna2CheckBox();
                ck.Checked = false;
            }

            foreach (Control cc in RamPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2CheckBox ck = new Guna.UI2.WinForms.Guna2CheckBox();
                ck.Checked = false;
            }

            TrackBar1.Value = 0;
            TrackBar2.Value = TrackBar2.Maximum;
            lblMin.Text = "0";
            lblMax.Text = TrackBar2.Maximum.ToString();
            guna2MessageDialog1.Show("Uspesno Sacuvano...!");
            

        }
    }
}
