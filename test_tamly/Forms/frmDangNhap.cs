using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_tamly.Classes;

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

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            var email = txtTenDangNhap.Text.Trim();
            var matKhau = txtMatKhau.Text;

            // ── Kiểm tra dữ liệu đầu vào ──
            if (email.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập email đăng nhập.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (matKhau.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // ── Trạng thái đang xử lý: khóa nút, chống bấm nhiều lần ──
            btnDangNhap.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                // 1) Đăng nhập Firebase Email/Password
                await XacThucFirebase.DangNhapAsync(email, matKhau);

                // 2) Lấy ID token và gọi backend để xác nhận token hoạt động thật
                var idToken = await PhienDangNhap.LayIdTokenAsync();
                if (string.IsNullOrEmpty(idToken))
                {
                    MessageBox.Show("Đăng nhập Firebase thành công nhưng không lấy được ID token.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ketQua = await KetNoi.LayThongTinNguoiDungAsync(idToken);
                if (!ketQua.ThanhCong)
                {
                    // Đăng nhập Firebase OK nhưng backend không truy cập được —
                    // vẫn coi là đăng nhập thành công, chỉ cảnh báo backend
                    var tieuDe = ketQua.StatusCode == 0 ? "Cảnh báo" : "Cảnh báo backend";
                    MessageBox.Show(
                        "Đăng nhập Firebase thành công nhưng không gọi được backend.\n" +
                        $"{ketQua.LoiMo}\n\n" +
                        "Bạn vẫn có thể dùng các chức năng không cần backend.",
                        tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Đăng nhập thành công!\nXin chào {email}.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(XacThucFirebase.DichLoi(ex), "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using var frm = new frmDangKy();
            frm.ShowDialog(this);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
