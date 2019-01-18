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

        //-------------------------------------------- Update ----------------------------------------------------------
        
        public static void updateData(int id, int tahun, Rekapitulasi rekapitulasi, string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Rekapitulasi SET Data = @Data, Januari = @Januari, Februari = @Februari," +
                    "Maret = @Maret, April = @April, Mei = @Mei, Juni = @Juni, Juli = @Juli," +
                    "Agustus = @Agustus, September = @September, Oktober = @Oktober, November = @November," +
                    "Desember = @Desember, Total = @Total, updatedAt = @updatedAt  WHERE Ruangan = '" + ruangan + "' AND Id = " + id + " AND Tahun = " + tahun + "", rekapitulasi);
            }
        }

        public static void updateIndikator(int id, int tahun, Indikator indikator, string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Indikator SET Data = @Data, Januari = @Januari, Februari = @Februari," +
                    "Maret = @Maret, April = @April, Mei = @Mei, Juni = @Juni, Juli = @Juli," +
                    "Agustus = @Agustus, September = @September, Oktober = @Oktober, November = @November," +
                    "Desember = @Desember, Total = @Total  WHERE Ruangan = '"+ruangan+"' AND Id = " + id + " AND Tahun = " + tahun + "", indikator);
            }
        }

        public static void UpdateTahunRekapitulasi(int id, int tahun, int newTahun, string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Rekapitulasi SET Tahun = " + newTahun + " WHERE Ruangan = '" + ruangan + "' AND Id = " + id + " AND Tahun = " + tahun + " ");
            }
        }

        public static void UpdateTahunIndikator(int id, int tahun, int newTahun, string ruangan)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Indikator SET Tahun = " + newTahun + " WHERE Ruangan = '" + ruangan + "' AND Id = " + id + " AND Tahun = " + tahun + " ");
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
                    " @Maret, @April, @Mei, @Juni, @Juli, @Agustus, @September, @Oktober, @November, @Desember, @Total)", dataIndikator);;
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

        public static int CheckIfUserExist(UserModel user)
        {
            int count = 0;
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                count = cnn.ExecuteScalar<int>("SELECT count(*) FROM User Where Username =='" + user.Username + "'");
            }
            return count;
        }

        public static void AddUser(UserModel user)
        {
            string password = EncryptPassword.Encrypt(user.Password, "zxc123");
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (CheckIfUserExist(user) > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Username sudah ada!", "Error", System.Windows.Forms.MessageBoxButtons.OK);
                }else
                {
                    cnn.Execute("INSERT INTO User (Username, Password, Nama, Jabatan, Instalasi, Role) " +
                    "VALUES (@Username, '"+password+"', @Nama, @Jabatan, @Instalasi, @Role)", user);
                }
            }
        }

        public static void DeleteUser(string username)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM User Where Username = '" + username +"'");
            }
        }

        public static void UpdateUser(string username, UserModel user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE User SET Username = @Username, Password = @Password, Nama = @Nama," +
                    "Jabatan = @Jabatan, Instalasi = @Instalasi, Role = @Role  Where Username = '" + username + "'", user);
            }
        }

        public static bool CheckLogin(string user = "", string Password = "")
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string decryptedPassword = SqliteDataAccess.GetDecryptedPassword(user);
                if (Password == SqliteDataAccess.GetDecryptedPassword(user) && Password != "" && user != "")
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
                string Password = "";
                if (listUser.Count > 0)
                {
                    userModel = listUser[0];
                    LoginForm.userModel = userModel;
                    Password = EncryptPassword.Decrypt(userModel.Password, "zxc123");
                }
                return Password;
            }
        }

        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
