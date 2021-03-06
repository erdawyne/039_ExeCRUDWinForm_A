using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Exercise_CRUD
{
    class DBStudent
    {
        public static object MessageBoxButton { get; private set; }

        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=siswa";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }
        public static void AddStudent(siswa std)
        {
            string sql = "INSERT INTO siswa_table VALUES (Null,@StudentNama, @StudentNo, @StudentJK, @StudentKelas, Null)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentNama", MySqlDbType.VarChar.Value) = std.Nama;
            cmd.Parameters.Add("@StudentNo", MySqlDbType.VarChar.Value) = std.No;
            cmd.Parameters.Add("@StudentJK", MySqlDbType.VarChar.Value) = std.JK;
            cmd.Parameters.Add("@StudentKelas", MySqlDbType.VarChar.Value) = std.Kelas;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil DItambahkan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Siswa tidak dapat ditambahkan. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void UpdateStudent(siswa std, string id)
        {
            string sql = "UPDATE INTO siswa_table SET Nama = @StudentNama, No Siswa = @StudentNo, Jenis Kelamin= @StudentJK, Kelas = @StudentKelas WHERE ID = @StudentID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentNama", MySqlDbType.VarChar.Value) = std.Nama;
            cmd.Parameters.Add("@StudentNo", MySqlDbType.VarChar.Value) = std.No;
            cmd.Parameters.Add("@StudentJK", MySqlDbType.VarChar.Value) = std.JK;
            cmd.Parameters.Add("@StudentKelas", MySqlDbType.VarChar.Value) = std.Kelas;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Siswa tidak dapat Update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DeleteStudent(string id)
        {
            string sql = "DELETE FROM siswa_table WHERE ID = @StudentID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentNama", MySqlDbType.VarChar.Value) = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Dihapus.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Siswa tidak dapat dihapus. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            con.Close();
        }
    }

    public class siswa
    {
        public siswa(string v1, string v2, string v3, string v4)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
        }

        public object Nama { get; internal set; }
        public object Kelas { get; internal set; }
        public object JK { get; internal set; }
        public object No { get; internal set; }
        public string V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public string V4 { get; }
    }
}
