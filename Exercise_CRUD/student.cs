using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_CRUD
{
    class student
    {
        public string Nama { get; set; }
        public string No { get; set; }
        public string JK { get; set; }
        public string Kelas { get; set; }

        public student(string nama, string no, string jK, string kelas)
        {
            Nama = nama;
            No = no;
            JK = jK;
            Kelas = kelas;
        }
    }
}
