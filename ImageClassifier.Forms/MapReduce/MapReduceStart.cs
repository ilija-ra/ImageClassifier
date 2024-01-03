using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageClassifier.Forms.MapReduce
{
    public partial class MapReduceStart : Form
    {
        private readonly int _height;
        private readonly int _numRows;
        private readonly List<Bitmap> _bitmaps = new List<Bitmap>();
        public MapReduceStart(int numberOfImages, int imageSize)
        {
            InitializeComponent();

            switch (imageSize)
            {
                case 1:
                    _height = 50;
                    break;
                case 2:
                    _height = 75;
                    break;
                case 3:
                    _height = 100;
                    break;
                case 4:
                    _height = 200;
                    break;
                default:
                    break;
            }

            _numRows = numberOfImages;

            InitializeLayout();
        }

        private void InitializeLayout()
        {
            var tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Left;
            tableLayoutPanel.AutoScroll = true;
            tableLayoutPanel.RowCount = _numRows;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.BackColor = Color.White;
            tableLayoutPanel.AutoSize = true;

            var vScrollBar = new VScrollBar();
            vScrollBar.Dock = DockStyle.Right;
            vScrollBar.Scroll += (sender, e) => tableLayoutPanel.VerticalScroll.Value = vScrollBar.Value;

            Controls.Add(tableLayoutPanel);
            Controls.Add(vScrollBar);

            generateRandomImages(tableLayoutPanel, vScrollBar);
        }

        private void generateRandomImages(TableLayoutPanel tableLayoutPanel, VScrollBar vScrollBar)
        {
            for (int row = 0; row < _numRows; row++)
            {
                PictureBox pictureBox = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                //pictureBox.Dock = DockStyle.Fill;
                //pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Click += PictureBox_Click;

                Bitmap generatedBitmap = GenerateImage(_height, _height);

                _bitmaps.Add(generatedBitmap);

                pictureBox.Image = generatedBitmap;

                tableLayoutPanel.Controls.Add(pictureBox, 1, row);
            }

            vScrollBar.Maximum = tableLayoutPanel.VerticalScroll.Maximum;
        }

        //private void Funcc()
        //{
        //    foreach (var bitmap in _bitmaps)
        //    {
        //        for (int i = 0; i < bitmap.Width; i++)
        //        {
        //            for (int j = 0; j < bitmap.Height; j++)
        //            {
        //                Color pixelColor = bitmap.GetPixel(i, j);

        //                // Do something with the pixelColor, e.g., access pixelColor.R, pixelColor.G, pixelColor.B
        //            }
        //        }
        //    }

        //    // Map step: Split the input into key-value pairs (word, 1) in parallel
        //    var mappedResults = _bitmaps
        //        .AsParallel()
        //        .GroupBy(word => word)
        //        .Select(group => new KeyValuePair<string, int>(group.Key, group.Count()));

        //    // Reduce step: Aggregate the values for each key in parallel
        //    var reducedResults = mappedResults
        //        .GroupBy(pair => pair.Key)
        //        .AsParallel()
        //        .Select(group => new KeyValuePair<string, int>(group.Key, group.Sum(pair => pair.Value)));

        //}

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;

            PictureBox newPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = clickedPictureBox.Image
            };

            Controls.Add(newPictureBox);

            newPictureBox.BringToFront();
            btn_startMapReduce.BringToFront();
        }

        private static Random rand = new Random();

        private static Bitmap GenerateImage(int height, int width)
        {
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                int baseRed = rand.Next(256);
                int baseGreen = rand.Next(256);
                int baseBlue = rand.Next(256);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int variationRed = rand.Next(-128, 127);
                        int variationGreen = rand.Next(-128, 127);
                        int variationBlue = rand.Next(-128, 127);

                        int currentRed = Clamp(baseRed + variationRed, 0, 255);
                        int currentGreen = Clamp(baseGreen + variationGreen, 0, 255);
                        int currentBlue = Clamp(baseBlue + variationBlue, 0, 255);

                        using (Brush brush = new SolidBrush(Color.FromArgb(currentRed, currentGreen, currentBlue)))
                        {
                            g.FillRectangle(brush, j, i, 1, 1);
                        }
                    }
                }
            }

            return bitmap;
        }

        private static int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }
}
