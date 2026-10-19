using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using test_tamly.Classes;

namespace test_tamly.Forms
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtNhapLaiMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            chkHienMatKhau.Text = chkHienMatKhau.Checked ? "ẩn mật khẩu" : "hiện mật khẩu";
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            var hoTen = txtHoTen.Text.Trim();
            var email = txtEmail.Text.Trim();
            var tenDangNhap = txtTenDangNhap.Text.Trim();
            var matKhau = txtMatKhau.Text;
            var nhapLai = txtNhapLaiMatKhau.Text;

            // ── Kiểm tra dữ liệu đầu vào ──
            if (hoTen.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (email.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập email.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (tenDangNhap.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (matKhau.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            if (matKhau != nhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp. Vui lòng nhập lại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            // ── Trạng thái đang xử lý: khóa nút, chống bấm nhiều lần ──
            btnDangKy.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                // 1) Đăng ký tài khoản Firebase Email/Password (lấy ID token ngay)
                await XacThucFirebase.DangKyAsync(email, matKhau, hoTen);

                // 2) Gửi token tới backend để xác nhận hệ thống hoạt động end-to-end
                var idToken = await PhienDangNhap.LayIdTokenAsync();
                if (!string.IsNullOrEmpty(idToken))
                {
                    var ketQua = await KetNoi.LayThongTinNguoiDungAsync(idToken);
                    if (!ketQua.ThanhCong && ketQua.StatusCode != 0)
                    {
                        MessageBox.Show(
                            "Đăng ký tài khoản thành công nhưng backend chưa phản hồi.\n" +
                            $"{ketQua.LoiMo}",
                            "Cảnh báo backend", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show(
                    "Đăng ký thành công! Bạn đã được đăng nhập tự động.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(XacThucFirebase.DichLoi(ex), "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangKy.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
