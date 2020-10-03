using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadSyllabus2 {
    public partial class Input_PW : Form {
        private string _PW = "";
        public Input_PW() {
            InitializeComponent();
        }

        private void cmd_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cmd_confirm_Click(object sender, EventArgs e) {
            _PW = txt_input.Text;
            this.Close();
        }

        public string GetPW {
            get {
                return _PW;
            }
        }
    }
}
