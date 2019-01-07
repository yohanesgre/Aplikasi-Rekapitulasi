using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Rekap_Pasien
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public string Jabatan { get; set; }
        public string Instalasi { get; set; }
        public int Role { get; set; }
    }
}
