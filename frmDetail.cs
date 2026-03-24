using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop1
{
    public partial class frmDetail : Form
    {
        public frmDetail()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDetail_Load(object sender, EventArgs e)
        {

            if (id > 0)
            {
                string qry = @"SELECT proID,
                          ImeProizvoda,
                          brandID,
                          colorID,
                          SistemProizvoda,
                          Ram,
                          Memorija,
                          PrednjaKamera,
                          ZadnjaKamera,
                          Godina,
                          Baterija,
                          Trosak,
                          Cena,
                          VelicinaMonitora,
                          Sim,
                          Rejting,
                          Slika
                   FROM tblProduct
                   WHERE proID = " + id;

                DataTable dt = MainClass.GetData(qry);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    txtName.Text = dr["ImeProizvoda"].ToString() + "" + dr["Memorija"].ToString();
                  
                    txtRam.Text = dr["Ram"].ToString();
                  
                    txtfCamera.Text = dr["PrednjaKamera"].ToString();
                    txtCamera.Text = dr["PrednjaKamera"].ToString();
                    txtbCamera.Text = dr["ZadnjaKamera"].ToString();
                    txtYear.Text = dr["Godina"].ToString();
                    txtBattery.Text = dr["Baterija"].ToString();
                  
                    txtPrice.Text = dr["Cena"].ToString();
                    txtScreen.Text = dr["VelicinaMonitora"].ToString();
                    txtSim.Text = dr["Sim"].ToString();



                    Single rate = 0;
                    Single.TryParse(dr["Rejting"].ToString(), out rate);
                    txtRate.Value = rate;

                    if (dr["Slika"] != DBNull.Value)
                    {
                        byte[] imageArr = (byte[])dr["Slika"];
                        txtPic.Image = Image.FromStream(new MemoryStream(imageArr));
                    }
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
