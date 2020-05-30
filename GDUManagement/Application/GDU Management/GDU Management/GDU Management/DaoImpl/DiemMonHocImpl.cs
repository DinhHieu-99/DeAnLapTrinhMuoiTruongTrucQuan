using GDU_Management.IDao;
using GDU_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDU_Management.DaoImpl
{
    class DiemMonHocImpl : IDaoDiemMonHoc
    {
        //tao ket noi database
        GDUDataConnectionsDataContext db = new GDUDataConnectionsDataContext();
        List<DiemMonHoc> diemMonHoc;
        public DiemMonHoc AddDiemMonHoc(DiemMonHoc diemMonHoc)
        {
            //code content
            return null;
        }

        public void DeleteDiemMonHoc( string MaSV, string maMonHoc)
        {
            //code content
        }

        public List<DiemMonHoc> GetAllDiemMonHoc()
        {
            var diemMH = from x in db.DiemMonHocs select x;
            diemMonHoc = diemMH.ToList();
            return diemMonHoc;
        }

        public void UpdateDiemMonHoc(DiemMonHoc diemMonHoc)
        {
            //code content
        }
    }
}
