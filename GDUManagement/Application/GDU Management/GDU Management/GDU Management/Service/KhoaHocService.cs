﻿using GDU_Management.DaoImpl;
using GDU_Management.IDao;
using GDU_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDU_Management.Service
{
    class KhoaHocService
    {
        IDaoKhoaHoc khoaHocIDao = new KhoaHocImpl();

        //lấy danh sách khóa học
       public  List<KhoaHoc> GetAllKhoaHoc()
        {
            return khoaHocIDao.GetAllKhoaHoc();
        }
        //tạo khóa học
        public KhoaHoc CreateKhoaHoc(KhoaHoc khoaHoc)
        {
            return khoaHocIDao.CreateKhoaHoc(khoaHoc);
        }
        //xóa khóa học
        public void DeleteKhoaHoc(string maKhoaHoc)
        {
            khoaHocIDao.DeleteKhoaHoc(maKhoaHoc);
        }
        //cập nhật khóa học
        public void UpdateKhoaHoc(KhoaHoc khoaHoc)
        {
            khoaHocIDao.UpdateKhoaHoc(khoaHoc);
        }
    }
}
