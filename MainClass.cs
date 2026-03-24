using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShop1
{
    internal class MainClass
    {
        public static readonly string con_string = "Data Source=DESKTOP-FUSGD8B\\SQLEXPRESS;Initial Catalog=SmartShop;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public static SqlConnection con = new SqlConnection(con_string);

        public static bool isValidUser(string user, string pass)
        {
            bool isValid = false;
            string qry = @"Select * from tblUser1 where KorisnickoIme = '" + user + "' and Lozinka = '" + pass + "'  ";
            SqlCommand cmd = new SqlCommand(qry, con);


            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;

                USER = dt.Rows[0]["KorisnickoIme"].ToString();
            }

            return isValid;

        }

        public static string user;

        public static string USER
        {
            get { return user; }

            private set { user = value; }
        }

        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                if (con.State == ConnectionState.Closed) { con.Open(); }

                res = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open) { con.Close(); }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return res;
        }


        public static DataTable GetData(string qry)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {

            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);


            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;

            }
        }

        public static void BlurBackground(Form Model)
        {
            Form b = new Form();
            using (Model)
            {
                b.StartPosition = FormStartPosition.Manual;
                b.FormBorderStyle = FormBorderStyle.None;
                b.Opacity = 0.5d;
                b.BackColor = Color.Black;
                b.Size = frmMain.instance.Size;
                b.Location = frmMain.instance.Location;
                b.ShowInTaskbar = false;
                b.Show();
                Model.Owner = b;
                Model.ShowDialog(b);
                b.Dispose();


            }
        }


        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            cb.DisplayMember = "Ime";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;

        }
    }
}

