using QuanLyTaiSanDHBK.BLL;
using QuanLyTaiSanDHBK.DTO;
using QuanLyTaiSanDHBK.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyTaiSanDHBK
{
    public partial class MainForm : Form
    {
        QLTS_BLL bll;
        private static Random random = new Random();
        static string clickingButton = "ThemPhong";
        string t = "";
        public MainForm()
        {
            bll = new QLTS_BLL();
            InitializeComponent();
            LoadCbb();
            numericUpDownTyLeCL.Minimum = 0;
            numericUpDownTyLeCL.Maximum = 100;
            numericUpDownTyLeHM.Minimum = 0;
            numericUpDownTyLeHM.Maximum = 100;



        }
        public static string RandomString(int length)
        {
            const string chars = "0123";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void stt(DataGridView dt)
        {
            int n = dt.RowCount;
            for (int i = 0; i <= n - 1; i++)
            {
                dt.Rows[i].Cells[0].Value = i + 1;
            }

        }

        private void addVeKhoTruong()
        {
            dgvTruong.DataSource = null;
            dgvTruong.DataSource = bll.GetInfoNhapTruong_BLL();
            stt(dgvTruong);
        }
        public void addVeKhoKhoa()
        {
            dgvKhoa.DataSource = null;
            if (cbbKhoa.SelectedItem.ToString() == "Tat ca")
            {
                dgvKhoa.DataSource = bll.GetInfoNhapAllKhoa_BLL();
                stt(dgvKhoa);
            }
            else
            {
                dgvKhoa.DataSource = bll.GetInfoNhapOneKhoa_BLL(bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()));
                stt(dgvKhoa);

            }
        }


        public void addVePhong()
        {
            dgvTS.DataSource = null;
            if (cbbKhoa.SelectedItem.ToString() == "Tat ca" && cbbPhong.SelectedItem.ToString() == "Tat ca")
            {
                dgvTS.DataSource = bll.GetInfoTSAllPhong_BLL();
                stt(dgvTS);
            }
            if (cbbKhoa.SelectedItem.ToString() != "Tat ca" && cbbPhong.SelectedItem.ToString() == "Tat ca")
            {
                string makhoa = bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString());
                dgvTS.DataSource = bll.GetinfoTScua1khoa_BLL(makhoa);
                stt(dgvTS);
            }
            if (cbbKhoa.SelectedItem.ToString() != "Tat ca" && cbbPhong.SelectedItem.ToString() != "Tat ca")
            {
                string maphong = bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
                dgvTS.DataSource = bll.GetInfoTSOnePhong_BLL(maphong);
                stt(dgvTS);

            }

        }

        public void addCTG()
        {

            dgvCTG.DataSource = null;
            if (cbbKhoa.SelectedItem.ToString() == "Tat ca" && cbbPhong.SelectedItem.ToString() == "Tat ca")
            {
                dgvCTG.DataSource = bll.ShowCTGAllTruong_BLL();
                stt(dgvCTG);

            }
            if (cbbKhoa.SelectedItem.ToString() != "Tat ca" && cbbPhong.SelectedItem.ToString() == "Tat ca")
            {

                string makhoa = bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString());

                dgvCTG.DataSource = bll.ShowCTGOneKhoa_Bll(makhoa);
                stt(dgvCTG);
            }
            if (cbbKhoa.SelectedItem.ToString() != "Tat ca" && cbbPhong.SelectedItem.ToString() != "Tat ca")
            {
                string maphong = bll.GetMaPhong_BLL(cbbPhong.SelectedItem.ToString());
                dgvCTG.DataSource = bll.ShowCTGOnePhong_Bll(maphong);
                stt(dgvCTG);

            }

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            ThemVeKhoCuaTruong f = new ThemVeKhoCuaTruong();
            f.d += new ThemVeKhoCuaTruong.myDelegate(addVeKhoTruong);
            f.Show();
        }
        private void LoadCbb()
        {

            cbbKhoa.DataSource = bll.GetListKhoa_BLL();
            List<string> listSortSX = new List<string> { "Ten tai san", "Ten loai tai san", "So luong", "Ty le hao mon", "Ty le con lai" };
            com.DataSource = listSortSX;
            List<string> listSortSXTruong = new List<string> { "Ten tai san", "Ten loai tai san", "So luong", "Ty le hao mon", "Ty le con lai" };
            comboBox1.DataSource = listSortSXTruong;
            List<string> listSortSXKhoa = new List<string> { "Ten tai san", "Ten loai tai san", "So luong", "Ty le hao mon", "Ty le con lai" };
            cbbSapXepKhoa.DataSource = listSortSXKhoa;
            List<string> listSortSXCTG = new List<string> { "Ten tai san", "Ten loai tai san", "So luong" };
            cbbSapXepCTG.DataSource = listSortSXCTG;

        }
        public void LoadTSAllPhong()
        {
            clickingButton = "ThemPhong";
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabTaiSan);
            tabControl1.TabPages.Add(tabChungTuGiam);
            dgvTS.DataSource = null;
            dgvTS.DataSource = bll.GetInfoTSAllPhong_BLL();
            stt(dgvTS);
            cbbKhoa.SelectedIndex = cbbKhoa.FindStringExact("Tat ca");
            cbbPhong.SelectedIndex = cbbPhong.FindStringExact("Tat ca");

        }


        private void buttonXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string id = dgvTS.SelectedRows[0].Cells[3].Value.ToString();
                    int sl = int.Parse(dgvTS.SelectedRows[0].Cells[6].Value.ToString());
                    string ma = id.Substring(0, 7) + "-000";
                    int t = bll.GetSL_BLL(ma) + sl;
                    bll.UpdateSL(ma, t, t * 10);
                    bll.DeleTS_BLL(id);
                    dgvTS.DataSource = null;
                    dgvTS.DataSource = bll.GetInfoTSAllPhong_BLL();
                    stt(dgvTS);

                    MessageBox.Show("Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception)
                {
                    MessageBox.Show("Không được phép xóa vì có ràng buộc với bảng CHỨNG TỪ GIẢM!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbKhoa.SelectedItem.ToString() != "Tat ca")
            {

                cbbPhong.DataSource = bll.GetListPhongKhoa_BLL(bll.GetMaKhoa_BLL(cbbKhoa.SelectedItem.ToString()));

            }
            else cbbPhong.SelectedIndex = cbbPhong.FindStringExact("Tat ca");

        }



        private void button1_Click(object sender, EventArgs e)
        {
            PhanPhongBan f = new PhanPhongBan();
            clickingButton = "ThemPhong";
            f.d += new PhanPhongBan.myDelegate(addVePhong);
            f.Show();
        }

        private void buttonCTT_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabKhoTruong);
            dgvTruong.DataSource = null;
            dgvTruong.DataSource = bll.GetInfoNhapTruong_BLL();
            stt(dgvTruong);


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        { if (tabControl1.SelectedIndex == 0) { clickingButton = "ThemPhong"; }
            if (tabControl1.SelectedIndex == 1)
            {

                clickingButton = "ThemCTG";
                addCTG();
            }


        }

        private void buttonKhoa_Click(object sender, EventArgs e)
        {
            clickingButton = "ThemKhoa";
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabKhoKhoa);

            dgvKhoa.DataSource = null;
            dgvKhoa.DataSource = bll.GetInfoNhapAllKhoa_BLL();
            stt(dgvKhoa);



        }



        private void buttonTaiSan_Click(object sender, EventArgs e)
        {
            clickingButton = "ThemPhong";
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tabTaiSan);

            tabControl1.TabPages.Add(tabChungTuGiam);
            dgvTS.DataSource = null;
            dgvTS.DataSource = bll.GetInfoTSAllPhong_BLL();
            stt(dgvTS);
        }




        private void cbbPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            if (clickingButton == "ThemPhong") addVePhong();
            if (clickingButton == "ThemCTG") addCTG();
        }

        private void cbbKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (clickingButton == "ThemKhoa") addVeKhoKhoa();
            cbbPhong.SelectedIndex = cbbPhong.FindStringExact("Tat ca");


        }

        private void tabTaiSan_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThemVeKhoCuaTruong f = new ThemVeKhoCuaTruong();
            f.d += new ThemVeKhoCuaTruong.myDelegate(addVeKhoTruong);
            f.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChiaVeKhoa f = new ChiaVeKhoa();
            clickingButton = "ThemKhoa";
            f.d += new ChiaVeKhoa.myDelegate(addVeKhoKhoa);
            f.Show();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTSAllPhong();


        }

        private void dgvTruong_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTS.RowCount != 0)
            {
                string mats = dgvTruong.SelectedRows[0].Cells[1].Value.ToString();
                List<string> data = new List<string>();

                data.Add(mats);
                data.Add(dgvTruong.SelectedRows[0].Cells[2].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[3].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[4].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[5].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[6].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[7].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[8].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[9].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[10].Value.ToString());
                data.Add(dgvTruong.SelectedRows[0].Cells[11].Value.ToString());

                string[] arrHeader = new string[] { "Mã tài sản: ", "Tên tài sản: ", "Loại tài sản: ", "Số lượng:", "Số lượng nhập:", "Thành tiền:", "Thông số kỹ thuật: ", "Mã chứng từ tăng: ", "Ngày ghi tăng:", "Tỷ lệ CL:", "Tỷ lệ HM:" };

                textBox4.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    textBox4.AppendText(String.Format("{0}{1}", arrHeader[i], data[i].ToString()) + "\n");
                }
            }
        }

        private void dgvKhoa_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTS.RowCount != 0)
            {
                string mats = dgvKhoa.SelectedRows[0].Cells[1].Value.ToString();
                List<string> data = new List<string>();
                data.Add(bll.GetTenKhoa_BLL(mats.Substring(4, 3)));
                data.Add(mats);
                data.Add(dgvKhoa.SelectedRows[0].Cells[2].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[3].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[4].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[5].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[6].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[7].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[8].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[9].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[10].Value.ToString());
                data.Add(dgvKhoa.SelectedRows[0].Cells[11].Value.ToString());


                string[] arrHeader = new string[] {"Tên khoa:", "Mã tài sản: ", "Tên tài sản: ", "Loại tài sản: ", "Số lượng:", "Số lượng nhập", "Thành tiền:", "Thông số kỹ thuật: ", "Mã chứng từ tăng: ", "Ngày ghi tăng:", "Tỷ lệ CL:", "Tỷ lệ HM" };

                textBox7.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    textBox7.AppendText(String.Format("{0}{1}", arrHeader[i], data[i].ToString()) + "\n");
                }
            }
        }

        private void btXoaTruong_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string id = dgvTruong.SelectedRows[0].Cells[1].Value.ToString();
                    bll.DeleTSTruong_BLL(id);
                    dgvTruong.DataSource = null;
                    dgvTruong.DataSource = bll.GetInfoNhapTruong_BLL();
                    stt(dgvTruong);
                    MessageBox.Show("Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception)
                {
                    MessageBox.Show("Không được phép xóa vì có ràng buộc với bảng CHỨNG TỪ GIẢM!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
                MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);






        }

        private void btXoaKhoa_Click(object sender, EventArgs e)
        {
            clickingButton = "ThemKhoa";
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                       "Confirm Delete",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string id = dgvKhoa.SelectedRows[0].Cells[1].Value.ToString();
                    int sl = int.Parse(dgvKhoa.SelectedRows[0].Cells[4].Value.ToString());
                    string ma = id.Substring(0, 3) + "-000-000";
                    int t = bll.GetSL_BLL(ma) + bll.GetSLNhapKhoa_BLL(id);
                    bll.UpdateSL(ma, t, t * 10);
                    bll.DeleTSKhoa_BLL(id);
                    dgvKhoa.DataSource = null;
                    dgvKhoa.DataSource = bll.GetInfoNhapAllKhoa_BLL();
                    stt(dgvKhoa);


                    MessageBox.Show("Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception )
                {
                    MessageBox.Show("Không được phép xóa vì có ràng buộc với bảng CHỨNG TỪ GIẢM!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
        public string getMTS()
        {
            return dgvTS.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            clickingButton = "ThemPhong";
            string id = dgvTS.SelectedRows[0].Cells[3].Value.ToString();
            txtMTS.Text = dgvTS.SelectedRows[0].Cells[3].Value.ToString();
            txtkhoa.Text = bll.GetTenKhoa_BLL(id.Substring(4, 3));
            txtPhong.Text = bll.GetTenPhong_BLL(id.Substring(8, 3));
            int TyLeHM = int.Parse(dgvTS.SelectedRows[0].Cells[13].Value.ToString());
            int TyLeCL = int.Parse(dgvTS.SelectedRows[0].Cells[12].Value.ToString());
            numericUpDownTyLeCL.Value = TyLeCL;
            numericUpDownTyLeHM.Value = TyLeHM;

            numericUpDownSoLuong.Value = int.Parse(dgvTS.SelectedRows[0].Cells[6].Value.ToString());
            numericUpDownSoLuong.Maximum = bll.GetSL_BLL(id.Substring(0, 8) + "000") + int.Parse(dgvTS.SelectedRows[0].Cells[6].Value.ToString());


        }

        private void dgvTS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn lưu dữ liệu update hay không ?",
                                      "Confirm update",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string id = dgvTS.SelectedRows[0].Cells[3].Value.ToString();
                int slmoi = int.Parse(numericUpDownSoLuong.Value.ToString());
                bll.UpdateSL(id, slmoi, slmoi * 10);
                int slTong = bll.GetSL_BLL(id.Substring(0, 8) + "000") + int.Parse(dgvTS.SelectedRows[0].Cells[6].Value.ToString());
                bll.UpdateSL(id.Substring(0, 8) + "000", slTong - slmoi, (slTong - slmoi) * 10);
                int ConLai = int.Parse(numericUpDownTyLeCL.Value.ToString());
                int HaoMon = int.Parse(numericUpDownTyLeHM.Value.ToString());
                bll.UpDateCLHM_BLL(id, HaoMon, ConLai);

                addVePhong();

                MessageBox.Show("Update Thanh Cong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Không thực hiện update!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void buttonSapXep_Click(object sender, EventArgs e)
        {

            dgvTS.DataSource = null;
            dgvTS.DataSource = bll.SortListTaiSan_BLL(cbbKhoa.SelectedItem.ToString(), cbbPhong.SelectedItem.ToString(), com.SelectedValue.ToString());
            stt(dgvTS);

        }

        private void buttonTim_Click(object sender, EventArgs e)
        {
            string id = " ";
            string tents = textBoxTim.Text.ToString();
            try
            {
                id = bll.GetMaTSTruong_BLL(tents);
                string FirstIdPhong = id.Substring(0, 3);
                dgvTS.DataSource = null;
                dgvTS.DataSource = bll.SearchTS_BLL(cbbKhoa.SelectedItem.ToString(), cbbPhong.SelectedItem.ToString(), FirstIdPhong);
                stt(dgvTS);
                MessageBox.Show("Da thuc hien tim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong ton tai ten tai san nay,vui long kiem tra lai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvTruong.DataSource = null;
            dgvTruong.DataSource = bll.SortTruong_BLL(comboBox1.SelectedItem.ToString());
            stt(dgvTruong);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = " ";
            string tents = txtTimTruong.Text.ToString();
            try
            {
                id = bll.GetMaTSTruong_BLL(tents);

                dgvTruong.DataSource = null;
                dgvTruong.DataSource = bll.SearchTruong_BLL(id);
                stt(dgvTruong);
                MessageBox.Show("Da thuc hien tim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong ton tai ten tai san nay,vui long kiem tra lai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dgvKhoa.DataSource = null;
            dgvKhoa.DataSource = bll.SortKhoa_BLL(cbbKhoa.SelectedItem.ToString(), cbbSapXepKhoa.SelectedItem.ToString());
            stt(dgvKhoa);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id;
            string tents = textBox6.Text.ToString();
            try
            {
                id = bll.GetMaTSTruong_BLL(tents);
                string First = id.Substring(0, 3);

                string tenkhoa = cbbKhoa.SelectedItem.ToString();
                dgvKhoa.DataSource = null;
                dgvKhoa.DataSource = bll.SearchTSkhoa_BLL(cbbKhoa.SelectedItem.ToString(), First);
                stt(dgvKhoa);
                MessageBox.Show("Da thuc hien tim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong ton tai ten tai san nay,vui long kiem tra lai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void buttonThemCTG_Click(object sender, EventArgs e)
        {
            clickingButton = "ThemCTG";
            GUI.ChungTuGiam ctg = new GUI.ChungTuGiam();
            ctg.d += new GUI.ChungTuGiam.myDelegate(addCTG);
            ctg.Show();
        }

        private void buttonSuaCTG_Click(object sender, EventArgs e)
        {
            GUI.SuaChungTuGiam f = new GUI.SuaChungTuGiam();
            f.d += new SuaChungTuGiam.myDelegate(addCTG);
            addVePhong();
            f.Show();
        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonXoaCTG_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa ?",
                                      "Confirm Delete",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string maTS = dgvCTG.SelectedRows[0].Cells[4].Value.ToString();
                string maCTG = dgvCTG.SelectedRows[0].Cells[1].Value.ToString();
                int slThanhly = int.Parse(dgvCTG.SelectedRows[0].Cells[7].Value.ToString());
                int slPhong = bll.GetSL_BLL(maTS) + slThanhly;
                bll.UpdateSL(maTS, slPhong, slPhong * 10);
                bll.DeleCTG_BLL(maCTG);
                addCTG();
                addVePhong();

                MessageBox.Show(" Xóa Thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else MessageBox.Show("Không thực hiện xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void textBoxTim_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void numericUpDownTyLeHM_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTyLeCL.Value = 100 - numericUpDownTyLeHM.Value;

        }

        private void numericUpDownTyLeCL_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownTyLeHM.Value = 100 - numericUpDownTyLeCL.Value;
        }

        private void buttonSapXepCTG_Click(object sender, EventArgs e)
        {

            dgvCTG.DataSource = null;
            dgvCTG.DataSource = bll.SortListCTG_DLL(cbbKhoa.SelectedItem.ToString(), cbbPhong.SelectedItem.ToString(), cbbSapXepCTG.SelectedValue.ToString());
            stt(dgvCTG);
        }

        private void buttonTimCTG_Click(object sender, EventArgs e)
        {
            string id = " ";
            string tents = textBoxTimCTG.Text.ToString();
            try
            {
                id = bll.GetMaTSTruong_BLL(tents);
                string FirstIdCTG = id.Substring(0, 3);
                dgvCTG.DataSource = null;
                dgvCTG.DataSource = bll.SearchCTG_BLL(cbbKhoa.SelectedItem.ToString(), cbbPhong.SelectedItem.ToString(), FirstIdCTG);
                stt(dgvTS);
                MessageBox.Show("Da thuc hien tim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong ton tai ten tai san nay,vui long kiem tra lai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTS_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvTS.RowCount != 0)
            {
                string mats = dgvTS.SelectedRows[0].Cells[3].Value.ToString();
                List<string> data = new List<string>();
                data.Add(dgvTS.SelectedRows[0].Cells[1].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[2].Value.ToString());
                data.Add(mats);
                data.Add(dgvTS.SelectedRows[0].Cells[4].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[5].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[6].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[7].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[8].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[9].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[10].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[11].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[12].Value.ToString());
                data.Add(dgvTS.SelectedRows[0].Cells[13].Value.ToString());


                string[] arrHeader = new string[] {"Tên phòng:","Tên khoa:", "Mã tài sản: ", "Tên tài sản: ", "Loại tài sản: ", "Số lượng:", "Số lượng nhập:", "Thành tiền:", "Thông số kỹ thuật: ", "Mã chứng từ tăng: ", "ngày ghi tăng:", "Tỷ lệ CL:", "Tỷ lệ HM:" };

                textBox1.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    textBox1.AppendText(String.Format("{0}{1}", arrHeader[i], data[i].ToString()) + "\n");
                }
            }

        }

        private void dgvCTG_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCTG.RowCount != 0)
            {
                string mctg = dgvCTG.SelectedRows[0].Cells[1].Value.ToString();
                List<string> data = new List<string>();

                data.Add(mctg);
                data.Add(dgvCTG.SelectedRows[0].Cells[2].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[3].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[4].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[5].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[6].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[7].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[8].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[9].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[10].Value.ToString());
                data.Add(dgvCTG.SelectedRows[0].Cells[11].Value.ToString());



                string[] arrHeader = new string[] { "Mã tài chứng từ giảm: ","Tên phòng:","Tên khoa:", "Mã tài sản: ", "Tên tài sản: ", "Tên loại tài sản:", "Số lượng xuất:", "Thành tiền:", "Ngày ghi giảm:", "Nội dung: ", "Ghi chú:" };

                textBox3.Clear();
                for (int i = 0; i < data.Count; i++)
                {
                    textBox3.AppendText(String.Format("{0}{1}", arrHeader[i], data[i].ToString()) + "\n");
                }
            }

        }

        private void tựĐộngThanhLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int count = 0;
            List<TaiSan> liTS = bll.GetListTS_BLL();
            foreach (TaiSan ts in liTS)
            {
                List<DTO.ChungTuGiam> ThongtinCtg = bll.GetThongTinCTGbyMaTS_BLL(ts.MaTaiSan);
                if (ThongtinCtg.Count > 0) continue;

                int nsd = ts.NgayGhiTang.Value.Year;
                int now = DateTime.Now.Year;

                if (ts.TyLeCL - ts.TyLeHM * (now - nsd) == 0)
                {
                    count++;
                    DTO.ChungTuGiam ctg = new DTO.ChungTuGiam();
                    ctg.MaChungTuGiam = "02-TDTL-" + RandomString(8);
                    ctg.MaTaiSan = ts.MaTaiSan;
                    ctg.NgayGhiGiam = DateTime.Now;
                    ctg.SoLuong = ts.SoLuong;
                    ctg.ThanhTien = ts.ThanhTien;
                    ctg.NoiDung = "Thanh lý hao mòn dưới 0%";
                    ctg.GhiChu = "ghi chu 1";
                    bll.UpdateSL(ctg.MaTaiSan, 0, 0);
                    bll.AddChungTuGiam_BLL(ctg);

                }
            }
            addCTG();
            addVePhong();
            MessageBox.Show("Đã thanh lý " + count.ToString() + " tài sản có tỷ lệ còn lại dưới 0%!");
        }

        private void exportToXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "excel.xls";
            save.Filter = "Microsoft Excel(*.xls)|All File (*.*)";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string pat = Path.GetFullPath(save.FileName);
                exportToExcel(pat);
            }
        }
    

         void exportToExcel(string fullpath)
         {
             Excel.Application xlApp;
             Excel.Workbook xlWorkBook;

             object misValue = System.Reflection.Missing.Value;
         xlApp = new Excel.Application();
           xlWorkBook = xlApp.Workbooks.Add(misValue);


           List<string> ListKhoa = bll.GetListKhoa_BLL();
           ListKhoa.RemoveAt(ListKhoa.Count - 1);
         foreach (string tenkhoa in ListKhoa)
             {
               tbStatusBar.Text = "Saving... Please Wait";
                Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(Type.Missing, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], 1, XlSheetType.xlWorksheet);
                xlWorkSheet.Name = tenkhoa;



                    Range r = xlWorkSheet.Range["A8:A10"];
                    r.Merge();
                    r.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r.Font.Bold = true;
                    r.Cells[1, 1] = "Số TT";


                   Range r1 = xlWorkSheet.Range["B8:N8"];
                   r1.Merge();
                   r1.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                   r1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                   r1.Font.Bold = true;
                   xlWorkSheet.Cells[8, 2] = "Ghi tăng tài sản, dụng cụ, đồ gỗ";

                   Range r2 = xlWorkSheet.Range["O8:S8"];
                   r2.Merge();
                   r2.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                   r2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                   r2.Font.Bold = true;
                   r2.Cells[1, 1] = "Ghi giảm tài sản";

                   Range r3 = xlWorkSheet.Range["B9:D9"];
                   r3.Merge();
                   r3.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                   r3.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                   r3.Font.Bold = true;
                   r3.Cells[1, 1] = "Chứng từ";
                   xlWorkSheet.Cells[10, 2] = "Mã TS";
                   xlWorkSheet.Cells[10, 3] = "SLTS Nhập về";
                   xlWorkSheet.Cells[10, 4] = "Mã NSD";

                   Range r4 = xlWorkSheet.Range["E9:E10"];
                    r4.Merge();
                    r4.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    r4.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    r4.Font.Bold = true;
                    r4.Cells[1, 1] = "Tên tài sản cố định, CC, DC  và đồ gỗ ...";

                    Range r5 = xlWorkSheet.Range["F9:F10"];
                 r5.Merge();
                 r5.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
               r5.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r5.Font.Bold = true;
               r5.Cells[1, 1] = "Số hiệu, thông số kỹ thuật";

                Range r6 = xlWorkSheet.Range["G9:G10"];
                r6.Merge();
                 r6.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                  r6.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                 r6.Font.Bold = true;
               r6.Cells[1, 1] = "SL Tại Phòng";

               Range r7 = xlWorkSheet.Range["H9:H10"];
                r7.Merge();
               r7.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
               r7.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r7.Font.Bold = true;
                r7.Cells[1, 1] = "Thành tiền";

                 Range r8 = xlWorkSheet.Range["I9:I10"];
                 r8.Merge();
                r8.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                 r8.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                 r8.Font.Bold = true;
               r8.Cells[1, 1] = "Tỷ lệ %CL";

               Range r9 = xlWorkSheet.Range["J9:J10"];
               r9.Merge();
                r9.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                 r9.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                 r9.Font.Bold = true;
                 r9.Cells[1, 1] = "Tỷ lệ %CL";

                Range r10 = xlWorkSheet.Range["K9:K10"];
                r10.Merge();
                 r10.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r10.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r10.Font.Bold = true;
                r10.Cells[1, 1] = "Tỷ lệ %CL";

                  Range r11 = xlWorkSheet.Range["L9:L10"];
                r11.Merge();
                r11.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r11.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r11.Font.Bold = true;
                  r11.Cells[1, 1] = "Tỷ lệ %CL";

                  Range r12 = xlWorkSheet.Range["M9:M10"];
                  r12.Merge();
                  r12.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                  r12.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r12.Font.Bold = true;
                 r12.Cells[1, 1] = "Tỷ lệ %CL";

                  Range r13 = xlWorkSheet.Range["N9:N10"];
                  r13.Merge();
                  r13.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                  r13.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r13.Font.Bold = true;
                  r13.Cells[1, 1] = "Tỷ lệ HM";

                   Range r14 = xlWorkSheet.Range["O9:P9"];
                   r14.Merge();
                r14.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r14.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
               r14.Font.Bold = true;
                r14.Cells[1, 1] = "Chứng từ";

                 Range r15 = xlWorkSheet.Range["O10:O10"];
               r15.Merge();
                  r15.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                  r15.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r15.Font.Bold = true;
                  r15.Cells[1, 1] = "Ngày";

                 Range r16 = xlWorkSheet.Range["P10:P10"];
                  r16.Merge();
                  r16.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                  r16.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                 r16.Font.Bold = true;
                  r16.Cells[1, 1] = "Lý do";

                  Range r17 = xlWorkSheet.Range["Q9:Q10"];
                  r17.Merge();
                  r17.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                 r17.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                  r17.Font.Bold = true;
                 r17.Cells[1, 1] = "Số lượng Thanh lý";

               Range r18 = xlWorkSheet.Range["R9:R10"];
               r18.Merge();
                 r18.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                r18.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r18.Font.Bold = true;
               r18.Cells[1, 1] = "Thành tiền";

             Range r19 = xlWorkSheet.Range["S9:S10"];
             r19.Merge();
            r19.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            r19.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
           r19.Font.Bold = true;
         r19.Cells[1, 1] = "Ghi chú";

         QLTSDataContext db = new QLTSDataContext();

         var s = db.TaiSans.Where(p => p.MaTaiSan.Substring(4, 3) == bll.GetMaKhoa_BLL(tenkhoa)&&p.MaTaiSan.Substring(8,3)=="000").Select(p => p);
              
        List<TaiSan> li = s.ToList<TaiSan>();


        int begini = 12;
        int beginj = 2;
        int STT = 0;
        foreach (TaiSan ts in li)
        {
            xlWorkSheet.Cells[begini, beginj - 1] = ++STT;
            xlWorkSheet.Cells[begini, beginj] = ts.MaTaiSan;
            xlWorkSheet.Cells[begini, beginj + 1] = ts.SoLuongNhap;
            xlWorkSheet.Cells[begini, beginj + 2] = ts.NgayGhiTang.Value.Year.ToString();
            xlWorkSheet.Cells[begini, beginj + 3] = ts.TenTaiSan;
            xlWorkSheet.Cells[begini, beginj + 4] = ts.ThongSoKyThuat;
            xlWorkSheet.Cells[begini, beginj + 5] = bll.GetSLTSOPhong_BLL(ts.MaTaiSan.Substring(0,7));
            xlWorkSheet.Cells[begini, beginj + 6] = ts.SoLuongNhap*10;
            xlWorkSheet.Cells[begini, beginj + 7] = ts.TyLeCL;
            xlWorkSheet.Cells[begini, beginj + 8].Formula = "=I" + begini + "-N" + begini;
            xlWorkSheet.Cells[begini, beginj + 9].Formula = "=J" + begini + "-N" + begini;
            xlWorkSheet.Cells[begini, beginj + 10].Formula = "=K" + begini + "-N" + begini;
            xlWorkSheet.Cells[begini, beginj + 11].Formula = "=L" + begini + "-N" + begini;
            xlWorkSheet.Cells[begini, beginj + 12] = ts.TyLeHM;
             List<DTO.ChungTuGiam> k = db.ChungTuGiams.Where(p => p.MaTaiSan.Substring(0, 7) == ts.MaTaiSan.Substring(0, 7)).Select(p => p).ToList<DTO.ChungTuGiam>();

           { } DTO.ChungTuGiam ctg = null;
             if (k.Count > 0) ctg = k[0];
             if (ctg != null)
              {
                xlWorkSheet.Cells[begini, beginj + 13] = ctg.NgayGhiGiam.Value.Year.ToString();
                xlWorkSheet.Cells[begini, beginj + 14] = ctg.NoiDung;
                xlWorkSheet.Cells[begini, beginj + 15] = bll.GetSLThanhLy_DAL(ts.MaTaiSan.Substring(0,7));
                xlWorkSheet.Cells[begini, beginj + 16] = ctg.ThanhTien.ToString();
                xlWorkSheet.Cells[begini, beginj + 17] = ctg.GhiChu;
                    }
                   begini++;
                }

              Range b = xlWorkSheet.Range[xlWorkSheet.Cells[11, 1], xlWorkSheet.Cells[begini, beginj + 17]];
               b.Borders.LineStyle = XlLineStyle.xlDot;
               b.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
               b.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
               b.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
               b.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
               xlWorkSheet.Columns.AutoFit();
               xlWorkSheet.Rows.AutoFit();

               Range x = xlWorkSheet.Range["E4:E4"];
                  x.Merge();
                  xlWorkSheet.Cells[4, 5].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                  x.Font.Bold = true;
                  x.Font.Size = 22;
                  x.Cells[1, 1] = "BẢNG KIỂM KÊ, ĐÁNH GIÁ TÀI SẢN NĂM 2018";

                  x = xlWorkSheet.Range["C5:C5"];
                  x.Merge();
                  xlWorkSheet.Cells[5, 3].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                  x.Font.Bold = true;
                x.Font.Size = 16;
                  x.Cells[1, 1] = "SỔ THEO DÕI TÀI SẢN CỐ ĐỊNH VÀ CÔNG CỤ, DỤNG CỤ, VRTMH TẠI NƠI SỬ DỤNG";

                  xlWorkSheet.Cells[begini + 3, 2] = "  - Gồm : */ Thiết bị : ................mục ; */ Đồ gỗ, VRTNH :.............mục ";
                 xlWorkSheet.Cells[begini + 3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                  xlWorkSheet.Cells[begini + 4, 2] = "  - Sổ này có ..................trang, đánh số từ trang 01 đến ...........";
                  xlWorkSheet.Cells[begini + 4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                  xlWorkSheet.Cells[begini + 5, 2] = "  - Ngày mở sổ:.......................";
                  xlWorkSheet.Cells[begini + 5, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                  xlWorkSheet.Cells[begini + 6, 3] = "Hiệu trưởng";
                  xlWorkSheet.Cells[begini + 6, 3].Font.Bold = true;

                  xlWorkSheet.Cells[begini + 6, 5] = "Kế toán tài sản";
                  xlWorkSheet.Cells[begini + 6, 5].Font.Bold = true;
                  xlWorkSheet.Cells[begini + 5, beginj + 14] = "Đà Nẵng, ngày        tháng      năm";
                  xlWorkSheet.Cells[begini + 6, beginj + 14] = "Người ghi sổ";
                  xlWorkSheet.Cells[begini + 6, beginj + 14].Font.Bold = true;



                 Marshal.ReleaseComObject(xlWorkSheet);
              }


             xlWorkBook.SaveAs(fullpath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

              xlWorkBook.Close(0);
          xlApp.Quit();

          Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
             tbStatusBar.Text = "Working normally";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "p.xls"))
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "p.xls");
            }
            exportToExcel(AppDomain.CurrentDomain.BaseDirectory + "p.xls");

            Excel.Application ex = new Excel.Application();
            Excel.Workbook wb = ex.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "p.xls");
            ex.Visible = true;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
  
    


  }

