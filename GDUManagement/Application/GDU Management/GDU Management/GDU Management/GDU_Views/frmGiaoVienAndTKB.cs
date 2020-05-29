using GDU_Management.Model;
using GDU_Management.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDU_Management
{
    public partial class frmGiaoVienAndTKB : Form
    {
        public frmGiaoVienAndTKB()
        {
            InitializeComponent();
            timerGiangvien_TKB.Start();
        }

        //Khai báo các service
        GiangVienService giangVienService = new GiangVienService();

        //Load danh sách vào dgv

        public void LoadDanhSachGiangVienToDatagridview()
        {
            dataGridView1.DataSource = giangVienService.GetAllGiangVien().ToList();
        }
        //hàm show dữ liệu dgv lên textbox
        public void ShowDataTuDataGridViewToTextBox()
        {
          
            txtMaGV.DataBindings.Clear();
            txtMaGV.DataBindings.Add("text", dataGridView1.DataSource, "MaGV");

            txtTenGV.DataBindings.Clear();
            txtTenGV.DataBindings.Add("text", dataGridView1.DataSource, "TenGV");

            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("text", dataGridView1.DataSource, "GioiTinh");

            cboTrinhDo.DataBindings.Clear();
            cboTrinhDo.DataBindings.Add("text", dataGridView1.DataSource, "TrinhDo");

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("text", dataGridView1.DataSource, "SDT");

            txtEmailGV.DataBindings.Clear();
            txtEmailGV.DataBindings.Add("text", dataGridView1.DataSource, "Email");

            //dateTimePicker3.DataBindings.Clear();
            //dateTimePicker3.DataBindings.Add("text", dataGridView1.DataSource, "NamSinh");

            rtxtGhiChu.DataBindings.Clear();
            rtxtGhiChu.DataBindings.Add("text", dataGridView1.DataSource, "GhiChu");

            rtxtDiaChi.DataBindings.Clear();
            rtxtDiaChi.DataBindings.Add("text", dataGridView1.DataSource, "DiaChi");

        }

        //hàm check data 
        public bool checkDataGiangVien()
        {
            if (string.IsNullOrEmpty(txtTenGV.Text))
            {
                MessageBox.Show("Tên giảng viên Không được bỏ trống, vui lòng kiểm tra lại...");
                txtTenGV.Focus();
                return false;
            }
            return true;
        }


        //CÁC HÀM PUBLIC DÙNG TRONG FORM
        //1-hàm trở về Menu Chính - GDU Management
        public void goHomeMenu()
        {
            this.Hide();
            GDUManagement gdu =new GDUManagement();
            gdu.ShowDialog();
        }

        //KẾT THÚC CÁC HÀM PUBLIC DÙNG TRONG FORM
        private void timerGiangvien_TKB_Tick(object sender, EventArgs e)
        {
            //hàm lấy ngày giờ
            lblTime.Text = DateTime.Now.ToLongTimeString();
            //lblDay.Text = DateTime.Now.ToLongDateString();
            DateTime ngay = DateTime.Now;
            lblDay.Text = ngay.ToString("dd/MM/yyyy");

            //hàm bộ điếm thời gian online
            int giay_gv = Convert.ToInt32(lblGiay_gv.Text);
            int phut_gv = Convert.ToInt32(lblPhut_gv.Text);
            giay_gv++;

            int giay_tkb = Convert.ToInt32(lblGiay_tkb.Text);
            int phut_tkb = Convert.ToInt32(lblPhut_tkb.Text);
            giay_tkb++;

            if (giay_gv > 59 & giay_tkb > 59)
            {
                giay_gv = 0;
                phut_gv++;

                giay_tkb = 0;
                phut_tkb++;
            }
            
            if (giay_gv < 10 & giay_tkb < 10)
            {
                lblGiay_gv.Text = "0" + giay_gv;
                lblGiay_tkb.Text = "0" + giay_tkb;
            }
            else
            {
                lblGiay_gv.Text = "" + giay_gv;
                lblGiay_tkb.Text = "" + giay_tkb;
            }
            if (phut_gv < 10  & phut_tkb < 10)
            {
                lblPhut_gv.Text = "0" + phut_gv;
                lblPhut_tkb.Text = "0" + phut_tkb;
            }
            else
            {
                lblPhut_gv.Text = "" + phut_gv;
                lblPhut_tkb.Text = "" + phut_tkb;
            }
          
            if (giay_gv % 2 == 0  & giay_tkb % 2 == 0)
            {
                lblAnimation1_gv.Text = "(^_^)";
                lblAnimation2_gv.Text = "(+_+)";
                lblAnimation3_gv.Text = "(-_^)";

                lblAnimation1_tkb.Text = "(^_^)";
                lblAnimation2_tkb.Text = "(+_+)";
                lblAnimation3_tkb.Text = "(-_^)";
            }
            else if (giay_gv % 2 != 0  & giay_tkb % 2 != 0)
            {
                lblAnimation1_gv.Text = "(+_+)";
                lblAnimation2_gv.Text = "(^_^)";
                lblAnimation3_gv.Text = "(^_-)";

                lblAnimation1_tkb.Text = "(+_+)";
                lblAnimation2_tkb.Text = "(^_^)";
                lblAnimation3_tkb.Text = "(^_-)";
            }
        }

        private void btnHomTKB_Click(object sender, EventArgs e)
        {
            goHomeMenu();
        }

        private void btnHomeGV_Click(object sender, EventArgs e)
        {
            goHomeMenu();
        }

        private void btnExit_TKB_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnExit_GV_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmGiaoVienAndTKB_Load(object sender, EventArgs e)
        {
            LoadDanhSachGiangVienToDatagridview();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            btnUpdateGV.Enabled = true;
            btnDeleteGV.Enabled = true;
            btnSaveGV.Enabled = false;
            txtMaGV.Enabled = false;
            ShowDataTuDataGridViewToTextBox();

        }

        private void btnSaveGV_Click(object sender, EventArgs e)
        {
            if (checkDataGiangVien())
            {
                GiangVien giangVien = new GiangVien();
                giangVien.MaGV = txtMaGV.Text.Trim();
                giangVien.TenGV = txtTenGV.Text.Trim();
                giangVien.GioiTinh = cboGioiTinh.Text.Trim();
                giangVien.TrinhDo = cboTrinhDo.Text.Trim();
                giangVien.SDT = txtSDT.Text.Trim();
                giangVien.Email = txtEmailGV.Text.Trim();
                giangVien.GhiChu = rtxtGhiChu.Text.Trim();
                giangVien.DiaChi = rtxtDiaChi.Text.Trim();

                
                giangVienService.CreateGiangVien(giangVien);
                LoadDanhSachGiangVienToDatagridview();
                MessageBox.Show("Thêm Thành Công...", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSaveGV.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lỗi, Thêm Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewGV_Click(object sender, EventArgs e)
        {
            btnSaveGV.Enabled = true;
            btnUpdateGV.Enabled = false;
            btnDeleteGV.Enabled = false;
            txtMaGV.Enabled = true;
            txtMaGV.Text = "";
            txtTenGV.Text = "";
            cboGioiTinh.Text = "";
            cboTrinhDo.Text = "";
            txtSDT.Text = "";
            txtEmailGV.Text = "";
            rtxtDiaChi.Text = "";
            rtxtGhiChu.Text = "";


        }

        private void btnUpdateGV_Click(object sender, EventArgs e)
        {
            GiangVien gv = new GiangVien();
            gv.MaGV = txtMaGV.Text;
            gv.TenGV = txtTenGV.Text;
            gv.GioiTinh = cboGioiTinh.Text;
            gv.TrinhDo = cboTrinhDo.Text;
            gv.SDT = txtSDT.Text;
            gv.Email = txtEmailGV.Text;
            gv.GhiChu = rtxtGhiChu.Text;
            gv.DiaChi = rtxtDiaChi.Text;
            giangVienService.UpdateGiangVien(gv);
            MessageBox.Show("Cập Nhật Thông Tin  '" + txtMaGV + "' Thành Công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDanhSachGiangVienToDatagridview();
        }

        private void btnDeleteGV_Click(object sender, EventArgs e)
        {
           
            if(MessageBox.Show("Bạn Có Muốn Xóa '" + txtMaGV.Text +"' ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maGiangVien;
                maGiangVien = txtMaGV.Text.Trim();
                if (string.IsNullOrEmpty(txtMaGV.Text))
                {
                    MessageBox.Show("Xóa Thất Bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    giangVienService.DeleteGiangVien(maGiangVien);
                    txtMaGV.Text = "";
                    txtTenGV.Text = "";
                    cboGioiTinh.Text = "";
                    cboTrinhDo.Text = "";
                    txtSDT.Text = "";
                    txtEmailGV.Text = "";
                    rtxtDiaChi.Text = "";
                    rtxtGhiChu.Text = "";
                    btnNewGV.Enabled = true;
                    btnSaveGV.Enabled = false;
                    btnUpdateGV.Enabled = false;
                    btnDeleteGV.Enabled = false;
                    LoadDanhSachGiangVienToDatagridview();
                    MessageBox.Show("Đã Xóa!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnUpdateGV.Enabled = true;
            btnDeleteGV.Enabled = true;
            btnSaveGV.Enabled = false;
            txtMaGV.Enabled = false;
            ShowDataTuDataGridViewToTextBox();
        }
    }
}
