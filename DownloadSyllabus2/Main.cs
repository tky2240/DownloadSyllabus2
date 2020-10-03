using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using static DownloadSyllabus2.Globals;

namespace DownloadSyllabus2 {
    public partial class Main : Form {
        private DataGridViewComboBoxColumn WeekColumn = new DataGridViewComboBoxColumn();
        private DataGridViewComboBoxColumn TimeColumn = new DataGridViewComboBoxColumn();
        private DataGridViewComboBoxColumn SemesterColumn = new DataGridViewComboBoxColumn();
        private DataGridViewComboBoxColumn YearColumn = new DataGridViewComboBoxColumn();
        private string[] columnList = { "Semester", "Year", "ClassName", "Week", "Time", "Teacher" };
        public Main(){
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e){
            if (!Load_ini()){
                MessageBox.Show("iniの読み込みに失敗しました。");
            }

            dgv_class.DataSource = Load_csv();

            Create_Combobox_Columns();
            Set_Columns();
            Set_DataGridView();
        }

        private bool Load_ini(){
            StringBuilder lpReturnedString = new StringBuilder(1024);
            int result = 0;
            result = GetPrivateProfileString("Default", "csvPath", "", lpReturnedString, lpReturnedString.Capacity - 1, $"{Application.StartupPath}\\settings.ini");
            if (result > 0){
                csvPath = lpReturnedString.ToString().Trim();
                if (csvPath == "") {
                    lab_csvPath.Text = "無し";
                } else {
                    lab_csvPath.Text = csvPath;
                }
            } else {
                return false;
            }

            lpReturnedString = new StringBuilder(1024);
            result = GetPrivateProfileString("Default", "folderPath", "", lpReturnedString, lpReturnedString.Capacity - 1, $"{Application.StartupPath}\\settings.ini");
            if (result > 0) {
                folderPath = lpReturnedString.ToString().Trim();
                if (folderPath == "") {
                    lab_folderPath.Text = "無し";
                } else {
                    lab_folderPath.Text = folderPath;
                }
                folderPath = lpReturnedString.ToString().Trim();
            } else {
                return false;
            }
            return true;
        }

        private void Create_Combobox_Columns() {
            SetDataSource_Combobox_Columns(WeekColumn, Weeks);
            SetDataSource_Combobox_Columns(TimeColumn, Times);
            SetDataSource_Combobox_Columns(SemesterColumn, Semesters);
            SetDataSource_Combobox_Columns(YearColumn, Years);
        }

        private void SetDataSource_Combobox_Columns(DataGridViewComboBoxColumn col, Dictionary<string,string> src) {
            col.DataSource = src.ToList();
            col.DisplayMember = "value";
            col.ValueMember = "key";
            col.SortMode = DataGridViewColumnSortMode.Automatic;
            col.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            col.FlatStyle = FlatStyle.Flat;
        }

        private void Set_Columns() {
            SetDataGridView_Combobox_Columns(TimeColumn, "Time");
            SetDataGridView_Combobox_Columns(WeekColumn, "Week");
            SetDataGridView_Combobox_Columns(SemesterColumn, "Semester");
            SetDataGridView_Combobox_Columns(YearColumn, "Year");

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Name = "Show";
            col.UseColumnTextForButtonValue = true;
            col.Text = "PDF表示";
            col.FlatStyle = FlatStyle.Flat;
            dgv_class.Columns.Add(col);
        }

        private void SetDataGridView_Combobox_Columns(DataGridViewComboBoxColumn col, string name) {
            col.DataPropertyName = dgv_class.Columns[name].DataPropertyName;
            dgv_class.Columns.Insert(dgv_class.Columns[name].Index, col);
            dgv_class.Columns.Remove(name);
            col.Name = name;
        }

        private void Set_DataGridView() {
            dgv_class.Columns[0].Width = 100;
            dgv_class.Columns[1].Width = 100;
            dgv_class.Columns[2].Width = 200;
            dgv_class.Columns[3].Width = 100;
            dgv_class.Columns[4].Width = 100;
            dgv_class.Columns[5].Width = 100;
            dgv_class.Columns[6].Width = 60;
        }

        private DataTable Load_csv() {
            DataTable csvTable = new DataTable();
            csvTable.Columns.AddRange(columnList.Select(n => new DataColumn(n, typeof(string))).ToArray());
            if(csvPath == "") {
                return csvTable;
            }

            TextFieldParser parser = new TextFieldParser(csvPath);
            parser.TextFieldType = FieldType.Delimited;
            parser.Delimiters = new string[] { "," };
            parser.HasFieldsEnclosedInQuotes = true;
            parser.TrimWhiteSpace = true;
            try {
                while (!parser.EndOfData) {
                    csvTable.Rows.Add(parser.ReadFields());
                }
            } catch (MalformedLineException e) {
                MessageBox.Show($"CSV読み込みエラーです。\n{e.Message}");
                return csvTable;
            }
            parser.Close();

            return csvTable;
        }
        private void cmd_updtae_Click(object sender, EventArgs e) {
            if (CSV_Update()) {
                MessageBox.Show("CSVが更新されました。");
            } else {
                MessageBox.Show("CSVの更新に失敗しました。");
            }
        }
        private bool CSV_Update() {
            DataTable DataGridViewTable = (DataTable)dgv_class.DataSource;

            if(csvPath == "") {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = "Syllabus.csv";
                saveFile.InitialDirectory = "C:\\";
                saveFile.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
                saveFile.FilterIndex = 1;
                saveFile.Title = "csvを保存する場所を指定してください";
                saveFile.RestoreDirectory = true;
                if(saveFile.ShowDialog() == DialogResult.OK) {
                    csvPath = saveFile.FileName;
                    lab_csvPath.Text = saveFile.FileName;
                } else {
                    return false;
                }
            }
            try {
                StreamWriter writer = new StreamWriter(csvPath);
                for(int i = 0; i < DataGridViewTable.Rows.Count; i++) {
                    for(int j = 0; j < DataGridViewTable.Columns.Count; j++) {
                        if(j == DataGridViewTable.Columns.Count - 1) {
                            writer.WriteLine(DataGridViewTable.Rows[i].ItemArray[j].ToString());
                        } else {
                            writer.Write($"{DataGridViewTable.Rows[i].ItemArray[j].ToString()}, ");
                        }
                    }
                }
                writer.Close();
                if (!Write_ini()) {
                    MessageBox.Show("ini書き込みに失敗しました。");
                }
                return true;
            } catch {
                return false;
            }
        }

