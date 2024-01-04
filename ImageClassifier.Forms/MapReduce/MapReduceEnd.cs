using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageClassifier.Forms.MapReduce
{
    public partial class MapReduceEnd : Form
    {
        private readonly int _fifthPart;
        private readonly List<Bitmap> _bitmaps = new List<Bitmap>();

        //used in SplitPhase
        private List<Color> _serverOne = new List<Color>();
        private List<Color> _serverTwo = new List<Color>();
        private List<Color> _serverThree = new List<Color>();
        private List<Color> _serverFour = new List<Color>();
        private List<Color> _serverFive = new List<Color>();

        //used in MapPhase
        private Dictionary<Color, int> _serverOneCounts = new Dictionary<Color, int>();
        private Dictionary<Color, int> _serverTwoCounts = new Dictionary<Color, int>();
        private Dictionary<Color, int> _serverThreeCounts = new Dictionary<Color, int>();
        private Dictionary<Color, int> _serverFourCounts = new Dictionary<Color, int>();
        private Dictionary<Color, int> _serverFiveCounts = new Dictionary<Color, int>();


        //used in ShuffleSortPhase
        private List<Dictionary<Color, int>> _groupedServerCounts = new List<Dictionary<Color, int>>();

        public MapReduceEnd(List<Bitmap> bitmaps)
        {
            InitializeComponent();

            _bitmaps = bitmaps;
            _fifthPart = bitmaps[0].Height / 5;

            MapReduceAlgorithm();
        }

        private void MapReduceAlgorithm()
        {
            foreach (var bitmap in _bitmaps)
            {
                SplitPhase(bitmap);
                MapPhase();
                ShuffleSortPhase();
                //ReducePhase(_shuffleSortResult);
            }
        }

        private void SplitPhase(Bitmap bitmap)
        {
            for (int i = 0; i < _fifthPart; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);

                    _serverOne.Add(pixelColor);
                }
            }

            for (int i = _fifthPart; i < _fifthPart * 2; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);

                    _serverTwo.Add(pixelColor);
                }
            }

            for (int i = _fifthPart * 2; i < _fifthPart * 3; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);

                    _serverThree.Add(pixelColor);
                }
            }

            for (int i = _fifthPart * 3; i < _fifthPart * 4; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);

                    _serverFour.Add(pixelColor);
                }
            }

            for (int i = _fifthPart * 4; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixelColor = bitmap.GetPixel(i, j);

                    _serverFive.Add(pixelColor);
                }
            }
        }

        private void MapPhase()
        {
            foreach (var pixelColor in _serverOne)
            {
                if (_serverOneCounts.ContainsKey(pixelColor))
                    _serverOneCounts[pixelColor]++;
                else
                    _serverOneCounts[pixelColor] = 1;
            }

            foreach (var pixelColor in _serverTwo)
            {
                if (_serverTwoCounts.ContainsKey(pixelColor))
                    _serverTwoCounts[pixelColor]++;
                else
                    _serverTwoCounts[pixelColor] = 1;
            }

            foreach (var pixelColor in _serverThree)
            {
                if (_serverThreeCounts.ContainsKey(pixelColor))
                    _serverThreeCounts[pixelColor]++;
                else
                    _serverThreeCounts[pixelColor] = 1;
            }

            foreach (var pixelColor in _serverFour)
            {
                if (_serverFourCounts.ContainsKey(pixelColor))
                    _serverFourCounts[pixelColor]++;
                else
                    _serverFourCounts[pixelColor] = 1;
            }

            foreach (var pixelColor in _serverFive)
            {
                if (_serverFiveCounts.ContainsKey(pixelColor))
                    _serverFiveCounts[pixelColor]++;
                else
                    _serverFiveCounts[pixelColor] = 1;
            }

            _groupedServerCounts.Add(_serverOneCounts);
            _groupedServerCounts.Add(_serverTwoCounts);
            _groupedServerCounts.Add(_serverThreeCounts);
            _groupedServerCounts.Add(_serverFourCounts);
            _groupedServerCounts.Add(_serverFiveCounts);
        }

        private void ShuffleSortPhase()
        {
            // Combine color counts from all servers into a single dictionary
            Dictionary<Color, int> combinedCounts = new Dictionary<Color, int>();

            foreach (var serverCounts in _groupedServerCounts)
            {
                foreach (var kvp in serverCounts)
                {
                    if (combinedCounts.ContainsKey(kvp.Key))
                        combinedCounts[kvp.Key] += kvp.Value;
                    else
                        combinedCounts[kvp.Key] = kvp.Value;
                }
            }

            // Sort the combined counts by the color key
            var sortedCombinedCounts = combinedCounts.OrderByDescending(c => c.Value).ToList();

            label1.Text += "\n" + $"Color: {sortedCombinedCounts[0].Key.Name}, Appereances: {sortedCombinedCounts[0].Value}";
        }

        //private void ReducePhase(List<KeyValuePair<Color, int>> shuffleSortResult)
        //{
        //Color mostFrequentColor = shuffleSortResult.OrderByDescending(kvp => kvp).First();
        //bitmap.Tag = mostFrequentColor.Name;
        //Console.WriteLine($"Final color: {mostFrequentColor.Name}");
        //}

        //private void findMostFrequentColor()
        //{
        //    foreach (var bitmap in _bitmaps)
        //    {
        //        Dictionary<Color, int> colorCounts = new Dictionary<Color, int>();

        //        for (int i = 0; i < bitmap.Width; i++)
        //        {
        //            for (int j = 0; j < bitmap.Height; j++)
        //            {
        //                Color pixelColor = bitmap.GetPixel(i, j);

        //                if (colorCounts.ContainsKey(pixelColor))
        //                    colorCounts[pixelColor]++;
        //                else
        //                    colorCounts[pixelColor] = 1;
        //            }
        //        }

        //        Color mostFrequentColor = colorCounts.OrderByDescending(kvp => kvp.Value).First().Key;
        //        bitmap.Tag = mostFrequentColor.Name;

        //        Console.WriteLine($"Bitmap[{bitmap.Tag}], Most frequent color: " + mostFrequentColor.A + mostFrequentColor.R + mostFrequentColor.G + mostFrequentColor.B);
        //    }
        //}

        //private void calculateAverageColor()
        //{
        //    foreach (var bitmap in _bitmaps)
        //    {
        //        int totalPixels = bitmap.Width * bitmap.Height;
        //        int totalRed = 0, totalGreen = 0, totalBlue = 0;

        //        for (int i = 0; i < bitmap.Width; i++)
        //        {
        //            for (int j = 0; j < bitmap.Height; j++)
        //            {
        //                Color pixelColor = bitmap.GetPixel(i, j);
        //                totalRed += pixelColor.R;
        //                totalGreen += pixelColor.G;
        //                totalBlue += pixelColor.B;
        //            }
        //        }

        //        // Calculate average values for each channel
        //        int averageRed = totalRed / totalPixels;
        //        int averageGreen = totalGreen / totalPixels;
        //        int averageBlue = totalBlue / totalPixels;

        //        // Create the average color
        //        Color averageColor = Color.FromArgb(averageRed, averageGreen, averageBlue);

        //        // Assign the average color to the Tag property
        //        bitmap.Tag = averageColor.Name;

        //        Console.WriteLine($"Bitmap[{bitmap.Tag}], Average color: " + averageColor);
        //    }
        //}
    }
}
