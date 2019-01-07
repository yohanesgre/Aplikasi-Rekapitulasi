using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Rekap_Pasien
{
    public static class Formula
    {
        public static float calculateBOR(int hariPerawatan, int tempatTidur, int hariDlmSeperiode)
        {
            float hasil;
            if (tempatTidur != 0 && hariDlmSeperiode != 0)
            {
                hasil = ((float)hariPerawatan * 100f) / ((float)tempatTidur * (float)hariDlmSeperiode);
                return hasil;
            }
            return 0;
        }
        public static float calculateALOS(int hariPerawatan, int pasienKeluar)
        {
            if (pasienKeluar != 0)
                return (float)hariPerawatan / (float)pasienKeluar;
            return 0;
        }
        public static float calculateTOI(int tempatTidur, int periode, int hariPerawatan, int pasienKeluar)
        {
            if (pasienKeluar != 0)
                return (((float)tempatTidur * (float)periode) - (float)hariPerawatan) / (float)pasienKeluar;
            return 0;
        }
        public static float calculateBTO(int pasienKeluar, int tempatTidur)
        {
            if (tempatTidur != 0)
                return (float)pasienKeluar / (float)tempatTidur;
            return 0;
        }
        public static float calculateNDR(int pasienMatiK48, int pasienKeluar)
        {
            if (pasienKeluar != 0)
                return ((float)pasienMatiK48 * 100f) / (float)pasienKeluar;
            return 0;
        }
        public static float calculateGDR(int pasienMati, int pasienKeluar)
        {
            if (pasienKeluar != 0)
                return ((float)pasienMati * 100f) / (float)pasienKeluar;
            return 0;
        }

    }
}
