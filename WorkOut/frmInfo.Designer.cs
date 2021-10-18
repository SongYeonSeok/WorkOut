namespace WorkOut
{
    partial class frmInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnoutput = new System.Windows.Forms.Button();
            this.TbBox1 = new System.Windows.Forms.TextBox();
            this.TbBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBoxDate = new System.Windows.Forms.TextBox();
            this.tbBoxDoW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "WEIGHT : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "REPS : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnoutput
            // 
            this.btnoutput.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnoutput.Location = new System.Drawing.Point(238, 167);
            this.btnoutput.Name = "btnoutput";
            this.btnoutput.Size = new System.Drawing.Size(105, 35);
            this.btnoutput.TabIndex = 6;
            this.btnoutput.Text = "Ok";
            this.btnoutput.UseVisualStyleBackColor = true;
            this.btnoutput.Click += new System.EventHandler(this.btnoutput_Click);
            // 
            // TbBox1
            // 
            this.TbBox1.Location = new System.Drawing.Point(194, 64);
            this.TbBox1.Name = "TbBox1";
            this.TbBox1.Size = new System.Drawing.Size(93, 25);
            this.TbBox1.TabIndex = 7;
            // 
            // TbBox2
            // 
            this.TbBox2.Location = new System.Drawing.Point(194, 112);
            this.TbBox2.Name = "TbBox2";
            this.TbBox2.Size = new System.Drawing.Size(93, 25);
            this.TbBox2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date :";
            // 
            // tbBoxDate
            // 
            this.tbBoxDate.Enabled = false;
            this.tbBoxDate.Location = new System.Drawing.Point(80, 10);
            this.tbBoxDate.Name = "tbBoxDate";
            this.tbBoxDate.Size = new System.Drawing.Size(123, 25);
            this.tbBoxDate.TabIndex = 13;
            // 
            // tbBoxDoW
            // 
            this.tbBoxDoW.Enabled = false;
            this.tbBoxDoW.Location = new System.Drawing.Point(220, 10);
            this.tbBoxDoW.Name = "tbBoxDoW";
            this.tbBoxDoW.Size = new System.Drawing.Size(67, 25);
            this.tbBoxDoW.TabIndex = 14;
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 205);
            this.Controls.Add(this.tbBoxDoW);
            this.Controls.Add(this.tbBoxDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbBox2);
            this.Controls.Add(this.TbBox1);
            this.Controls.Add(this.btnoutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmInfo";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnoutput;
        public System.Windows.Forms.TextBox TbBox1;
        public System.Windows.Forms.TextBox TbBox2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbBoxDate;
        public System.Windows.Forms.TextBox tbBoxDoW;
    }
}