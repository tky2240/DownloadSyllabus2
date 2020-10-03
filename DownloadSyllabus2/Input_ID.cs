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
    public partial class Input_ID : Form {
        private string _ID = "";
        public Input_ID() {
            InitializeComponent();
        }

        private void cmd_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cmd_confirm_Click(object sender, EventArgs e) {
            _ID = txt_input.Text;
            this.Close();
        }
        public string GetID {
            get {
                return _ID;
            }
        }
    }
}
