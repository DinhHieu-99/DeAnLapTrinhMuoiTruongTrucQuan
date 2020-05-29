using GDU_Management.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDU_Management.Model;

namespace GDU_Management.DaoImpl
{
    class GiangVienImpl : IDaoGiangVien
    {
        //tao ket noi database
        GDUDataConnectionsDataContext db;
        List<GiangVien> giangVien;

        public GiangVienImpl()
        {
            db = new GDUDataConnectionsDataContext();
            using (db)
            {
                var giangViens = from x in db.GiangViens select x;
                db.DeferredLoadingEnabled = true;
                giangVien = giangViens.ToList();
            }
        }


        public GiangVien CreateGiangVien(GiangVien giangVien)
        {
            //code content
            return null;
        }

        public void DeleteGiangVien(string maGV)
        {
           //code content
        }

        public List<GiangVien> GetAllGiangVien()
        {
            //code content
            db = new GDUDataConnectionsDataContext();
            var gv = from x in db.GiangViens select x;
            giangVien = gv.ToList();
            return giangVien;
        }

        public void UpdateGiangVien(GiangVien giangVien)
        {
            //code content
        }
    }
}
