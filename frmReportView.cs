using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop1
{
    public partial class frmReportView : Form
    {
        public frmReportView()
        {
            InitializeComponent();
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            string qry = @"Select * from tblProduct p inner join tblColor c on c.BojaID = p.colorID
                            inner join tblBrand b on b.brandID = p.brandID";

            DataTable dt = MainClass.GetData(qry);
            frmPrint fm = new frmPrint();
            CrystalReport1 cr = new CrystalReport1();

            cr.SetDataSource(dt);
            cr.SetDatabaseLogon("sa", "123");
            fm.crystalReportViewer1.ReportSource = cr;
            fm.crystalReportViewer1.Refresh();
            fm.Show();

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = @"
            SELECT 
                p.proID,
                p.ImeProizvoda,
                SUM(d.Kolicina) AS Kolicina,
                SUM(d.Iznos) AS Iznos
            FROM tblMain m
            INNER JOIN tblDetail d ON d.dmainID = m.mainID
            INNER JOIN tblProduct p ON p.proID = d.proID
            WHERE m.Datum BETWEEN @sdate AND @edate
            GROUP BY p.proID, p.ImeProizvoda";

                using (SqlCommand cmd = new SqlCommand(qry, MainClass.con))
                {
                    cmd.Parameters.AddWithValue("@sdate", sdate.Value.Date);
                    cmd.Parameters.AddWithValue("@edate", edate.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Nema podataka za izabrani period!");
                        return;
                    }

                    frmPrint fm = new frmPrint();
                    CrystalReport2 cr = new CrystalReport2();

                    cr.SetDataSource(dt);
                    cr.SetDatabaseLogon("sa", "123");

                    fm.crystalReportViewer1.ReportSource = null;
                    fm.crystalReportViewer1.Refresh();

                    fm.crystalReportViewer1.ReportSource = cr;
                    fm.crystalReportViewer1.Refresh();

                    fm.Show();

                    fm.FormClosed += (s, args) => { cr.Dispose(); };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            string qry = @"Select * from tblProduct";
            SqlCommand cmd1 = new SqlCommand(qry, MainClass.con);
            MainClass.con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            sda.Fill(dt);
            MainClass.con.Close();


            frmPrint fp = new frmPrint();
            CrystalReport3 cr = new CrystalReport3();

            cr.SetDatabaseLogon("sa", "123");
            cr.SetDataSource(dt);
            fp.crystalReportViewer1.ReportSource = cr;
            fp.crystalReportViewer1.Refresh();
            fp.Show();
        }
    }
}
