using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Project_Rekap_Pasien
{
    public static class Exporter
    {
        static DataTable dtRekap;
        static DataTable dtIndi;

        static void initInputDataTable(int date, string ruangan)
        {
            AppForm.listRekapitulasi = SqliteDataAccess.getAllRekapitulasiDataOfRuanganTahun(ruangan, date);
            AppForm.listIndikator = SqliteDataAccess.getAllIndikatorDataOfRuanganTahun(ruangan, date);

            dtRekap = new DataTable();
            dtRekap.Columns.Add("no", typeof(int));
            dtRekap.Columns.Add("data", typeof(string));
            dtRekap.Columns.Add("januari", typeof(int));
            dtRekap.Columns.Add("februari", typeof(int));
            dtRekap.Columns.Add("maret", typeof(int));
            dtRekap.Columns.Add("april", typeof(int));
            dtRekap.Columns.Add("mei", typeof(int));
            dtRekap.Columns.Add("juni", typeof(int));
            dtRekap.Columns.Add("juli", typeof(int));
            dtRekap.Columns.Add("agustus", typeof(int));
            dtRekap.Columns.Add("september", typeof(int));
            dtRekap.Columns.Add("oktober", typeof(int));
            dtRekap.Columns.Add("november", typeof(int));
            dtRekap.Columns.Add("desember", typeof(int));
            dtRekap.Columns.Add("total", typeof(int));
            int count = 0;
            if (AppForm.listRekapitulasi.Count > 0)
            {
                foreach (Rekapitulasi rekap in AppForm.listRekapitulasi)
                {
                    count++;
                    dtRekap.Rows.Add(count, rekap.Data, rekap.Januari, rekap.Februari, rekap.Maret, rekap.April, rekap.Mei, rekap.Juni, rekap.Juli, rekap.Agustus, rekap.September, rekap.Oktober, rekap.November, rekap.Desember, rekap.Total);
                }
            }

            dtIndi = new DataTable();
            dtIndi.Columns.Add("no", typeof(int));
            dtIndi.Columns.Add("indikator", typeof(string));
            dtIndi.Columns.Add("januari", typeof(float));
            dtIndi.Columns.Add("februari", typeof(float));
            dtIndi.Columns.Add("maret", typeof(float));
            dtIndi.Columns.Add("april", typeof(float));
            dtIndi.Columns.Add("mei", typeof(float));
            dtIndi.Columns.Add("juni", typeof(float));
            dtIndi.Columns.Add("juli", typeof(float));
            dtIndi.Columns.Add("agustus", typeof(float));
            dtIndi.Columns.Add("september", typeof(float));
            dtIndi.Columns.Add("oktober", typeof(float));
            dtIndi.Columns.Add("november", typeof(float));
            dtIndi.Columns.Add("desember", typeof(float));
            dtIndi.Columns.Add("total", typeof(float));
            if (AppForm.listIndikator.Count > 0)
            {
                foreach (Indikator ind in AppForm.listIndikator)
                    dtIndi.Rows.Add(ind.Id, ind.Data, ind.Januari, ind.Februari, ind.Maret, ind.April, ind.Mei, ind.Juni, ind.Juli, ind.Agustus, ind.September, ind.Oktober, ind.November, ind.Desember, ind.Total);
            }
        }

        public static void ExportToExcel(int date, string ruangan)
        {
            initInputDataTable(date, ruangan);
            FolderBrowserDialog folderFD = new FolderBrowserDialog();
            Excel.Application exl;
            Excel.Workbook exlWorkBook;
            Excel.Worksheet exlSheet;
            Excel.Range exlRange;

            string sheetName = "Rekapitulasi_" + ruangan + "_" + date.ToString();
            string filename;

            folderFD.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folderFD.ShowNewFolderButton = true;

            if (folderFD.ShowDialog() == DialogResult.OK)
            {
                exl = new Microsoft.Office.Interop.Excel.Application();
                exl.Visible = false;
                exl.DisplayAlerts = false;
                exlWorkBook = exl.Workbooks.Add(Type.Missing);
                exlSheet = (Excel.Worksheet)exlWorkBook.ActiveSheet;
                exlSheet.Name = sheetName;

                int rowCount = 1;

                exlSheet.Cells[1, 1] = "Data Rekapitulasi " + ruangan;
                exlSheet.Cells[1, 2] = "Tahun: " + date;
                rowCount++;
                for (int i = 0; i < dtRekap.Columns.Count; i++)
                {
                    exlSheet.Cells[rowCount, i+3] = dtRekap.Columns[i].ColumnName;
                }
                rowCount++;
                for (int j = 0; j < dtRekap.Rows.Count; j++)
                {
                    for (int k = 0; k < dtRekap.Columns.Count; k++)
                    {
                        exlSheet.Cells[rowCount, k + 3] = dtRekap.Rows[j].ItemArray[k].ToString();
                    }
                    rowCount++;
                }

                exlSheet.Cells[rowCount + 1, 1] = "Data Indikator";
                rowCount+=2;
                for (int i = 0; i < dtIndi.Columns.Count; i++)
                {
                    exlSheet.Cells[rowCount, i + 3] = dtIndi.Columns[i].ColumnName;
                }
                rowCount++;
                for (int j = 0; j < dtIndi.Rows.Count; j++)
                {
                    for (int k = 0; k < dtIndi.Columns.Count; k++)
                    {
                        exlSheet.Cells[rowCount, k + 3] = dtIndi.Rows[j].ItemArray[k].ToString();
                    }
                    rowCount++;
                }

                exlRange = exlSheet.Range[exlSheet.Cells[2, 1], exlSheet.Cells[rowCount, dtRekap.Columns.Count]];
                exlRange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = exlRange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                filename = folderFD.SelectedPath + @"\Rekapitulasi_" + ruangan + "_" + date;
                exlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing,
               Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
               Excel.XlSaveConflictResolution.xlUserResolution, true,
               Type.Missing, Type.Missing, Type.Missing);
                exlWorkBook.Close();
                exl.Quit();
                MessageBox.Show("Table telah diekspor ke Excel!", "Export to Excel", MessageBoxButtons.OK);
            }
        }

        public static void ExportChartToWord(Chart chart)
        {
            Font chtFont = new System.Drawing.Font("Trebuchet MS", 35F, System.Drawing.FontStyle.Bold);
            Font smallFont = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold);
            Chart newChart = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend = new Legend();
            
            newChart.Width = 3000;
            newChart.Height = 1500;

            newChart.ChartAreas.Add(chartArea1);
            newChart.Dock = DockStyle.Fill;
            newChart.Legends.Add(legend);
            var chartA = newChart.ChartAreas[0];
            chartA.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            chartA.AxisX.MajorGrid.LineColor = Color.Gray;
            chartA.AxisY.MajorGrid.LineColor = Color.Gray;

            chartA.AxisY.LabelStyle.Format = "";
            chartA.AxisX.LabelStyle.Format = "";
            chartA.AxisX.LabelStyle.IsEndLabelVisible = true;

            chartA.AxisX.Minimum = 0;
            chartA.AxisY.Minimum = 0;

            chartA.AxisX.Maximum = 20;
            chartA.AxisY.Maximum = 20;

            chartA.AxisY.ScaleView.Zoom(0, 20);

            chartA.AxisY.LineWidth = 3;
            chartA.AxisY.MajorGrid.LineWidth = 3;
            chartA.AxisY.MajorTickMark.LineWidth = 3;
            chartA.AxisX.LabelStyle.Font = smallFont;

            chartA.AxisX.LineWidth = 3;
            chartA.AxisX.MajorGrid.LineWidth = 3;
            chartA.AxisX.MajorTickMark.LineWidth = 3;
            chartA.AxisY.LabelStyle.Font = smallFont;

            chartA.AxisX.Interval = 1;
            chartA.AxisY.Interval = 1;

            if (newChart.Legends.Count > 0)
            {
                newChart.Legends[0].Font = chtFont;
            }

            foreach (Series series in chart.Series)
            {
                newChart.Series.Add(series);
            }

            foreach(Series series in newChart.Series)
            {
                series.BorderWidth = 8;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".png";
            save.Filter = "PNG | .png";
            if (save.ShowDialog() == DialogResult.OK)
            {
                newChart.SaveImage(save.FileName, ChartImageFormat.Png);
                foreach (Series series in newChart.Series)
                {
                    series.BorderWidth = 2;
                }
            }
        }
    }
}

/*
        public static void ExportToExcel(this DataTable dataTable, String filePath, bool overwiteFile = true)
        {
            var conn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=Yes;IMEX=0';";
            using (OleDbConnection connection = new OleDbConnection(conn))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;

                    List<String> columnNames = new List<string>();
                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        columnNames.Add(dataColumn.ColumnName);
                    }

                    String tableName = !String.IsNullOrWhiteSpace(dataTable.TableName) ? dataTable.TableName : Guid.NewGuid().ToString();
                    command.CommandText = $"CREATE TABLE [{tableName}] ({String.Join(",", columnNames.Select(c => $"[{c}] VARCHAR").ToArray())});";
                    command.ExecuteNonQuery();


                    foreach (DataRow row in dataTable.Rows)
                    {
                        List<String> rowValues = new List<string>();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            rowValues.Add((row[column] != null && row[column] != DBNull.Value) ? row[column].ToString() : String.Empty);
                        }
                        command.CommandText = $"INSERT INTO [{tableName}]({String.Join(",", columnNames.Select(c => $"[{c}]"))}) VALUES ({String.Join(",", rowValues.Select(r => $"'{r}'").ToArray())});";
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }*/
