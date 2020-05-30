using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDU_Management.IDao;
using GDU_Management.Model;

namespace GDU_Management.DaoImpl
{
    class MonHocImpl: IDaoMonHoc
    {
        //tao ket noi database
        GDUDataConnectionsDataContext db ;
        List<MonHoc> listmonHoc;

        public MonHoc CreateMonHoc(MonHoc monHoc)
        {
            db = new GDUDataConnectionsDataContext();
            MonHoc mhoc = new MonHoc();
            mhoc = monHoc;
            db.MonHocs.InsertOnSubmit(mhoc);
            db.SubmitChanges();
            return mhoc;
        }

        public void DeleteMonHoc(string maMonHoc)
        {
           
        }

        public List<MonHoc> GetAllMonHoc()
        {
            db = new GDUDataConnectionsDataContext();
            var mh = from x in db.MonHocs select x;
            listmonHoc = mh.ToList();
            return listmonHoc;
        }

        public void UpdateMonHoc(MonHoc monHoc)
        {
            
        }
    }
}
