namespace WindowsFormsApp1
{
    partial class CusForm
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
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CusSetting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(72, 32);
            this.txt_1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(216, 22);
            this.txt_1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(613, 325);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CusSetting
            // 
            this.CusSetting.AutoSize = true;
            this.CusSetting.Location = new System.Drawing.Point(12, 35);
            this.CusSetting.Name = "CusSetting";
            this.CusSetting.Size = new System.Drawing.Size(55, 12);
            this.CusSetting.TabIndex = 2;
            this.CusSetting.Text = "CusSetting";
            // 
            // CusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 395);
            this.Controls.Add(this.CusSetting);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CusForm";
            this.Text = "CusForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CusSetting;
    }
}