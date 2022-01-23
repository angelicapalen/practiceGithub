namespace FrontDeskApp
{
    partial class RetrieveDate
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnRetrieveBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 7);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // btnRetrieveBox
            // 
            this.btnRetrieveBox.Location = new System.Drawing.Point(9, 181);
            this.btnRetrieveBox.Name = "btnRetrieveBox";
            this.btnRetrieveBox.Size = new System.Drawing.Size(227, 23);
            this.btnRetrieveBox.TabIndex = 1;
            this.btnRetrieveBox.Text = "Retrieve Box";
            this.btnRetrieveBox.UseVisualStyleBackColor = true;
            this.btnRetrieveBox.Click += new System.EventHandler(this.BtnRetrieveBox_Click);
            // 
            // RetrieveDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(244, 212);
            this.Controls.Add(this.btnRetrieveBox);
            this.Controls.Add(this.monthCalendar1);
            this.MaximizeBox = false;
            this.Name = "RetrieveDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retrieve Date";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnRetrieveBox;
    }
}