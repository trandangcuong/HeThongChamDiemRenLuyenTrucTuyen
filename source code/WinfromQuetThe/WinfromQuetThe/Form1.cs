using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity;


namespace WinfromQuetThe
{
    

    public partial class Form1 : Form
    {

        THAMGIASUKIEN model = new THAMGIASUKIEN();

        private SerialPort RFID;
        private string DispString;
        private string rfid_code = "";
        public Form1()
        {
           
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

            RFID = new SerialPort();
            RFID.PortName = "COM5";
            RFID.BaudRate = 9600;
            RFID.DataBits = 8;
            RFID.Parity = Parity.None;
            RFID.StopBits = StopBits.One;
            RFID.Open();
            RFID.ReadTimeout = 200;
            if (RFID.IsOpen)
            {
                DispString = "";
            }
            else
            {
                RFID.Close();
            }
            RFID.DataReceived += new SerialDataReceivedEventHandler(RFID_DataReceived);
            comboclass.Text = Form2.LuuThongtin.ID;
            txt_tensk.Text = Form2.LuuThongtin.TenSk;
            txt_diem.Text = Form2.LuuThongtin.Diem;


        }


        private void RFID_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            //if (DispString.Length >10 && dem>0)
            //{

            //    DispString = "";
            //    dem = 0;
            // }
            // else
            // {
                DispString = RFID.ReadExisting();
           //     dem = 1;
                this.Invoke(new EventHandler(DisplayText));
            //Loaddata();
            // }
           
        

        }
        private void DisplayText(object sender, EventArgs e)
        {
            //txttag.Text = "";
            //var val = DispString.ToString().TrimStart().TrimEnd();
            //var test = val.Remove(0, 0);
            //txttag.Text = test;
            txt_rfid_code.AppendText(DispString);
          
           
        }

        private void themthamgiasukien1()
        {
            if (KtTrungThamGiaSK())
            {

                AutoClosingMessageBox.Show("Bạn Đã Điểm danh rồi !", "Thông báo", 3000);
               

                txttag.Text = "";
                txtstudname.Text = "";
                txtrollno.Text = "";
            }
            else
            {
                string masv = txttag.Text;
                int mask = int.Parse(comboclass.Text.Trim());
                //model.MASV = txttag.Text.Trim();
                //model.MASK = int.Parse(comboclass.Text.Trim());

                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {


                   
               
                    db.sp_themthamgiasukien(masv, mask,null);


                }
                AutoClosingMessageBox.Show("Điểm danh thành công", "Thông báo", 3000);

           
            txttag.Text = "";
            txtstudname.Text = "";
            txtrollno.Text = "";
            }
        }

        //private void themthamgiasukien()
        //{
        //    if (KtTrungThamGiaSK())
        //    {
        //        AutoClosingMessageBox.Show("Bạn Đã Điểm danh rồi !", "Thông báo", 3000);


                

        //        txttag.Text = "";
        //        txtstudname.Text = "";
        //        txtrollno.Text = "";
        //    }
        //    else
        //    {


        //        string chuoi_ket_noi = @"Data Source=quanlydiemrenluyen.database.windows.net;Initial Catalog=QuanLyDiemRenLuyen;Persist Security Info=True;User ID=cuong123";
        //        SqlConnection ket_noi = new SqlConnection(chuoi_ket_noi);
        //        ket_noi.Open();
        //        var cmd = new SqlCommand("sp_themthamgiasukien1", ket_noi);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@masv", SqlDbType.NVarChar).Value = txttag.Text;
        //        cmd.Parameters.Add("@mask", SqlDbType.Int).Value = comboclass.Text;
        //        cmd.ExecuteNonQuery();
        //        ket_noi.Close();
        //        MessageBox.Show("Điểm danh thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txttag.Text = "";
        //        txtstudname.Text = "";
        //        txtrollno.Text = "";
        //        }


        //}
        private void Loaddata()
        {
            if (kiemtratontai())
            {

                AutoClosingMessageBox.Show("sinh viên không tồn tại !", "Thông báo", 3000);
               
                txttag.Text = "";
                txtstudname.Text = "";
                txtrollno.Text = "";
            }
            else
            {



                string chuoi_ket_noi = @"Data Source =DESKTOP-R8KE3JJ; Initial Catalog = QL_DIEMRENLUYEN; Integrated Security = True";
                SqlConnection ket_noi = new SqlConnection(chuoi_ket_noi);



                string query = "SELECT sTenSV, FK_sMaLopID FROM SINHVIEN WHERE PK_sMaSVID = @masv";
                SqlCommand command1 = new SqlCommand(query, ket_noi);
                ket_noi.Open();
                command1.Parameters.AddWithValue("@masv", txttag.Text);

                SqlDataReader reader1 = command1.ExecuteReader();


                reader1.Read();


                this.txtstudname.Text = (reader1["sTenSV"].ToString());
                this.txtrollno.Text = (reader1["FK_sMaLopID"].ToString());


                reader1.Close();

                themthamgiasukien1();


            }



        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            Loaddata();
         

          
        }
        private bool KtTrungThamGiaSK()
        {
            string masv = txttag.Text;
            int mask = int.Parse(comboclass.Text.Trim());



            using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
            {

                var kiemtra = (from dg in db.THAMGIASUKIENs where dg.MASV == masv && dg.MASK == mask select dg).ToList();
              
                bool tatkt = false;
               
                if (kiemtra.Count > 0)
                {
                    tatkt = true;


                }
                else
                {
                    kiemtra.Clear();


                }
                return tatkt;
            }


            //string chuoi_ket_noi = @"Data Source =DESKTOP-R8KE3JJ; Initial Catalog = QL_DIEMRENLUYEN; Integrated Security = True";


            //SqlConnection con = new SqlConnection(chuoi_ket_noi);
            //con.Open();

            //SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from THAMGIASUKIEN  where MASV='" + masv + "' and MASK='" + mask + "'", con);
            //DataTable dt_kiemtra = new DataTable();
            //da_kiemtra.Fill(dt_kiemtra);

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool kiemtratontai()
        {
            string chuoi_ket_noi = @"Data Source =DESKTOP-R8KE3JJ; Initial Catalog = QL_DIEMRENLUYEN; Integrated Security = True";
            bool tatkt = false;
            string maso = txttag.Text;
            SqlConnection con = new SqlConnection(chuoi_ket_noi);
            con.Open();

            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from SINHVIEN where PK_sMaSVID='" + maso + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                da_kiemtra.Dispose();
                
               
            }
            else
            {
              tatkt = true;
            }
            return tatkt;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(txt_rfid_code.TextLength==10)
            {
                txttag.Text = txt_rfid_code.Text;
                txt_rfid_code.Text = "";
                Loaddata();
            }
        }
         void Clear()

        {

            txtrollno.Text = txtstudname.Text = txtrollno.Text = "";

        }
       
        private void Thoat_Click(object sender, EventArgs e)
        {
            Thoat.Enabled = false;
            if (MessageBox.Show("Bạn có chắc muốn thoát ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Thất Bại !");
                    Thoat.Enabled = true;
                }
            }
            else
            {
                Thoat.Enabled = true;
            }
        }
    }
}
