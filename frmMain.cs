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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        static frmMain _obj;

        public static frmMain instance
        {
            get { if (_obj == null) { _obj = new frmMain(); } return _obj; }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();

            RoundPanel(guna2Panel1, 20); // 20 = radius zaobljenj
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
            AddControls(new frmSettingsView());
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as Panel;
            var radius = 20;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            panel.Region = new Region(path);
        }

        private void RoundPanel(Control ctrl, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(ctrl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(ctrl.Width - radius, ctrl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, ctrl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);

            // Održava zaobljenje i kad se promeni veličina
            ctrl.SizeChanged += (s, e) =>
            {
                var p = new System.Drawing.Drawing2D.GraphicsPath();
                p.AddArc(0, 0, radius, radius, 180, 90);
                p.AddArc(ctrl.Width - radius, 0, radius, radius, 270, 90);
                p.AddArc(ctrl.Width - radius, ctrl.Height - radius, radius, radius, 0, 90);
                p.AddArc(0, ctrl.Height - radius, radius, radius, 90, 90);
                p.CloseAllFigures();
                ctrl.Region = new Region(p);
            };
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            AddControls(new frmPos());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            AddControls(new frmReportView());
        }
    }
}
