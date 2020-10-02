namespace DownloadSyllabus2 {
    partial class Main {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_folderPath = new System.Windows.Forms.Label();
            this.cmd_folderPath = new System.Windows.Forms.Button();
            this.cmd_NullPath = new System.Windows.Forms.Button();
            this.lab_csvPath = new System.Windows.Forms.Label();
            this.cmd_csvPath = new System.Windows.Forms.Button();
            this.cmd_exit = new System.Windows.Forms.Button();
            this.cmd_download = new System.Windows.Forms.Button();
            this.cmd_updtae = new System.Windows.Forms.Button();
            this.dgv_class = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_class)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_folderPath
            // 
            this.lab_folderPath.AutoSize = true;
            this.lab_folderPath.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab_folderPath.Location = new System.Drawing.Point(812, 256);
            this.lab_folderPath.Name = "lab_folderPath";
            this.lab_folderPath.Size = new System.Drawing.Size(45, 15);
            this.lab_folderPath.TabIndex = 17;
            this.lab_folderPath.Text = "Label1";
            // 
            // cmd_folderPath
            // 
            this.cmd_folderPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_folderPath.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_folderPath.Location = new System.Drawing.Point(812, 187);
            this.cmd_folderPath.Name = "cmd_folderPath";
            this.cmd_folderPath.Size = new System.Drawing.Size(87, 46);
            this.cmd_folderPath.TabIndex = 16;
            this.cmd_folderPath.Text = "DLフォルダパス";
            this.cmd_folderPath.UseVisualStyleBackColor = true;
            // 
            // cmd_NullPath
            // 
            this.cmd_NullPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_NullPath.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_NullPath.Location = new System.Drawing.Point(905, 85);
            this.cmd_NullPath.Name = "cmd_NullPath";
            this.cmd_NullPath.Size = new System.Drawing.Size(87, 46);
            this.cmd_NullPath.TabIndex = 15;
            this.cmd_NullPath.Text = "CSVパスなし";
            this.cmd_NullPath.UseVisualStyleBackColor = true;
            // 
            // lab_csvPath
            // 
            this.lab_csvPath.AutoSize = true;
            this.lab_csvPath.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lab_csvPath.Location = new System.Drawing.Point(812, 151);
            this.lab_csvPath.Name = "lab_csvPath";
            this.lab_csvPath.Size = new System.Drawing.Size(45, 15);
            this.lab_csvPath.TabIndex = 14;
            this.lab_csvPath.Text = "Label1";
            // 
            // cmd_csvPath
            // 
            this.cmd_csvPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_csvPath.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_csvPath.Location = new System.Drawing.Point(812, 85);
            this.cmd_csvPath.Name = "cmd_csvPath";
            this.cmd_csvPath.Size = new System.Drawing.Size(87, 46);
            this.cmd_csvPath.TabIndex = 13;
            this.cmd_csvPath.Text = "CSVパス指定";
            this.cmd_csvPath.UseVisualStyleBackColor = true;
            // 
            // cmd_exit
            // 
            this.cmd_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_exit.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_exit.Location = new System.Drawing.Point(905, 392);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(86, 46);
            this.cmd_exit.TabIndex = 12;
            this.cmd_exit.Text = "終了";
            this.cmd_exit.UseVisualStyleBackColor = true;
            // 
            // cmd_download
            // 
            this.cmd_download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_download.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_download.Location = new System.Drawing.Point(812, 392);
            this.cmd_download.Name = "cmd_download";
            this.cmd_download.Size = new System.Drawing.Size(87, 46);
            this.cmd_download.TabIndex = 11;
            this.cmd_download.Text = "DL開始";
            this.cmd_download.UseVisualStyleBackColor = true;
            // 
            // cmd_updtae
            // 
            this.cmd_updtae.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_updtae.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmd_updtae.Location = new System.Drawing.Point(812, 12);
            this.cmd_updtae.Name = "cmd_updtae";
            this.cmd_updtae.Size = new System.Drawing.Size(87, 46);
            this.cmd_updtae.TabIndex = 10;
            this.cmd_updtae.Text = "CSV更新";
            this.cmd_updtae.UseVisualStyleBackColor = true;
            // 
            // dgv_class
            // 
            this.dgv_class.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_class.Location = new System.Drawing.Point(3, 12);
            this.dgv_class.Name = "dgv_class";
            this.dgv_class.RowTemplate.Height = 21;
            this.dgv_class.Size = new System.Drawing.Size(803, 426);
            this.dgv_class.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 450);
            this.Controls.Add(this.lab_folderPath);
            this.Controls.Add(this.cmd_folderPath);
            this.Controls.Add(this.cmd_NullPath);
            this.Controls.Add(this.lab_csvPath);
            this.Controls.Add(this.cmd_csvPath);
            this.Controls.Add(this.cmd_exit);
            this.Controls.Add(this.cmd_download);
            this.Controls.Add(this.cmd_updtae);
            this.Controls.Add(this.dgv_class);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_class)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lab_folderPath;
        internal System.Windows.Forms.Button cmd_folderPath;
        internal System.Windows.Forms.Button cmd_NullPath;
        internal System.Windows.Forms.Label lab_csvPath;
        internal System.Windows.Forms.Button cmd_csvPath;
        internal System.Windows.Forms.Button cmd_exit;
        internal System.Windows.Forms.Button cmd_download;
        internal System.Windows.Forms.Button cmd_updtae;
        internal System.Windows.Forms.DataGridView dgv_class;
    }
}

