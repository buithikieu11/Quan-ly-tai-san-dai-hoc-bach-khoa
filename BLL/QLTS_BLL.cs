using QuanLyTaiSanDHBK.DAL;
using QuanLyTaiSanDHBK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiSanDHBK.BLL
{
    class QLTS_BLL
    {
        QLTS_DAL dt;
        private static Random random = new Random();
        public delegate void myDelegate(TaiSan myTS);
        public myDelegate d;
        public QLTS_BLL()
        {
            dt = new QLTS_DAL();
        }
        public List<string> GetListTenLoaiTS_BLL()
        {
            return dt.GetListTenLoaiTS_DAL();
        }
        public string GetMaLoaiTS_BLL(string tenLoaiTS)
        {
            return dt.GetMaLoaiTS_DAL(tenLoaiTS);
        }
        public List<string> GetListMaTS_BLL()
        {
            return dt.GetListMaTS_DAL();
        }
        public List<string> GetListMaCTT_BLL()
        {
            return dt.GetListMaCTT_DAL();
        }
        public void AddTS_BLL(TaiSan myTS)
        {
            dt.AddTS_DAL(myTS);
        }
        public List<string> GetListPhongKhoa_BLL(string makhoa)
        {
            return dt.GetListPhongKhoa_DAL(makhoa);
        }
        public List<string> GetListKhoa_BLL()
        {
            return dt.GetListKhoa_DAL();
        }
        public string GetMaKhoa_BLL(string tenkhoa)
        {
            return dt.GetMaKhoa_DAL(tenkhoa);
        }
        public List<string> GetTenTSChiaKhoa_BLL()
        {
            return dt.GetTenTSChiaKhoa_DAL();
        }
        public string GetMaTSTruong_BLL(string tents)
        {
            return dt.GetMaTSTruong_DAL(tents);

        }
        public TaiSan GetInfoAdd_BLL(string mats)
        {
            return dt.GetinfoAdd_DAL(mats);
        }
        public dynamic GetSL_BLL(string mats)
        {
            return dt.GetSL_DAL(mats);
        }
        public void UpdateSL(string mats, int sl, int thanhtien)
        {
            dt.UpdateSL(mats, sl, thanhtien);
        }
        public List<string> GetTenTSChiaPhong_DAL(string makhoa)
        {
            return dt.GetTenTSChiaPhong_DAL(makhoa);
        }
        public string GetMaTSKhoa_DAL(string tents, string makhoa)
        {
            return dt.GetMaTSKhoa_DAL(tents, makhoa);
        }
        public string GetMaPhong_BLL(string tenphong)
        {
            return dt.GetMaPhong_DAL(tenphong);
        }
        public dynamic GetInfoNhapTruong_BLL()
        {
            return dt.GetInfoNhapTruong_DAL();
        }
        public dynamic GetInfoNhapAllKhoa_BLL()
        {
            return dt.GetInfoNhapAllKhoa_DAL();
        }

        public dynamic GetInfoTSAllPhong_BLL()
        {
            return dt.GetInfoTSAllPhong_DAL();

        }
        public dynamic GetInfoTSOnePhong_BLL(string maphong)
        {
            return dt.GetInfoTSOnePhong_DAL(maphong);

        }
        public void DeleTS_BLL(string id)
        {
            dt.DeleTS_DAL(id);
        }
        public void DeleTSTruong_BLL(string id)
        {
            dt.DeleTSTruong_DAL(id);

        }
        public void DeleTSKhoa_BLL(string id)
        {
            dt.DeleTSKhoa_DAL(id);

        }

        public dynamic GetInfoNhapOneKhoa_BLL(string makhoa)
        {
            return dt.GetInfoNhapOneKhoa_DAL(makhoa);
        }
        public dynamic GetinfoTScua1khoa_BLL(string makhoa)
        {
            return dt.GetinfoTScua1khoa_DAL(makhoa);

        }
        public string GetTenKhoa_BLL(string makhoa)
        {
            return dt.GetTenKhoa_DAL(makhoa);
        }
        public string GetTenPhong_BLL(string maphong)
        {
            return dt.GetTenPhong_DAL(maphong);

        }
        public List<object> SortListTaiSan_BLL(string tenkhoa, string tenphong, string columnName)
        {
            return dt.SortListTaiSan_DAL(tenkhoa, tenphong, columnName);
        }
        public dynamic SearchTS_BLL(string tenkhoa, string tenphong, string idfirst)
        {
            return dt.SearchTS_DAL(tenkhoa, tenphong, idfirst);

        }
        public dynamic SortTruong_BLL(string columnName)
        {
            return dt.SortTruong_DAL(columnName);
        }
        public dynamic SearchTruong_BLL(string id)
        {
            return dt.SearchTruong_DAL(id);
        }
        public dynamic SortKhoa_BLL(string tenkhoa, string columnName)
        {
            return dt.SortKhoa_DAL(tenkhoa, columnName);
        }
        public dynamic SearchTSkhoa_BLL(string tenkhoa, string id)
        {
            return dt.SearchTSkhoa_DAL(tenkhoa, id);
        }
        public dynamic GetMTSOnePhong_BLL(string maphong)
        {
            return dt.GetMTSOnePhong_DAL(maphong);

        }

        public int GetThanhtien_BLL(string mats)
        {
            return dt.GetThanhtien_DAL(mats);


        }
        public void AddChungTuGiam_BLL(DTO.ChungTuGiam myTS)
        {
            dt.AddChungTuGiam_DAL(myTS);

        }
        public dynamic ShowCTGAllTruong_BLL()
        {
            return dt.ShowCTGAllTruong_DAL();

        }
        public dynamic ShowCTGOneKhoa_Bll(string tenkhoa)
        {
            return dt.ShowCTGOneKhoa_DAL(tenkhoa);
        }
        public dynamic ShowCTGOnePhong_Bll(string tenphong)
        {
            return dt.ShowCTGOnePhong_DAL(tenphong);

        }
        public int GetSLNhapKhoa_BLL(string id)
        {
            return dt.GetSLNhapKhoa_DAL(id);

        }
        public void DeleCTG_BLL(string id)
        {
            dt.DeleCTG_DAL(id);

        }
        public void UpDateCLHM_BLL(string mats, int haomon, int conlai)
        {
            dt.UpDateCLHM_DAL(mats, haomon, conlai);
        }
        public List<object> SortListCTG_DLL(string tenkhoa, string tenphong, string columnName)
        {
            return dt.SortListCTG_DAL(tenkhoa, tenphong, columnName);
        }
        public dynamic SearchCTG_BLL(string tenkhoa, string tenphong, string idfirst)
        {
            return dt.SearchCTG_DAL(tenkhoa, tenphong, idfirst);
        }
        public dynamic GetMCTG_BLL()
        {
            return dt.GetMCTG_DAL();
        }
        public DTO.ChungTuGiam GetInfoCTG_BLL(string MCTG)
        {
            return dt.GetInfoCTG_DAL(MCTG);

        }
        public string GetTenTS_BLL(string mats)
        {
            return dt.GetTenTS_DAL(mats);
        }
        public dynamic GetMTS_CTG(string maphong)
        {
            return dt.GetMTS_CTG(maphong);
        }
        public void UpdateCTG_BLL(string mctg, int sl, DateTime ngg, int tt, string nd, string gc)
        {
            dt.UpdateCTG_DAL(mctg, sl, ngg, tt, nd, gc);
        }
        public dynamic Loadkhoa_CTG_DAL()
        {
            return dt.Loadkhoa_CTG_DAL();
        }
        public dynamic LoadKhoaDuocTruongPhanVe_BLL()
        {
            return dt.LoadKhoaDuocTruongPhanVe_DAL();
        }
        public void updateSLNhap_DAL(string mats, int sln)
        {
            dt.updateSLNhap_DAL(mats, sln);
        }
        public int GetSLnhap_BLL(string mats)
        {
            return dt.GetSLnhap_DAL(mats);
        }
        public dynamic GetKhoaVaPhongDuocChiaTS_DAL()
        {
            return dt.GetKhoaVaPhongDuocChiaTS_DAL();
        }
        public dynamic LoadPhongCTG_BLL(string makhoa)
        {
            return dt.LoadPhongCTG_DAL(makhoa);
        }
        public List<TaiSan> GetListTS_BLL()
        {
            return dt.GetListTS_DAL();
        }
        public List<DTO.ChungTuGiam> GetThongTinCTGbyMaTS_BLL(string MaTS)
        {
            return dt.GetThongTinCTGbyMaTS_DAL(MaTS);
        }
        public int GetSLTSOPhong_BLL(string id)
        {
            return dt.GetSLTSOPhong_DAL(id);

        }
        public int GetSLThanhLy_DAL(string id)
        {
            return dt.GetSLThanhLy_DAL(id);
        }
    }
}