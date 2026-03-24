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
    public partial class ucProduct : UserControl
    {
        public EventHandler onSelect = null;
        public ucProduct()
        {
            InitializeComponent();
        }

       


        public int id  { get; set; }
        public string pCoast { get; set; }

        public string pName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }


        }

        public string pPrice
        {
            get { return txtPrice.Text; }
            set { txtPrice.Text = value; }
        }

        public Single pRateing
        {
            get { return txtRateing.Value; }
            set { txtRateing.Value = value; }
        }

        public Image pImage
        {
            get { return txtPic.Image; }
            set { txtPic.Image = value; }
        }

        private void txtPic_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmDetail() { id = id });
        }

        private void ucProduct_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }
    }
}
