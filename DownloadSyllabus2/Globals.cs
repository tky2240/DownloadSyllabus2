using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DownloadSyllabus2 {
    public static class Globals {

        public static Dictionary<string, string> Weeks = new Dictionary<string, string>{
            ["指示なし"] = "selected",
            ["月曜日"] = "1",
            ["火曜日"] = "2",
            ["水曜日"] = "3",
            ["木曜日"] = "4",
            ["金曜日"] = "5",
            ["土曜日"] = "6",
            ["その他"] = "9",
        };

        public static Dictionary<string, string> Times = new Dictionary<string, string>
        {
            ["指示なし"] = "selected",
            ["1限"] = "1",
            ["2限"] = "2",
            ["3限"] = "3",
            ["4限"] = "4",
            ["5限"] = "5",
            ["6限"] = "6",
            ["7限"] = "7",
            ["その他"] = "0",
        };

        public static Dictionary<string, string> Semesters = new Dictionary<string, string>
        {
            ["指示なし"] = "",
            ["前学期"] = "1",
            ["後学期"] = "2",
        };

        public static Dictionary<string, string> Years = new Dictionary<string, string>
        {
            ["指示なし"] = "selected",
            ["1年"] = "1",
            ["2年"] = "2",
            ["3年"] = "3",
            ["4年"] = "4",
            ["5年"] = "5",
            ["6年"] = "6",
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