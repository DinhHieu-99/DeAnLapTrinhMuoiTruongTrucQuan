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
    public partial class frmDiemAndMonHoc : Form
    {
        public frmDiemAndMonHoc()
        {
            InitializeComponent();
            NgayGio();
        }

        //CÁC HÀM PUBLIC
        

        //1-Hàm lấy thời gian
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
            lblTime.Text= DateTime.Now.ToLongTimeString();

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
    }
}
