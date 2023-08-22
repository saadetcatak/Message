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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=SAADET\\SQLEXPRESS01;Initial Catalog=DbTest;Integrated Security=True");

        public string numara;

        void Gelenkutusu()
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select*From TblMesaj where Alıcı=" + numara, connection);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
        }


        void Gidenkutusu()
        {
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select*From TblMesaj where Gönderen=" + numara,connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            dataGridView2.DataSource= dt2;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
            Gelenkutusu();
            Gidenkutusu();

            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Ad,Soyad from TblKisiler where numara=" + numara,connection);
            SqlDataReader dr =cmd.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text= dr[0]+ " " + dr[1];
            }
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into TblMesaj (Gönderen,Alıcı,Başlık,İçerik) values @p1,@p2,@p3,@p4", connection);
            command.Parameters.AddWithValue("@p1", numara);
            command.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            command.Parameters.AddWithValue("@p3", textBox1.Text);
            command.Parameters.AddWithValue("@p4", richTextBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Mesajınız İletildi");
            Gidenkutusu();
        }
    }
}
