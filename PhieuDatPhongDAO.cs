using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class PhieuDatPhongDAO
    {
        DataProvider dataProvider = new DataProvider();

        public PhieuDatPhongDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // dat phong 
        public void DatPhong(int soPhong)
        {
            string sql = "update Phong set TrangThaiDat = '" + true + "' where [SoPhong] = '" + soPhong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // them thong tin khach hang 
        public void ThemKhachHang(KhachHangDTO kh)
        {
            string sql = "insert into KhachHang(HoTen, NgaySinh, GioiTinh, DiaChi, SoCMND, SoDienThoai, SoPhong, NgayThue) values (N'" + kh.HoTen + "', '" + kh.NgaySinh + "', N'" + kh.GioiTinh + "', N'" + kh.DiaChi + "', '" + kh.SoCMND + "','" + kh.SoDT + "', '" + kh.SoPhong + "', '" + kh.NgayThue + "' )";
            dataProvider.ExecuteNonQuery(sql);
        }
    }
}
