namespace DialDetector
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
            this.components = new System.ComponentModel.Container();
            this.VideoImage = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoImage)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoImage
            // 
            this.VideoImage.Location = new System.Drawing.Point(13, 42);
            this.VideoImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoImage.MaximumSize = new System.Drawing.Size(2000, 1000);
            this.VideoImage.MinimumSize = new System.Drawing.Size(100, 100);
            this.VideoImage.Name = "VideoImage";
            this.VideoImage.Size = new System.Drawing.Size(2000, 1000);
            this.VideoImage.TabIndex = 2;
            this.VideoImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, -3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "ProcessImage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 814);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VideoImage);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Dial Detector";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox VideoImage;
        private System.Windows.Forms.Button button1;
    }
}

