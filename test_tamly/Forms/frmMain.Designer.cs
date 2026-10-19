using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_tamly.Forms
{
    partial class frmMain
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
            // Màu sắc dùng chung cho giao diện (đồng bộ với frmDangKy)
            // ==========================================================
            Color mauChuDao = Color.FromArgb(79, 70, 229);      // Màu chủ đạo (indigo)
            Color mauChuDaoDam = Color.FromArgb(63, 55, 201);   // Màu chủ đạo đậm hơn (khi rê chuột)
            Color mauNen = Color.FromArgb(247, 249, 254);       // Màu nền form
            Color mauChu = Color.FromArgb(58, 62, 82);          // Màu chữ chính

            SuspendLayout();

            // ----------------------------------------------------------
            // menuMain : Thanh menu chức năng phụ của phần mềm
            // ----------------------------------------------------------
            menuMain = new MenuStrip();
            mnuCaiDat = new ToolStripMenuItem();
            mnuHoTro = new ToolStripMenuItem();
            mnuHuongDan = new ToolStripMenuItem();
            mnuPhanHoi = new ToolStripMenuItem();
            mnuGioiThieu = new ToolStripMenuItem();
            mnuTaiKhoan = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();

            // ----------------------------------------------------------
            // mnuCaiDat : Mục "Cài đặt"
            // ----------------------------------------------------------
            mnuCaiDat.Name = "mnuCaiDat";
            mnuCaiDat.Text = "Cài đặt";
            mnuCaiDat.Click += mnuCaiDat_Click;

            // ----------------------------------------------------------
            // mnuHoTro : Mục "Hỗ trợ" (chứa submenu)
            // ----------------------------------------------------------
            mnuHoTro.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDan });
            mnuHoTro.Name = "mnuHoTro";
            mnuHoTro.Text = "Hỗ trợ";

            // ----------------------------------------------------------
            // mnuHuongDan : Mục "Hướng dẫn sử dụng"
            // ----------------------------------------------------------
            mnuHuongDan.Name = "mnuHuongDan";
            mnuHuongDan.Text = "Hướng dẫn sử dụng";
            mnuHuongDan.Click += mnuHuongDan_Click;

            // ----------------------------------------------------------
            // mnuPhanHoi : Mục "Phản hồi" (gộp chức năng Đặt câu hỏi)
            // ----------------------------------------------------------
            mnuPhanHoi.Name = "mnuPhanHoi";
            mnuPhanHoi.Text = "Phản hồi";
            mnuPhanHoi.Click += mnuPhanHoi_Click;

            // ----------------------------------------------------------
            // mnuGioiThieu : Mục "Giới thiệu"
            // ----------------------------------------------------------
            mnuGioiThieu.Name = "mnuGioiThieu";
            mnuGioiThieu.Text = "Giới thiệu";
            mnuGioiThieu.Click += mnuGioiThieu_Click;

            // ----------------------------------------------------------
            // mnuTaiKhoan : Mục "Tài khoản" (chứa submenu)
            // ----------------------------------------------------------
            mnuTaiKhoan.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat });
            mnuTaiKhoan.Name = "mnuTaiKhoan";
            mnuTaiKhoan.Text = "Tài khoản";

            // ----------------------------------------------------------
            // mnuDangXuat : Mục "Đăng xuất"
            // ----------------------------------------------------------
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;

            // ----------------------------------------------------------
            // menuMain : Gắn các mục vào thanh menu
            // ----------------------------------------------------------
            menuMain.Items.AddRange(new ToolStripItem[]
            {
                mnuCaiDat,
                mnuHoTro,
                mnuPhanHoi,
                mnuGioiThieu,
                mnuTaiKhoan
            });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(7, 2, 0, 2);
            menuMain.Size = new Size(900, 28);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuMain";

            // ----------------------------------------------------------
            // lblTieuDe : Tiêu đề "PHẦN MỀM TEST TÂM LÝ" nằm giữa form
            // ----------------------------------------------------------
            lblTieuDe = new Label();
            lblTieuDe.BackColor = mauChuDao;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(0, 35);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(900, 50);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "PHẦN MỀM TEST TÂM LÝ";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // ----------------------------------------------------------
            // Khu vực tài khoản đã bị lược bỏ nhóm
            // ----------------------------------------------------------

            // ----------------------------------------------------------
            // btnDangNhap : Nút "Đăng nhập" (hiển thị khi chưa đăng nhập)
            // ----------------------------------------------------------
            btnDangNhap = new Button();
            btnDangNhap.BackColor = mauChuDao;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatAppearance.MouseOverBackColor = mauChuDaoDam;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(250, 100);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(400, 55);
            btnDangNhap.TabIndex = 0;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;

            // ----------------------------------------------------------
            // btnDangKy : Nút "Đăng ký" (hiển thị khi chưa đăng nhập)
            // ----------------------------------------------------------
            btnDangKy = new Button();
            btnDangKy.BackColor = mauChuDao;
            btnDangKy.FlatAppearance.BorderSize = 0;
            btnDangKy.FlatAppearance.MouseOverBackColor = mauChuDaoDam;
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangKy.ForeColor = Color.White;
            btnDangKy.Location = new Point(250, 165);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(400, 55);
            btnDangKy.TabIndex = 1;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;

            // ----------------------------------------------------------
            // btnThongTinCaNhan : Nút "Thông tin cá nhân" (ẩn ban đầu)
            // hiển thị thay thế 2 nút trên sau khi đăng nhập thành công
            // ----------------------------------------------------------
            btnThongTinCaNhan = new Button();
            btnThongTinCaNhan.BackColor = mauChuDao;
            btnThongTinCaNhan.FlatAppearance.BorderSize = 0;
            btnThongTinCaNhan.FlatAppearance.MouseOverBackColor = mauChuDaoDam;
            btnThongTinCaNhan.FlatStyle = FlatStyle.Flat;
            btnThongTinCaNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThongTinCaNhan.ForeColor = Color.White;
            btnThongTinCaNhan.Location = new Point(250, 100);
            btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            btnThongTinCaNhan.Size = new Size(400, 55);
            btnThongTinCaNhan.TabIndex = 2;
            btnThongTinCaNhan.Text = "Thông tin cá nhân";
            btnThongTinCaNhan.UseVisualStyleBackColor = false;
            btnThongTinCaNhan.Visible = false;
            btnThongTinCaNhan.Click += btnThongTinCaNhan_Click;

            // Add buttons directly to the form instead

            // ----------------------------------------------------------
            // lblDanhSachTest : Tiêu đề "CÁC BÀI TEST"
            // ----------------------------------------------------------
            lblDanhSachTest = new Label();
            lblDanhSachTest.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDanhSachTest.ForeColor = mauChu;
            lblDanhSachTest.Location = new Point(150, 235);
            lblDanhSachTest.Name = "lblDanhSachTest";
            lblDanhSachTest.Size = new Size(600, 40);
            lblDanhSachTest.TabIndex = 3;
            lblDanhSachTest.Text = "CÁC BÀI TEST";
            lblDanhSachTest.TextAlign = ContentAlignment.MiddleCenter;

            // ----------------------------------------------------------
            // pnlDanhSachTest : Khu vực chứa danh sách bài test động
            // Không tạo sẵn Button cho từng bài test; bài test sẽ được
            // tạo động bằng code dựa trên dữ liệu từ Firebase.
            // ----------------------------------------------------------
            pnlDanhSachTest = new Panel();
            pnlDanhSachTest.AutoScroll = true;
            pnlDanhSachTest.BackColor = Color.White;
            pnlDanhSachTest.BorderStyle = BorderStyle.FixedSingle;
            pnlDanhSachTest.Location = new Point(150, 275);
            pnlDanhSachTest.Name = "pnlDanhSachTest";
            pnlDanhSachTest.Size = new Size(600, 300);
            pnlDanhSachTest.TabIndex = 4;

            // ----------------------------------------------------------
            // btnXemKetQua : Nút "Xem kết quả" (chức năng cố định)
            // ----------------------------------------------------------
            btnXemKetQua = new Button();
            btnXemKetQua.BackColor = mauChuDao;
            btnXemKetQua.FlatAppearance.BorderSize = 0;
            btnXemKetQua.FlatAppearance.MouseOverBackColor = mauChuDaoDam;
            btnXemKetQua.FlatStyle = FlatStyle.Flat;
            btnXemKetQua.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnXemKetQua.ForeColor = Color.White;
            btnXemKetQua.Location = new Point(250, 590);
            btnXemKetQua.Name = "btnXemKetQua";
            btnXemKetQua.Size = new Size(400, 55);
            btnXemKetQua.TabIndex = 5;
            btnXemKetQua.Text = "Xem kết quả";
            btnXemKetQua.UseVisualStyleBackColor = false;
            btnXemKetQua.Click += btnXemKetQua_Click;

            // ----------------------------------------------------------
            // btnThoat : Nút "Thoát"
            // ----------------------------------------------------------
            btnThoat = new Button();
            btnThoat.BackColor = Color.FromArgb(220, 53, 69);
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(250, 660);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(400, 55);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;

            // ----------------------------------------------------------
            // frmMain : Cấu hình chung của form
            // ----------------------------------------------------------
            Controls.Add(btnThoat);
            Controls.Add(menuMain);
            Controls.Add(lblTieuDe);
            Controls.Add(btnDangNhap);
            Controls.Add(btnDangKy);
            Controls.Add(btnThongTinCaNhan);
            Controls.Add(lblDanhSachTest);
            Controls.Add(pnlDanhSachTest);
            Controls.Add(btnXemKetQua);

            AutoScaleMode = AutoScaleMode.None;
            BackColor = mauNen;
            ClientSize = new Size(900, 745);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuMain;
            MaximizeBox = false;
            MinimizeBox = true;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm Test Tâm lý";
            KeyPreview = true;
            KeyDown += frmMain_KeyDown;

            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ==========================================================
        // Khai báo các control (đặt ở cuối file để dễ đọc)
        // ==========================================================
        private MenuStrip menuMain;
        private ToolStripMenuItem mnuCaiDat;
        private ToolStripMenuItem mnuHoTro;
        private ToolStripMenuItem mnuHuongDan;
        private ToolStripMenuItem mnuPhanHoi;
        private ToolStripMenuItem mnuGioiThieu;
        private ToolStripMenuItem mnuTaiKhoan;
        private ToolStripMenuItem mnuDangXuat;
        private Label lblTieuDe;
        private Button btnDangNhap;
        private Button btnDangKy;
        private Button btnThongTinCaNhan;
        private Label lblDanhSachTest;
        private Panel pnlDanhSachTest;
        private Button btnXemKetQua;
        private Button btnThoat;
    }
}