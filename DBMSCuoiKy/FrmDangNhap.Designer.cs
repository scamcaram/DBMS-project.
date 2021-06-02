namespace DBMSCuoiKy
{
    partial class FrmDangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.PanelLogin = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelLogon = new System.Windows.Forms.Panel();
            this.btndangnhap = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.linklblDangky = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtmatkhau = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txttaikhoan = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PanelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panelLogon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.PanelLogin;
            this.bunifuDragControl1.Vertical = true;
            // 
            // PanelLogin
            // 
            this.PanelLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PanelLogin.BackgroundImage")));
            this.PanelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelLogin.Controls.Add(this.btnExit);
            this.PanelLogin.Controls.Add(this.panelLogon);
            this.PanelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLogin.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.PanelLogin.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(135)))), ((int)(((byte)(147)))));
            this.PanelLogin.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(135)))), ((int)(((byte)(147)))));
            this.PanelLogin.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.PanelLogin.Location = new System.Drawing.Point(0, 0);
            this.PanelLogin.Name = "PanelLogin";
            this.PanelLogin.Quality = 10;
            this.PanelLogin.Size = new System.Drawing.Size(586, 591);
            this.PanelLogin.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageActive = null;
            this.btnExit.Location = new System.Drawing.Point(544, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 25);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelLogon
            // 
            this.panelLogon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelLogon.Controls.Add(this.btndangnhap);
            this.panelLogon.Controls.Add(this.label1);
            this.panelLogon.Controls.Add(this.linklblDangky);
            this.panelLogon.Controls.Add(this.label3);
            this.panelLogon.Controls.Add(this.label2);
            this.panelLogon.Controls.Add(this.pictureBox2);
            this.panelLogon.Controls.Add(this.txtmatkhau);
            this.panelLogon.Controls.Add(this.txttaikhoan);
            this.panelLogon.Controls.Add(this.pictureBox1);
            this.panelLogon.Controls.Add(this.lblLogin);
            this.panelLogon.Location = new System.Drawing.Point(142, 53);
            this.panelLogon.Name = "panelLogon";
            this.panelLogon.Size = new System.Drawing.Size(323, 490);
            this.panelLogon.TabIndex = 0;
            // 
            // btndangnhap
            // 
            this.btndangnhap.Active = false;
            this.btndangnhap.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btndangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btndangnhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndangnhap.BackgroundImage")));
            this.btndangnhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndangnhap.BorderRadius = 7;
            this.btndangnhap.ButtonText = "Đăng Nhập";
            this.btndangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndangnhap.DisabledColor = System.Drawing.Color.Gray;
            this.btndangnhap.Font = new System.Drawing.Font("#9Slide03 Arima Madurai Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangnhap.Iconcolor = System.Drawing.Color.Transparent;
            this.btndangnhap.Iconimage = null;
            this.btndangnhap.Iconimage_right = null;
            this.btndangnhap.Iconimage_right_Selected = null;
            this.btndangnhap.Iconimage_Selected = null;
            this.btndangnhap.IconMarginLeft = 0;
            this.btndangnhap.IconMarginRight = 0;
            this.btndangnhap.IconRightVisible = true;
            this.btndangnhap.IconRightZoom = 0D;
            this.btndangnhap.IconVisible = true;
            this.btndangnhap.IconZoom = 90D;
            this.btndangnhap.IsTab = false;
            this.btndangnhap.Location = new System.Drawing.Point(52, 310);
            this.btndangnhap.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btndangnhap.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btndangnhap.OnHoverTextColor = System.Drawing.Color.White;
            this.btndangnhap.selected = false;
            this.btndangnhap.Size = new System.Drawing.Size(214, 41);
            this.btndangnhap.TabIndex = 19;
            this.btndangnhap.Text = "Đăng Nhập";
            this.btndangnhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btndangnhap.Textcolor = System.Drawing.Color.White;
            this.btndangnhap.TextFont = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("#9Slide03 Arima Madurai Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(91, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Chưa có tài khoản?";
            // 
            // linklblDangky
            // 
            this.linklblDangky.AutoSize = true;
            this.linklblDangky.Font = new System.Drawing.Font("#9Slide03 Arima Madurai", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblDangky.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linklblDangky.Location = new System.Drawing.Point(117, 433);
            this.linklblDangky.Name = "linklblDangky";
            this.linklblDangky.Size = new System.Drawing.Size(66, 26);
            this.linklblDangky.TabIndex = 16;
            this.linklblDangky.TabStop = true;
            this.linklblDangky.Text = "Đăng ký";
            this.linklblDangky.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDangky_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("#9Slide03 Arima Madurai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(15, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("#9Slide03 Arima Madurai", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên tài khoản";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DBMSCuoiKy.Properties.Resources.icons8_lock_24px_1;
            this.pictureBox2.Location = new System.Drawing.Point(18, 217);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtmatkhau.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtmatkhau.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtmatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmatkhau.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtmatkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtmatkhau.HintForeColor = System.Drawing.Color.Empty;
            this.txtmatkhau.HintText = "";
            this.txtmatkhau.isPassword = true;
            this.txtmatkhau.LineFocusedColor = System.Drawing.Color.AliceBlue;
            this.txtmatkhau.LineIdleColor = System.Drawing.Color.Gray;
            this.txtmatkhau.LineMouseHoverColor = System.Drawing.Color.Thistle;
            this.txtmatkhau.LineThickness = 2;
            this.txtmatkhau.Location = new System.Drawing.Point(60, 217);
            this.txtmatkhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtmatkhau.MaxLength = 32767;
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(243, 35);
            this.txtmatkhau.TabIndex = 10;
            this.txtmatkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txttaikhoan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txttaikhoan.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txttaikhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttaikhoan.Font = new System.Drawing.Font("#9Slide03 Arima Madurai Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttaikhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttaikhoan.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txttaikhoan.HintText = "Nhập tên tài khoản";
            this.txttaikhoan.isPassword = false;
            this.txttaikhoan.LineFocusedColor = System.Drawing.Color.AliceBlue;
            this.txttaikhoan.LineIdleColor = System.Drawing.Color.Gray;
            this.txttaikhoan.LineMouseHoverColor = System.Drawing.Color.Thistle;
            this.txttaikhoan.LineThickness = 2;
            this.txttaikhoan.Location = new System.Drawing.Point(60, 131);
            this.txttaikhoan.Margin = new System.Windows.Forms.Padding(4);
            this.txttaikhoan.MaxLength = 32767;
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(243, 35);
            this.txttaikhoan.TabIndex = 9;
            this.txttaikhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DBMSCuoiKy.Properties.Resources.icons8_customer_24px_3;
            this.pictureBox1.Location = new System.Drawing.Point(18, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("#9Slide03 Arima Madurai ExtraBo", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(74, 25);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(170, 50);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Đăng Nhập";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.panelLogon;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 35;
            this.bunifuElipse3.TargetControl = this;
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 591);
            this.Controls.Add(this.PanelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.PanelLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panelLogon.ResumeLayout(false);
            this.panelLogon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuGradientPanel PanelLogin;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelLogon;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtmatkhau;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txttaikhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklblDangky;
        private Bunifu.Framework.UI.BunifuFlatButton btndangnhap;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
    }
}

