using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class HoaDonDAO
    {
        DataProvider dataProvider = new DataProvider();

        public HoaDonDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay thong tin phong 
        public DataTable LayThongTinPhong(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from Phong where [SoPhong] = '" +soPhong+ "'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // lay thong tin khach hang 
        public DataTable LayThongTinKhachHang(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from KhachHang where [SoPhong] = '" + soPhong + "'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // lay thong tin khach hang 
        public DataTable LayThongTinDichVu(int soPhong)
        {
            DataTable table = new DataTable();
            string sql = "select * from DichVuPhong where [SoPhong] = '" + soPhong + "'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // tra phong 
        public void TraPhong(int soPhong)
        {
            string sql = "update Phong set TrangThaiDat = 0 where [SoPhong] = '" + soPhong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa thong tin KH 
        public void XoaThongTinKH(int ma)
        {
            string sql = "delete from KhachHang where [SoPhong] = '" + ma + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // them thong tin dh 
        public void ThemHoaDon(ThongKeHoaDonDTO tk)
        {
            string sql = "insert into BaoCaoHD(SoPhong, HoTen, SoCMND, NgayLap, TongTien) values ('" + tk.SoPhong + "', N'" + tk.HoTen + "', '" + tk.SoCMND + "', '" + tk.NgayLap + "', '" + tk.TongTien + "' )";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa dich vu 
        public void XoaDV(int phong)
        {
            string sql = "delete from DichVuPhong where [SoPhong] = '" + phong + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

    }
}
