using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DownloadSyllabus2 {
    public static class Globals {

        public static Dictionary<string, string> Weeks = new Dictionary<string, string>{
            [""] = "指示なし",
            ["1"] = "月曜日",
            ["2"] = "火曜日",
            ["3"] = "水曜日",
            ["4"] = "木曜日",
            ["5"] = "金曜日",
            ["6"] = "土曜日",
            ["9"] = "その他",
        };

        public static Dictionary<string, string> Times = new Dictionary<string, string>
        {
            [""] = "指示なし",
            ["1"] = "1限",
            ["2"] = "2限",
            ["3"] = "3限",
            ["4"] = "4限",
            ["5"] = "5限",
            ["6"] = "6限",
            ["7"] = "7限",
            ["0"] = "その他",
        };

        public static Dictionary<string, string> Semesters = new Dictionary<string, string>
        {
            [""] = "指示なし",
            ["1"] = "前学期",
            ["2"] = "後学期",
        };

        public static Dictionary<string, string> Years = new Dictionary<string, string>
        {
            [""] = "指示なし",
            ["1"] = "1年",
            ["2"] = "2年",
            ["3"] = "3年",
            ["4"] = "4年",
            ["5"] = "5年",
            ["6"] = "6年",
        };

        public static string[] WeekName = new string[Weeks.Keys.Count];
        public static string[] WeekValue = new string[Weeks.Values.Count];
        public static string[] TimeName = new string[Times.Keys.Count];
        public static string[] TimeValue = new string[Times.Values.Count];
        public static string[] SemesterName = new string[Semesters.Keys.Count];
        public static string[] SemesterValue = new string[Semesters.Values.Count];
        public static string[] YearName = new string[Years.Keys.Count];
        public static string[] YearValue = new string[Years.Values.Count];

        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(
        string lpApplicationName,
        string lpKeyName,
        string lpDefault,
        StringBuilder lpReturnedstring,
        int nSize,
        string lpFileName);

        [DllImport("kernel32.dll")]
        public static extern int WritePrivateProfileString(
        string lpApplicationName,
        string lpKeyName,
        string lpstring,
        string lpFileName);

        public static string csvPath = "";
        public static string folderPath = "";
    }
}