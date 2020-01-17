using QuanLyTaiSanDHBK.BLL;
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
    public partial class SuaChungTuGiam : Form
    {
        QLTS_BLL bll;
        public delegate void myDelegate();
        public myDelegate d;
         List<string> tenkhoa;
        public SuaChungTuGiam()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();
            tenkhoa = new List<string>();
            
        }
        public void InitializeControl()
        {
            //List<string> t = bll.GetListKhoa_BLL();
            //int k = t.Count;
            //t.RemoveAt(k - 1);
            //cbbKhoa.DataSource = t;
            //cbbKhoa = bll.Loadkhoa_CTG_DAL();
            var s=bll.Loadkhoa_CTG_DAL();
            foreach( var i in s)
            {    
                string t =i;
                if (cbbKhoa.FindStringExact(bll.GetTenKhoa_BLL(t.Substring(4, 3))) < 0)
                    {
                    cbbKhoa.Items.Add(bll.GetTenKhoa_BLL(t.Substring(4, 3)));
                    }

            }
            numericUpDownSoLuong.Minimum = 0;
            cbbMCTG.DataSource = bll.GetMCTG_BLL();

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn lưu dữ liệu update hay không ?",
                                       "Confirm update",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                DTO.ChungTuGiam ctg = bll.GetInfoCTG_BLL(cbbMCTG.SelectedItem.ToString());
                string mctg = cbbMCTG.SelectedItem.ToString();
                string mts = bll.GetMaTSTruong_BLL(cbbTenTS.SelectedItem.ToString()).Substring(0, 3) + "-" +bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()) + "-" +bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
                int soluong = int.Parse(numericUpDownSoLuong.Value.ToString());
                string noidung = textBoxNoiDung.Text;
                string ghichu = textBoxGhiChu.Text;
                DateTime NgayGhiGiam = dateTimePickerGhiGiam.Value;
                int ThanhTien = int.Parse(textBoxThanhTien.Text);
                bll.UpdateCTG_BLL(mctg,soluong, NgayGhiGiam, ThanhTien, noidung, ghichu);
                d();
                MessageBox.Show(mts);
                int slPhong = bll.GetSL_BLL(mts)+ctg.SoLuong - soluong;
                bll.UpdateSL(mts,slPhong, slPhong * 10);
                this.Close();
                MessageBox.Show("Update dữ liệu thành công tài sản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Không thực hiện update!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        



    }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<string> t = bll.GetListPhongKhoa_BLL(bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()));
            //int k = t.Count;
            //t.RemoveAt(k - 1);
            //cbbPhong.DataSource = t;
            var s = bll.Loadkhoa_CTG_DAL();
            foreach (var i in s)
            {
                string t = i;
                if (cbbPhong.FindStringExact(bll.GetTenPhong_BLL(t.Substring(8, 3))) < 0)
                {
                    cbbPhong.Items.Add(bll.GetTenPhong_BLL(t.Substring(8, 3)));
                }

            }

        }

        private void cbbMCTG_SelectedIndexChanged(object sender, EventArgs e)
        {    DTO.ChungTuGiam ctg = bll.GetInfoCTG_BLL(cbbMCTG.SelectedItem.ToString());
            string mats = ctg.MaTaiSan;
            MessageBox.Show(mats);
            string idKhoa = ctg.MaTaiSan.Substring(4, 3);
            string idPhong = ctg.MaTaiSan.Substring(8, 3);
            cbbKhoa.SelectedIndex = cbbKhoa.FindStringExact(bll.GetTenKhoa_BLL(idKhoa));
            cbbPhong.SelectedIndex = cbbPhong.FindStringExact(bll.GetTenPhong_BLL(idPhong));
            textBoxNoiDung.Text = ctg.NoiDung;
            textBoxGhiChu.Text = ctg.GhiChu;
            dateTimePickerGhiGiam.Value = ctg.NgayGhiGiam.Value;
            numericUpDownSoLuong.Value = ctg.SoLuong.Value;
            textBoxThanhTien.Text = ctg.ThanhTien.Value.ToString();
            cbbTenTS.SelectedIndex = cbbTenTS.FindStringExact(bll.GetTenTS_BLL(mats));
            MessageBox.Show(bll.GetTenTS_BLL(mats));


        }

        private void SuaChungTuGiam_Load(object sender, EventArgs e)
        {

        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenphong = cbbPhong.SelectedItem.ToString();
            cbbTenTS.DataSource = bll.GetMTS_CTG(bll.GetMaPhong_BLL(tenphong));

        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            DTO.ChungTuGiam ctg = bll.GetInfoCTG_BLL(cbbMCTG.SelectedItem.ToString());
            string mats = ctg.MaTaiSan;
            numericUpDownSoLuong.Maximum = bll.GetSL_BLL(mats)+ctg.SoLuong;
           
            textBoxThanhTien.Text = ((int.Parse(numericUpDownSoLuong.Value.ToString()))*10).ToString();

           



        }
    }
}
