using System;
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
    public partial class frmSettingsView : Form
    {
        public frmSettingsView()
        {
            InitializeComponent();
        }

        private void AddControls(Form f)
        {
            centarpanel.Controls.Clear();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            centarpanel.Controls.Add(f);
            f.Show();

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            AddControls(new frmUserView());
        }

        private void frmSettingsView_Load(object sender, EventArgs e)
        {
            // ili boja po izboru
            guna2Panel1.BorderRadius = 17;
            guna2Panel1.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
            {
                TopLeft = true,
                TopRight = true,
                BottomLeft = true,
                BottomRight = true
            };

        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            AddControls(new frmBrandView());
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            AddControls(new frmColorView());
        }
    }
    
}
