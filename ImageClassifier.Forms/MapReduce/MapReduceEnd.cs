using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageClassifier.Forms.MapReduce
{
    public partial class MapReduceEnd : Form
    {
        // Simulate parallel processing with 5 servers
        private const int NUMSERVERS = 5;
        private const int COL_COUNT = 4;
        private const int PICTURE_DIM = 122;
        private readonly List<Bitmap> _bitmaps = new List<Bitmap>();

        public MapReduceEnd(List<Bitmap> bitmaps = null)
        {
            InitializeComponent();

            _bitmaps = bitmaps;

            MapReduceAlgorithm();
        }

        private void MapReduceAlgorithm()
        {
            if (_bitmaps.Count > 0)
            {
                var partialResults = new List<Dictionary<Bitmap, Dictionary<Color, int>>>();

                // Divide the images and distribute to servers
                List<List<Bitmap>> numberOfImagesPerServer = DivideImages(_bitmaps);

                // Start parallel processing
                Parallel.For(0, NUMSERVERS, serverIndex =>
                {
                    Dictionary<Bitmap, Dictionary<Color, int>> partialResult = MapPhase(numberOfImagesPerServer[serverIndex]);
                    lock (partialResults)
                    {
                        partialResults.Add(partialResult);
                    }
                });

                // Combine results from all servers
                Dictionary<Bitmap, string> result = ReducePhase(partialResults);

                DisplayResults(result);
            }
        }

        private List<List<Bitmap>> DivideImages(List<Bitmap> images)
        {
            int imagesPerPart = images.Count / NUMSERVERS;
            List<List<Bitmap>> imageParts = new List<List<Bitmap>>();

            for (int i = 0; i < NUMSERVERS; i++)
            {
                int startIndex = i * imagesPerPart;
                int endIndex = (i == NUMSERVERS - 1) ? images.Count : (i + 1) * imagesPerPart;

                List<Bitmap> part = images.GetRange(startIndex, endIndex - startIndex);
                imageParts.Add(part);
            }

            return imageParts;
        }

        private Dictionary<Bitmap, Dictionary<Color, int>> MapPhase(List<Bitmap> imagePart)
        {
            var resultMap = new Dictionary<Bitmap, Dictionary<Color, int>>();

            foreach (var bitmap in imagePart)
            {
                Dictionary<Color, int> colorCount = new Dictionary<Color, int>();

                // Count occurrences of each color in the picture part
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color pixelColor = bitmap.GetPixel(i, j);
                        if (colorCount.ContainsKey(pixelColor))
                            colorCount[pixelColor]++;
                        else
                            colorCount[pixelColor] = 1;
                    }
                }

                resultMap.Add(bitmap, colorCount);
            }

            return resultMap;
        }

        private Dictionary<Bitmap, string> ReducePhase(List<Dictionary<Bitmap, Dictionary<Color, int>>> partialResults)
        {
            Dictionary<Bitmap, string> resultMap = new Dictionary<Bitmap, string>();

            foreach (var partialResult in partialResults)
            {
                foreach (var kvp in partialResult)
                {
                    Color dominantColor = kvp.Value.OrderByDescending(x => x.Value).First().Key;

                    // Assign the dominant color to the corresponding bitmap
                    resultMap.Add(kvp.Key, ColorTranslator.ToHtml(dominantColor));
                }
            }

            return resultMap;
        }

        private void DisplayResults(Dictionary<Bitmap, string> resultMap)
        {
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            int rowCount = (int)Math.Ceiling((double)resultMap.Count / COL_COUNT);

            tableLayoutPanel.RowCount = rowCount * 2; // Account for 2 rows per picture (image + label)
            tableLayoutPanel.ColumnCount = COL_COUNT;

            int rowIndex = 0;
            int colIndex = 0;

            foreach (var kvp in resultMap)
            {
                // Create PictureBox for the bitmap
                PictureBox pictureBox = new PictureBox
                {
                    Image = kvp.Key,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = PICTURE_DIM,
                    Height = PICTURE_DIM
                };

                // Create Label for the color name
                Label label = new Label
                {
                    Text = kvp.Value,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Add PictureBox and Label to the TableLayoutPanel at the specified row and column
                tableLayoutPanel.Controls.Add(pictureBox, colIndex, rowIndex);
                tableLayoutPanel.Controls.Add(label, colIndex, rowIndex + 1); // Place the label below the picture

                colIndex++;

                if (colIndex >= COL_COUNT)
                {
                    colIndex = 0;
                    rowIndex += 2; // Move to the next row (accounting for 2 rows per picture)
                }
            }

            Controls.Add(tableLayoutPanel);
        }

        private void btn_startAgain_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            Hide();
        }
    }
}
