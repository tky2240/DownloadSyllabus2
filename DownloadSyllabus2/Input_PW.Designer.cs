namespace DownloadSyllabus2 {
    partial class Input_PW {
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
            this.cmd_cancel = new System.Windows.Forms.Button();
            this.cmd_confirm = new System.Windows.Forms.Button();
            this.lab_caption = new System.Windows.Forms.Label();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmd_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_cancel.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_cancel.Location = new System.Drawing.Point(133, 80);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.Size = new System.Drawing.Size(78, 34);
            this.cmd_cancel.TabIndex = 11;
            this.cmd_cancel.Text = "キャンセル";
            this.cmd_cancel.UseVisualStyleBackColor = true;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_cancel_Click);
            // 
            // cmd_confirm
            // 
            this.cmd_confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmd_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_confirm.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_confirm.Location = new System.Drawing.Point(16, 80);
            this.cmd_confirm.Name = "cmd_confirm";
            this.cmd_confirm.Size = new System.Drawing.Size(78, 34);
            this.cmd_confirm.TabIndex = 10;
            this.cmd_confirm.Text = "完了";
            this.cmd_confirm.UseVisualStyleBackColor = true;
            this.cmd_confirm.Click += new System.EventHandler(this.cmd_confirm_Click);
            // 
            // lab_caption
            // 
            this.lab_caption.AutoSize = true;
            this.lab_caption.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab_caption.Location = new System.Drawing.Point(12, 9);
            this.lab_caption.Name = "lab_caption";
            this.lab_caption.Size = new System.Drawing.Size(173, 19);
            this.lab_caption.TabIndex = 9;
            this.lab_caption.Text = "パスワードを入力してください";
            // 
            // txt_input
            // 
            this.txt_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_input.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_input.Location = new System.Drawing.Point(16, 43);
            this.txt_input.Name = "txt_input";
            this.txt_input.PasswordChar = '*';
            this.txt_input.Size = new System.Drawing.Size(195, 27);
            this.txt_input.TabIndex = 8;
            // 
            // Input_PW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 126);
            this.Controls.Add(this.cmd_cancel);
            this.Controls.Add(this.cmd_confirm);
            this.Controls.Add(this.lab_caption);
            this.Controls.Add(this.txt_input);
            this.Name = "Input_PW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input_PW";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmd_cancel;
        internal System.Windows.Forms.Button cmd_confirm;
        internal System.Windows.Forms.Label lab_caption;
        internal System.Windows.Forms.TextBox txt_input;
    }
}