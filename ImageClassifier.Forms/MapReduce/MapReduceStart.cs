using System.Drawing;
using System.Windows.Forms;

namespace ImageClassifier.Forms.MapReduce
{
    public partial class MapReduceStart : Form
    {
        private readonly int _numberOfImages;
        private readonly int _imageSize;

        public MapReduceStart(int numberOfImages, int imageSize)
        {
            InitializeComponent();

            _numberOfImages = numberOfImages;
            _imageSize = imageSize;

            generateRandomImages();
        }

        //TODO: generateRandomImages check what code below does
        private void generateRandomImages()
        {
            //for (int i = 0; i < _numberOfImages; i++)
            //{
            //    Bitmap bitmap = new Bitmap(_imageSize, _imageSize);
            //    Graphics bitmapGraphics = Graphics.FromImage(bitmap);
            //}
            int numRows = 3;
            int numCols = 3;

            // Create a TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = numRows;
            tableLayoutPanel.ColumnCount = numCols;

            // Add PictureBox controls to the TableLayoutPanel
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    // Generate your bitmap dynamically
                    Bitmap generatedBitmap = GenerateImage(row, col); // Adjust this based on your logic

                    // Set the generated bitmap to the PictureBox
                    pictureBox.Image = generatedBitmap;

                    // Add click event handler if needed
                    // pictureBox.Click += pictureBox_Click;

                    tableLayoutPanel.Controls.Add(pictureBox, col, row);
                }
            }

            // Add the TableLayoutPanel to the form
            this.Controls.Add(tableLayoutPanel);
        }

        private Bitmap GenerateImage(int row, int col)
        {
            // Replace this with your logic to generate images dynamically
            // For demonstration purposes, creating a simple colored bitmap
            Bitmap bitmap = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(row * 50, col * 50, (row + col) * 30)))
                {
                    g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
                }
            }
            return bitmap;
        }
    }
}
