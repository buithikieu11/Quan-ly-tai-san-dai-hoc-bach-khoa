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
    public partial class ThemVeKhoCuaTruong: Form
    {
        private static Random random = new Random();
        
        QLTS_BLL bll;
        public delegate void myDelegate();
        public myDelegate d;
        public ThemVeKhoCuaTruong()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            InitializeControl();

        }
        public static string RandomString(int length)
        {
            const string chars = "0123";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void InitializeControl()
        {  comboBoxTenLoaiTS.DataSource = bll.GetListTenLoaiTS_BLL();
           textBoxMaTS.Text =RandomString(3)+"-000-000";
           textBoxMaCTT.Text= "01-TSCĐ-" + RandomString(8);
            numericUpDownTyLeHM.Maximum = 100;
           numericUpDownTyLeCL.Maximum = 100;
          
           numericUpDownSoLuong.Minimum = 1;
            numericUpDownSoLuong.Maximum = 1000;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Check textBoxMaTS, textBoxMaCTT == null or duplicated ?
           bool isGoodToGo = true;
            if (String.IsNullOrEmpty(textBoxMaTS.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mã tài sản", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isGoodToGo = false;
            }
            foreach (object ob in bll.GetListMaTS_BLL())
            {
                if (textBoxMaTS.Text.Equals(ob.ToString()))
                {
                    MessageBox.Show("Nhập lại mã tài sản", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    isGoodToGo = false;
                    break;
                }
            }

            if (String.IsNullOrEmpty(textBoxMaCTT.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mã chứng từ tăng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isGoodToGo = false;
            }

            foreach (string ob in bll.GetListMaCTT_BLL())
            {
                if (textBoxMaCTT.Text.Equals(ob.ToString()))
                {
                    MessageBox.Show("Nhập lại mã chứng từ tăng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isGoodToGo = false;
                    break;
                }
            }

            if (isGoodToGo)
            {
                TaiSan myTS = new TaiSan();
                myTS.MaTaiSan = textBoxMaTS.Text;
                myTS.MaLoaiTaiSan = bll.GetMaLoaiTS_BLL(comboBoxTenLoaiTS.SelectedValue.ToString());
                myTS.TenTaiSan = textBoxTenTS.Text;
                myTS.MaChungTuTang = textBoxMaCTT.Text;
                myTS.ThongSoKyThuat = textBoxTSKT.Text;
                int tien;
                Int32.TryParse(textBoxThanhTien.Text, out tien);
                myTS.ThanhTien = tien;
                myTS.SoLuong = int.Parse(numericUpDownSoLuong.Value.ToString());
                myTS.SoLuongNhap= int.Parse(numericUpDownSoLuong.Value.ToString());
                myTS.TyLeHM = int.Parse(numericUpDownTyLeHM.Value.ToString());
                myTS.TyLeCL = int.Parse(numericUpDownTyLeCL.Value.ToString());
                myTS.GhiChu = textBoxGhiChu.Text;
                myTS.NgayGhiTang = DateTime.Parse(dateTimePickerGhiTang.Value.ToShortDateString());
                myTS.NoiDung = textBoxNoiDung.Text;
                bll.AddTS_BLL(myTS);
                d();
                this.Close();
                MessageBox.Show("Thêm tài sản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }
        private void ShowThanhTien()
        {
            float dongia;
            float.TryParse(textBoxDonGia.Text, out dongia);
            textBoxThanhTien.Text = ((int)(dongia) * int.Parse(numericUpDownSoLuong.Value.ToString())).ToString();
        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            ShowThanhTien();

        }

        private void numericUpDownVAT_ValueChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void numericUpDownTyLeHM_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTyLeCL.Value = 100 - numericUpDownTyLeHM.Value;

        }

        private void textBoxDonGia_TextChanged(object sender, EventArgs e)
        {
            ShowThanhTien();
        }

        private void ThemVeKhoCuaTruong_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDownTyLeCL_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTyLeHM.Value=100-numericUpDownTyLeCL.Value;
        }
    }
}
