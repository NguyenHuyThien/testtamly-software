using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_tamly.Forms
{
    partial class frmDangNhap
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
            // ==========================================================
            // Màu sắc dùng chung cho giao diện
            // ==========================================================
            Color mauChuDao = Color.FromArgb(79, 70, 229);      // Màu chủ đạo (indigo)
            Color mauChuDaoDam = Color.FromArgb(63, 55, 201);   // Màu chủ đạo đậm hơn (khi rê chuột)
            Color mauNen = Color.FromArgb(247, 249, 254);       // Màu nền form
            Color mauChu = Color.FromArgb(58, 62, 82);          // Màu chữ chính
            Color mauChuNhat = Color.FromArgb(90, 95, 115);     // Màu chữ phụ

            SuspendLayout();

            // pnlHeader : Thanh tiêu đề chạy ngang đầu form
            pnlHeader = new Panel();
            pnlHeader.BackColor = mauChuDao;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(440, 80);
            pnlHeader.TabIndex = 0;

            // btnQuayLai : Nút Quay lại
            btnQuayLai = new Button();
            btnQuayLai.BackColor = mauChuDao;
            btnQuayLai.FlatAppearance.BorderSize = 0;
            btnQuayLai.FlatAppearance.MouseOverBackColor = mauChuDaoDam;
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

            // lblTieuDe : Tiêu đề "ĐĂNG NHẬP" nằm giữa thanh header
            lblTieuDe = new Label();
            lblTieuDe.BackColor = mauChuDao;
            lblTieuDe.Dock = DockStyle.Fill;
            lblTieuDe.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "ĐĂNG NHẬP";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // lblTenDangNhap : Nhãn "Tên đăng nhập"
            lblTenDangNhap = new Label();
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 10F);
            lblTenDangNhap.ForeColor = mauChu;
            lblTenDangNhap.Location = new Point(60, 120);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.TabIndex = 1;
            lblTenDangNhap.Text = "Tên đăng nhập";

            // txtTenDangNhap : Ô nhập tên đăng nhập
            txtTenDangNhap = new TextBox();
            txtTenDangNhap.BackColor = Color.White;
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 10F);
            txtTenDangNhap.ForeColor = Color.FromArgb(30, 34, 50);
            txtTenDangNhap.Location = new Point(60, 148);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(320, 30);
            txtTenDangNhap.TabIndex = 2;

            // lblMatKhau : Nhãn "Mật khẩu"
            lblMatKhau = new Label();
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F);
            lblMatKhau.ForeColor = mauChu;
            lblMatKhau.Location = new Point(60, 200);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mật khẩu";

            // txtMatKhau : Ô nhập mật khẩu (hiện dấu chấm)
            txtMatKhau = new TextBox();
            txtMatKhau.BackColor = Color.White;
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 10F);
            txtMatKhau.ForeColor = Color.FromArgb(30, 34, 50);
            txtMatKhau.Location = new Point(60, 228);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(320, 30);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.UseSystemPasswordChar = true;

            // chkHienMatKhau : Hiện / ẩn mật khẩu
            chkHienMatKhau = new CheckBox();
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Font = new Font("Segoe UI", 9F);
            chkHienMatKhau.ForeColor = mauChuNhat;
            chkHienMatKhau.Location = new Point(62, 272);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;

            // ----------------------------------------------------------
            // btnDangNhap : Nút "ĐĂNG NHẬP" (nút chính)
            // ----------------------------------------------------------
            btnDangNhap = new Button();
            btnDangNhap.BackColor = mauChuDao;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatAppearance.MouseOverBackColor = mauChuDaoDam;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(60, 312);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(320, 44);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;

            // ----------------------------------------------------------
            // btnQuenMatKhau : Nút "Quên mật khẩu?"
            // ----------------------------------------------------------
            btnQuenMatKhau = new Button();
            btnQuenMatKhau.BackColor = Color.White;
            btnQuenMatKhau.FlatAppearance.BorderColor = mauChuDao;
            btnQuenMatKhau.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 234, 248);
            btnQuenMatKhau.FlatStyle = FlatStyle.Flat;
            btnQuenMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQuenMatKhau.ForeColor = mauChuDao;
            btnQuenMatKhau.Location = new Point(60, 380);
            btnQuenMatKhau.Name = "btnQuenMatKhau";
            btnQuenMatKhau.Size = new Size(150, 40);
            btnQuenMatKhau.TabIndex = 7;
            btnQuenMatKhau.Text = "Quên mật khẩu?";
            btnQuenMatKhau.UseVisualStyleBackColor = false;

            // ----------------------------------------------------------
            // btnDangKy : Nút "Đăng ký" (chuyển sang form đăng ký)
            // ----------------------------------------------------------
            btnDangKy = new Button();
            btnDangKy.BackColor = Color.White;
            btnDangKy.FlatAppearance.BorderColor = mauChuDao;
            btnDangKy.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 234, 248);
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangKy.ForeColor = mauChuDao;
            btnDangKy.Location = new Point(230, 380);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(150, 40);
            btnDangKy.TabIndex = 8;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;

            // ----------------------------------------------------------
            // frmDangNhap : Cấu hình chung của form
            // ----------------------------------------------------------
            pnlHeader.Controls.Add(btnQuayLai);
            pnlHeader.Controls.Add(lblTieuDe);
            Controls.Add(pnlHeader);
            Controls.Add(lblTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(chkHienMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(btnQuenMatKhau);
            Controls.Add(btnDangKy);

            AutoScaleMode = AutoScaleMode.None;
            BackColor = mauNen;
            ClientSize = new Size(440, 452);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ==========================================================
        // Khai báo các control (đặt ở cuối file để dễ đọc)
        // ==========================================================
        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap;
        private Button btnQuenMatKhau;
        private Button btnDangKy;
        private Button btnQuayLai;
    }
}