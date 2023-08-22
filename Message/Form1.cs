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

namespace Message
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection=new SqlConnection("Data Source=SAADET\\SQLEXPRESS01;Initial Catalog=DbTest;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select*From TblKisiler where Numara=@p1 and Sifre=@p2", connection);
            command.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@p2",textBox1.Text);
            SqlDataReader dr=command.ExecuteReader();
            if (dr.Read())
            { 
                Form2 frm= new Form2();
                frm.numara = maskedTextBox1.Text;
                frm.Show();

            }

            else 
            {
                MessageBox.Show("Hatalı Bilgi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            connection.Close();
        }
    }
}
