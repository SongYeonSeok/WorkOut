namespace WorkOut
{
    partial class form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.shoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shoulderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSohp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSarere = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRearDelt = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOhp = new System.Windows.Forms.ToolStripMenuItem();
            this.legsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSquat = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLegExtention = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLegCurl = new System.Windows.Forms.ToolStripMenuItem();
            this.bicepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDumbelCurl = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBarbelCurl = new System.Windows.Forms.ToolStripMenuItem();
            this.chestBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBenchpress = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDumbelpress = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuInclinebenchpress = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDips = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuFly = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuPullUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRatpulldown = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnudumbelrow = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuRow = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuDeadlift = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuBarbelrow = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuArmpulldown = new System.Windows.Forms.ToolStripMenuItem();
            this.tricepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuCablepushdown = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dbGrid = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shoToolStripMenuItem,
            this.chestBackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // shoToolStripMenuItem
            // 
            this.shoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shoulderToolStripMenuItem,
            this.legsToolStripMenuItem,
            this.bicepsToolStripMenuItem});
            this.shoToolStripMenuItem.Name = "shoToolStripMenuItem";
            this.shoToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.shoToolStripMenuItem.Text = "Shoulder/Legs";
            // 
            // shoulderToolStripMenuItem
            // 
            this.shoulderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSohp,
            this.MnuSarere,
            this.MnuRearDelt,
            this.MnuOhp});
            this.shoulderToolStripMenuItem.Name = "shoulderToolStripMenuItem";
            this.shoulderToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.shoulderToolStripMenuItem.Text = "Shoulder";
            // 
            // MnuSohp
            // 
            this.MnuSohp.Name = "MnuSohp";
            this.MnuSohp.Size = new System.Drawing.Size(123, 22);
            this.MnuSohp.Text = "S_Ohp";
            this.MnuSohp.Click += new System.EventHandler(this.MnuSohp_Click);
            // 
            // MnuSarere
            // 
            this.MnuSarere.Name = "MnuSarere";
            this.MnuSarere.Size = new System.Drawing.Size(123, 22);
            this.MnuSarere.Text = "Sarere";
            this.MnuSarere.Click += new System.EventHandler(this.MnuSarere_Click);
            // 
            // MnuRearDelt
            // 
            this.MnuRearDelt.Name = "MnuRearDelt";
            this.MnuRearDelt.Size = new System.Drawing.Size(123, 22);
            this.MnuRearDelt.Text = "Rear Delt";
            this.MnuRearDelt.Click += new System.EventHandler(this.MnuRearDelt_Click);
            // 
            // MnuOhp
            // 
            this.MnuOhp.Name = "MnuOhp";
            this.MnuOhp.Size = new System.Drawing.Size(123, 22);
            this.MnuOhp.Text = "Ohp";
            this.MnuOhp.Click += new System.EventHandler(this.MnuOhp_Click);
            // 
            // legsToolStripMenuItem
            // 
            this.legsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSquat,
            this.MnuLegExtention,
            this.MnuLegCurl});
            this.legsToolStripMenuItem.Name = "legsToolStripMenuItem";
            this.legsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.legsToolStripMenuItem.Text = "Legs";
            // 
            // MnuSquat
            // 
            this.MnuSquat.Name = "MnuSquat";
            this.MnuSquat.Size = new System.Drawing.Size(147, 22);
            this.MnuSquat.Text = "Squat";
            this.MnuSquat.Click += new System.EventHandler(this.MnuSquat_Click);
            // 
            // MnuLegExtention
            // 
            this.MnuLegExtention.Name = "MnuLegExtention";
            this.MnuLegExtention.Size = new System.Drawing.Size(147, 22);
            this.MnuLegExtention.Text = "Leg Extention";
            this.MnuLegExtention.Click += new System.EventHandler(this.MnuLegExtention_Click);
            // 
            // MnuLegCurl
            // 
            this.MnuLegCurl.Name = "MnuLegCurl";
            this.MnuLegCurl.Size = new System.Drawing.Size(147, 22);
            this.MnuLegCurl.Text = "Leg Curl";
            this.MnuLegCurl.Click += new System.EventHandler(this.MnuLegCurl_Click);
            // 
            // bicepsToolStripMenuItem
            // 
            this.bicepsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuDumbelCurl,
            this.MnuBarbelCurl});
            this.bicepsToolStripMenuItem.Name = "bicepsToolStripMenuItem";
            this.bicepsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.bicepsToolStripMenuItem.Text = "Biceps";
            this.bicepsToolStripMenuItem.Click += new System.EventHandler(this.bicepsToolStripMenuItem_Click);
            // 
            // MnuDumbelCurl
            // 
            this.MnuDumbelCurl.Name = "MnuDumbelCurl";
            this.MnuDumbelCurl.Size = new System.Drawing.Size(143, 22);
            this.MnuDumbelCurl.Text = "Dumbel Curl";
            this.MnuDumbelCurl.Click += new System.EventHandler(this.MnuDumbelCurl_Click);
            // 
            // MnuBarbelCurl
            // 
            this.MnuBarbelCurl.Name = "MnuBarbelCurl";
            this.MnuBarbelCurl.Size = new System.Drawing.Size(143, 22);
            this.MnuBarbelCurl.Text = "Barbel Curl";
            this.MnuBarbelCurl.Click += new System.EventHandler(this.MnuBarbelCurl_Click);
            // 
            // chestBackToolStripMenuItem
            // 
            this.chestBackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chestToolStripMenuItem,
            this.backToolStripMenuItem,
            this.tricepsToolStripMenuItem});
            this.chestBackToolStripMenuItem.Name = "chestBackToolStripMenuItem";
            this.chestBackToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.chestBackToolStripMenuItem.Text = "Chest/Back";
            // 
            // chestToolStripMenuItem
            // 
            this.chestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuBenchpress,
            this.MnuDumbelpress,
            this.MnuInclinebenchpress,
            this.MnuDips,
            this.MnuFly});
            this.chestToolStripMenuItem.Name = "chestToolStripMenuItem";
            this.chestToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.chestToolStripMenuItem.Text = "Chest";
            // 
            // MnuBenchpress
            // 
            this.MnuBenchpress.Name = "MnuBenchpress";
            this.MnuBenchpress.Size = new System.Drawing.Size(177, 22);
            this.MnuBenchpress.Text = "Bench Press";
            this.MnuBenchpress.Click += new System.EventHandler(this.MnuBenchpress_Click);
            // 
            // MnuDumbelpress
            // 
            this.MnuDumbelpress.Name = "MnuDumbelpress";
            this.MnuDumbelpress.Size = new System.Drawing.Size(177, 22);
            this.MnuDumbelpress.Text = "Dumbel Press";
            this.MnuDumbelpress.Click += new System.EventHandler(this.MnuDumbelpress_Click);
            // 
            // MnuInclinebenchpress
            // 
            this.MnuInclinebenchpress.Name = "MnuInclinebenchpress";
            this.MnuInclinebenchpress.Size = new System.Drawing.Size(177, 22);
            this.MnuInclinebenchpress.Text = "Incline Bench Press";
            this.MnuInclinebenchpress.Click += new System.EventHandler(this.MnuInclinebenchpress_Click);
            // 
            // MnuDips
            // 
            this.MnuDips.Name = "MnuDips";
            this.MnuDips.Size = new System.Drawing.Size(177, 22);
            this.MnuDips.Text = "Dips";
            this.MnuDips.Click += new System.EventHandler(this.MnuDips_Click);
            // 
            // MnuFly
            // 
            this.MnuFly.Name = "MnuFly";
            this.MnuFly.Size = new System.Drawing.Size(177, 22);
            this.MnuFly.Text = "Fly";
            this.MnuFly.Click += new System.EventHandler(this.MnuFly_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuPullUp,
            this.MnuRatpulldown,
            this.Mnudumbelrow,
            this.MnuRow,
            this.MnuDeadlift,
            this.MnuBarbelrow,
            this.MnuArmpulldown});
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.backToolStripMenuItem.Text = "Back";
            // 
            // MnuPullUp
            // 
            this.MnuPullUp.Name = "MnuPullUp";
            this.MnuPullUp.Size = new System.Drawing.Size(166, 22);
            this.MnuPullUp.Text = "Pull Up";
            this.MnuPullUp.Click += new System.EventHandler(this.MnuPullUp_Click);
            // 
            // MnuRatpulldown
            // 
            this.MnuRatpulldown.Name = "MnuRatpulldown";
            this.MnuRatpulldown.Size = new System.Drawing.Size(166, 22);
            this.MnuRatpulldown.Text = "Rat Pull Down";
            this.MnuRatpulldown.Click += new System.EventHandler(this.MnuRatpulldown_Click);
            // 
            // Mnudumbelrow
            // 
            this.Mnudumbelrow.Name = "Mnudumbelrow";
            this.Mnudumbelrow.Size = new System.Drawing.Size(166, 22);
            this.Mnudumbelrow.Text = "OA_Dumbel Row";
            this.Mnudumbelrow.Click += new System.EventHandler(this.Mnudumbelrow_Click);
            // 
            // MnuRow
            // 
            this.MnuRow.Name = "MnuRow";
            this.MnuRow.Size = new System.Drawing.Size(166, 22);
            this.MnuRow.Text = "Row";
            this.MnuRow.Click += new System.EventHandler(this.MnuRow_Click);
            // 
            // MnuDeadlift
            // 
            this.MnuDeadlift.Name = "MnuDeadlift";
            this.MnuDeadlift.Size = new System.Drawing.Size(166, 22);
            this.MnuDeadlift.Text = "Deadlift";
            this.MnuDeadlift.Click += new System.EventHandler(this.MnuDeadlift_Click);
            // 
            // MnuBarbelrow
            // 
            this.MnuBarbelrow.Name = "MnuBarbelrow";
            this.MnuBarbelrow.Size = new System.Drawing.Size(166, 22);
            this.MnuBarbelrow.Text = "Barbel Row";
            this.MnuBarbelrow.Click += new System.EventHandler(this.MnuBarbelrow_Click);
            // 
            // MnuArmpulldown
            // 
            this.MnuArmpulldown.Name = "MnuArmpulldown";
            this.MnuArmpulldown.Size = new System.Drawing.Size(166, 22);
            this.MnuArmpulldown.Text = "Arm Pull Down";
            this.MnuArmpulldown.Click += new System.EventHandler(this.MnuArmpulldown_Click);
            // 
            // tricepsToolStripMenuItem
            // 
            this.tricepsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuCablepushdown});
            this.tricepsToolStripMenuItem.Name = "tricepsToolStripMenuItem";
            this.tricepsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.tricepsToolStripMenuItem.Text = "Triceps";
            // 
            // MnuCablepushdown
            // 
            this.MnuCablepushdown.Name = "MnuCablepushdown";
            this.MnuCablepushdown.Size = new System.Drawing.Size(170, 22);
            this.MnuCablepushdown.Text = "Cable Push Down";
            this.MnuCablepushdown.Click += new System.EventHandler(this.MnuCablepushdown_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dbGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbChat);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(652, 464);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 3;
            // 
            // dbGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dbGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dbGrid.Location = new System.Drawing.Point(1, 1);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dbGrid.RowTemplate.Height = 23;
            this.dbGrid.Size = new System.Drawing.Size(647, 264);
            this.dbGrid.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(417, 185);
            this.textBox1.TabIndex = 1;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Location = new System.Drawing.Point(432, 3);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(217, 21);
            this.DateTimePicker1.TabIndex = 5;
            this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // tbChat
            // 
            this.tbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChat.Location = new System.Drawing.Point(419, 2);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChat.Size = new System.Drawing.Size(229, 185);
            this.tbChat.TabIndex = 2;
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 488);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "form1";
            this.Text = "WorkOut";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_FormClosing);
            this.Load += new System.EventHandler(this.form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem shoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shoulderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuSohp;
        private System.Windows.Forms.ToolStripMenuItem MnuSarere;
        private System.Windows.Forms.ToolStripMenuItem MnuRearDelt;
        private System.Windows.Forms.ToolStripMenuItem MnuOhp;
        private System.Windows.Forms.ToolStripMenuItem legsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuSquat;
        private System.Windows.Forms.ToolStripMenuItem MnuLegExtention;
        private System.Windows.Forms.ToolStripMenuItem MnuLegCurl;
        private System.Windows.Forms.ToolStripMenuItem bicepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuDumbelCurl;
        private System.Windows.Forms.ToolStripMenuItem MnuBarbelCurl;
        private System.Windows.Forms.ToolStripMenuItem chestBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuBenchpress;
        private System.Windows.Forms.ToolStripMenuItem MnuDumbelpress;
        private System.Windows.Forms.ToolStripMenuItem MnuInclinebenchpress;
        private System.Windows.Forms.ToolStripMenuItem MnuDips;
        private System.Windows.Forms.ToolStripMenuItem MnuFly;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuPullUp;
        private System.Windows.Forms.ToolStripMenuItem MnuRatpulldown;
        private System.Windows.Forms.ToolStripMenuItem Mnudumbelrow;
        private System.Windows.Forms.ToolStripMenuItem MnuRow;
        private System.Windows.Forms.ToolStripMenuItem MnuDeadlift;
        private System.Windows.Forms.ToolStripMenuItem MnuBarbelrow;
        private System.Windows.Forms.ToolStripMenuItem MnuArmpulldown;
        private System.Windows.Forms.ToolStripMenuItem tricepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuCablepushdown;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.DataGridView dbGrid;
        private System.Windows.Forms.TextBox tbChat;
    }
}

