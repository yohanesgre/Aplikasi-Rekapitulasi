using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Rekap_Pasien
{
    public static class Formula
    {
        static float hasil;
        public static float calculateBOR(int hariPerawatan, int tempatTidur, int hariDlmSeperiode)
        {
            
            if (tempatTidur != 0 && hariDlmSeperiode != 0)
            {
                hasil = ((float)hariPerawatan * 100f) / ((float)tempatTidur * (float)hariDlmSeperiode);
                return (float)Math.Round((double)hasil, 2);
            }
            return 0;
        }
        public static float calculateALOS(int hariPerawatan, int pasienKeluar)
        {
            if (pasienKeluar != 0) {
                hasil = (float)hariPerawatan / (float)pasienKeluar;
                return (float)Math.Round((double)hasil, 2);
            }
            return 0;
        }
        public static float calculateTOI(int tempatTidur, int periode, int hariPerawatan, int pasienKeluar)
        {
            if (pasienKeluar != 0)
            {
                hasil = (((float)tempatTidur * (float)periode) - (float)hariPerawatan) / (float)pasienKeluar;
                return (float)Math.Round((double)hasil, 2);
            }
            return 0;
        }
        public static float calculateBTO(int pasienKeluar, int tempatTidur)
        {
            if (tempatTidur != 0)
            {
                hasil = (float)pasienKeluar / (float)tempatTidur;
                return (float)Math.Round((double)hasil, 2);
            }
            return 0;
        }
        public static float calculateNDR(int pasienMatiK48, int pasienKeluar)
        {
            if (pasienKeluar != 0)
            {
                hasil = ((float)pasienMatiK48 * 100f) / (float)pasienKeluar;
                return (float)Math.Round((double)hasil, 2);
            }
            return 0;
        }
        public static float calculateGDR(int pasienMati, int pasienKeluar)
        {
            if (pasienKeluar != 0)
            {
                hasil = ((float)pasienMati * 100f) / (float)pasienKeluar;
                return (float)Math.Round((double)hasil, 2);
            }
            return 0;
        }

    }
}
