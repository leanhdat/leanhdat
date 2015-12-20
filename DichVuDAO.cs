using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan.DAO
{
    class DichVuDAO
    {
        DataProvider dataProvider = new DataProvider();

        public DichVuDAO()
        {
            dataProvider.OpenConnec();
        }

        // dong ket noi
        public void DongDL()
        {
            dataProvider.CloseConnec();
        }

        // lay danh sach 
        public DataTable DanhSachDichVu()
        {
            DataTable table = new DataTable();
            string sql = "select * from DichVu";
            table = dataProvider.ExecuteReader(sql);
            return table;
        }

        // them thong tin 
        public void ThemDichVu(DichVuDTO dv)
        {
            string sql = "insert into DichVu(MaDV, TenDV, DonGia, GhiChu) values ('" + dv.MaDV + "', N'" + dv.TenDV + "', '" + dv.DonGia + "', N'" + dv.GhiChu + "')";
            dataProvider.ExecuteNonQuery(sql);
        }

        // xoa thong tin 
        public void XoaDichVu(string ma)
        {
            string sql = "delete from DichVu where [MaDV] = '" + ma + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }

        // sua thong tin 
        public void SuaDichVu(DichVuDTO dv)
        {
            string sql = "update DichVu set TenDV = N'" + dv.TenDV + "', DonGia = '" + dv.DonGia + "', GhiChu = N'" + dv.GhiChu + "' where [MaDV] = '" + dv.MaDV + "' ";
            dataProvider.ExecuteNonQuery(sql);
        }
    }
}
