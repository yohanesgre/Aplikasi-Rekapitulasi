using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_Rekap_Pasien
{
    public partial class RekapitulasiUserControl : UserControl
    {
        IndikatorUserControl indikatorUC = new IndikatorUserControl();

        DataTable dt = new DataTable();

        Rekapitulasi newData;
        DataGridViewRow newAddedRow;

        string namaRuangan = null;
        int tahunSelected;

        public RekapitulasiUserControl()
        {
            InitializeComponent();
        }

        private void refreshRuangan()
        {
            if (listView1.Items.Count > 0 || listView1.Items != null)
            {
                listView1.Items.Clear();
            }
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataAll();
            var deleteDuplicateRuangan = AppForm.listRekapitulasi.Distinct(new RuanganComparer());
            deleteDuplicateRuangan = deleteDuplicateRuangan.OrderBy(rekap => rekap.Ruangan).ToList();
            var items = listView1.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            foreach (Rekapitulasi rekap in deleteDuplicateRuangan)
            {
                bool alreadyExists = items.Any(x => x == rekap.Ruangan.ToString());
                if (!alreadyExists)
                    listView1.Items.Add("Ruangan " + rekap.Ruangan.ToString());
            }
        }

        private void initDataRekapitulasiByTahun()
        {
            dt = new DataTable();
            dt.Columns.Add("no", typeof(int));
            dt.Columns.Add("data", typeof(string));
            dt.Columns.Add("januari", typeof(int));
            dt.Columns.Add("februari", typeof(int));
            dt.Columns.Add("maret", typeof(int));
            dt.Columns.Add("april", typeof(int));
            dt.Columns.Add("mei", typeof(int));
            dt.Columns.Add("juni", typeof(int));
            dt.Columns.Add("juli", typeof(int));
            dt.Columns.Add("agustus", typeof(int));
            dt.Columns.Add("september", typeof(int));
            dt.Columns.Add("oktober", typeof(int));
            dt.Columns.Add("november", typeof(int));
            dt.Columns.Add("desember", typeof(int));
            dt.Columns.Add("total", typeof(int));
            int count = 0;
            if (AppForm.listRekapitulasi.Count > 0)
            {
                foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                {
                    count++;
                    dt.Rows.Add(count, rekap.Data, rekap.Januari, rekap.Februari, rekap.Maret, rekap.April, rekap.Mei, rekap.Juni, rekap.Juli, rekap.Agustus, rekap.September, rekap.Oktober, rekap.November, rekap.Desember, rekap.Total);
                }
            }
            AppForm.listIndikator = SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(namaRuangan, tahunSelected);
            dataGridView1.DataSource = dt;
            lblTitleTable.Text = "Tabel Rekapitulasi Ruang " + namaRuangan + " Tahun " + tahunSelected + "";
            panel6.Visible = true;
            panel7.Visible = true;
            dataGridView1.Visible = true;
        }

        private void updateDataRekapitulasi()
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                Rekapitulasi updateRekap = new Rekapitulasi();
                updateRekap.Data = (string)row.Cells[1].Value;
                updateRekap.Januari = (int)row.Cells[2].Value;
                updateRekap.Februari = (int)row.Cells[3].Value;
                updateRekap.Maret = (int)row.Cells[4].Value;
                updateRekap.April = (int)row.Cells[5].Value;
                updateRekap.Mei = (int)row.Cells[6].Value;
                updateRekap.Juni = (int)row.Cells[7].Value;
                updateRekap.Juli = (int)row.Cells[8].Value;
                updateRekap.Agustus = (int)row.Cells[9].Value;
                updateRekap.September = (int)row.Cells[10].Value;
                updateRekap.Oktober = (int)row.Cells[11].Value;
                updateRekap.November = (int)row.Cells[12].Value;
                updateRekap.Desember = (int)row.Cells[13].Value;
                for (int j = 2; j < 14; j++)
                    updateRekap.Total += (int)row.Cells[j].Value;
                updateRekap.updatedAt = DateTime.Now.ToString("HH:mm | dd-MM-yyyy");
                SqliteDataAccess.updateData((int)row.Cells[0].Value, tahunSelected, updateRekap, namaRuangan);
            }
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuanganTahun(namaRuangan, tahunSelected);
            lblUpdate.Text = "Diperbarui: " + AppForm.listRekapitulasi[0].updatedAt;
            if (SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(namaRuangan, tahunSelected).Count == 0)
            {
                addNewIndikator(tahunSelected, namaRuangan);
            }
            indikatorUC.CalculateIndikator(tahunSelected, namaRuangan);
            foreach (Indikator indikator in AppForm.listIndikator)
            {
                SqliteDataAccess.updateIndikator(indikator.Id, tahunSelected, indikator, namaRuangan);
            }
            MessageBox.Show("Perbaruan data berahasil!", "Berhasil", MessageBoxButtons.OK);
            initDataRekapitulasiByTahun();
        }


        private void addNewData(int tahun, string ruangan)
        {
            for (int i = 0; i < 8; i++)
            {
                string data = null;
                switch (i)
                {
                    case 0:
                        data = "Hari Perawatan";
                        break;
                    case 1:
                        data = "Lama Dirawat";
                        break;
                    case 2:
                        data = "Pasien Keluar (H&M)";
                        break;
                    case 3:
                        data = "Pasien Mati Keseluruhan";
                        break;
                    case 4:
                        data = "Pasien Mati < 48 jam";
                        break;
                    case 5:
                        data = "Pasien Mati >= 48 jam";
                        break;
                    case 6:
                        data = "Jumlah Tempat Tidur";
                        break;
                    case 7:
                        data = "Jumlah Periode";
                        break;
                    default:
                        break;
                }
                newData = new Rekapitulasi();
                newData.Id = i + 1;
                newData.Ruangan = ruangan;
                newData.Tahun = tahun;
                newData.Data = data;
                newData.Januari = 0;
                newData.Februari = 0;
                newData.Maret = 0;
                newData.April = 0;
                newData.Mei = 0;
                newData.Juni = 0;
                newData.Juli = 0;
                newData.Agustus = 0;
                newData.September = 0;
                newData.Oktober = 0;
                newData.November = 0;
                newData.Desember = 0;
                newData.Total = 0;
                SqliteDataAccess.insertNewData(newData);
            }
            addNewIndikator(tahun, ruangan);
        }

        private void addNewIndikator(int tahun, string ruangan)
        {
            int count = 0;
            string data = null;
            float[] value = new float[12];
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        data = "BOR";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = 0;
                        }
                        break;
                    case 1:
                        data = "ALOS";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = 0;
                        }
                        break;
                    case 2:
                        data = "TOI";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = 0;
                        }
                        break;
                    case 3:
                        data = "BTO";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = 0;
                        }
                        break;
                    case 4:
                        data = "NDR";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = 0;
                        }
                        break;
                    case 5:
                        data = "GDR";
                        for (int j = 0; j < 12; j++)
                        {
                            value[j] = 0;
                        }
                        break;
                    default:
                        break;
                }
                count++;
                float rerata = 0;
                Indikator indikator = new Indikator
                {
                    Id = count,
                    Ruangan = ruangan,
                    Tahun = tahun,
                    Data = data,
                    Januari = value[0],
                    Februari = value[1],
                    Maret = value[2],
                    April = value[3],
                    Mei = value[4],
                    Juni = value[5],
                    Juli = value[6],
                    Agustus = value[7],
                    September = value[8],
                    Oktober = value[9],
                    November = value[10],
                    Desember = value[11],
                    Total = rerata
                };
                SqliteDataAccess.insertNewIndikator(indikator);
            }
        }

        private void addTahunInListView() {
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuangan(namaRuangan);
            var deleteDuplicateTahun = AppForm.listRekapitulasi.Distinct(new TahunComparer());
            deleteDuplicateTahun = deleteDuplicateTahun.OrderBy(rekap => rekap.Tahun).ToList();
            var items = listViewTahun.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
            foreach (Rekapitulasi rekap in deleteDuplicateTahun)
            {
                bool alreadyExists = items.Any(x => x == rekap.Tahun.ToString());
                if (!alreadyExists)
                    listViewTahun.Items.Add(rekap.Tahun.ToString());
            }
            panel6.Visible = false;
            panel7.Visible = false;
            dataGridView1.Visible = false;
            panel4.Visible = true;
            listViewTahun.Visible = true;
            listViewTahun.Refresh();
        }

          
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewTahun.Items.Count != 0)
            {
                listViewTahun.Items.Clear();
            }
            int indexOfSpace = e.Item.Text.IndexOf(" ");
            namaRuangan = e.Item.Text.Substring(indexOfSpace + 1);
            addTahunInListView();
        }

        private void listViewTahun_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tahunSelected = Int32.Parse(e.Item.Text);
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuanganTahun(namaRuangan, tahunSelected);
            AppForm.listIndikator = SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(namaRuangan, tahunSelected);
            listViewTahun.Visible = false;
            panel4.Visible = false;
            initDataRekapitulasiByTahun();
        }

        private void btnParseData_Click(object sender, EventArgs e)
        {
            updateDataRekapitulasi();       
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (i == 6)
                {
                    row.Cells[14].Value = row.Cells[3].Value;
                    return;
                }
                int total = 0;
                for (int j = 2; j <= 13; j++)
                {
                    if (row.Cells[j].Value == null)
                        row.Cells[j].Value = 0;
                    total += (int)row.Cells[j].Value;
                }
                row.Cells[14].Value = total;
            }
        }

        private void listViewTahun_VisibleChanged(object sender, EventArgs e)
        {
            if (listViewTahun.Visible)
            {
                btnParseData.Visible = false;
                btnAddNewData.Visible = true;
      //          btnTambahRuangan.Visible = true;
                btnReload.Visible = false;
                lblUpdate.Visible = false;
                btnEditTahun.Visible = false;
                //        btnHapusTahun.Visible = false;
                //      btnHapusRuangan.Visible = true;
                btnExportExcel.Visible = false;
            }
            else
            {
                if (AppForm.listRekapitulasi[0].updatedAt == null || AppForm.listRekapitulasi[0].updatedAt == "")
                    lblUpdate.Text = "Diperbarui: Belum pernah";
                else
                    lblUpdate.Text = "Diperbarui: " + AppForm.listRekapitulasi[0].updatedAt;
                lblUpdate.Visible = true;
                btnParseData.Visible = true;
                btnAddNewData.Visible = false;
//                btnTambahRuangan.Visible = false;
                btnReload.Visible = true;
                btnEditTahun.Visible = true;
                //              btnHapusTahun.Visible = true;
                //            btnHapusRuangan.Visible = true;
                btnExportExcel.Visible = true;
            }
        }

        private void btnAddNewData_Click(object sender, EventArgs e)
        {
            if (namaRuangan != "" && namaRuangan != null && namaRuangan != " ")
            {
                int mTahun = RekapAddDataDialog.newData("Tambah Data Baru Ruangan ", namaRuangan);
                if (mTahun != 0)
                {
                    addNewData(mTahun, namaRuangan);
                    addTahunInListView();
                    //refreshRuangan();
                    indikatorUC.RefreshRuangan();
                    indikatorUC.RefreshTahunInListView();
                }
            }else
            {
                MessageBox.Show("Pilih ruangan terlebih dahulu!", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            int count = 0;
            if (AppForm.listRekapitulasi.Count > 0)
            {
                foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                {
                    count++;
                    dt.Rows.Add(count, rekap.Data, rekap.Januari, rekap.Februari, rekap.Maret, rekap.April, rekap.Mei, rekap.Juni, rekap.Juli, rekap.Agustus, rekap.September, rekap.Oktober, rekap.November, rekap.Desember, rekap.Total);
                }
            }
            MessageBox.Show("Data Table dikembalikan ke pembaruan terakhir!", "Pemberitahuan", MessageBoxButtons.OK);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Exporter.ExportToExcel(tahunSelected, namaRuangan);
        }

        private void btnEditTahun_Click(object sender, EventArgs e)
        {
            int newTahun = RekapAddDataDialog.editTahun("Edit Tahun");
            foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
            {
                SqliteDataAccess.UpdateTahunRekapitulasi(rekap.Id, tahunSelected, newTahun, namaRuangan);
            }
            foreach (Indikator indikator in AppForm.listIndikator)
            {
                SqliteDataAccess.UpdateTahunIndikator(indikator.Id, tahunSelected, newTahun, namaRuangan);
            }
            tahunSelected = newTahun;
            initDataRekapitulasiByTahun();
            MessageBox.Show("Tahun berhasil diubah!", "Pemberitahuan", MessageBoxButtons.OK);
        }

        private void RekapitulasiUserControl_Load(object sender, EventArgs e)
        {
            lblNamaUser.Text = LoginForm.userModel.Nama;
            lblUsername.Text = LoginForm.userModel.Username;
            //refreshRuangan();
        }

        /*
        private void btnTambahRuangan_Click(object sender, EventArgs e)
        {
            string ruangan = RekapAddDataDialog.newRuangan("Tambah Ruangan");
            if (ruangan != null && ruangan != "" && ruangan != " ") { 
                listView1.Items.Add("Ruangan " + ruangan);
            }else
            {
                MessageBox.Show("Nama ruangan tidak boleh kosong!", "Error", MessageBoxButtons.OK);
            }
        }
        */

        /*
                private void btnHapusRuangan_Click(object sender, EventArgs e)
                {
                    var confirmResult = MessageBox.Show("Apakah Anda yakin untuk menghapus ruangan " + namaRuangan + "?", "Konfirmasi Menghapus Ruangan", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        SqliteDataAccess.deleteRuanganInRekap(namaRuangan);
                        SqliteDataAccess.deleteRuanganInIndikator(namaRuangan);
                        refreshRuangan();
                        if (dataGridView1.Visible)
                        {
                            dataGridView1.Visible = false;
                            listViewTahun.Visible = true;
                        }
                        if (listViewTahun.Items.Count > 0)
                        {
                            listViewTahun.Items.Clear();
                        }
                    }
                }
                */
        /*
        private void btnHapusTahun_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Apakah Anda yakin untuk menghapus data tahun " + tahunSelected + " di raungan "+namaRuangan+"?", 
                "Konfirmasi Menghapus Data Tahun "+tahunSelected+" Ruangan "+namaRuangan+"", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SqliteDataAccess.deleteTahunInRekap(tahunSelected);
                SqliteDataAccess.deleteTahunInIndikator(tahunSelected);
                if (dataGridView1.Visible)
                {
                    dataGridView1.Visible = false;
                    listViewTahun.Visible = true;
                }
                if (listViewTahun.Items.Count > 0)
                {
                    listViewTahun.Items.Clear();
                    addTahunInListView();
                }
            }
        }
*/

        ////private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        ////{
        ////    newAddedRow = dataGridView1.Rows[e.Row.Index-1];
        ////    newAddedRow.Cells[0].Value = dataGridView1.Rows[newAddedRow.Index - 1].Cells[0].Value;
        ////    if (newAddedRow != null)
        ////    {
        ////        dataGridView1.Refresh();
        ////        newData = new Rekapitulasi();
        ////        newData.Id = (int)newAddedRow.Cells[0].Value;
        ////        newData.Ruangan = namaRuangan;
        ////        newData.Tahun = tahunSelected;
        ////        newData.Data = (string)newAddedRow.Cells[1].Value;
        ////        queueAddData.Enqueue(newData);
        ////    }
        ////}

    }

    public static class RekapAddDataDialog
    {
        public static int newData(string caption, string namaRuangan)
        {
            Form prompt = new Form();
            prompt.Width = 320;
            prompt.Height = 170;
            prompt.Text = caption + namaRuangan;
            prompt.StartPosition = FormStartPosition.CenterParent; 
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Tahun: ", AutoSize = true, Font = new Font("Microsoft San Serif", 15, FontStyle.Bold) };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 200,};
            Button confirmation = new Button() { Text = "Ok", Left = 140, Width = 50, Top = 80 };
            int tahun = 0;
            confirmation.Click += (sender, e) =>
            {
                tahun = Int32.Parse(inputBox.Text);
                prompt.Close();
            };
            Button cancelBox = new Button() { Text = "Cancel", Left = 200, Width = 50, Top = 80 };
            cancelBox.Click += (sender, e) =>
            {
                tahun = 0;
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(cancelBox);
            prompt.ShowDialog();
            return tahun;
        }

        public static int editTahun(string caption)
        {
            Form prompt = new Form();
            prompt.Width = 320;
            prompt.Height = 170;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterParent;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Ubah Tahun: ", AutoSize = true, Font = new Font("Microsoft San Serif", 15, FontStyle.Bold) };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 200, };
            Button confirmation = new Button() { Text = "Ok", Left = 140, Width = 50, Top = 80 };
            int tahun = 0;
            confirmation.Click += (sender, e) =>
            {
                tahun = Int32.Parse(inputBox.Text);
                prompt.Close();
            };
            Button cancelBox = new Button() { Text = "Cancel", Left = 200, Width = 50, Top = 80 };
            cancelBox.Click += (sender, e) =>
            {
                tahun = 0;
                prompt.Close();
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(cancelBox);
            prompt.ShowDialog();
            return tahun;
        }
    }

        class TahunComparer : IEqualityComparer<Rekapitulasi>
    {
        public bool Equals(Rekapitulasi x, Rekapitulasi y)
        {
            // Two items are equal if their keys are equal.
            return x.Tahun == y.Tahun;
        }

        public int GetHashCode(Rekapitulasi obj)
        {
            return obj.Tahun.GetHashCode();
        }
    }
    class RuanganComparer : IEqualityComparer<Rekapitulasi>
    {
        public bool Equals(Rekapitulasi x, Rekapitulasi y)
        {
            // Two items are equal if their keys are equal.
            return x.Ruangan == y.Ruangan;
        }

        public int GetHashCode(Rekapitulasi obj)
        {
            return obj.Ruangan.GetHashCode();
        }
    }
}