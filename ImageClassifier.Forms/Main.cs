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
                new ImageSize{ Id = 3, Size = "100x100" }
            };

            cb_imageSize.DisplayMember = "Size";
            cb_imageSize.ValueMember = "Id";
        }

        private class ImageSize
        {
            public long Id { get; set; }

            public string Size { get; set; }
        }

        private void btn_generateImages_Click(object sender, System.EventArgs e)
        {
            if (validateForm())
            {

            }
        }

        private static bool validateForm()
        {
            return true;
        }
    }
}
