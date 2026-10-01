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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            chkHienMatKhau.Text = chkHienMatKhau.Checked ? "ẩn mật khẩu" : "hiện mật khẩu";
                }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Tạm thời để kiểm tra giao diện
            MessageBox.Show("Đăng nhập được nhấn.");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
