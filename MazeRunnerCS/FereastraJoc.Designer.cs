namespace MazeRunnerCS
{
    partial class FereastraJoc
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FereastraJoc));
            this.labirint = new System.Windows.Forms.PictureBox();
            this.caracter = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.labirint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caracter)).BeginInit();
            this.SuspendLayout();
            // 
            // labirint
            // 
            this.labirint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.labirint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labirint.Image = ((System.Drawing.Image)(resources.GetObject("labirint.Image")));
            this.labirint.Location = new System.Drawing.Point(0, 0);
            this.labirint.Name = "labirint";
            this.labirint.Size = new System.Drawing.Size(800, 450);
            this.labirint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.labirint.TabIndex = 0;
            this.labirint.TabStop = false;
            this.labirint.SizeChanged += new System.EventHandler(this.FereastraJoc_Resize);
            this.labirint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FereastraJoc_MouseMove);
            this.labirint.Resize += new System.EventHandler(this.labirint_Resize);
            // 
            // caracter
            // 
            this.caracter.BackColor = System.Drawing.Color.Transparent;
            this.caracter.Location = new System.Drawing.Point(407, 425);
            this.caracter.Name = "caracter";
            this.caracter.Size = new System.Drawing.Size(29, 25);
            this.caracter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.caracter.TabIndex = 1;
            this.caracter.TabStop = false;
            this.caracter.Click += new System.EventHandler(this.caracter_Click);
            this.caracter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.caracter_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 2;
            // 
            // FereastraJoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caracter);
            this.Controls.Add(this.labirint);
            this.Name = "FereastraJoc";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.FereastraJoc_SizeChanged);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FereastraJoc_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.labirint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caracter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox labirint;
        private System.Windows.Forms.PictureBox caracter;
        private System.Windows.Forms.Label label1;
    }
}
