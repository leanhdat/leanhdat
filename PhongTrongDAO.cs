using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKhachSan.DAO
{
    class PhongTrongDAO
    {
        DataProvider dataProvider = new DataProvider();

        public PhongTrongDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach 
        public DataTable DanhSachPhongTrong()
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong where [TrangThaiDat] = 0";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // dem so luong phong 
        public int SoLuongPhong()
        {
            string sql = "select count(*) from Phong where [TrangThaiDat] = 0";
            int count = dataProvider.ExecuteScalar(sql);
            return count;
        }

        // tim kiem theo so phong 
        public DataTable TimKiemSoPhong(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong where [SoPhong] like '%" + soPhong + "%' and [TrangThaiDat] = 0";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // tim kiem theo hang phong  
        public DataTable TimKiemHangPhong(string hangPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong where [HangPhong] like '%" + hangPhong + "%' and [TrangThaiDat] = 0";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

    }
}
