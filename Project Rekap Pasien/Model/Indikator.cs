using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Rekap_Pasien
{
    public class Indikator
    {
        public int Id { get; set; }
        public string Ruangan { get; set; }
        public int Tahun { get; set; }
        public string Data { get; set; }
        public float Januari { get; set; }
        public float Februari { get; set; }
        public float Maret { get; set; }
        public float April { get; set; }
        public float Mei { get; set; }
        public float Juni { get; set; }
        public float Juli { get; set; }
        public float Agustus { get; set; }
        public float September { get; set; }
        public float Oktober { get; set; }
        public float November { get; set; }
        public float Desember { get; set; }
        public float Total { get; set; }
    }
}
