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
    public partial class Khách_hàng : Form
    {
        public Khách_hàng()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mkh = txtMakhachhang.Text;
            string tkh = txtTenkhachhang.Text;
            string dc =     txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string querry = "insert into Khachhang (makh,tenkh,diachi,sdt )VALUES('" + mkh + "', '" + tkh + "', '" + dc + "','" + sdt + "')";
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
            string mkh = txtMakhachhang.Text;
            string tkh = txtTenkhachhang.Text;
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string querry = "update Khachhang set tenkh = '" + tkh + "', diachi ='" + dc + "' , sdt='" + sdt + "' where makh = '" + mkh + "'";
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
            string mkh = txtMakhachhang.Text;
            string tkh = txtTenkhachhang.Text;
            string dc = txtDiachi.Text;
            string sdt = txtSodienthoai.Text;
            string querry = "delete from Khachhang where makh='" + mkh + "'";
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
            string querry = "select * from Khachhang";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Khachhang");

            dgvKhachhang.DataSource = ds.Tables["Khachhang"];

        }

        private void Khách_hàng_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMakhachhang.Text = "";
            txtTenkhachhang.Text = "";
            txtDiachi.Text = "";
            txtSodienthoai.Text = "";
            getData();

        }

        private void dgvKhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMakhachhang.Text = dgvKhachhang.Rows[row].Cells["makh"].Value.ToString();
                txtTenkhachhang.Text = dgvKhachhang.Rows[row].Cells["tenkh"].Value.ToString();
                txtDiachi.Text = dgvKhachhang.Rows[row].Cells["diachi"].Value.ToString();
                txtSodienthoai.Text = dgvKhachhang.Rows[row].Cells["sdt"].Value.ToString();
               
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string querry = "select * from khachhang where tenkh like '%" + tk + "%'";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Khachhang");
            dgvKhachhang.DataSource = ds.Tables["khachhang"];
        }
    }
}
