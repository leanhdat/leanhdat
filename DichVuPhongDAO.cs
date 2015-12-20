using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class DichVuPhongDAO
    {
        DataProvider dataProvider = new DataProvider();

        public DichVuPhongDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach DV
        public DataTable DanhSachDichVu()
        {
            DataTable table = new DataTable();
            string sql = "select * from DichVu";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // lay danh sach DV da dat
        public DataTable DanhSachDichVuDat(string phong)
        {
            DataTable table = new DataTable();
            string sql = "select * from DichVuPhong where [SoPhong] = '" + phong + "'";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // dat them dich vu 
        public void ThemDV(DichVuPhongDTO p)
        {
            string sql = "insert into DichVuPhong(MaDV, TenDV, DonGia, SoPhong, HoTen, SoCMND) values ('" + p.MaDV + "', N'" + p.TenDV + "', '" + p.DonGia + "', '" + p.SoPhong + "', N'" + p.HoTen + "', '" + p.SoCMDN + "')";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa dich vu da dat
        public void XoaDV(string ma)
        {
            string sql = "delete from DichVuPhong where [MaDV] = '" + ma + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

    }
}
