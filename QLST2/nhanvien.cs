using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST2
{
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mnv = txtManhanvien.Text;
            string tnv = txtTennhanvien.Text;
            string gt = txtGioitinh.Text;
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string querry = "insert into Nhanvien (manv, tennv, gioitinh, diachi, sdt)VALUES('" + mnv + "', '" + tnv + "', '" + gt + "', '" + dc + "','" + sdt + "')";
            ketnoi cn = new ketnoi();
            bool kt = cn.thucthi(querry);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mnv = txtManhanvien.Text;
            string tnv = txtTennhanvien.Text;
            string gt = txtGioitinh.Text;
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string querry = "update Nhanvien set tennv = '" + tnv + "', gioitinh = '" + gt + "', diachi ='" + dc + "', sodienthoai='" + sdt + "'  where manhanvien = '" + mnv + "'";
            ketnoi cn = new ketnoi();
            bool kt = cn.thucthi(querry);
            if (kt == true)
            {
                MessageBox.Show("Sửa thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mnv = txtManhanvien.Text;
            string tnv = txtTennhanvien.Text;
            string gt = txtGioitinh.Text;
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string querry = "delete from Nhanvien where manv ='" + mnv + "'";
            ketnoi cn = new ketnoi();
            bool kt = cn.thucthi(querry);
            if (kt == true)
            {
                MessageBox.Show("Xóa thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }
        public void getData()
        {
            string querry = "select * from Nhanvien";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Nhanvien");

            dgvNhanvien.DataSource = ds.Tables["Nhanvien"];

        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            txtGioitinh.Text = "";
            txtDiachi.Text = "";
            txtSodienthoai.Text = "";
            getData();
        }

        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtManhanvien.Text = dgvNhanvien.Rows[row].Cells["manv"].Value.ToString();
                txtTennhanvien.Text = dgvNhanvien.Rows[row].Cells["tennv"].Value.ToString();
                txtGioitinh.Text = dgvNhanvien.Rows[row].Cells["gioitinh"].Value.ToString();
                txtDiachi.Text = dgvNhanvien.Rows[row].Cells["diachi"].Value.ToString();
                txtSodienthoai.Text = dgvNhanvien.Rows[row].Cells["sdt"].Value.ToString();
               
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string querry = "select * from Nhanvien where tennv like '%" + tk + "%'";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Nhanvien");
            dgvNhanvien.DataSource = ds.Tables["Nhanvien"];

        }
    }
}
