using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class PhongDAO
    {
        DataProvider dataProvider = new DataProvider();

        public PhongDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach 
        public DataTable DanhSachPhong()
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // dem so luong phong 
        public int SoLuongPhong()
        {
            string sql = "select count(*) from Phong";
            int count = dataProvider.ExecuteScalar(sql);
            return count;
        }

        // dem so luong phong trong 
        public int SoLuongPhongTrong()
        {
            string sql = "select count(*) from Phong where [TrangThaiDat] = 0";
            int count = dataProvider.ExecuteScalar(sql);
            return count;
        }

        // dem so luong phong trong 
        public int SoLuongPhongDat()
        {
            string sql = "select count(*) from Phong where [TrangThaiDat] = 1";
            int count = dataProvider.ExecuteScalar(sql);
            return count;
        }

        // them thong tin 
        public void ThemPhong(PhongDTO phong)
        {
            string sql = "insert into Phong(SoPhong, HangPhong, SoLuongGiuong, TrangThaiDat, DonGia) values ('" + phong.SoPhong + "', '" + phong.HangPhong + "', N'" + phong.SoLuongGiuong + "', '" + phong.TrangThaiDat + "', '" + phong.DonGia + "' )";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa thong tin 
        public void XoaPhong(int ma)
        {
            string sql = "delete from Phong where [SoPhong] = '" + ma + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // sua thong tin 
        public void SuaPhong(PhongDTO phong)
        {
            string sql = "update Phong set HangPhong = '" + phong.HangPhong + "', SoLuongGiuong = N'" + phong.SoLuongGiuong + "', TrangThaiDat = '" + phong.TrangThaiDat + "', DonGia = '" + phong.DonGia + "' where [SoPhong] = '" + phong.SoPhong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // tim kiem theo so phong 
        public DataTable TimKiemSoPhong(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong where [SoPhong] like '%" + soPhong + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // tim kiem theo hang phong  
        public DataTable TimKiemHangPhong(string hangPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong where [HangPhong] like '%" + hangPhong + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // thue phong 
        public void ThuePhong(int soPhong)
        {
            string sql = "update Phong set TrangThaiDat = 1 where [SoPhong] = '" + soPhong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // tra phong 
        public void TraPhong(int soPhong)
        {
            string sql = "update Phong set TrangThaiDat = 0 where [SoPhong] = '" + soPhong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

    }
}
