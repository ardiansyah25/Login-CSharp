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

namespace AppLogin
{
    public partial class FormLogin : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;

        Koneksi Konn = new Koneksi();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = Konn.GetConn();

            conn.Open();
            cmd = new SqlCommand("select * from TBl_USER where KodeUser = '" + textBox1.Text + "' and PasswordUser = '" + textBox2.Text + "'", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                FormMenuUtama frmUtama = new FormMenuUtama();
                frmUtama.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Salah Bro !!");
            }

            //if (textBox1.Text == "admin" && textBox2.Text == "admin")
            //{
            //    FormMenuUtama frmUtama = new FormMenuUtama();
            //    frmUtama.Show();
            //}
            //else
            //{
            //   
            //}
        }
    }
}
