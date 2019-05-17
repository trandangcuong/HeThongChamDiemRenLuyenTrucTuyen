using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinfromQuetThe
{
    public partial class Form2 : Form
    {
        int index;
        DataTable table = new DataTable();
        BindingManagerBase mbm;
        public Form2()
        {
            InitializeComponent();
        }
       

        public class LuuThongtin
        {
            static public string ID;
            static public string TenSk;
            static public string Diem;
        }
     
        private void load_combobox()
        {
            DataTable dt = new DataTable();
            dt = KetNoi_CSDL.Doc_bang("select * from SUKIEN");

            txt_maid.DataSource = dt;
            txt_maid.DisplayMember = "ID";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LuuThongtin.ID = txt_maid.Text;
            LuuThongtin.TenSk = txt_tensk.Text;
            LuuThongtin.Diem = txt_diem.Text;
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
        private void load_datagridview()
        {
            table = new DataTable();
            table = load_ID();
            index = table.Rows.Count - 1;
            lay_index(index);
            dataGrid1.DataSource = table;
        }
        public DataTable load_ID()
        {
            DataTable dtb = new DataTable();
            dtb = KetNoi_CSDL.Doc_bang("select * from SUKIEN");
            return dtb;
        }
        public void lay_index(int index)
        {
            this.txt_maid.Text = table.Rows[index]["ID"].ToString();
            this.txt_tensk.Text = table.Rows[index]["TENSK"].ToString();
            this.txt_diadiem.Text = table.Rows[index]["DIADIEM"].ToString();
            this.txt_thoigian.Text = table.Rows[index]["THOIGIAN"].ToString();
            this.txt_diem.Text = table.Rows[index]["DIEM"].ToString();
            this.txt_ghichu.Text = table.Rows[index]["GHICHU"].ToString();
        }
        public void load_textbox()
        {
            int c;
            DataTable dt = new DataTable();
            dt = KetNoi_CSDL.Doc_bang(" select * from SUKIEN");
            c = dt.Rows.Count - 1;
            if (c > 0)
            {
                txt_maid.DataBindings.Add("text", dt, "ID");
                txt_tensk.DataBindings.Add("text", dt, "TENSK");
                txt_diadiem.DataBindings.Add("text", dt, "DIADIEM");
                txt_thoigian.DataBindings.Add("text", dt, "THOIGIAN");
                txt_diem.DataBindings.Add("text", dt, "DIEM");
                txt_ghichu.DataBindings.Add("text", dt, "GHICHU");
                mbm = this.BindingContext[dt];
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            load_datagridview();
            load_textbox();

            load_combobox();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            string sql = "select * from SUKIEN  Where ID Like'%" + txt_timkiem.Text + "%'";
            tb = KetNoi_CSDL.Doc_bang(sql);
            dataGrid1.DataSource = tb;
        }

        private void txt_maid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable pbl = new DataTable();
                pbl = KetNoi_CSDL.Doc_bang("select * from SUKIEN");
                foreach (DataRow r in pbl.Rows)
                    if (txt_maid.Text == r["ID"].ToString())
                    {
                        txt_tensk.Text = r["TENSK"].ToString();
                        txt_diadiem.Text = r["DIADIEM"].ToString();
                        txt_thoigian.Text = r["THOIGIAN"].ToString();
                        txt_diem.Text = r["DIEM"].ToString();
                        txt_ghichu.Text = r["GHICHU"].ToString();
                    }
            }
            catch
            {


            }
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            index = dataGrid1.CurrentRowIndex;
            lay_index(index);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
