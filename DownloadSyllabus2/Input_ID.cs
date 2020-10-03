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

namespace DownloadSyllabus2 {
    public partial class Input_ID : Form {
        private string _ID = "";
        public Input_ID() {
            InitializeComponent();
        }

        private void cmd_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cmd_confirm_Click(object sender, EventArgs e) {
            if (Regex.IsMatch(txt_input.Text, "^[a-z][0-9]{7}$")) {
                _ID = txt_input.Text;
                this.Close();
            } else {
                MessageBox.Show("正しい形式で入力してください。");
                DialogResult = DialogResult.None;
            }
            
        }
        public string GetID {
            get {
                return _ID;
            }
        }
    }
}
