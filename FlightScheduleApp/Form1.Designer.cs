namespace FlightScheduleApp
{
    partial class Form1
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
            this.dgfOpenTxt = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.bntClose = new System.Windows.Forms.Button();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dgfOpenTxt
            // 
            this.dgfOpenTxt.FileName = "Schedule";
            this.dgfOpenTxt.Filter = "All files(*.*)|*.*|Text files(*.txt)|*.txt";
            this.dgfOpenTxt.FilterIndex = 2;
            this.dgfOpenTxt.InitialDirectory = "C:\\Users\\vicgr\\source\\repos\\FlightScheduleApp\\FlightScheduleApp";
            this.dgfOpenTxt.RestoreDirectory = true;
            this.dgfOpenTxt.Title = "Schedule Files";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(63, 103);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // bntClose
            // 
            this.bntClose.Location = new System.Drawing.Point(159, 102);
            this.bntClose.Name = "bntClose";
            this.bntClose.Size = new System.Drawing.Size(75, 23);
            this.bntClose.TabIndex = 1;
            this.bntClose.Text = "Close";
            this.bntClose.UseVisualStyleBackColor = true;
            this.bntClose.Click += new System.EventHandler(this.BntClose_Click);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(159, 25);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(151, 20);
            this.dtpBegin.TabIndex = 2;
            this.dtpBegin.Value = new System.DateTime(2020, 4, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Begin schedule";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End schedulee";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(159, 61);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 20);
            this.dtpEnd.TabIndex = 4;
            this.dtpEnd.Value = new System.DateTime(2021, 3, 31, 23, 59, 0, 0);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpBegin);
            this.Controls.Add(this.bntClose);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "schedule Writer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dgfOpenTxt;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button bntClose;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
    }
}

