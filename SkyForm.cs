namespace WinFormsApp1
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;

    /// <summary>
    /// Simulate the atmosphere.
    /// </summary>

    public partial class SkyForm
    {
        /// <summary>
        /// The gases we want to display, along with their relevant ratios and colours.
        /// </summary>
        private static readonly Gas[] Gases = new Gas[]
        {
            new Gas(GasIndex.GAS_N2, "Nitrogen", 78.0 / 100.0, Color.Silver, Color.Silver.ToArgb()),
            new Gas(GasIndex.GAS_O2, "Oxygen", 21.0 / 100.0, Color.Goldenrod, Color.Goldenrod.ToArgb()),
            new Gas(GasIndex.GAS_Ar, "Argon", 1.0 / 100.0, Color.Gold, Color.Gold.ToArgb()),
            new Gas(GasIndex.GAS_H20, "Water", 2.0 / 100.0, Color.Blue, Color.Blue.ToArgb()),
            new Gas(GasIndex.GAS_CO2, "CO2", 400.0 / 1000000.0, Color.Green, Color.Green.ToArgb()),
            new Gas(GasIndex.GAS_ACO2, "Human CO2", 15.0 / 1000000.0, Color.Red, Color.Red.ToArgb()),
        };

        /// <summary>
        /// Image sizes we support.
        /// </summary>
        /// <remarks>
        /// Ideally, these should be convenient multiples of 1 million pixels. In practice, the various 16x9 formats are
        /// a little bit over.
        /// </remarks>
        private static readonly SupportedSize[] Sizes =
        {
            new SupportedSize(1280, 800, 20, "WXGA / ~1 Megapixel"),
            new SupportedSize(1000, 1000, 20, "1 Megapixel"),
            new SupportedSize(1600, 1200, 40, "UXGA / ~2 Megapixels"),
            new SupportedSize(1920, 1080, 40, "Full HD / ~2 Megapixels"),
            new SupportedSize(1920, 1200, 40, "WUXGA / ~2 Megapixels"),
            new SupportedSize(2048, 1080, 40, "QWXGA / 2K / ~2 Megapixels"),
            new SupportedSize(2560, 1080, 80, "UW-FHD 21:9 / ~2.8 Megapixels"),
            new SupportedSize(2500, 1600, 80, "4 Megapixels"),
            new SupportedSize(2560, 1600, 80, "WQXGA / 4 Megapixels"),
            new SupportedSize(3840, 2160, 160, "4K UHD / ~8 Megapixels"),
            new SupportedSize(5120, 2160, 160, "UW5K / ~11 Megapixels"),
            new SupportedSize(5000, 3200, 160, "16 Megapixels"),
            new SupportedSize(5120, 2880, 160, "5K / ~15 Megapixels"),
            new SupportedSize(5120, 3200, 160, "WHXGA / ~16 Megapixels"),
            new SupportedSize(7680, 4320, 500, "8K / ~32 Megapixels"),
            new SupportedSize(8120, 4320, 500, "Full 8K / ~35 Megapixels"),
            new SupportedSize(10240, 4320, 500, "UW 10K / ~44 Megapixels"),
            new SupportedSize(15360, 8640, 1000, "16K / ~132 Megapixels"),
        };

        private static readonly int[] SpaceRatios =
        {
            20,
            40,
            80,
            100,
            120,
            160,
            200,
            240,
            300,
            320,
            400,
            500,
            600,
            800,
            1000
        };

        private static SupportedSize defaultSize = Sizes[0];

        readonly bool _initialized;

        /// <summary>
        /// SkyForm Constructor.
        /// </summary>
        /// <remarks>
        /// Sizes and gases should probably go into a settings file.
        /// </remarks>
        public SkyForm()
        {
            InitializeComponent();

            AddSizeMenuItems();
            AddSpaceRatioMenuItems();

            AddHandlers();
            _initialized = true;

            PaintMe();
        }

        /// <summary>
        /// Add event handlers as the last initialisation step so that we don't have clicky user slowing down the process.
        /// </summary>
        void AddHandlers()
        {
            this.saveAs.Click += SaveAs_Click;

            this.humanCO2HighlightSelector.CheckedChanged += (s, e) => this.PaintMe();
            this.cO2HighlightSelector.CheckedChanged += (s, e) => this.PaintMe();

            this.DarkMode.Click += (s, e) =>
            {
                this.DarkMode.Checked = true;
                this.LightMode.Checked = false;
                BackgroundColour = Color.Black;
                PaintMe();
            };

            this.LightMode.Click += (s, e) =>
            {
                this.DarkMode.Checked = false;
                this.LightMode.Checked = true;
                BackgroundColour = Color.White;
                PaintMe();
            };

            this.PictureBox1.MouseDoubleClick += (s, e) => PaintMe();
            this.PictureBox1.MouseMove += (s, e) => mouseLocation.Text = $"Mouse:({e.X},{e.Y});";
        }

        /// <summary>
        /// Use the size list to generate a menu item for each size.
        /// </summary>
        private void AddSizeMenuItems()
        {
            foreach (var size in Sizes)
            {
                sizeSelector.DropDownItems.Add(CreateSizeMenuItem(size));
            }
        }

        /// <summary>
        /// Use the size list to generate a menu of gas:space ratios to offer.
        /// </summary>
        private void AddSpaceRatioMenuItems()
        {
            foreach (int ratio in SpaceRatios)
            {
                spaceRatioSelector.DropDownItems.Add(CreateSpaceRatioMenuItem(ratio));
            }
        }

        /// <summary>
        /// Change the canvas size and space ratio.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="spaceRatio"></param>
        private void ChangePictureSize(int width, int height, int spaceRatio)
        {
            CanvasSize = new Size(width, height);
            SpaceRatio = spaceRatio;
            this.PictureBox1.Size = CanvasSize;
            this.PaintMe();
            this.Invalidate();
        }

        /// <summary>
        /// Create a menu item for a specific canvas size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private ToolStripMenuItem CreateSizeMenuItem(SupportedSize size)
        {
            string menuText = $"{size.Width}x{size.Height} ({size.Name})";
            return new ToolStripMenuItem(menuText, (Image)null, SizeMenuItem_Clicked(size))
            {
                Checked = CanvasSize == size.CanvasSize,
                Tag = size.DefaultSpaceRatio.ToString()
            };
        }

        /// <summary>
        /// Create a menu item for a specific space ratio.
        /// </summary>
        /// <param name="spaceRatio"></param>
        /// <returns></returns>
        private ToolStripMenuItem CreateSpaceRatioMenuItem(int spaceRatio)
        {
            return new ToolStripMenuItem(spaceRatio.ToString(), (Image)null, SpaceRatio_Clicked(spaceRatio))
            {
                Checked = spaceRatio == SpaceRatio,
            };
        }

        /// <summary>
        /// Draw a primitive circle around a pixel.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="colour"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void EncirclePixel(Bitmap bitmap, Color colour, int x, int y)
        {
            bitmap.SetPixel(x - 2, y - 1, colour);
            bitmap.SetPixel(x - 2, y, colour);
            bitmap.SetPixel(x - 2, y + 1, colour);

            bitmap.SetPixel(x - 1, y + 2, colour);
            bitmap.SetPixel(x, y + 2, colour);
            bitmap.SetPixel(x + 1, y + 2, colour);

            bitmap.SetPixel(x + 2, y + 1, colour);
            bitmap.SetPixel(x + 2, y, colour);
            bitmap.SetPixel(x + 2, y - 1, colour);

            bitmap.SetPixel(x + 1, y - 2, colour);
            bitmap.SetPixel(x, y - 2, colour);
            bitmap.SetPixel(x - 1, y - 2, colour);
        }

        /// <summary>
        /// Paint the actual image.
        /// </summary>
        /// <remarks>
        /// This is down by drawing individual pixels to an in-memory image and then displaying the completed
        /// image.
        /// </remarks>
        private void PaintMe()
        {
            if (!_initialized)
                return;

            Bitmap bitmap = new(CanvasSize.Width, CanvasSize.Height);
            var graphics = Graphics.FromImage(bitmap);

            GasStatusLabel.Text = "Gases: ";
            humanLocations.Text = "Man: ";

            int bgi = BackgroundColour.ToArgb();
            graphics.Clear(BackgroundColour);

            var capacity = (CanvasSize.Width * CanvasSize.Height);

            int totalGasMolecules = 0;

            Random randomizer = new((int)(DateTime.Now.Ticks & 0x7FFFFFFF));

            foreach (var gas in Gases) // .OrderBy(g => g.Ratio))
            {
                int molecules = (int)Math.Round(capacity * gas.Ratio / SpaceRatio, 0, MidpointRounding.AwayFromZero);
                GasStatusLabel.Text += $"{gas.Name}: {molecules}; ";

                int overwrites = 0;
                for (int c = 0; c < molecules; c += 1)
                {
                    int x = randomizer.Next(1, CanvasSize.Width);
                    int y = randomizer.Next(1, CanvasSize.Height);

                    int escape = 0;
                    int pixel = bitmap.GetPixel(x, y).ToArgb();
                    while (pixel != bgi)
                    {
                        // escape if we've tried too many times and our current attempt is 
                        // the same colour.
                        if (++escape >= SpaceRatio && pixel == gas.ARGB)
                        {
                            // Debug.Print($"{escape} - ({x},{y})");
                            overwrites++;
                            break;
                        }

                        x += randomizer.Next(-SpaceRatio, SpaceRatio);
                        y += randomizer.Next(-SpaceRatio, SpaceRatio);

                        if (x < 0)
                            x = CanvasSize.Width + x;
                        if (y < 0)
                            y = CanvasSize.Height + y;
                        if (x >= CanvasSize.Width)
                            x -= CanvasSize.Width;
                        if (y >= CanvasSize.Height)
                            y -= CanvasSize.Height;
                        pixel = bitmap.GetPixel(x, y).ToArgb();
                    }

                    bitmap.SetPixel(x, y, gas.Colour);

                    if (gas.Index == GasIndex.GAS_ACO2)
                    {
                        humanLocations.Text += $"({x},{y});";
                    }

                    if ((gas.Index == GasIndex.GAS_CO2 && this.cO2HighlightSelector.Checked) ||
                        (gas.Index == GasIndex.GAS_ACO2 && this.humanCO2HighlightSelector.Checked))
                    {
                        EncirclePixel(bitmap, gas.Colour, x, y);
                    }

                    if (overwrites > 0)
                    {
                        System.Diagnostics.Debug.Print($"{gas.Name} overwrites: {overwrites}");
                    }
                }
                totalGasMolecules += molecules;
            }

            GasStatusLabel.Text += $"Canvas size: {capacity:0,000}; ";
            GasStatusLabel.Text += $"Total molecules: {totalGasMolecules:0,000}; ";
            GasStatusLabel.Text += $"Total space: {(capacity - totalGasMolecules):0,000}.";

            PictureBox1.Image = bitmap;
            this.Invalidate();
        }

        /// <summary>
        /// Save the current image to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAs_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = "BMP",
                Filter = "PNG Files|*.PNG",
                OverwritePrompt = true,
                Title = "Save image"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.PictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }

        /// <summary>
        /// Creates an event handler for when a Canvas Size menu item is clicked
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private EventHandler SizeMenuItem_Clicked(SupportedSize size)
        {
            return (s, e) =>
             {
                 ToolStripMenuItem mi = s as ToolStripMenuItem;

                 ChangePictureSize(size.CanvasSize.Width, size.CanvasSize.Height, size.DefaultSpaceRatio);
                 foreach (ToolStripMenuItem ddi in sizeSelector.DropDownItems)
                 {
                     ddi.Checked = ddi == mi;
                 }

                 foreach (ToolStripMenuItem ddi in spaceRatioSelector.DropDownItems)
                 {
                     ddi.Checked = string.Equals(ddi.Text, mi.Tag);
                 }
                 PaintMe();
             };
        }

        /// <summary>
        /// Creates an event handler for when a Space Ratio menu item is clicked.
        /// </summary>
        /// <param name="ratio"></param>
        /// <returns></returns>
        private EventHandler SpaceRatio_Clicked(int ratio)
        {
            return (s, e) =>
             {
                 ToolStripMenuItem mi = s as ToolStripMenuItem;
                 SpaceRatio = ratio;
                 foreach (ToolStripMenuItem ddi in spaceRatioSelector.DropDownItems)
                 {
                     ddi.Checked = ddi == mi;
                 }
                 PaintMe();
             };
        }

        private Color BackgroundColour { get; set; } = Color.Black;

        private Size CanvasSize { get; set; } = defaultSize.CanvasSize;

        private int SpaceRatio { get; set; } = defaultSize.DefaultSpaceRatio;
    }

    /// <summary>
    /// Enum for the gases we're mapping.
    /// </summary>
    /// <remarks>
    /// These are mostly of interest for the CO2 items, which can be highlighted.
    /// </remarks>
    internal enum GasIndex
    {
        GAS_N2,
        GAS_O2,
        GAS_Ar,
        GAS_H20,
        GAS_CO2,
        GAS_ACO2,
    }

    /// <summary>
    /// Describes a canvas size and default "space ratio" for the canvas size.
    /// </summary>
    /// <remarks>
    /// Gas Density:
    /// <para>
    /// Paraphrased from https://personal.ems.psu.edu/~bannon/moledyn.html:
    /// </para>
    /// <para>
    /// <em>
    /// Air molecules take up only 0.1% of the volume they occupy. 
    /// Thus air is a very sparse gas in which 99.9% of the atmosphere is vacuum.
    /// </em>
    /// </para>
    /// <para>
    /// So the 'technically correct 'Space Ratio' is 1000, i.e. only one in a 1000 pixels
    /// should be set. However, this doesn't necessarily visualise well, so we set smaller
    /// values that allow the visualisation of the space between atoms, even if they're 
    /// not quite big enough.
    /// </para>
    /// </remarks>    
    internal record struct SupportedSize(int Width, int Height, int DefaultSpaceRatio, string Name)
    {
        public readonly Size CanvasSize => new(Width, Height);
    }

    /// <summary>
    /// Describes a gas's name and ratio in the atmosphere, with some colour settings for
    /// making the image.
    /// </summary>
    /// <param name="Index"></param>
    /// <param name="Name"></param>
    /// <param name="Ratio"></param>
    /// <param name="Colour"></param>
    /// <param name="ARGB"></param>
    internal record struct Gas(GasIndex Index, string Name, double Ratio, Color Colour, int ARGB)
    {
    }
}
