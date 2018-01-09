namespace Quge.AuctionDataExport.Winform
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSelectExportPath = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.lblStateStr = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// btnSelectExportPath
			// 
			this.btnSelectExportPath.Location = new System.Drawing.Point(84, 147);
			this.btnSelectExportPath.Name = "btnSelectExportPath";
			this.btnSelectExportPath.Size = new System.Drawing.Size(105, 23);
			this.btnSelectExportPath.TabIndex = 2;
			this.btnSelectExportPath.Text = "导出并保存";
			this.btnSelectExportPath.UseVisualStyleBackColor = true;
			this.btnSelectExportPath.Click += new System.EventHandler(this.btnSelectExportPath_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(62, 230);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "导出状态：";
			// 
			// lblStateStr
			// 
			this.lblStateStr.AutoSize = true;
			this.lblStateStr.Location = new System.Drawing.Point(133, 230);
			this.lblStateStr.Name = "lblStateStr";
			this.lblStateStr.Size = new System.Drawing.Size(41, 12);
			this.lblStateStr.TabIndex = 4;
			this.lblStateStr.Text = "label3";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 309);
			this.Controls.Add(this.lblStateStr);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSelectExportPath);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "竞拍项目数据导出";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnSelectExportPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblStateStr;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}

