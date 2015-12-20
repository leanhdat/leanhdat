using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLyKhachSan.DAO
{
    class PhongThueDAO
    {
        DataProvider dataProvider = new DataProvider();

        public PhongThueDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach phong thue
        public DataTable DanhSachPhong()
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // dem so luong phong thue
        public int SoLuongPhong()
        {
            string sql = "select count(*) from KhachHang";
            int count = dataProvider.ExecuteScalar(sql);
            return count;
        }

        // tim kiem theo so phong 
        public DataTable TimKiemSoPhong(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang where [SoPhong] like '%" + soPhong + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // tim kiem theo ten KH 
        public DataTable TimKiemTen(string ten)
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang where [HoTen] like '%" + ten + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }
    }
}
