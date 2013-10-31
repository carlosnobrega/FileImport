namespace Test
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
            this.btnTestAmex = new System.Windows.Forms.Button();
            this.btnTestHipercard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestAmex
            // 
            this.btnTestAmex.Location = new System.Drawing.Point(29, 12);
            this.btnTestAmex.Name = "btnTestAmex";
            this.btnTestAmex.Size = new System.Drawing.Size(227, 23);
            this.btnTestAmex.TabIndex = 0;
            this.btnTestAmex.Text = "Test Amex";
            this.btnTestAmex.UseVisualStyleBackColor = true;
            this.btnTestAmex.Click += new System.EventHandler(this.btnTestAmex_Click);
            // 
            // btnTestHipercard
            // 
            this.btnTestHipercard.Location = new System.Drawing.Point(29, 41);
            this.btnTestHipercard.Name = "btnTestHipercard";
            this.btnTestHipercard.Size = new System.Drawing.Size(227, 23);
            this.btnTestHipercard.TabIndex = 0;
            this.btnTestHipercard.Text = "Test Hipercard";
            this.btnTestHipercard.UseVisualStyleBackColor = true;
            this.btnTestHipercard.Click += new System.EventHandler(this.btnTestHipercard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnTestHipercard);
            this.Controls.Add(this.btnTestAmex);
            this.Name = "Form1";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestAmex;
        private System.Windows.Forms.Button btnTestHipercard;
    }
}

