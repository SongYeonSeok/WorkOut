namespace myLibrary
{
    partial class frminput
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Prompt = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.Font = new System.Drawing.Font("Consolas", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prompt.Location = new System.Drawing.Point(12, 7);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(54, 20);
            this.Prompt.TabIndex = 0;
            this.Prompt.Text = "Input";
            this.Prompt.Visible = false;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(15, 30);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(172, 25);
            this.tbInput.TabIndex = 1;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            // 
            // frminput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 67);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.Prompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frminput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.TextBox tbInput;
    }
}
