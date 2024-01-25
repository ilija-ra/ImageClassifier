namespace ImageClassifier.Forms.MapReduce
{
    partial class MapReduceEnd
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
            this.btn_startAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "FINAL RESULTS";
            // 
            // btn_startAgain
            // 
            this.btn_startAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_startAgain.Location = new System.Drawing.Point(237, 1);
            this.btn_startAgain.Name = "btn_startAgain";
            this.btn_startAgain.Size = new System.Drawing.Size(32, 40);
            this.btn_startAgain.TabIndex = 3;
            this.btn_startAgain.Tag = "";
            this.btn_startAgain.Text = "↻";
            this.btn_startAgain.UseVisualStyleBackColor = true;
            this.btn_startAgain.Click += new System.EventHandler(this.btn_startAgain_Click);
            // 
            // MapReduceEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 553);
            this.Controls.Add(this.btn_startAgain);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapReduceEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Classifier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_startAgain;
    }
}