using QuanLyTaiSanDHBK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanDHBK.DAL
{
    class QLTS_DAL
    {
        QLTSDataContext db;

        public QLTS_DAL()
        {
            db = new QLTSDataContext();
        }
        public List<string> GetListTenLoaiTS_DAL()
        {
            var s = db.LoaiTaiSans.Select(p => new { p.TenLoaiTaiSan, p.MaLoaiTaiSan }).Distinct().OrderBy(p => p.MaLoaiTaiSan);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenLoaiTaiSan);
            }
            return list;
        }

        public string GetMaLoaiTS_DAL(string tenLoaiTS)
        {
            return db.LoaiTaiSans.Where(p => p.TenLoaiTaiSan.Equals(tenLoaiTS)).Select(p => p.MaLoaiTaiSan).Single();
        }
        public List<string> GetListMaTS_DAL()
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan }).OrderBy(p => p.MaTaiSan);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.MaTaiSan);
            }
            return list;
        }
        public List<string> GetListMaCTT_DAL()
        {
            var s = db.TaiSans.Distinct().OrderBy(p => p.MaTaiSan).Select(p => p.MaChungTuTang);
            return s.ToList<string>();
        }
        public void AddTS_DAL(TaiSan myTS)
        {
            db.TaiSans.InsertOnSubmit(myTS);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
            }
        }
        public List<string> GetListPhongKhoa_DAL(string makhoa)
        {
            var s = db.Phongs.Select(p => new { p.TenPhong, p.MaPhong, p.MaKhoa }).Where(p => p.MaKhoa == makhoa).Distinct().OrderBy(p => p.MaPhong);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenPhong);
            }
            list.Add("Tat ca");
            return list;
        }
        public List<string> GetListKhoa_DAL()
        {
            var s = db.Khoas.Select(p => new { p.TenKhoa, p.MaKhoa }).Where(p => p.MaKhoa != "000").Distinct().OrderBy(p => p.MaKhoa);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenKhoa);
            }
            list.Add("Tat ca");
            return list;
        }
        public string GetMaKhoa_DAL(string tenkhoa)
        {
            var s = db.Khoas.Select(p => new { p.MaKhoa, p.TenKhoa }).Where(p => p.TenKhoa == tenkhoa).Single();
            return s.MaKhoa;
        }
        public List<string> GetTenTSChiaKhoa_DAL()
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan, p.SoLuong }).Where(p => p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0).Distinct().OrderBy(p => p.MaTaiSan);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenTaiSan);
               
            }
            return list;

        }
        public string GetMaTSTruong_DAL(string tents)
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan }).Where(p => p.TenTaiSan == tents && p.MaTaiSan.Substring(4, 7) == "000-000").Single();
           
            return s.MaTaiSan;

        }
        public TaiSan GetinfoAdd_DAL(string mats)
        {
            TaiSan myTS = new TaiSan();
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.MaChungTuTang, p.MaLoaiTaiSan, p.NgayGhiTang, p.TenTaiSan, p.ThanhTien, p.ThongSoKyThuat, p.TyLeCL, p.TyLeHM, p.SoLuong, p.NoiDung,p.SoLuongNhap }).Where(p => p.MaTaiSan == mats).Single();
            myTS.MaChungTuTang = s.MaChungTuTang;
            myTS.MaLoaiTaiSan = s.MaLoaiTaiSan;
            myTS.NgayGhiTang = s.NgayGhiTang;
            myTS.TenTaiSan = s.TenTaiSan;
            myTS.SoLuong = s.SoLuong;
            myTS.ThongSoKyThuat = s.ThongSoKyThuat;
            myTS.ThanhTien = s.ThanhTien;
            myTS.TyLeCL = s.TyLeCL;
            myTS.TyLeHM = s.TyLeHM;
            myTS.NoiDung = s.NoiDung;
            myTS.SoLuongNhap = s.SoLuongNhap;
            return myTS;

        }
        public dynamic GetSL_DAL(string mats)
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.SoLuong }).Where(p => p.MaTaiSan == mats).Single();
            return s.SoLuong;

        }
        public void UpdateSL(string mats, int sl, int thanhtien)
        {
            var s = db.TaiSans.Single(p => p.MaTaiSan == mats);
            s.SoLuong = sl;
            s.ThanhTien = thanhtien;
            db.SubmitChanges();
        }
        public List<string> GetTenTSChiaPhong_DAL(string makhoa)
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan, p.SoLuong }).Where(p => p.MaTaiSan.Substring(4, 7) == makhoa + "-000" && p.SoLuong != 0).Distinct().OrderBy(p => p.MaTaiSan);
            List<string> list = new List<string>();
            foreach (var item in s)
            {
                list.Add(item.TenTaiSan);

            }
            return list;

        }
        public string GetMaTSKhoa_DAL(string tents, string makhoa)
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan }).Where(p => p.TenTaiSan == tents && p.MaTaiSan.Substring(4, 7) == makhoa + "-000").Single();
            // MessageBox.Show(s.MaTaiSan);
            return s.MaTaiSan;

        }
        public string GetMaPhong_DAL(string tenphong)
        {
            var s = db.Phongs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.TenPhong == tenphong).Single();
            return s.MaPhong;
        }
        public dynamic GetInfoNhapTruong_DAL()
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0);
            return s;
        }
        public dynamic GetInfoNhapAllKhoa_DAL()
        {
            var s = db.TaiSans.Select(p => new {  p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0);
            return s;
        }
        public dynamic GetInfoNhapOneKhoa_DAL(string makhoa)
        {
            var s = db.TaiSans.Select(p => new {   p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) == makhoa && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0);
            return s;
        }

        public dynamic GetInfoTSAllPhong_DAL()
        {
            var s = db.TaiSans.Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) != "000" && p.SoLuong != 0);
            return s;


        }

        public dynamic GetInfoTSOnePhong_DAL(string maphong)
        {
            var s = db.TaiSans.Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == maphong && p.SoLuong != 0);
            return s;


        }

        public void DeleTS_DAL(string id)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan == id).Single();
            db.TaiSans.DeleteOnSubmit(s);
            db.SubmitChanges();


        }
        public void DeleTSTruong_DAL(string id)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(0, 3) == id.Substring(0, 3));
            db.TaiSans.DeleteAllOnSubmit(s);
            db.SubmitChanges();

        }
        public void DeleTSKhoa_DAL(string id)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(0, 7) == id.Substring(0, 7));
            db.TaiSans.DeleteAllOnSubmit(s);
            db.SubmitChanges();

        }
        public dynamic GetinfoTScua1khoa_DAL(string makhoa)
        {
            var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan, p.MaLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) == makhoa && p.MaTaiSan.Substring(8, 3) != "000" && p.SoLuong != 0);
            return s;
        }
        public string GetTenKhoa_DAL(string makhoa)
        {
            var s = db.Khoas.Select(p => new { p.MaKhoa, p.TenKhoa }).Where(p => p.MaKhoa == makhoa).Single();
            return s.TenKhoa;
        }
        public string GetTenPhong_DAL(string maphong)
        {
            var s = db.Phongs.Select(p => new { p.MaPhong, p.TenPhong }).Where(p => p.MaPhong == maphong).Single();
            return s.TenPhong;
        }
        public List<object> SortListTaiSan_DAL(string tenkhoa, string tenphong, string columnName)
        {
            string maPhong;
            if (tenkhoa == "Tat ca")
            {
                if (columnName == "Ten loai tai san")
                {
                    var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.SoLuong != 0)).Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenLoaiTaiSan);
                    return s.ToList<object>();
                }
                else if (columnName == "So luong")
                {

                    var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.SoLuong != 0)).Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.SoLuong);
                    return s.ToList<object>();
                }
                else if (columnName == "Ty le hao mon")
                {
                    var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.SoLuong != 0)).Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeHM);
                    return s.ToList<object>();
                }
                else if (columnName == "Ty le con lai")
                {
                    var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.SoLuong != 0)).Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeCL);
                    return s.ToList<object>();
                }
                else
                {
                    var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.SoLuong != 0)).Select(p => new { p.Phong.TenPhong, p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
                    return s.ToList<object>();

                }
            }
            else
            {
                if (tenphong == "Tat ca")
                {
                    if (columnName == "Ten loai tai san")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.Phong.MaKhoa == GetMaKhoa_DAL(tenkhoa) && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenLoaiTaiSan);
                        return s.ToList<object>();
                    }
                    else if (columnName == "So luong")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.Phong.MaKhoa == GetMaKhoa_DAL(tenkhoa) && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.SoLuong);
                        return s.ToList<object>();
                    }
                    else if (columnName == "Ty le hao mon")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.Phong.MaKhoa == GetMaKhoa_DAL(tenkhoa) && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeHM);
                        return s.ToList<object>();
                    }
                    else if (columnName == "Ty le con lai")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.Phong.MaKhoa == GetMaKhoa_DAL(tenkhoa) && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeCL);
                        return s.ToList<object>();
                    }
                    else
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong.Substring(8, 3) != "000" && p.Phong.MaKhoa == GetMaKhoa_DAL(tenkhoa) && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
                        return s.ToList<object>();

                    }

                }
                else
                {
                    var x = db.Phongs.Select(p => new { p.MaPhong, p.TenPhong, p.MaKhoa }).Where(p => p.MaPhong == GetMaPhong_DAL(tenphong));
                    maPhong = x.First().MaPhong;

                    if (columnName == "Ten loai tai san")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong == maPhong && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenLoaiTaiSan);
                        return s.ToList<object>();
                    }
                    else if (columnName == "So luong")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong == maPhong && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.SoLuong);
                        return s.ToList<object>();
                    }
                    else if (columnName == "Ty le hao mon")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong == maPhong && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeHM);
                        return s.ToList<object>();
                    }
                    else if (columnName == "Ty le con lai")
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong == maPhong && p.SoLuong != 0)).Select(p => new { p.Phong.TenPhong,p.Phong.Khoa.TenKhoa,p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang,p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeCL);
                        return s.ToList<object>();
                    }
                    else
                    {
                        var s = db.TaiSans.Where(p => (p.MaPhong == maPhong && p.SoLuong != 0)).Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
                        return s.ToList<object>();

                    }

                }

            }

        }
        public dynamic SearchTS_DAL(string tenkhoa, string tenphong, string idfirst)
        {

            if (tenkhoa == "Tat ca")
            {
                var s = db.TaiSans.Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(0, 3) == idfirst && p.MaTaiSan.Substring(8, 3) != "000" && p.SoLuong != 0);
                return s;
            }
            else
            {
                if (tenphong == "Tat ca")
                {
                    var s = db.TaiSans.Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(0, 3) == idfirst && p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) != "000" && p.SoLuong != 0);
                    return s;

                }
                else
                {
                    var s = db.TaiSans.Select(p => new {p.Phong.TenPhong,p.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(0, 3) == idfirst && p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == GetMaPhong_DAL(tenphong) && p.SoLuong != 0);
                    return s;
                }
            }

        }
        public dynamic SortTruong_DAL(string columnName)
        {
            if (columnName == "Ten loai tai san")
            {
                var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenLoaiTaiSan);
                return s.ToList<object>();
            }
            else if (columnName == "So luong")
            {
                var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.SoLuong);
                return s.ToList<object>();
            }
            else if (columnName == "Ty le hao mon")
            {
                var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeHM);
                return s.ToList<object>();
            }
            else if (columnName == "Ty le con lai")
            {
                var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeCL);
                return s.ToList<object>();
            }
            else
            {
                var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 7) == "000-000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
                return s.ToList<object>();

            }

        }
        public dynamic SearchTruong_DAL(string id)
        {
            var s = db.TaiSans.Where(p => (p.MaTaiSan == id && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang,p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
            return s;
        }
        public dynamic SortKhoa_DAL(string tenkhoa, string columnName)
        {
            if (tenkhoa == "Tat ca")
            {
                if (columnName == "Ten loai tai san")
                {
                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenLoaiTaiSan);
                    return s.ToList<object>();
                }
                else if (columnName == "So luong")
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.SoLuong);
                    return s.ToList<object>();
                }
                else if (columnName == "Ty le hao mon")
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeHM);
                    return s.ToList<object>();
                }
                else if (columnName == "Ty le con lai")
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeCL);
                    return s.ToList<object>();
                }
                else
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
                    return s.ToList<object>();
                }

            }
            else
            {
                if (columnName == "Ten loai tai san")
                {
                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenLoaiTaiSan);
                    return s.ToList<object>();
                }
                else if (columnName == "So luong")
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.SoLuong);
                    return s.ToList<object>();
                }
                else if (columnName == "Ty le hao mon")
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeHM);
                    return s.ToList<object>();
                }
                else if (columnName == "Ty le con lai")
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TyLeCL);
                    return s.ToList<object>();
                }
                else
                {

                    var s = db.TaiSans.Where(p => (p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == "000" && p.SoLuong != 0)).Select(p => new { p.MaTaiSan, p.TenTaiSan, p.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).OrderBy(p => p.TenTaiSan);
                    return s.ToList<object>();
                }
            }
        }
        public dynamic SearchTSkhoa_DAL(string tenkhoa, string id)
        {
            if (tenkhoa == "Tat ca")
            {
                var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan, p.MaLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000" && p.MaTaiSan.Substring(0, 3) == id && p.SoLuong != 0);
                return s;
            }
            else
            {
                var s = db.TaiSans.Select(p => new { p.MaTaiSan, p.TenTaiSan, p.MaLoaiTaiSan, p.SoLuong, p.SoLuongNhap, p.ThanhTien, p.ThongSoKyThuat, p.MaChungTuTang,p.NgayGhiTang, p.TyLeCL, p.TyLeHM }).Where(p => p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) && p.MaTaiSan.Substring(8, 3) == "000" && p.MaTaiSan.Substring(0, 3) == id && p.SoLuong != 0);
                return s;

            }
        }
        public dynamic GetMTSOnePhong_DAL(string maphong)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(8, 3) == maphong && p.SoLuong != 0).Select(p => p.TenTaiSan);
            return s;


        }

        public int GetThanhtien_DAL(string mats)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan == mats).Select(p => p.ThanhTien).Single();
            return s.Value;


        }
        public void AddChungTuGiam_DAL(DTO.ChungTuGiam myTS)
        {
            db.ChungTuGiams.InsertOnSubmit(myTS);
            try
            {
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
            }

        }
        public dynamic ShowCTGAllTruong_DAL()
        {

            var s = db.ChungTuGiams.Where(p => (p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) != "000"&&p.SoLuong!=0)).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu });

            return s;
        }

        public dynamic ShowCTGOneKhoa_DAL(string makhoa)
        {
           
            var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(4, 3) == makhoa&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu });

            return s;
        }
        public dynamic ShowCTGOnePhong_DAL(string maphong)
        {
            var s = db.ChungTuGiams.Where(p => (p.MaTaiSan.Substring(8, 3) == maphong)&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu });
            return s;



        }

        public int GetSLNhapKhoa_DAL(string id)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan == id).Select(p => p.SoLuongNhap).Single();
            return s.Value;
        }
        public void DeleCTG_DAL(string id)
        {
            var s = db.ChungTuGiams.Where(p => p.MaChungTuGiam == id).Single();
            db.ChungTuGiams.DeleteOnSubmit(s);
            db.SubmitChanges();



        }
        public void UpDateCLHM_DAL(string mats, int haomon, int conlai)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan == mats).Single();
            s.TyLeCL = conlai;
            s.TyLeHM = haomon;
            db.SubmitChanges();
        }
        public List<object> SortListCTG_DAL(string tenkhoa, string tenphong, string columnName)
        {
            string maPhong;
            if (tenkhoa == "Tat ca")
            {
                if (columnName == "Ten loai tai san")
                {
                    var s = db.ChungTuGiams.Where(p=>p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.TenLoaiTaiSan);
                    return s.ToList<object>();
                }
                else if (columnName == "So luong")
                {
                    var s = db.ChungTuGiams.Where(p=>p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.SoLuong);
                    return s.ToList<object>();

                }

                else
                {
                    var s = db.ChungTuGiams.Where(p=>p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.TenTaiSan);
                    return s.ToList<object>();

                }
            }
            else
            {
                if (tenphong == "Tat ca")
                {
                    if (columnName == "Ten loai tai san")
                    {
                        var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa)&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.TenLoaiTaiSan);
                        return s.ToList<object>();
                    }
                    else if (columnName == "So luong")
                    {
                        var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa)&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.SoLuong);
                        return s.ToList<object>();
                    }

                    else
                    {
                        var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(4, 3) == GetMaKhoa_DAL(tenkhoa) &&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.TenTaiSan);
                        return s.ToList<object>();

                    }

                }
                else
                {
                    var x = db.Phongs.Select(p => new { p.MaPhong, p.TenPhong, p.MaKhoa }).Where(p => p.MaPhong == GetMaPhong_DAL(tenphong));
                    maPhong = x.First().MaPhong;

                    if (columnName == "Ten loai tai san")
                    {
                        var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(8, 3) == maPhong&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.TenLoaiTaiSan);
                        return s.ToList<object>();
                    }
                    else if (columnName == "So luong")
                    {
                        var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(8, 3) == maPhong&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.SoLuong);
                        return s.ToList<object>();
                    }

                    else
                    {
                        var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(8, 3) == maPhong&&p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa ,p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).OrderBy(p => p.TenTaiSan);
                        return s.ToList<object>();

                    }

                }
            

                }
            }
        public dynamic SearchCTG_DAL(string tenkhoa, string tenphong, string idfirst)
        {

            if (tenkhoa == "Tat ca")
            {
                var s = db.ChungTuGiams.Where(p=>p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).Where(p=>p.MaTaiSan.Substring(0,3)==idfirst);
                return s;
            }
            else
            {
                if (tenphong == "Tat ca")
                {

                    var s = db.ChungTuGiams.Where(p=>p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).Where(p=>p.MaTaiSan.Substring(4,3)==GetMaKhoa_DAL(tenkhoa)&&p.MaTaiSan.Substring(0,3)==idfirst);
                    return s;


                }
                else
                {
                    var s = db.ChungTuGiams.Where(p=>p.SoLuong!=0).Select(p => new { p.MaChungTuGiam, p.TaiSan.Phong.TenPhong, p.TaiSan.Phong.Khoa.TenKhoa, p.MaTaiSan, p.TaiSan.TenTaiSan, p.TaiSan.LoaiTaiSan.TenLoaiTaiSan, p.SoLuong, p.ThanhTien,p.NgayGhiGiam, p.NoiDung, p.GhiChu }).Where(p => p.MaTaiSan.Substring(8, 3) ==GetMaPhong_DAL(tenphong)&&p.MaTaiSan.Substring(0,3)==idfirst);
                    return s;

                }
            }

        }
        public dynamic GetMCTG_DAL()
        {
            var s = db.ChungTuGiams.Select(p => p.MaChungTuGiam);
            return s;
        }
        public DTO.ChungTuGiam GetInfoCTG_DAL(string MCTG)
        {
            DTO.ChungTuGiam myCT = new DTO.ChungTuGiam();
            var s = db.ChungTuGiams.Where(p => p.MaChungTuGiam == MCTG).Select(p => new {  p.MaTaiSan, p.NoiDung, p.NgayGhiGiam, p.GhiChu, p.ThanhTien, p.SoLuong }).Single();
            myCT.SoLuong = s.SoLuong;
           
            myCT.MaTaiSan = s.MaTaiSan;
            myCT.NoiDung = s.NoiDung;
            myCT.NgayGhiGiam = s.NgayGhiGiam;
            myCT.GhiChu = s.GhiChu;
            myCT.ThanhTien = s.ThanhTien;

            return myCT;
        }
        public string GetTenTS_DAL(string mats)
        {
            var s = db.TaiSans.Where(p =>p.MaTaiSan == mats).Select(p => p.TenTaiSan).Single();
            return s;
        }
        public dynamic GetMTS_CTG(string maphong)
        {
            var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(8, 3) == maphong).Select(p => p.TaiSan.TenTaiSan);
            return s;
        }
        public void UpdateCTG_DAL(string mctg,int sl,DateTime ngg,int tt,string nd,string gc)
        {
            var s = db.ChungTuGiams.Single(p => p.MaChungTuGiam == mctg);
            s.SoLuong = sl;
            s.NgayGhiGiam = ngg;
            s.ThanhTien = tt;
            s.NoiDung = nd;
            s.GhiChu = gc;
            db.SubmitChanges();
        }
        public dynamic Loadkhoa_CTG_DAL()
        {
            var s = db.ChungTuGiams.Select(p => p.MaTaiSan).Distinct();
            return s;
        }
        public dynamic LoadKhoaDuocTruongPhanVe_DAL()
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(4, 3) != "000" && p.MaTaiSan.Substring(8, 3) == "000").Select(p => p.MaTaiSan);
            return s;
        }
        public void updateSLNhap_DAL(string mats, int sln)
        {
            var s = db.TaiSans.Single(p => p.MaTaiSan == mats);
            s.SoLuongNhap = sln;
            db.SubmitChanges();
        }
        public int GetSLnhap_DAL(string mats)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan == mats).Select(p => p.SoLuongNhap).Single();

            return s.Value;
        }
        public dynamic GetKhoaVaPhongDuocChiaTS_DAL()
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(8, 3) != "000").Select(p => p.MaTaiSan);
            return s;
        }
        public dynamic LoadPhongCTG_DAL(string makhoa)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(4, 3) == makhoa && p.Phong.MaPhong == p.MaTaiSan.Substring(8, 3)).Select(p=>p.MaTaiSan);
            return s;

        }
        public List<TaiSan> GetListTS_DAL()
        {
            List<TaiSan> li = db.TaiSans.Where(p => p.MaTaiSan.Substring(8, 3) != "000"&&p.SoLuong!=0).ToList<TaiSan>();
            return li;
        }
        public List<DTO.ChungTuGiam> GetThongTinCTGbyMaTS_DAL(string MaTS)
        {
            List<DTO.ChungTuGiam> s = db.ChungTuGiams.Where(p => p.MaTaiSan.Equals(MaTS)).Select(p => p).ToList<ChungTuGiam>();

            return s;
        }
        public int GetSLTSOPhong_DAL(string id)
        {
            var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(0, 7) == id && p.MaTaiSan.Substring(8, 3) != "000").Sum(p => p.SoLuong);
            return s.Value;

        }
        public int GetSLThanhLy_DAL(string id)
        {
            var s = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(0, 7) == id).Sum(p => p.SoLuong);
            return s.Value;
        }

    }
    }




