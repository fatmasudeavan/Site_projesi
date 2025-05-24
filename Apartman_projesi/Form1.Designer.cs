namespace Apartman_projesi
{
    partial class anaForm
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
            this.btnKisiler = new System.Windows.Forms.Button();
            this.btnDaireler = new System.Windows.Forms.Button();
            this.btnBloklar = new System.Windows.Forms.Button();
            this.btnKiralamaGecmisi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKisiler
            // 
            this.btnKisiler.BackColor = System.Drawing.Color.SteelBlue;
            this.btnKisiler.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKisiler.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnKisiler.Location = new System.Drawing.Point(484, 120);
            this.btnKisiler.Name = "btnKisiler";
            this.btnKisiler.Size = new System.Drawing.Size(284, 95);
            this.btnKisiler.TabIndex = 0;
            this.btnKisiler.Text = "Kişiler";
            this.btnKisiler.UseVisualStyleBackColor = false;
            this.btnKisiler.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDaireler
            // 
            this.btnDaireler.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDaireler.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaireler.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDaireler.Location = new System.Drawing.Point(484, 233);
            this.btnDaireler.Name = "btnDaireler";
            this.btnDaireler.Size = new System.Drawing.Size(284, 92);
            this.btnDaireler.TabIndex = 1;
            this.btnDaireler.Text = "Daireler";
            this.btnDaireler.UseVisualStyleBackColor = false;
            this.btnDaireler.Click += new System.EventHandler(this.btnDaireler_Click);
            // 
            // btnBloklar
            // 
            this.btnBloklar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBloklar.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBloklar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBloklar.Location = new System.Drawing.Point(484, 12);
            this.btnBloklar.Name = "btnBloklar";
            this.btnBloklar.Size = new System.Drawing.Size(284, 90);
            this.btnBloklar.TabIndex = 2;
            this.btnBloklar.Text = "Bloklar";
            this.btnBloklar.UseVisualStyleBackColor = false;
            this.btnBloklar.Click += new System.EventHandler(this.btnBloklar_Click);
            // 
            // btnKiralamaGecmisi
            // 
            this.btnKiralamaGecmisi.BackColor = System.Drawing.Color.SteelBlue;
            this.btnKiralamaGecmisi.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiralamaGecmisi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnKiralamaGecmisi.Location = new System.Drawing.Point(484, 347);
            this.btnKiralamaGecmisi.Name = "btnKiralamaGecmisi";
            this.btnKiralamaGecmisi.Size = new System.Drawing.Size(284, 91);
            this.btnKiralamaGecmisi.TabIndex = 3;
            this.btnKiralamaGecmisi.Text = "Kiralama Geçmişi";
            this.btnKiralamaGecmisi.UseVisualStyleBackColor = false;
            this.btnKiralamaGecmisi.Click += new System.EventHandler(this.btnKiralamaGecmisi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Apartman_projesi.Properties.Resources.background1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 465);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // anaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnKiralamaGecmisi);
            this.Controls.Add(this.btnBloklar);
            this.Controls.Add(this.btnDaireler);
            this.Controls.Add(this.btnKisiler);
            this.DoubleBuffered = true;
            this.Name = "anaForm";
            this.Text = "Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKisiler;
        private System.Windows.Forms.Button btnDaireler;
        private System.Windows.Forms.Button btnBloklar;
        private System.Windows.Forms.Button btnKiralamaGecmisi;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

