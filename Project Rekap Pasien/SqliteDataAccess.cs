using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using Dapper;

namespace Project_Rekap_Pasien
{
    public class SqliteDataAccess
    {
        public static List<Rekapitulasi> getAllRekapitulasiDataAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Rekapitulasi>("SELECT * FROM Rekapitulasi");
                return output.ToList();
            }
        }


        public static List<Rekapitulasi> getAllRekapitulasiDataOfRuangan(string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Rekapitulasi>("SELECT * FROM Rekapitulasi where Ruangan = '" +ruangan+ "'");
                return output.ToList();
            }
        }

        public static List<Rekapitulasi> getAllRekapitulasiDataOfRuanganTahun(string ruangan, int tahun)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Rekapitulasi>("SELECT * FROM Rekapitulasi where Ruangan = '"+ruangan+"' AND Tahun = "+tahun+"");
                return output.ToList();
            }
        }

        public static List<Indikator> getAllIndikatorDataOfRuangan(string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Indikator>("SELECT * FROM Indikator where Ruangan = '" + ruangan + "'");
                return output.ToList();
            }
        }

        public static List<Indikator> getAllIndikatorDataOfRuanganTahun(string ruangan, int tahun)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Indikator>("SELECT * FROM Indikator where Ruangan = '" + ruangan + "' AND Tahun = " + tahun + "");
                return output.ToList();
            }
        }

        //public static void insertNewData(string tableName, Rekapitulasi dataRekap)
        //{
        //    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        //    {
        //        cnn.Execute("INSERT INTO " + tableName + " (Ruangan, Data, Tahun, Januari, Februari, Maret, April, Mei, Juni, Juli" +
        //            ", Agustus, September, Oktober, November, Desember, Total) VALUES (@Ruangan, @Data, @Tahun, @Januari, @Februari," +
        //            " @Maret, @April, @Mei, @Juni, @Juli, @Agustus, @September, @Oktober, @November, @Desember, @Total)", dataRekap);
        //    }
        //}

        //-------------------------------------------- Update ----------------------------------------------------------
        
        public static void updateData(int id, int tahun, Rekapitulasi rekapitulasi)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Rekapitulasi SET Data = @Data, Januari = @Januari, Februari = @Februari," +
                    "Maret = @Maret, April = @April, Mei = @Mei, Juni = @Juni, Juli = @Juli," +
                    "Agustus = @Agustus, September = @September, Oktober = @Oktober, November = @November," +
                    "Desember = @Desember, Total = @Total, updatedAt = @updatedAt  WHERE Id = " + id + " AND Tahun = " + tahun + "", rekapitulasi);
            }
        }

        public static void updateIndikator(int id, int tahun, Indikator indikator)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Indikator SET Data = @Data, Januari = @Januari, Februari = @Februari," +
                    "Maret = @Maret, April = @April, Mei = @Mei, Juni = @Juni, Juli = @Juli," +
                    "Agustus = @Agustus, September = @September, Oktober = @Oktober, November = @November," +
                    "Desember = @Desember, Total = @Total  WHERE Id = " + id + " AND Tahun = " + tahun + "", indikator);
            }
        }

        //-------------------------------------------- Insert ----------------------------------------------------------

        public static void insertNewData(Rekapitulasi dataRekap)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (dataRekap.Data != null)
                {
                    cnn.Execute("INSERT INTO Rekapitulasi (Id, Ruangan, Tahun, Data, Januari, Februari, Maret, April, Mei, Juni, Juli" +
                    ", Agustus, September, Oktober, November, Desember, Total) VALUES (@Id, @Ruangan, @Tahun, @Data, @Januari, @Februari," +
                    " @Maret, @April, @Mei, @Juni, @Juli, @Agustus, @September, @Oktober, @November, @Desember, @Total)", dataRekap);
                    Console.WriteLine("added");
                }
            }
        }

        public static void insertNewIndikator(Indikator dataIndikator)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (dataIndikator.Data != null)
                {
                    cnn.Execute("INSERT INTO Indikator (Id, Ruangan, Tahun, Data, Januari, Februari, Maret, April, Mei, Juni, Juli" +
                    ", Agustus, September, Oktober, November, Desember, Total) VALUES (@Id, @Ruangan, @Tahun, @Data, @Januari, @Februari," +
                    " @Maret, @April, @Mei, @Juni, @Juli, @Agustus, @September, @Oktober, @November, @Desember, @Total)", dataIndikator);
                    Console.WriteLine("added");
                }
            }
        }

        //-------------------------------------------- Delete ----------------------------------------------------------

        public static void deleteTahunInRekap(int tahun)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Rekapitulasi Where Tahun = " +tahun+"");
            }
        }

        public static void deleteTahunInIndikator(int tahun)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Indikator Where Tahun = " + tahun + "");
            }
        }

        public static void deleteRuanganInRekap(string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Rekapitulasi Where Ruangan = '" + ruangan + "'");
            }
        }

        public static void deleteRuanganInIndikator(string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Indikator Where Ruangan = '" + ruangan + "'");
            }
        }

        // ------------------------------------------------------- User -----------------------------------------------------------------

        public static List<UserModel> loadUser()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>("SELECT * FROM User", new DynamicParameters());
                return output.ToList();
            }
        }

        public static bool CheckLogin(string user = "", string password = "")
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string decryptedPassword = SqliteDataAccess.GetDecryptedPassword(user);
                if (password == SqliteDataAccess.GetDecryptedPassword(user))
                {
                    return true;
                }
                else
                    return false;
            }
        }

        private static string GetDecryptedPassword(string user = "")
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserModel>("SELECT * FROM User WHERE Username = '" + user + "'", new DynamicParameters());
                List<UserModel> listUser = output.ToList();
                UserModel userModel;
                string password = "";
                if (listUser.Count > 0)
                {
                    userModel = listUser[0];
                    password = EncryptPassword.Decrypt(userModel.password, "zxc123");
                }
                return password;
            }
        }

        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
