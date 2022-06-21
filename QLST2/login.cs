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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tk = txtTendangnhap.Text;
            string mk = txtMatkhau.Text;
            string querry = "select count(*) as soluong from Nguoidung where tendangnhap ='" + tk + "' and Matkhau ='" + mk + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.laydulieu(querry, "Nguoidung");
            if ((int)ds.Tables["Nguoidung"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("Đăng Nhập thành công");
                Quanlisieuthi frm = new Quanlisieuthi();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
