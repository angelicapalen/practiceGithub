namespace FrontDeskApp
{
    partial class CheckAvailable
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSmallArea = new System.Windows.Forms.TextBox();
            this.tbMediumArea = new System.Windows.Forms.TextBox();
            this.tbLargeArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Small Area ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Medium Area ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Large Area ";
            // 
            // tbSmallArea
            // 
            this.tbSmallArea.Enabled = false;
            this.tbSmallArea.Location = new System.Drawing.Point(113, 17);
            this.tbSmallArea.Name = "tbSmallArea";
            this.tbSmallArea.Size = new System.Drawing.Size(189, 20);
            this.tbSmallArea.TabIndex = 3;
            // 
            // tbMediumArea
            // 
            this.tbMediumArea.Enabled = false;
            this.tbMediumArea.Location = new System.Drawing.Point(113, 56);
            this.tbMediumArea.Name = "tbMediumArea";
            this.tbMediumArea.Size = new System.Drawing.Size(189, 20);
            this.tbMediumArea.TabIndex = 4;
            // 
            // tbLargeArea
            // 
            this.tbLargeArea.Enabled = false;
            this.tbLargeArea.Location = new System.Drawing.Point(113, 95);
            this.tbLargeArea.Name = "tbLargeArea";
            this.tbLargeArea.Size = new System.Drawing.Size(189, 20);
            this.tbLargeArea.TabIndex = 5;
            // 
            // CheckAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(332, 134);
            this.Controls.Add(this.tbLargeArea);
            this.Controls.Add(this.tbMediumArea);
            this.Controls.Add(this.tbSmallArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "CheckAvailable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckAvailable";
            this.Load += new System.EventHandler(this.CheckAvailable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSmallArea;
        private System.Windows.Forms.TextBox tbMediumArea;
        private System.Windows.Forms.TextBox tbLargeArea;
    }
}