using ImageClassifier.Forms.MapReduce;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageClassifier.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            cb_imageSize.DataSource = new ImageSize[]
            {
                new ImageSize{ Id = 1, Size = "50x50" },
                new ImageSize{ Id = 2, Size = "75x75" },
                new ImageSize{ Id = 3, Size = "100x100" },
                new ImageSize{ Id = 4, Size = "200x200" },
                new ImageSize{ Id = 5, Size = "500x500" },
                new ImageSize{ Id = 6, Size = "1000x1000" },
            };

            cb_imageSize.DisplayMember = "Size";
            cb_imageSize.ValueMember = "Id";
        }

        private class ImageSize
        {
            public long Id { get; set; }

            public string Size { get; set; }
        }

        private void btn_generateImages_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                //ProgressBar progressBar = new ProgressBar()
                //{
                //    Name = "progressBar",
                //    Height = 23,
                //    Width = 358,
                //    Location = new Point(12, 318),
                //    Step = 5,
                //    Value = 0,
                //    Visible = true
                //};

                //// Simulate some progress (for demonstration purposes)
                //for (int i = 0; i <= 100; i += 5)
                //{
                //    System.Threading.Thread.Sleep(100); // Simulate work being done
                //    progressBar.PerformStep();
                //    Application.DoEvents(); // Allow the UI to update
                //}

                //if (progressBar.Value == 100)
                //{
                MapReduceStart mapReduceStart = new MapReduceStart(Convert.ToInt32(num_noImages.Value), Convert.ToInt32(cb_imageSize.SelectedValue));
                mapReduceStart.Show();
                Hide();
                //}
            }
        }

        private bool validateForm()
        {
            if (num_noImages.Value < 0 || num_noImages.Value > 200)
            {
                num_noImages.BackColor = Color.LightCoral;
                valerr_numberOfImages.Text = "Value must be in range 0-200";
                return false;
            }

            return true;
        }
    }
}
