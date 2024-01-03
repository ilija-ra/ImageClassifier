using ImageClassifier.Forms.MapReduce;
using System;
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
                new ImageSize{ Id = 4, Size = "200x200" }
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
                MapReduceStart mapReduceStart = new MapReduceStart(Convert.ToInt32(num_noImages.Value), Convert.ToInt32(cb_imageSize.SelectedValue));
                mapReduceStart.Show();
                Hide();
            }
        }

        private static bool validateForm()
        {
            return true;
        }
    }
}
