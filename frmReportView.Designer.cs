namespace SmartShop1
{
    partial class frmReportView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sdate = new System.Windows.Forms.DateTimePicker();
            this.edate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2TileButton2 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnProductList = new Guna.UI2.WinForms.Guna2TileButton();
            this.SuspendLayout();
            // 
            // sdate
            // 
            this.sdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sdate.Location = new System.Drawing.Point(73, 426);
            this.sdate.Name = "sdate";
            this.sdate.Size = new System.Drawing.Size(151, 20);
            this.sdate.TabIndex = 2;
            // 
            // edate
            // 
            this.edate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.edate.Location = new System.Drawing.Point(73, 574);
            this.edate.Name = "edate";
            this.edate.Size = new System.Drawing.Size(151, 20);
            this.edate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pocetni Datum:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 611);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Krajni Datum:";
            // 
            // guna2TileButton2
            // 
            this.guna2TileButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TileButton2.BorderRadius = 17;
            this.guna2TileButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton2.FillColor = System.Drawing.Color.SlateBlue;
            this.guna2TileButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TileButton2.ForeColor = System.Drawing.Color.White;
            this.guna2TileButton2.HoverState.FillColor = System.Drawing.Color.Black;
            this.guna2TileButton2.Image = global::SmartShop1.Properties.Resources.printing;
            this.guna2TileButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2TileButton2.Location = new System.Drawing.Point(890, 134);
            this.guna2TileButton2.Name = "guna2TileButton2";
            this.guna2TileButton2.Size = new System.Drawing.Size(193, 81);
            this.guna2TileButton2.TabIndex = 6;
            this.guna2TileButton2.Text = "Katalog/Meni";
            this.guna2TileButton2.Click += new System.EventHandler(this.guna2TileButton2_Click);
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2TileButton1.BorderRadius = 17;
            this.guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton1.FillColor = System.Drawing.Color.SlateBlue;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TileButton1.ForeColor = System.Drawing.Color.White;
            this.guna2TileButton1.HoverState.FillColor = System.Drawing.Color.Black;
            this.guna2TileButton1.Image = global::SmartShop1.Properties.Resources.sale_report;
            this.guna2TileButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2TileButton1.Location = new System.Drawing.Point(52, 467);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Size = new System.Drawing.Size(193, 81);
            this.guna2TileButton1.TabIndex = 1;
            this.guna2TileButton1.Text = "Prodajni Izvestaj";
            this.guna2TileButton1.Click += new System.EventHandler(this.guna2TileButton1_Click);
            // 
            // btnProductList
            // 
            this.btnProductList.BorderRadius = 17;
            this.btnProductList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnProductList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnProductList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnProductList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnProductList.FillColor = System.Drawing.Color.SlateBlue;
            this.btnProductList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProductList.ForeColor = System.Drawing.Color.White;
            this.btnProductList.HoverState.FillColor = System.Drawing.Color.Black;
            this.btnProductList.Image = global::SmartShop1.Properties.Resources.category__1_;
            this.btnProductList.ImageSize = new System.Drawing.Size(30, 30);
            this.btnProductList.Location = new System.Drawing.Point(52, 134);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Size = new System.Drawing.Size(193, 81);
            this.btnProductList.TabIndex = 0;
            this.btnProductList.Text = "Lista Proizvoda";
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // frmReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1142, 645);
            this.Controls.Add(this.guna2TileButton2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edate);
            this.Controls.Add(this.sdate);
            this.Controls.Add(this.guna2TileButton1);
            this.Controls.Add(this.btnProductList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReportView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TileButton btnProductList;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private System.Windows.Forms.DateTimePicker sdate;
        private System.Windows.Forms.DateTimePicker edate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton2;
    }
}