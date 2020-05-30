﻿
using GDU_Management.Model;
using GDU_Management.Service;
using System;
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
    public partial class frmQuanLySinhVien : Form
    {
        public frmQuanLySinhVien()
        {
            InitializeComponent();
            NgayGio();
            btnSaveKhoa.Enabled = false;
            btnUpdateKhoa.Enabled = false;
            btnDeleteKhoa.Enabled = false; 
        }

        //các delegate dùng để truyền id qua các form con
        delegate void SendMaKhoaToFrmDanhSachKhoa(TextBox dlgtxtMaKhoa);


        //khai báo service 
        SinhVienService sinhVienService = new SinhVienService();
        KhoaService khoaService = new KhoaService();
        KhoaHocService khoaHocService = new KhoaHocService();
        NganhHocService nganhHocService = new NganhHocService();

      //------------------------DS HÀM PUBLIC---------------------//

            //hàm lấy ngày giờ và điếm thời gian
        public void NgayGio()
        {
            //get ngày
            DateTime ngay = DateTime.Now;
            lblDay.Text = ngay.ToString("dd/MM/yyyy");
            lblDay2.Text = ngay.ToString("dd/MM/yyyy");

            //get thời gian + điếm thời gian
            timerTime_QLSV.Start();
        }

        //hàm trở lại menu chính
        void goToGDUmanagement()
        {
            this.Hide();
            GDUManagement gdu = new GDUManagement();
            gdu.ShowDialog();
        }

        //load danh sach sinh viên lên datagridview
        public void LoadDanhSachSinhVienToDatagridview()
        {
            dgvDSSV.DataSource = sinhVienService.GetAllSinhVien();
        }

        //laod danh sach khoa lên datagridview
        public void LoadDanhSachKhoaToDatagridview()
        {
            dgvDanhSachKhoa.DataSource = khoaService.GetAllKhoa();
        }

        //load danh sách khóa lên datagridview
        public void LoadDanhSachKhoaHocToDatagridview()
        {
            dgvDanhSachKhoaHoc.DataSource = khoaHocService.GetAllKhoaHoc();
        }

        //hàm show dữ liệu dgv lên textbox
        public void ShowDataTuDataGridViewToTextBox()
        {
            //Tab Khoa & Nganh
            txtMaKhoa.DataBindings.Clear();
            txtMaKhoa.DataBindings.Add("text", dgvDanhSachKhoa.DataSource, "MaKhoa");
            txtTenKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Add("text", dgvDanhSachKhoa.DataSource, "TenKhoa");

            lblMaKhoa.DataBindings.Clear();
            lblMaKhoa.DataBindings.Add("text", dgvDanhSachKhoa.DataSource, "MaKhoa");
            lblTenKhoa.DataBindings.Clear();
            lblTenKhoa.DataBindings.Add("text", dgvDanhSachKhoa.DataSource, "TenKhoa");

            //Tab Khóa & Lớp
            txtMaKhoaHoc.DataBindings.Clear();
            txtMaKhoaHoc.DataBindings.Add("text", dgvDanhSachKhoaHoc.DataSource, "MaKhoaHoc");
            txtTenKhoaHoc.DataBindings.Clear();
            txtTenKhoaHoc.DataBindings.Add("text", dgvDanhSachKhoaHoc.DataSource, "TenKhoaHoc");
            txtNienKhoa.DataBindings.Clear();
            txtNienKhoa.DataBindings.Add("text", dgvDanhSachKhoaHoc.DataSource, "NienKhoa");

            //  lblMaKhoaHocKL.DataBindings.Clear();
            //lblMaKhoaHocKL.DataBindings.Add("text", dgvDanhSachKhoaHoc.DataSource, "MaKhoaHoc");

            // string maKhoa = cboChonKhoa.SelectedValue.ToString();

        }

        //show dữ liệu lên combox
        public void LoadDataToCombox()
        {
            cboChonKhoa.DataSource = khoaService.GetAllKhoa();
            cboChonKhoa.DisplayMember = "TenKhoa";
            cboChonKhoa.ValueMember = "MaKhoa";
        }

        public void LoadDuLieuNganh(string maKhoa)
        {
            maKhoa = cboChonKhoa.SelectedItem.ToString();
            cboChonNganh.DisplayMember = "TenNganh";
            cboChonNganh.DataSource = nganhHocService.GetNganhHocByKHOA(maKhoa);
        }

        //hàm check data 
        public bool checkDataKHOA()
        {
            if (string.IsNullOrEmpty(txtTenKhoa.Text))
            {
                MessageBox.Show("Tên Khoa Không được bỏ trống, vui lòng kiểm tra lại...");
                txtTenKhoa.Focus();
                return false;
            }
            return true;
        }

        //KẾT THÚC DS HÀM PUBLIC

     //--------------------------------------------------------------------------------------//
        private void timerTime_QLSV_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblTime2.Text = DateTime.Now.ToLongTimeString();

            int giay_qlk = Convert.ToInt32(lblGiay_QLK.Text);
            int phut_qlk = Convert.ToInt32(lblPhut_QLK.Text);

            int giay_qlkh = Convert.ToInt32(lblGiay_QLKH.Text);
            int phut_qlkh = Convert.ToInt32(lblPhut_QLKH.Text);
            giay_qlk++;
            giay_qlkh++;
            if (giay_qlk > 59 & giay_qlkh > 59)
            {
                giay_qlk = 0;
                phut_qlk++;

                giay_qlkh = 0;
                phut_qlkh++;
            }

            if (giay_qlk < 10  & giay_qlkh <10)
            {
                lblGiay_QLK.Text = "0" + giay_qlk;
                lblGiay_QLKH.Text = "0" + giay_qlkh;
            }
            else
            {
                lblGiay_QLK.Text = "" + giay_qlk;
                lblGiay_QLKH.Text = "" + giay_qlkh;
            }
            if (phut_qlk < 10 & phut_qlkh < 10)
            {
                lblPhut_QLK.Text = "0" + phut_qlk;
                lblPhut_QLKH.Text = "0" + phut_qlkh;
            }
            else
            {
                lblPhut_QLK.Text = "" + phut_qlk;
                lblPhut_QLKH.Text = "" + phut_qlkh;
            }
            if (giay_qlk % 2 == 0  & giay_qlkh % 2 == 0)
            {
                lblAnimation1_QKL.Text = "(^_^)";
                lblAnimation2_QLK.Text = "(+_+)";
                lblAnimation3_QLK.Text = "(-_^)";

                lblAnimation1_QLKH.Text = "(^_^)";
                lblAnimation2_QLKH.Text = "(+_+)";
                lblAnimation3_QLKH.Text = "(-_^)";
            }
            else if (giay_qlk % 2 != 0 & giay_qlkh % 2 != 0)
            {
                lblAnimation2_QLK.Text = "(^_^)";
                lblAnimation1_QKL.Text = "(+_+)";
                lblAnimation3_QLK.Text = "(^_-)";

                lblAnimation2_QLKH.Text = "(^_^)";
                lblAnimation2_QLKH.Text = "(+_+)";
                lblAnimation3_QLKH.Text = "(^_-)";
            }
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadDanhSachSinhVienToDatagridview();
            LoadDanhSachKhoaToDatagridview();
            LoadDanhSachKhoaHocToDatagridview();
            ShowDataTuDataGridViewToTextBox();
            LoadDataToCombox();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnDSNganh_Click(object sender, EventArgs e)
        {
            frmDanhSachNganh frmDSNganh = new frmDanhSachNganh();
            SendMaKhoaToFrmDanhSachKhoa sendMaKhoa = new SendMaKhoaToFrmDanhSachKhoa(frmDSNganh.FunData);
            sendMaKhoa(this.txtMaKhoa);
            frmDSNganh.ShowDialog();
        }

        private void btnXemDanhSachLop_Click(object sender, EventArgs e)
        {
            frmDanhSachLop frmDSLop = new frmDanhSachLop();
            frmDSLop.ShowDialog();
        }

        private void btnHome_QLK_Click(object sender, EventArgs e)
        {
            goToGDUmanagement();
        }

        private void btnHome_QLKH_Click(object sender, EventArgs e)
        {
            goToGDUmanagement();
        }

        private void btnExit_QLK_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnExit_QLKH_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHome_SV_Click(object sender, EventArgs e)
        {
            goToGDUmanagement();
        }

        private void dgvDanhSachKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSaveKhoa.Enabled = false;
            btnUpdateKhoa.Enabled = true;
            btnDeleteKhoa.Enabled = true;
            ShowDataTuDataGridViewToTextBox();
        }

        private void btnSaveKhoa_Click(object sender, EventArgs e)
        {
            if (checkDataKHOA())
            {
                Khoa khoa = new Khoa();
                khoa.MaKhoa = txtMaKhoa.Text.Trim();
                khoa.TenKhoa = txtTenKhoa.Text.Trim();

                khoaService.CreateKhoa(khoa);
                LoadDanhSachKhoaToDatagridview();
                MessageBox.Show("Thêm Thành Công...", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSaveKhoa.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lỗi, Thêm Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewKhoa_Click(object sender, EventArgs e)
        {
            btnSaveKhoa.Enabled = true;
            btnUpdateKhoa.Enabled = false;
            btnDeleteKhoa.Enabled = false;
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void btnUpdateKhoa_Click(object sender, EventArgs e)
        {
            Khoa kh = new Khoa();
            kh.MaKhoa = txtMaKhoa.Text;
            kh.TenKhoa = txtTenKhoa.Text;
            khoaService.UpdateKhoa(kh);
            MessageBox.Show("Cập nhật thông tin '"+txtMaKhoa+"' Thành Công", "THÔNG BÁO", MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadDanhSachKhoaToDatagridview();
        }

        private void btnDeleteKhoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Có Muốn Xóa '"+ txtMaKhoa.Text +"' ?", "THÔNG BÁO" ,MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maKhoa;
                maKhoa = txtMaKhoa.Text.Trim();
                if (string.IsNullOrEmpty(txtMaKhoa.Text))
                {
                    MessageBox.Show("Xóa Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    khoaService.DeleteKhoa(maKhoa);
                    txtMaKhoa.Text = "";
                    txtTenKhoa.Text = "";
                    btnNewKhoa.Enabled = true;
                    btnSaveKhoa.Enabled = false;
                    btnUpdateKhoa.Enabled = false;
                    btnDeleteKhoa.Enabled = false;
                    LoadDanhSachKhoaToDatagridview();
                    MessageBox.Show("Đã Xóa...!!!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void dgvDanhSachKhoa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSaveKhoa.Enabled = false;
            btnUpdateKhoa.Enabled = true;
            btnDeleteKhoa.Enabled = true;
            ShowDataTuDataGridViewToTextBox();
        }

        private void cboChonKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string maKhoa = cboChonKhoa.SelectedValue.ToString();
            cboChonNganh.DataSource = nganhHocService.GetNganhHocByKHOA(maKhoa);
            cboChonNganh.DisplayMember = "TenNganh";
        }

        private void cboChonNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnNewKhoaHoc_Click(object sender, EventArgs e)
        {
            txtMaKhoaHoc.Clear();
            txtTenKhoaHoc.Clear();
            txtNienKhoa.Clear();

            btnSaveKhoaHoc.Enabled = true;
            btnUpdateKhoaHoc.Enabled = false;
            btnDeleteKhoaHoc.Enabled = false;
        }
    }
}
