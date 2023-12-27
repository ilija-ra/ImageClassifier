namespace ImageClassifier.Forms
{
    partial class Main
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
            this.cb_imageSize = new System.Windows.Forms.ComboBox();
            this.noImages = new System.Windows.Forms.Label();
            this.num_noImages = new System.Windows.Forms.NumericUpDown();
            this.imageSize = new System.Windows.Forms.Label();
            this.btn_generateImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_noImages)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_imageSize
            // 
            this.cb_imageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_imageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_imageSize.FormattingEnabled = true;
            this.cb_imageSize.Location = new System.Drawing.Point(63, 160);
            this.cb_imageSize.Name = "cb_imageSize";
            this.cb_imageSize.Size = new System.Drawing.Size(263, 33);
            this.cb_imageSize.TabIndex = 0;
            // 
            // noImages
            // 
            this.noImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noImages.AutoSize = true;
            this.noImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noImages.Location = new System.Drawing.Point(110, 29);
            this.noImages.Name = "noImages";
            this.noImages.Size = new System.Drawing.Size(170, 25);
            this.noImages.TabIndex = 1;
            this.noImages.Text = "Number of images";
            this.noImages.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // num_noImages
            // 
            this.num_noImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.num_noImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_noImages.Location = new System.Drawing.Point(63, 57);
            this.num_noImages.Name = "num_noImages";
            this.num_noImages.Size = new System.Drawing.Size(263, 30);
            this.num_noImages.TabIndex = 2;
            // 
            // imageSize
            // 
            this.imageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageSize.AutoSize = true;
            this.imageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageSize.Location = new System.Drawing.Point(139, 132);
            this.imageSize.Name = "imageSize";
            this.imageSize.Size = new System.Drawing.Size(106, 25);
            this.imageSize.TabIndex = 3;
            this.imageSize.Text = "Image size";
            // 
            // btn_generateImages
            // 
            this.btn_generateImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generateImages.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_generateImages.Location = new System.Drawing.Point(128, 265);
            this.btn_generateImages.Name = "btn_generateImages";
            this.btn_generateImages.Size = new System.Drawing.Size(130, 47);
            this.btn_generateImages.TabIndex = 4;
            this.btn_generateImages.Text = "Generate images";
            this.btn_generateImages.UseVisualStyleBackColor = true;
            this.btn_generateImages.Click += new System.EventHandler(this.btn_generateImages_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.btn_generateImages);
            this.Controls.Add(this.imageSize);
            this.Controls.Add(this.num_noImages);
            this.Controls.Add(this.noImages);
            this.Controls.Add(this.cb_imageSize);
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.num_noImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_imageSize;
        private System.Windows.Forms.Label noImages;
        private System.Windows.Forms.NumericUpDown num_noImages;
        private System.Windows.Forms.Label imageSize;
        private System.Windows.Forms.Button btn_generateImages;
    }
}