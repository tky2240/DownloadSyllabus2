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
    public partial class Progress : Form {
        public Progress() {
            InitializeComponent();
        }

        private void Progress_Load(object sender, EventArgs e) {
            lab_Progress.Text = "";
            prg_Progress.Value = 0;
        }

        public string Set_Text {
            set {
                lab_Progress.Text = value;
                lab_Progress.Update();
            }
            get {
                return lab_Progress.Text;
            }
        }

        public int Set_Max {
            set {
                prg_Progress.Maximum = value;
            }
            get {
                return prg_Progress.Maximum;
            }
        }

        public void Add_ProgressBar(int add = 1) {
            prg_Progress.Value += add;
        }

        public void Quit() {
            this.Close();
        }
    }
}
