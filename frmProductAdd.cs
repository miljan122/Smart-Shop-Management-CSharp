using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class frmProductAdd : Form
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "";

                if (id == 0)
                {
                    qry = @"INSERT INTO tblProduct
                    (ImeProizvoda, brandID, colorID, SistemProizvoda, Ram, Memorija,  
                     PrednjaKamera, ZadnjaKamera, Godina, Baterija, Trosak, Cena,  
                     VelicinaMonitora, Sim, Rejting, Slika)
                    VALUES
                    (@ImeProizvoda, @brandID, @colorID, @SistemProizvoda, @Ram, @Memorija,  
                     @PrednjaKamera, @ZadnjaKamera, @Godina, @Baterija, @Trosak, @Cena,  
                     @VelicinaMonitora, @Sim, @Rejting, @Slika)";
                }
                else
                {
                    qry = @"UPDATE tblProduct SET 
                        ImeProizvoda    = @ImeProizvoda,
                        brandID         = @brandID,
                        colorID         = @colorID,
                        SistemProizvoda = @SistemProizvoda,
                        Ram             = @Ram,
                        Memorija        = @Memorija,
                        PrednjaKamera   = @PrednjaKamera,
                        ZadnjaKamera    = @ZadnjaKamera,
                        Godina          = @Godina,
                        Baterija        = @Baterija,
                        Trosak          = @Trosak,
                        Cena            = @Cena,
                        VelicinaMonitora= @VelicinaMonitora,
                        Sim             = @Sim,
                        Rejting         = @Rejting,
                        Slika           = @Slika
                    WHERE proID = @id";
                }

                byte[] btyArray = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        btyArray = ms.ToArray();
                    }
                }

                Hashtable ht = new Hashtable();

                ht.Add("@ImeProizvoda", txtpname.Text);
                ht.Add("@brandID", cmbBrand.SelectedIndex > -1 ? cmbBrand.SelectedValue : DBNull.Value);
                ht.Add("@colorID", cmbColor.SelectedIndex > -1 ? cmbColor.SelectedValue : DBNull.Value);

                ht.Add("@SistemProizvoda", cmbSystem.Text);
                ht.Add("@Ram", txtRam.Text);
                ht.Add("@Memorija", txtStorage.Text);
                ht.Add("@PrednjaKamera", txtfCamera.Text);
                ht.Add("@ZadnjaKamera", txtbCamera.Text);
                ht.Add("@Godina", txtYear.Text);
                ht.Add("@Baterija", txtBattery.Text);
                double trosak = 0, cena = 0;
                double.TryParse(txtCost.Text, out trosak);
                double.TryParse(txtPrice.Text, out cena);
                ht.Add("@Trosak", trosak);
                ht.Add("@Cena", cena);
                ht.Add("@VelicinaMonitora", txtScreen.Text);
                ht.Add("@Sim", cmbSim.Text);
                ht.Add("@Rejting", Convert.ToDouble(txtRaiting.Value));
                ht.Add("@Slika", btyArray ?? (object)DBNull.Value);

                int result = MainClass.SQL(qry, ht);
                if (result > 0)
                {
                    guna2MessageDialog1.Show("Uspesno sacuvano!");
                    id = 0;
                    txtpname.Clear();
                    txtpname.Focus();
                    pictureBox1.Image = Properties.Resources.lovepik_shopping_cart_png_image_400246975_wh1200;
                    txtRaiting.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri čuvanju: " + ex.Message);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {



            string qry1 = "SELECT brandID AS id, ImeBrenda AS Brend FROM tblBrand";
            MainClass.CBFill(qry1, cmbBrand);
            cmbBrand.DisplayMember = "Brend";   // šta se vidi u ComboBox-u
            cmbBrand.ValueMember = "id";        // vrednost iza toga (npr. ID)
            cmbBrand.SelectedIndex = -1;        // da ne bude automatski prvi izabran


            string qry2 = "SELECT BojaID AS id, ImeBoje AS Boja FROM tblColor";
            MainClass.CBFill(qry2, cmbColor);
            cmbColor.DisplayMember = "Boja";
            cmbColor.ValueMember = "id";
            cmbColor.SelectedIndex = -1;



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

                    txtpname.Text = dr["ImeProizvoda"].ToString();
                    cmbBrand.SelectedValue = dr["brandID"];
                    cmbColor.SelectedValue = dr["colorID"];
                    cmbSystem.Text = dr["SistemProizvoda"].ToString();
                    txtRam.Text = dr["Ram"].ToString();
                    txtStorage.Text = dr["Memorija"].ToString();
                    txtfCamera.Text = dr["PrednjaKamera"].ToString();
                    txtbCamera.Text = dr["ZadnjaKamera"].ToString();
                    txtYear.Text = dr["Godina"].ToString();
                    txtBattery.Text = dr["Baterija"].ToString();
                    txtCost.Text = dr["Trosak"].ToString();
                    txtPrice.Text = dr["Cena"].ToString();
                    txtScreen.Text = dr["VelicinaMonitora"].ToString();
                    cmbSim.Text = dr["Sim"].ToString();



                    Single rate = 0;
                    Single.TryParse(dr["Rejting"].ToString(), out rate);
                    txtRaiting.Value = rate;

                    if (dr["Slika"] != DBNull.Value)
                    {
                        byte[] imageArr = (byte[])dr["Slika"];
                        pictureBox1.Image = Image.FromStream(new MemoryStream(imageArr));
                    }
                }
            }

        }

        private void btnBrowe_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePatch = ofd.FileName;
                pictureBox1.Image = new Bitmap(filePatch);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "";

                if (id == 0)
                {
                    qry = @"INSERT INTO tblProduct
                    (ImeProizvoda, brandID, colorID, SistemProizvoda, Ram, Memorija,  
                     PrednjaKamera, ZadnjaKamera, Godina, Baterija, Trosak, Cena,  
                     VelicinaMonitora, Sim, Rejting, Slika)
                    VALUES
                    (@ImeProizvoda, @brandID, @colorID, @SistemProizvoda, @Ram, @Memorija,  
                     @PrednjaKamera, @ZadnjaKamera, @Godina, @Baterija, @Trosak, @Cena,  
                     @VelicinaMonitora, @Sim, @Rejting, @Slika)";
                }
                else
                {
                    qry = @"UPDATE tblProduct SET 
                        ImeProizvoda    = @ImeProizvoda,
                        brandID         = @brandID,
                        colorID         = @colorID,
                        SistemProizvoda = @SistemProizvoda,
                        Ram             = @Ram,
                        Memorija        = @Memorija,
                        PrednjaKamera   = @PrednjaKamera,
                        ZadnjaKamera    = @ZadnjaKamera,
                        Godina          = @Godina,
                        Baterija        = @Baterija,
                        Trosak          = @Trosak,
                        Cena            = @Cena,
                        VelicinaMonitora= @VelicinaMonitora,
                        Sim             = @Sim,
                        Rejting         = @Rejting,
                        Slika           = @Slika
                    WHERE proID = @id";
                }

                // Pretvaranje slike u byte[]
                byte[] btyArray = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        btyArray = ms.ToArray();
                    }
                }

                // Dodavanje parametara
                Hashtable ht = new Hashtable();
                ht.Add("@ImeProizvoda", txtpname.Text);
                ht.Add("@brandID", cmbBrand.SelectedIndex > -1 ? cmbBrand.SelectedValue : DBNull.Value);
                ht.Add("@colorID", cmbColor.SelectedIndex > -1 ? cmbColor.SelectedValue : DBNull.Value);
                ht.Add("@SistemProizvoda", cmbSystem.Text);
                ht.Add("@Ram", txtRam.Text);
                ht.Add("@Memorija", txtStorage.Text);
                ht.Add("@PrednjaKamera", txtfCamera.Text);
                ht.Add("@ZadnjaKamera", txtbCamera.Text);
                ht.Add("@Godina", txtYear.Text);
                ht.Add("@Baterija", txtBattery.Text);

                double trosak = 0, cena = 0;
                double.TryParse(txtCost.Text, out trosak);
                double.TryParse(txtPrice.Text, out cena);
                ht.Add("@Trosak", trosak);
                ht.Add("@Cena", cena);
                ht.Add("@VelicinaMonitora", txtScreen.Text);
                ht.Add("@Sim", cmbSim.Text);
                ht.Add("@Rejting", Convert.ToDouble(txtRaiting.Value));
                ht.Add("@Slika", btyArray ?? (object)DBNull.Value);

                // Samo za UPDATE dodaj id parametar
                if (id > 0)
                {
                    ht.Add("@id", id);
                }

                // Poziv metode za SQL izvršenje
                int result = MainClass.SQL(qry, ht);

                if (result > 0)
                {
                    guna2MessageDialog1.Show("Uspesno sacuvano!");

                    // Resetovanje polja
                    id = 0;
                    txtpname.Clear();
                    txtRam.Clear();
                    txtStorage.Clear();
                    txtfCamera.Clear();
                    txtbCamera.Clear();
                    txtYear.Clear();
                    txtBattery.Clear();
                    txtCost.Clear();
                    txtPrice.Clear();
                    txtScreen.Clear();
                    txtRaiting.Value = 0;
                    pictureBox1.Image = null;

                    txtpname.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri čuvanju: " + ex.Message);
            }
        }
    }
}
