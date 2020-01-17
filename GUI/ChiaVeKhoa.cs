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
    public partial class ChiaVeKhoa : Form
    {   QLTS_BLL bll;
        string mats;
        public delegate void myDelegate();
        public myDelegate d;
        public ChiaVeKhoa()
        {
            InitializeComponent();
            bll = new QLTS_BLL();
            mats = "";
            InitializeControl();
        }

        public void InitializeControl()
        {

            List<string> t = bll.GetListKhoa_BLL();
            int k = t.Count;
            t.RemoveAt(k - 1);
            cbbKhoa.DataSource = t;
            cbbMTS.DataSource = bll.GetTenTSChiaKhoa_BLL();
            numericUpDownSoLuong.Minimum = 0;
            
           
        }
      
        private void buttonOK_Click(object sender, EventArgs e)
        {  if (cbbMTS.SelectedItem.ToString() ==null)
            {
                this.Close();
                MessageBox.Show("Tài sản chưa nhâp về kho lấy đâu mà nhập cho khoa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool have = false;
                TaiSan k = bll.GetInfoAdd_BLL(bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString()));
                string phandau = bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString()).Substring(0, 3);
                mats = phandau + "-" + bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()) + "-" + "000";
                foreach (object ob in bll.GetListMaTS_BLL())
                {
                    if (mats.Equals(ob.ToString()))
                    {
                        have = true;
                        int sl = Convert.ToInt32(numericUpDownSoLuong.Value) + bll.GetSL_BLL(mats);
                        bll.UpdateSL(mats, sl,sl*10);
                        int slTruong = bll.GetSL_BLL(bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString())) - Convert.ToInt32(numericUpDownSoLuong.Value);

                        bll.UpdateSL(bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString()), slTruong, slTruong * 10);
                        bll.updateSLNhap_DAL(mats, bll.GetSLnhap_BLL(mats) + Convert.ToInt32(numericUpDownSoLuong.Value));
                        d();
                        this.Close();
                        MessageBox.Show("tài sản này đã có trong khoa,update số lượng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                if (have == false)
                {
                    k.MaTaiSan = mats;
                    k.GhiChu = "Phan Vat Tu Ve Khoa";
                    k.ThanhTien =  Convert.ToInt32(numericUpDownSoLuong.Value)*10;
                    k.SoLuong = Convert.ToInt32(numericUpDownSoLuong.Value);
                    k.SoLuongNhap= Convert.ToInt32(numericUpDownSoLuong.Value); 
                    bll.AddTS_BLL(k);
                    int slTruong=bll.GetSL_BLL(bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString())) - k.SoLuong;
                  
                    bll.UpdateSL(bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString()),slTruong,slTruong*10);
                    d();
                    this.Close();
                    MessageBox.Show("Thêm tài sản  vào khoa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            
            }
            }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            
            numericUpDownSoLuong.Maximum =Convert.ToDecimal(bll.GetSL_BLL(bll.GetMaTSTruong_BLL(cbbMTS.SelectedItem.ToString())));
           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
        

      
    }
}
