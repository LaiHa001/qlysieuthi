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
    public partial class Thông_tin_sản_phẩm : Form
    {
        public Thông_tin_sản_phẩm()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string msp = txtMasanpham.Text;
            string tsp = txtTensanpham.Text;
            string sl = txtSoluong.Text;
            string gb = txtGiaban.Text;
            string mcc = txtManhacungcap.Text;
            string querry = "insert into Sanpham (masp, tensp, soluong,giaban, mancc)values('" + msp + "', '" + tsp + "', '" + sl + "', '" + gb + "','" + mcc + "')";
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
            string msp = txtMasanpham.Text;
            string tsp = txtTensanpham.Text;
            string sl = txtSoluong.Text;
            string gb = txtGiaban.Text;
            string mcc = txtManhacungcap.Text;
            string querry = "update Sanpham set tensp = '" + tsp + "', soluong = '" + sl + "', giaban='" + gb + "',mancc='" + mcc + "' where masp='" + msp + "'";
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
            string msp = txtMasanpham.Text;
            string tsp = txtTensanpham.Text;
            string sl = txtSoluong.Text;
            string gb = txtGiaban.Text;
            string mcc = txtManhacungcap.Text;
            string querry = " delete from Sanpham where masp ='" + msp + "'";
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
            string querry = "select * from Sanpham";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Sanpham");

           dgvSanpham.DataSource = ds.Tables["Sanpham"];
        }

        private void Thông_tin_sản_phẩm_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMasanpham.Text = "";
            txtTensanpham.Text = "";
            txtSoluong.Text = "";
            txtGiaban.Text = "";
            txtManhacungcap.Text = "";
            getData();
        }

        private void dgvSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMasanpham.Text = dgvSanpham.Rows[row].Cells["masp"].Value.ToString();
                txtTensanpham.Text = dgvSanpham.Rows[row].Cells["tensp"].Value.ToString();
                txtSoluong.Text = dgvSanpham.Rows[row].Cells["soluong"].Value.ToString();
                txtGiaban.Text = dgvSanpham.Rows[row].Cells["giaban"].Value.ToString();
                txtManhacungcap.Text = dgvSanpham.Rows[row].Cells["mancc"].Value.ToString();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string querry = "select * from Sanpham where tensp like '%" + tk + "%'";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Sanpham");
            dgvSanpham.DataSource = ds.Tables["Sanpham"];
        }
    }
}
