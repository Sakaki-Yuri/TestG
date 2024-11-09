using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace btvnc6p1
{
    public partial class Form1 : Form
    {
        private string conStr = @"Server=DESKTOP-BI1T79Q\SQLEXPRESS;Database=A;Integrated Security=True;";
        private SqlConnection conn;
        private SqlDataAdapter adapter; 
        private DataSet ds;
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlstr = "Select * from Table_1";
            adapter = new SqlDataAdapter(sqlstr,conn);
            ds = new DataSet();
            adapter.Fill(ds, "Table_1");
            dt = ds.Tables["Table_1"];
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox6.ResetText();
            textBox1.Focus();//thiết lập điểm đang hoạt động
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button1.Enabled = false;
            this.button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlstr = @"INNSERT INTO Table_1 VALUES (@MaSo,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@DienThoai)";
            SqlCommand comm = new SqlCommand(sqlstr, conn);
            comm.Parameters.Add("@MaSo", SqlDbType.Char).Value = char.Parse(textBox1.Text);
            comm.Parameters.Add("@HoTen", SqlDbType.Char).Value = char.Parse(textBox2.Text);
            comm.Parameters.Add("@NgaySinh", SqlDbType.SmallDateTime).Value = DateTime.Parse(textBox4.Text);
            comm.Parameters.Add("@GioiTinh",SqlDbType.Char).Value = char.Parse(textBox3.Text);
            comm.Parameters.Add("@DiaChi",SqlDbType.Char).Value = char.Parse(textBox5.Text);
            comm.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = char.Parse(textBox6.Text);
            int count = (int)comm.ExecuteNonQuery();  // thực hiện truy vấn
            LoadData();
            conn.Close();
            textBox1.ReadOnly = true;
            this.button1.Enabled = true;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            textBox1.Text = dt.Rows[n]["MaSo"].ToString();
            textBox2.Text = dt.Rows[n]["HoTen"].ToString();
            textBox4.Text = dt.Rows[n]["NgaySinh"].ToString();
            textBox3.Text = dt.Rows[n]["GioiTinh"].ToString();
            textBox5.Text = dt.Rows[n]["DiaChi"].ToString();
            textBox6.Text = dt.Rows[n]["DienThoai"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlstr = @"UPDATE Table_1 SET HoTen = @HoTen,NgaySinh = @NgaySinh,GioiTinh = @GioiTinh,DiaChi = @DiaChi,DienThoai = @DienThoai";
            SqlCommand comm = new SqlCommand(sqlstr, conn);
            comm.Parameters.Add("@MaSo", SqlDbType.Char).Value = char.Parse(textBox1.Text);
            comm.Parameters.Add("@HoTen", SqlDbType.Char).Value = char.Parse(textBox2.Text);
            comm.Parameters.Add("@NgaySinh", SqlDbType.SmallDateTime).Value = DateTime.Parse(textBox4.Text);
            comm.Parameters.Add("@GioiTinh", SqlDbType.Char).Value = char.Parse(textBox3.Text);
            comm.Parameters.Add("@DiaChi", SqlDbType.Char).Value = char.Parse(textBox5.Text);
            comm.Parameters.Add("@DienThoai", SqlDbType.NVarChar).Value = char.Parse(textBox6.Text);
            int count = (int)comm.ExecuteNonQuery();  // thực hiện truy vấn
            LoadData();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult p = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if( p == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlstr = "DELETE FROM Table_1 WHERE MaSo = @MaSo";
                SqlCommand comm = new SqlCommand(sqlstr, conn);
                comm.Parameters.Add("@MaSo", SqlDbType.Char).Value = char.Parse(textBox1.Text);
                int count = (int)comm.ExecuteNonQuery();  // thực hiện truy vấn
                LoadData();
                conn.Close();
            } 
                
        }
    }
}
