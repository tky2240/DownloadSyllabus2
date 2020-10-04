namespace DownloadSyllabus2 {
    partial class Progress {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.prg_Progress = new System.Windows.Forms.ProgressBar();
            this.lab_Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prg_Progress
            // 
            this.prg_Progress.Location = new System.Drawing.Point(12, 32);
            this.prg_Progress.Name = "prg_Progress";
            this.prg_Progress.Size = new System.Drawing.Size(447, 32);
            this.prg_Progress.TabIndex = 0;
            // 
            // lab_Progress
            // 
            this.lab_Progress.AutoSize = true;
            this.lab_Progress.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab_Progress.Location = new System.Drawing.Point(10, 9);
            this.lab_Progress.Name = "lab_Progress";
            this.lab_Progress.Size = new System.Drawing.Size(111, 20);
            this.lab_Progress.TabIndex = 1;
            this.lab_Progress.Text = "lab_Progress";
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 78);
            this.ControlBox = false;
            this.Controls.Add(this.lab_Progress);
            this.Controls.Add(this.prg_Progress);
            this.Name = "Progress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.Progress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prg_Progress;
        private System.Windows.Forms.Label lab_Progress;
    }
}