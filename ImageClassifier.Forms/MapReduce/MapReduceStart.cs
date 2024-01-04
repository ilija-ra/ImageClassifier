using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageClassifier.Forms.MapReduce
{
    public partial class MapReduceStart : Form
    {
        private readonly int _height;
        private readonly int _numRows;
        private readonly static Random _rand = new Random();
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
                case 5:
                    _height = 500;
                    break;
                case 6:
                    _height = 1000;
                    break;
                default:
                    break;
            }

            _numRows = numberOfImages;

            InitializeLayout();
            findMostFrequentColor();
        }

        private void InitializeLayout()
        {
            var tableLayoutPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Left,
                AutoScroll = true,
                RowCount = _numRows,
                ColumnCount = 1,
                BackColor = Color.White,
                Width = 125
            };

            Controls.Add(tableLayoutPanel);

            generateRandomImages(tableLayoutPanel);
        }

        private void generateRandomImages(TableLayoutPanel tableLayoutPanel)
        {
            for (int row = 0; row < _numRows; row++)
            {
                PictureBox pictureBox = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                pictureBox.Click += PictureBox_Click;

                Bitmap generatedBitmap = GenerateImage(_height, _height);

                _bitmaps.Add(generatedBitmap);

                pictureBox.Image = generatedBitmap;

                tableLayoutPanel.Controls.Add(pictureBox, 1, row);
            }
        }

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
        }

        private static Bitmap GenerateImage(int height, int width)
        {
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                int baseRed = _rand.Next(256);
                int baseGreen = _rand.Next(256);
                int baseBlue = _rand.Next(256);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int variationRed = _rand.Next(-40, 40);
                        int variationGreen = _rand.Next(-40, 40);
                        int variationBlue = _rand.Next(-40, 40);

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

        private void findMostFrequentColor()
        {
            foreach (var bitmap in _bitmaps)
            {
                Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();

                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color pixelColor = bitmap.GetPixel(i, j);

                        if (colorCounts.ContainsKey(pixelColor))
                            colorCounts[pixelColor]++;
                        else
                            colorCounts[pixelColor] = 1;
                    }
                }

                Color mostFrequentColor = colorCounts.OrderByDescending(kvp => kvp.Value).First().Key;
                bitmap.Tag = mostFrequentColor.Name;

                Console.WriteLine($"Bitmap[{bitmap.Tag}], Most frequent color: " + mostFrequentColor.A + mostFrequentColor.R + mostFrequentColor.G + mostFrequentColor.B);
            }
        }
    }
}
