using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_tamly.Forms
{
    partial class frmDangKy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblNhapLaiMatKhau = new Label();
            txtNhapLaiMatKhau = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnDangKy = new Button();
            btnQuayLai = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(79, 70, 229);
            pnlHeader.Controls.Add(btnQuayLai);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(440, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.BackColor = Color.FromArgb(79, 70, 229);
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(0, 0);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(440, 80);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "ĐĂNG KÝ";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F);
            lblHoTen.ForeColor = Color.FromArgb(58, 62, 82);
            lblHoTen.Location = new Point(59, 112);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(97, 23);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.BackColor = Color.White;
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.ForeColor = Color.FromArgb(30, 34, 50);
            txtHoTen.Location = new Point(60, 140);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(320, 30);
            txtHoTen.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.FromArgb(58, 62, 82);
            lblEmail.Location = new Point(60, 196);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(82, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.FromArgb(30, 34, 50);
            txtEmail.Location = new Point(60, 224);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 30);
            txtEmail.TabIndex = 5;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 10F);
            lblTenDangNhap.ForeColor = Color.FromArgb(58, 62, 82);
            lblTenDangNhap.Location = new Point(60, 280);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(192, 23);
            lblTenDangNhap.TabIndex = 6;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = Color.White;
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 10F);
            txtTenDangNhap.ForeColor = Color.FromArgb(30, 34, 50);
            txtTenDangNhap.Location = new Point(60, 308);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(320, 30);
            txtTenDangNhap.TabIndex = 7;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F);
            lblMatKhau.ForeColor = Color.FromArgb(58, 62, 82);
            lblMatKhau.Location = new Point(60, 364);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(128, 23);
            lblMatKhau.TabIndex = 8;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Color.White;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.ForeColor = Color.FromArgb(30, 34, 50);
            txtMatKhau.Location = new Point(60, 392);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(320, 30);
            txtMatKhau.TabIndex = 9;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblNhapLaiMatKhau
            // 
            lblNhapLaiMatKhau.AutoSize = true;
            lblNhapLaiMatKhau.Font = new Font("Segoe UI", 10F);
            lblNhapLaiMatKhau.ForeColor = Color.FromArgb(58, 62, 82);
            lblNhapLaiMatKhau.Location = new Point(60, 448);
            lblNhapLaiMatKhau.Name = "lblNhapLaiMatKhau";
            lblNhapLaiMatKhau.Size = new Size(234, 23);
            lblNhapLaiMatKhau.TabIndex = 10;
            lblNhapLaiMatKhau.Text = "Nhập lại mật khẩu";
            // 
            // txtNhapLaiMatKhau
            // 
            txtNhapLaiMatKhau.BackColor = Color.White;
            txtNhapLaiMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtNhapLaiMatKhau.Font = new Font("Segoe UI", 10F);
            txtNhapLaiMatKhau.ForeColor = Color.FromArgb(30, 34, 50);
            txtNhapLaiMatKhau.Location = new Point(60, 476);
            txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            txtNhapLaiMatKhau.Size = new Size(320, 30);
            txtNhapLaiMatKhau.TabIndex = 11;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Font = new Font("Segoe UI", 9F);
            chkHienMatKhau.ForeColor = Color.FromArgb(90, 95, 115);
            chkHienMatKhau.Location = new Point(62, 520);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(203, 36);
            chkHienMatKhau.TabIndex = 12;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.FromArgb(79, 70, 229);
            btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 55, 201);
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangKy.ForeColor = Color.White;
            btnDangKy.Location = new Point(60, 556);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(320, 44);
            btnDangKy.TabIndex = 13;
            btnDangKy.Text = "ĐĂNG KÝ";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = Color.FromArgb(79, 70, 229);
            btnQuayLai.FlatAppearance.BorderSize = 0;
            btnQuayLai.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 55, 201);
            btnQuayLai.FlatStyle = FlatStyle.Flat;
            btnQuayLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuayLai.ForeColor = Color.White;
            btnQuayLai.Dock = DockStyle.Left;
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(100, 80);
            btnQuayLai.TabIndex = 0;
            btnQuayLai.Text = "< Quay lại";
            btnQuayLai.UseVisualStyleBackColor = false;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // frmDangKy
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(247, 249, 254);
            ClientSize = new Size(440, 624);
            Controls.Add(pnlHeader);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(lblNhapLaiMatKhau);
            Controls.Add(txtNhapLaiMatKhau);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnDangKy);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký";
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ==========================================================
        // Khai báo các control (đặt ở cuối file để dễ đọc)
        // ==========================================================
        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblNhapLaiMatKhau;
        private TextBox txtNhapLaiMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangKy;
        private Button btnQuayLai;
    }
}