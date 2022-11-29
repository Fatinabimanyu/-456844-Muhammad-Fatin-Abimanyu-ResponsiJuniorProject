using System.Data;
using Npgsql;
using System.Data;
using System.Xml.Linq;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = "host=localhost;Port=2022;Username=fatinabimanyu;Password=nitaf321;Database=Responsi";
        public DataTable tabel;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                sql = @"select * from st_insert(:_nama)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", txtName.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Users Berhasil diinputkan", "Well done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    txtName.Text =  null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Insert FAIL!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            conn.Open();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                sql = @"select * from st_update(:_id,:_name,:_alamat,:_no_handphone)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", txtName.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data Berhasil diupdate", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    r = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "update gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
                try
                {

                    sql = @"select * from st_delete(:_id)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", r.Cells["_id"].Value.ToString());
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("Data Users Berhasil dihapus", "Well Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        r = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Delete FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}

