namespace SmartShop1
{
    partial class ucProduct
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPic = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.Label();
            this.txtRateing = new Guna.UI2.WinForms.Guna2RatingStar();
            this.txtPrice = new System.Windows.Forms.Label();
            this.btnDetails = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPic
            // 
            this.txtPic.Image = global::SmartShop1.Properties.Resources.iphone_16_pro_black_titanium_pdp_image_position_1__cs_cz_1;
            this.txtPic.Location = new System.Drawing.Point(26, 3);
            this.txtPic.Name = "txtPic";
            this.txtPic.Size = new System.Drawing.Size(133, 135);
            this.txtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.txtPic.TabIndex = 0;
            this.txtPic.TabStop = false;
            this.txtPic.Click += new System.EventHandler(this.txtPic_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 141);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 29);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Ime Proizvoda";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRateing
            // 
            this.txtRateing.Location = new System.Drawing.Point(44, 173);
            this.txtRateing.Name = "txtRateing";
            this.txtRateing.Size = new System.Drawing.Size(115, 28);
            this.txtRateing.TabIndex = 2;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(6, 215);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(181, 23);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Text = "192,250";
            this.txtPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetails
            // 
            this.btnDetails.AutoRoundedCorners = true;
            this.btnDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetails.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetails.FillColor = System.Drawing.Color.Black;
            this.btnDetails.FillColor2 = System.Drawing.Color.SlateBlue;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(26, 241);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(133, 32);
            this.btnDetails.TabIndex = 4;
            this.btnDetails.Text = "Detalji";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtRateing);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPic);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(186, 284);
            this.MouseEnter += new System.EventHandler(this.ucProduct_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.txtPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox txtPic;
        private System.Windows.Forms.Label txtName;
        private Guna.UI2.WinForms.Guna2RatingStar txtRateing;
        private System.Windows.Forms.Label txtPrice;
        private Guna.UI2.WinForms.Guna2GradientButton btnDetails;
    }
}
