using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_CRUD
{
    public partial class Form3 : Form
    {
        private Form3 _parent;

        private readonly Form3 _parent;

        public Form3(Form3 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void Clear()
        {
            txtNama.Text = txtNo.Text = txtJK.Text = txtKelas.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNama.Text.Trim().Length < 3)
            {
                MessageBox.Show("Nama siswa tidak ditemukan ( > 3.");
                return;
            }
            if (txtNo.Text.Trim().Length < 3)
            {
                MessageBox.Show("No siswa tidak ditemukan ( > 3.");
                return;
            }
            if (txtJK.Text.Trim().Length < 3)
            {
                MessageBox.Show("Jenis Kelamin siswa tidak ditemukan ( > 3.");
                return;
            }
            if (txtKelas.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kelas siswa tidak ditemukan ( > 3.");
                return;
            }
            if(btnSave.Text == "Save")
            {
                siswa std = new siswa(txtNama.Text.Trim(), txtNo.Text.Trim(), txtJK.Text.Trim(), txtJK.Text.Trim());
                DBStudent.AddStudent(std);
                Clear();
            }
        }
    }
}
