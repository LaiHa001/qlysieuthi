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
    public partial class Phiếu_nhập_hàng : Form
    {
        public Phiếu_nhập_hàng()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mpn = txtMaphieunhap.Text;
            string mancc =txtManhacungcap.Text;
            string th = txtTenhang.Text;
            string nn = txtNgaynhap.Text;
            string sl = txtSoluong.Text;
            string gn = txtGianhap.Text;
            string querry = "insert into Phieunhaphang(mapn, mancc, tenhang, ngaynhap, soluong, gianhap)values('" + mpn + "', '" + mancc + "', '" + th + "', '" + nn + "'," +
                "'" + sl + "','" + gn + "')";
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
            string mpn = txtMaphieunhap.Text;
            string mancc = txtManhacungcap.Text;
            string th = txtTenhang.Text;
            string nn = txtNgaynhap.Text;
            string sl = txtSoluong.Text;
            string gn = txtGianhap.Text;
            string querry = "update Phieunhaphang set mancc  = '" + mancc + "', tenhang='" + th + "',  ngaynhap='" + nn + "',soluong='" + sl + "', gianhap ='" + gn + "' where mapn= '" + mpn + "'";
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
            string mpn = txtMaphieunhap.Text;
            string mancc = txtManhacungcap.Text;
            string th = txtTenhang.Text;
            string nn = txtNgaynhap.Text;
            string sl = txtSoluong.Text;
            string gn = txtGianhap.Text;
            string querry = "delete from Phieunhaphang where mancc ='" + mancc + "'";
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
            string querry = "select * from Phieunhaphang";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Phieunhaphang");

            dgvPhieunhap.DataSource = ds.Tables["Phieunhaphang"];

        }

        private void Phiếu_nhập_hàng_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvPhieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaphieunhap.Text = dgvPhieunhap.Rows[row].Cells["mapn"].Value.ToString();
                txtManhacungcap.Text = dgvPhieunhap.Rows[row].Cells["mancc"].Value.ToString();
                txtTenhang.Text = dgvPhieunhap.Rows[row].Cells["tenhang"].Value.ToString();
                txtNgaynhap.Text = dgvPhieunhap.Rows[row].Cells["ngaynhap"].Value.ToString();
                txtSoluong.Text = dgvPhieunhap.Rows[row].Cells["Soluong"].Value.ToString();
                txtGianhap.Text = dgvPhieunhap.Rows[row].Cells["Gianhap"].Value.ToString();
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMaphieunhap.Text = "";
            txtManhacungcap.Text = "";
            txtTenhang.Text = "";
            txtNgaynhap.Text = "";
            txtSoluong.Text = "";
            txtGianhap.Text = "";
            getData();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tk = txtTimkiem.Text;
            string querry = "select * from Phieunhaphang where tenhang like '% " + tk + " %'";
            DataSet ds = new DataSet();
            ketnoi cn = new ketnoi();
            ds = cn.laydulieu(querry, "Phieunhaphang");
            dgvPhieunhap.DataSource = ds.Tables["Phieunhaphang"];
        }
    }
}