        private bool Write_ini() {
            int result = 0;
            string lpstring = csvPath;
            result = WritePrivateProfileString("Default", "csvPath", lpstring, $"{Application.StartupPath}\\settings.ini");
            if(result == 0) {
                return false;
            }
            lpstring = folderPath;
            result = WritePrivateProfileString("Default", "folderPath", lpstring, $"{Application.StartupPath}\\settings.ini");
            if (result == 0) {
                return false;
            }
            return true;
        }
        private void cmd_csvPath_Click(object sender, EventArgs e) {
            if (CSV_Open()) {
                dgv_class.DataSource = Load_csv();
            } else {
                MessageBox.Show("CSVの読み込みに失敗しました。");
            }
        }
        private bool CSV_Open() {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "Syllabus.csv";
            openFile.InitialDirectory = folderPath;
            openFile.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.Title = "開くCSVファイルを選択してください。";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK) {
                lab_csvPath.Text = openFile.FileName;
                csvPath = openFile.FileName;
                if (!Write_ini()) {
                    MessageBox.Show("ini書き込みに失敗しました。");
                }
                return true;
            } else {
                return false;
            }
        }
        private void cmd_NullPath_Click(object sender, EventArgs e) {
            lab_csvPath.Text = "無し";
            csvPath = "";
        }
        private void cmd_folderPath_Click(object sender, EventArgs e) {
            if (!Open_Folder()) {
                MessageBox.Show("フォルダの指定に失敗しました。");
            }
        }
        private bool Open_Folder() {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "保存するフォルダを選択してください。";
            if (folderBrowser.ShowDialog() == DialogResult.OK) {
                folderPath = folderBrowser.SelectedPath;
                lab_folderPath.Text = folderBrowser.SelectedPath;
                return true;
            } else {
                return false;
            }
        }
        private void cmd_download_Click(object sender, EventArgs e) {
            if (!CSV_Update()) {
                if (MessageBox.Show("CSVの更新に失敗しましたが作業を継続しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                    MessageBox.Show("中止しました。");
                    return;
                }
            }
            if(folderPath == "") {
                if (!Open_Folder()) {
                    MessageBox.Show("中止しました。");
                    return;
                }
            }
            ConnectSyllabus connect = new ConnectSyllabus();
            if (connect.Start_Download(Load_csv())) {
                MessageBox.Show("正常に終了しました。");
            } else {
                MessageBox.Show("正常に終了しませんでした。");
            }
        }
        private void cmd_exit_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void dgv_class_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if(dgv_class.Columns[e.ColumnIndex].Name == "Show") {
                if(e.RowIndex != dgv_class.Rows.Count - 1 && e.RowIndex != -1) {
                    try {
                        string time = Times[dgv_class.Rows[e.RowIndex].Cells["Time"].Value.ToString()];
                        if (time == "指示なし") {
                            time = "";
                        }else if(time != "その他") {
                            time = time.Substring(0, 1);
                        }
                        string week = Weeks[dgv_class.Rows[e.RowIndex].Cells["Week"].Value.ToString()];
                        if (week == "指示なし") {
                            week = "";
                        } else if (week != "その他") {
                            week = week.Substring(0, 1);
                        }
                        string classname = dgv_class.Rows[e.RowIndex].Cells["ClassName"].Value.ToString();
                        string teacher = dgv_class.Rows[e.RowIndex].Cells["Teacher"].Value.ToString();
                        string[] files = Directory.GetFiles(folderPath, "*.pdf", System.IO.SearchOption.TopDirectoryOnly);
                        foreach(string file in files) {
                            if (time == "その他" || week == "その他") {
                                if (Regex.IsMatch(Path.GetFileName(file), $"^他_.*{classname}.*_,*{teacher}.*\\.pdf")) {
                                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(file);
                                }
                            } else {
                                if (Regex.IsMatch(Path.GetFileName(file), $"^{week}{time}_.*{classname}.*_,*{teacher}.*\\.pdf")) {
                                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(file);
                                }
                            }   
                        }
                    } catch {
                    MessageBox.Show("ファイルが見つかりません。保存フォルダ内にPDFがあるか確認してください。");
                    }   
                }
            }
        }
        private void dgv_class_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e) {
            e.Row.Cells["Time"].Value = "selected";
            e.Row.Cells["Week"].Value = "selected";
            e.Row.Cells["Semester"].Value = "";
            e.Row.Cells["Year"].Value = "selected";
        }
    }
}
