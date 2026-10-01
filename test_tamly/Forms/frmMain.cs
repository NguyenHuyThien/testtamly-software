using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_tamly.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frmDangKy = new frmDangKy();
            frmDangKy.ShowDialog();
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
        }

        private void mnuCaiDat_Click(object sender, EventArgs e)
        {
        }

        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
        }

        private void mnuPhanHoi_Click(object sender, EventArgs e)
        {
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
    }
}
