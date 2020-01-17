using QuanLyTaiSanDHBK.BLL;
using QuanLyTaiSanDHBK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTaiSanDHBK.GUI
{
    public partial class PhanPhongBan : Form
    {
        QLTS_BLL bll;
        string mats;
        public delegate void myDelegate();
        public myDelegate d;
        public PhanPhongBan()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();
        }
        public void InitializeControl()
        {
            //List<string> t = bll.GetListKhoa_BLL();
            //int k = t.Count;
            //t.RemoveAt(k - 1);
            //cbbKhoa.DataSource =t;
            var s = bll.LoadKhoaDuocTruongPhanVe_BLL();
            foreach (var i in s)
            {
                string t = i;
                if (cbbKhoa.FindStringExact(bll.GetTenKhoa_BLL(t.Substring(4, 3))) < 0)
                {
                    cbbKhoa.Items.Add(bll.GetTenKhoa_BLL(t.Substring(4, 3)));
                }

            }
         
            numericUpDownSoLuong.Minimum = 0;
         


        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string makhoa = bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString());

            bool have = false;
            TaiSan k = bll.GetInfoAdd_BLL(bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(),makhoa));
            string phandau = bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(),makhoa).Substring(0,3);
            mats = phandau + "-" +makhoa+ "-" +bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
            foreach (object ob in bll.GetListMaTS_BLL())
            {
                if (mats.Equals(ob.ToString()))
                {
                    have = true;
                    int slPhongdaco = bll.GetSL_BLL(mats);
                    int sl = Convert.ToInt32(numericUpDownSoLuong.Value) +slPhongdaco;
                    bll.UpdateSL(mats, sl,sl*10);
                    int slKhoa = bll.GetSL_BLL(bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(), makhoa)) - Convert.ToInt32(numericUpDownSoLuong.Value);
                    bll.UpdateSL(bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(), makhoa), slKhoa, slKhoa * 10);

                    bll.updateSLNhap_DAL(mats, bll.GetSLnhap_BLL(mats) + Convert.ToInt32(numericUpDownSoLuong.Value));
                    d();
                    this.Close();
                    MessageBox.Show("tài sản này đã có trong phòng,update số lượng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            if (have == false)
            {
                k.MaTaiSan = mats;
                k.GhiChu = "Phan Vat Tu Ve phong";
                k.MaPhong = bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
                k.ThanhTien = k.ThanhTien / k.SoLuong * Convert.ToInt32(numericUpDownSoLuong.Value);
                k.SoLuong = Convert.ToInt32(numericUpDownSoLuong.Value);
                k.ThanhTien = k.SoLuong * 10;
                k.SoLuongNhap = Convert.ToInt32(numericUpDownSoLuong.Value); 
                bll.AddTS_BLL(k);
                d();
                int slKhoa = bll.GetSL_BLL(bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(), makhoa)) - k.SoLuong;
                
                bll.UpdateSL(bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(),makhoa),slKhoa,slKhoa*10);
               
                this.Close();
                MessageBox.Show("Thêm tài sản  vào phòng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> t =bll.GetListPhongKhoa_BLL(bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()));
            int k = t.Count;
            t.RemoveAt(k - 1);
            cbbPhong.DataSource = t;
            cbbMTS.DataSource = bll.GetTenTSChiaPhong_DAL(bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()));

        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        { numericUpDownSoLuong.Maximum = Convert.ToDecimal(bll.GetSL_BLL(bll.GetMaTSKhoa_DAL(cbbMTS.SelectedItem.ToString(), bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()))));
           
        }

        private void PhanPhongBan_Load(object sender, EventArgs e)
        {

        }
    }
    }

