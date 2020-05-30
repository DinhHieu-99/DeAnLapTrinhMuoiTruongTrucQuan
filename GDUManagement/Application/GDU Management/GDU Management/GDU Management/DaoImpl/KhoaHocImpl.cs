using GDU_Management.IDao;
using GDU_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GDU_Management.DaoImpl
{
    class KhoaHocImpl : IDaoKhoaHoc
    {
        //tạo kết nối database 
        GDUDataConnectionsDataContext db = new GDUDataConnectionsDataContext();
        List<KhoaHoc> khoaHoc;

        public KhoaHoc CreateKhoaHoc(KhoaHoc khoaHoc)
        {
            //code content
            return null;
        }

        public void DeleteKhoaHoc(string maKhoaHoc)
        {
            //code content
        }

        public List<KhoaHoc> GetAllKhoaHoc()
        {
            //code content
            return null;
        }

        public void UpdateKhoaHoc(KhoaHoc khoaHoc)
        {
            //code content
        }
    }
}
