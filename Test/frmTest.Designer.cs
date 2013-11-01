namespace Test
{
    partial class frmTest
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
            this.btnSample1 = new System.Windows.Forms.Button();
            this.btnSample2 = new System.Windows.Forms.Button();
            this.txtResult2 = new System.Windows.Forms.TextBox();
            this.txtResult1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestAmex
            // 
            this.btnTestAmex.Location = new System.Drawing.Point(296, 12);
            this.btnTestAmex.Name = "btnTestAmex";
            this.btnTestAmex.Size = new System.Drawing.Size(137, 23);
            this.btnTestAmex.TabIndex = 0;
            this.btnTestAmex.Text = "Test Amex";
            this.btnTestAmex.UseVisualStyleBackColor = true;
            this.btnTestAmex.Click += new System.EventHandler(this.btnTestAmex_Click);
            // 
            // btnTestHipercard
            // 
            this.btnTestHipercard.Location = new System.Drawing.Point(439, 12);
            this.btnTestHipercard.Name = "btnTestHipercard";
            this.btnTestHipercard.Size = new System.Drawing.Size(137, 23);
            this.btnTestHipercard.TabIndex = 0;
            this.btnTestHipercard.Text = "Test Hipercard";
            this.btnTestHipercard.UseVisualStyleBackColor = true;
            this.btnTestHipercard.Click += new System.EventHandler(this.btnTestHipercard_Click);
            // 
            // btnSample1
            // 
            this.btnSample1.Location = new System.Drawing.Point(10, 12);
            this.btnSample1.Name = "btnSample1";
            this.btnSample1.Size = new System.Drawing.Size(137, 23);
            this.btnSample1.TabIndex = 0;
            this.btnSample1.Text = "Test Sample1";
            this.btnSample1.UseVisualStyleBackColor = true;
            this.btnSample1.Click += new System.EventHandler(this.btnSample1_Click);
            // 
            // btnSample2
            // 
            this.btnSample2.Location = new System.Drawing.Point(153, 12);
            this.btnSample2.Name = "btnSample2";
            this.btnSample2.Size = new System.Drawing.Size(137, 23);
            this.btnSample2.TabIndex = 0;
            this.btnSample2.Text = "Test Sample2";
            this.btnSample2.UseVisualStyleBackColor = true;
            this.btnSample2.Click += new System.EventHandler(this.btnSample2_Click);
            // 
            // txtResult2
            // 
            this.txtResult2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult2.Location = new System.Drawing.Point(10, 281);
            this.txtResult2.Multiline = true;
            this.txtResult2.Name = "txtResult2";
            this.txtResult2.ReadOnly = true;
            this.txtResult2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult2.Size = new System.Drawing.Size(566, 205);
            this.txtResult2.TabIndex = 1;
            // 
            // txtResult1
            // 
            this.txtResult1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult1.Location = new System.Drawing.Point(10, 57);
            this.txtResult1.Multiline = true;
            this.txtResult1.Name = "txtResult1";
            this.txtResult1.ReadOnly = true;
            this.txtResult1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult1.Size = new System.Drawing.Size(566, 199);
            this.txtResult1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resultado interpretado";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Conteúdo do Arquivo";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 498);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResult1);
            this.Controls.Add(this.txtResult2);
            this.Controls.Add(this.btnTestHipercard);
            this.Controls.Add(this.btnSample2);
            this.Controls.Add(this.btnSample1);
            this.Controls.Add(this.btnTestAmex);
            this.Name = "frmTest";
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestAmex;
        private System.Windows.Forms.Button btnTestHipercard;
        private System.Windows.Forms.Button btnSample1;
        private System.Windows.Forms.Button btnSample2;
        private System.Windows.Forms.TextBox txtResult2;
        private System.Windows.Forms.TextBox txtResult1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

