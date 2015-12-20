using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class KhachHangDAO
    {
        DataProvider dataProvider = new DataProvider();

        public KhachHangDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach 
        public DataTable DanhSachKhach()
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // dem so luong khach
        public int SoLuongKhach()
        {
            string sql = "select count(*) from KhachHang";
            int count = dataProvider.ExecuteScalar(sql);
            return count;
        }

        // kiem tra phong trong 
        public bool KiemTraPhongTrong(int soPhong)
        {
            string sql = "select * from Phong where [SoPhong] ='" + soPhong + "' and [TrangThaiDat] ='0'";
            if (dataProvider.Read(sql) == true)
                return true;
            return false;
        }

        // kiem tra phong da thue 
        public bool KiemTraPhongThue(int soPhong)
        {
            string sql = "select * from Phong where [SoPhong] ='" + soPhong + "' and [TrangThaiDat] ='1'";
            if (dataProvider.Read(sql) == true)
                return true;
            return false;
        }

        // them thong tin 
        public void ThemKhachHang(KhachHangDTO kh)
        {
            string sql = "insert into KhachHang(HoTen, NgaySinh, GioiTinh, DiaChi, SoCMND, SoDienThoai, SoPhong, NgayThue) values (N'" + kh.HoTen + "', '" + kh.NgaySinh + "', N'" + kh.GioiTinh + "', N'" + kh.DiaChi + "', '" + kh.SoCMND + "','"+kh.SoDT+"', '" + kh.SoPhong + "', '" + kh.NgayThue + "' )";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa thong tin 
        public void XoaThongTinKH(int ma)
        {
            string sql = "delete from KhachHang where [SoPhong] = '" + ma + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // sua thong tin 
        public void SuaThongTinKH(KhachHangDTO kh)
        {
            string sql = "update KhachHang set HoTen = N'" + kh.HoTen + "', NgaySinh = '" + kh.NgaySinh + "', GioiTinh = N'" + kh.GioiTinh + "', DiaChi = N'" + kh.DiaChi + "', SoCMND = '" + kh.SoCMND + "', SoDienThoai = '" + kh.SoDT + "', NgayThue = '" + kh.NgayThue + "'  where [SoPhong] = '" + kh.SoPhong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // tim kiem theo ten KH 
        public DataTable TimKiemTen(string ten)
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang where [HoTen] like '%" + ten + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // tim kiem theo so phong  
        public DataTable TimKiemPhong(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang where [SoPhong] like '%" + soPhong + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

    }
}
