using System;
using GDU_Management.Model;
using GDU_Management.Service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDU_Management
{
    public partial class frmDiemAndMonHoc : Form
    {
        public frmDiemAndMonHoc()
        {
            InitializeComponent();
            NgayGio();
        }

        //CÁC HÀM PUBLIC
        MonHocService monHocService = new MonHocService();
        DiemMonHocService diemMonHocService = new DiemMonHocService();

        //load danh sach môn học lên datagridview
        public void LoadDanhSachMonHocToDatagridview()
        {
            dgvDanhSachMonHoc.DataSource = monHocService.GetAllMonHoc();
        }
        public void LoadDanhSachDiemSinhVienToDatagridview()
        {
            dgvDanhSachDiemSinhVien.DataSource = diemMonHocService.GetAllDiemMonHoc();
        }
        //1-Hàm lấy thời gian
        public void ShowDataTuDataGridViewToTextBox()
        {
            txtMaMon.DataBindings.Clear();
            txtMaMon.DataBindings.Add("text", dgvDanhSachMonHoc.DataSource, "MaMonHoc");
            txtTenMon.DataBindings.Clear();
            txtTenMon.DataBindings.Add("text", dgvDanhSachMonHoc.DataSource, "TenMonHoc");
        }
        public void NgayGio()
        {
            //get ngày
            DateTime ngay = DateTime.Now;
            lblDay.Text = ngay.ToString("dd/MM/yyyy");

            //get thời gian
            timerMonHoc.Start();
        }

        //2-Hàm Quay Trở Lại Menu GDUmanagement
        public void GoToGDUmanagement()
        {
            this.Hide();
            GDUManagement gdu = new GDUManagement();
            gdu.ShowDialog();
        }


        //KẾT THÚC CÁC HÀM PUBLIC

        private void timerMonHoc_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();

            int giay = Convert.ToInt32(lblGiay.Text);
            int phut = Convert.ToInt32(lblPhut.Text);
            giay++;
            if (giay > 59)
            {
                giay = 0;
                phut++;
            }

            if (giay < 10)
            {
                lblGiay.Text = "0" + giay;
            }
            else
            {
                lblGiay.Text = "" + giay;
            }
            if (phut < 10)
            {
                lblPhut.Text = "0" + phut;
            }
            else
            {
                lblPhut.Text = "" + phut;
            }

            if (giay % 2 == 0)
            {
                lblAnimation1.Text = "(^_^)";
                lblAnimation2.Text = "(+_+)";
                lblAnimation3.Text = "(-_^)";
            }
            else if (giay % 2 != 0)
            {
                lblAnimation2.Text = "(^_^)";
                lblAnimation1.Text = "(+_+)";
                lblAnimation3.Text = "(^_-)";
            }
            else
            {
                lblAnimation1.Text = ".";
                lblAnimation1.Text = "..";
                lblAnimation1.Text = "...";
                lblAnimation2.Text = ".";
                lblAnimation2.Text = "..";
                lblAnimation2.Text = "...";
            }
        }

        private void btnHomeMenu_Click(object sender, EventArgs e)
        {
            GoToGDUmanagement();
        }

        private void btnHomQLD_Click(object sender, EventArgs e)
        {
            GoToGDUmanagement();
        }

        private void frmDiemAndMonHoc_Load(object sender, EventArgs e)
        {
            LoadDanhSachMonHocToDatagridview();
            LoadDanhSachDiemSinhVienToDatagridview();
            ShowDataTuDataGridViewToTextBox();
            ShowDataTudgvDiemSinhVienToTextBox();
        }

        private void btnNewMonHoc_Click(object sender, EventArgs e)
        {
            btnNewMonHoc.Enabled = true;
            btnSaveMonHoc.Enabled = false;
            btnDeleteMonHoc.Enabled = false;
            txtMaMon.Text = "";
            txtTenMon.Text = "";
        }
        public bool checkDataMonHoc()
        {
            if (string.IsNullOrEmpty(txtTenMon.Text))
            {
                MessageBox.Show("Tên Môn Không được bỏ trống, vui lòng kiểm tra lại...");
                txtTenMon.Focus();
                return false;
            }
            return true;
        }
        private void btnSaveMonHoc_Click(object sender, EventArgs e)
        {
            if (checkDataMonHoc())
            {
                MonHoc monHoc = new MonHoc();
                monHoc.MaMonHoc = txtMaMon.Text.Trim();
                monHoc.TenMonHoc = txtTenMon.Text.Trim();
                monHocService.CreateMonHoc(monHoc);
                LoadDanhSachMonHocToDatagridview();
                MessageBox.Show("Thêm Thành Công...", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSaveMonHoc.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lỗi, Thêm Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveDiem_Click(object sender, EventArgs e)
        {
            DiemMonHoc diemMonHoc = new DiemMonHoc();
            diemMonHoc.Diem30 = Convert.ToDouble(txtDiem30);
            diemMonHoc.Diem70L1 = Convert.ToDouble(txtDiem70L1);
            diemMonHoc.Diem70L1 = Convert.ToDouble(txtDiem70L2);

            diemMonHocService.AddDiemMonHoc(diemMonHoc);
            LoadDanhSachDiemSinhVienToDatagridview();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDiem30.Clear();
            txtDiem70L1.Clear();
            txtDiem70L2.Clear();
        }
        public void ShowDataTudgvDiemSinhVienToTextBox()
        {

            txtDiem30.DataBindings.Clear();
            txtDiem30.DataBindings.Add("text", dgvDanhSachDiemSinhVien.DataSource, "Diem30");
            txtDiem70L1.DataBindings.Clear();
            txtDiem70L1.DataBindings.Add("text", dgvDanhSachDiemSinhVien.DataSource, "Diem70L1");
            txtDiem70L2.DataBindings.Clear();
            txtDiem70L2.DataBindings.Add("text", dgvDanhSachDiemSinhVien.DataSource, "Diem70L2");
        }

        private void btnUpdateMonHoc_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.MaMonHoc = txtMaMon.Text;
            mh.TenMonHoc = txtTenMon.Text;
            monHocService.UpdateMonHoc(mh);
            MessageBox.Show("Cập nhật thông tin '" + txtMaMon + "' Thành Công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDanhSachMonHocToDatagridview();
        }

        private void btnDeleteMonHoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa '" + txtMaMon.Text + "' ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maMon;
                maMon = txtMaMon.Text.Trim();
                if (string.IsNullOrEmpty(txtMaMon.Text))
                {
                    MessageBox.Show("Xóa Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    monHocService.DeleteMonHoc(maMon);
                    txtMaMon.Text = "";
                    txtTenMon.Text = "";
                    btnNewMonHoc.Enabled = true;
                    btnSaveMonHoc.Enabled = false;
                    btnUpdateMonHoc.Enabled = false;
                    btnDeleteMonHoc.Enabled = false;
                    LoadDanhSachMonHocToDatagridview();
                    MessageBox.Show("Đã Xóa...!!!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }
    }
}
