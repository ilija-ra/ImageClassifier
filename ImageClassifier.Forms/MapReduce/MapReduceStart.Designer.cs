namespace ImageClassifier.Forms.MapReduce
{
    partial class MapReduceStart
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
            this.btn_startMapReduce = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_startMapReduce
            // 
            this.btn_startMapReduce.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_startMapReduce.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_startMapReduce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_startMapReduce.Location = new System.Drawing.Point(0, 491);
            this.btn_startMapReduce.Margin = new System.Windows.Forms.Padding(0);
            this.btn_startMapReduce.Name = "btn_startMapReduce";
            this.btn_startMapReduce.Size = new System.Drawing.Size(717, 62);
            this.btn_startMapReduce.TabIndex = 1;
            this.btn_startMapReduce.Text = "Start MapReduce Algorithm";
            this.btn_startMapReduce.UseVisualStyleBackColor = true;
            // 
            // MapReduceStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(717, 553);
            this.Controls.Add(this.btn_startMapReduce);
            this.Name = "MapReduceStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapReduce";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_startMapReduce;
    }
}