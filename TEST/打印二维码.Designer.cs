﻿namespace TEST
{
    partial class 打印二维码
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(打印二维码));
            this.wbv = new SpreadsheetGear.Windows.Forms.WorkbookView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbv
            // 
            this.wbv.Location = new System.Drawing.Point(12, 12);
            this.wbv.Name = "wbv";
            this.wbv.Size = new System.Drawing.Size(704, 500);
            this.wbv.TabIndex = 0;
            this.wbv.WorkbookSetState = resources.GetString("wbv.WorkbookSetState");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(747, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 打印二维码
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 588);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wbv);
            this.Name = "打印二维码";
            this.Text = "打印二维码";
            this.ResumeLayout(false);

        }

        #endregion

        private SpreadsheetGear.Windows.Forms.WorkbookView wbv;
        private System.Windows.Forms.Button button1;

    }
}