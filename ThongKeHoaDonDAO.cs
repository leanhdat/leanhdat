using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class ThongKeHoaDonDAO
    {
        DataProvider dataProvider = new DataProvider();

        public ThongKeHoaDonDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach 
        public DataTable DanhHoaDon()
        {
            DataTable table = new DataTable();
            string sql = "select * from BaoCaoHD";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // them thong tin 
        public void ThemHoaDon(ThongKeHoaDonDTO tk)
        {
            string sql = "insert into BaoCaoHD(SoPhong, HoTen, SoCMND, NgayLap, TongTien) values ('" + tk.SoPhong + "', N'" + tk.HoTen + "', '" + tk.SoCMND + "', '" + tk.NgayLap + "', '" + tk.TongTien + "' )";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa thong tin 
        public void XoaHoaDon(int ma)
        {
            string sql = "delete from BaoCaoHD where [MaHD] = '" + ma + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // sua thong tin 
        public void SuaHoaDon(ThongKeHoaDonDTO tk)
        {
            string sql = "update BaoCaoHD set SoPhong = '" + tk.SoPhong + "', HoTen = N'" + tk.HoTen + "', SoCMND = '" + tk.SoCMND + "', NgayLap = '" + tk.NgayLap + "', TongTien = '" + tk.TongTien + "' where [MaHD] = '" + tk.MaHD + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // tim kiem theo so phong 
        public DataTable TimKiemSoPhong(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from BaoCaoHD where [SoPhong] like '%" + soPhong + "%'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }
    }
}
