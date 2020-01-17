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
    public partial class ChungTuGiam : Form
    {
        QLTS_BLL bll;
        private static Random random = new Random();
        public delegate void myDelegate();
        public myDelegate d;
        public ChungTuGiam()
        {
            InitializeComponent();
            bll= new QLTS_BLL();
            InitializeControl();
            
        }
        public static string RandomString(int length)
        {
            const string chars = "0123";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void InitializeControl()
        {
           
            var s = bll.GetKhoaVaPhongDuocChiaTS_DAL();
            foreach (var i in s)
            {
                string t = i;
                if (cbbKhoa.FindStringExact(bll.GetTenKhoa_BLL(t.Substring(4, 3))) < 0)
                {
                    cbbKhoa.Items.Add(bll.GetTenKhoa_BLL(t.Substring(4, 3)));
                }

            }
            numericUpDownSoLuong.Minimum =0;
            textBoxMaCTG.Text ="02-TSCĐ-" + RandomString(8);
           

        }
     


private void ChungTuGiam_Load(object sender, EventArgs e)
        {

        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            cbbPhong.Items.Clear();
            var s = bll.LoadPhongCTG_BLL(bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()));
            foreach (var i in s)
            {
                string t = i;
                if (cbbPhong.FindStringExact(bll.GetTenPhong_BLL(t.Substring(8, 3))) < 0)
                {
                    cbbPhong.Items.Add(bll.GetTenPhong_BLL(t.Substring(8, 3)));
                }

            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool isGoodToGo = true;
           

           if (String.IsNullOrEmpty(textBoxMaCTG.Text.Trim()))
            {
                MessageBox.Show("Nhập lại mã chứng từ giảm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               isGoodToGo = false;
            }

            foreach (string ob in bll.GetListMaCTT_BLL())
            {
                if (textBoxMaCTG.Text.Equals(ob.ToString()))
               {
                    MessageBox.Show("Nhập lại mã chứng từ giảm", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isGoodToGo = false;
                    break;
                }
            }

            if (isGoodToGo)
            {
                DTO.ChungTuGiam myTS = new DTO.ChungTuGiam();
                //string mats= bll.GetMTS_BLL(bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString()), cbbTenTS.SelectedItem.ToString()); 
                string matsruong = bll.GetMaTSTruong_BLL(cbbTenTS.SelectedItem.ToString());
                string mats = matsruong.Substring(0, 3) + "-" + bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()) + "-" + bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
                myTS.MaTaiSan = mats;
                myTS.MaChungTuGiam = textBoxMaCTG.Text.ToString();
                myTS.SoLuong = int.Parse(numericUpDownSoLuong.Value.ToString());
                myTS.NgayGhiGiam = dateTimePickerGhiGiam.Value;
                myTS.ThanhTien = 10* int.Parse(numericUpDownSoLuong.Value.ToString());
                myTS.NoiDung = textBoxNoiDung.Text;
                myTS.GhiChu = textBoxGhiChu.Text;
                bll.AddChungTuGiam_BLL(myTS);
                int slPhong = bll.GetSL_BLL(mats) - myTS.SoLuong;
                bll.UpdateSL(mats,slPhong,slPhong*10);
                d();
                
             this.Close();
             MessageBox.Show("Thêm tài sản thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenphong = cbbPhong.SelectedItem.ToString();
            cbbTenTS.DataSource = bll.GetMTSOnePhong_BLL(bll.GetMaPhong_BLL(tenphong));


        }

        private void cbbPhong_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void cbbTenTS_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string matsruong = bll.GetMaTSTruong_BLL(cbbTenTS.SelectedItem.ToString());
                string mats = matsruong.Substring(0, 3) + "-" + bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()) + "-" + bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
                numericUpDownSoLuong.Maximum = bll.GetSL_BLL(mats);
               
                if (numericUpDownSoLuong.Value == Convert.ToDecimal(0))
                {

                    MessageBox.Show("Cảnh báo Số lượng của tài sản này =0,Không thực hiện Thanh lý!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                textBoxThanhTien.Text = Convert.ToString(bll.GetThanhtien_BLL(mats) / bll.GetSL_BLL(mats) * (int.Parse(numericUpDownSoLuong.Value.ToString())));
               
            }
            catch(Exception )
            {

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBoxThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNoiDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerGhiGiam_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMaCTG_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelSoLuong_Click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
