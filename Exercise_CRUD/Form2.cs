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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void  Display()
        {
            DBStudent.DisplayAndSearch("SELECT ID, Nama, No, JK, Kelas FROM siswa_table", dataGridView);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(this);
            form.ShowDialog();
        }
    }
}
