using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKC2_Entrance_Randomizer
{
    public partial class Form1 : Form
    {
        Image backupDiddy;
        Image backupDixie;
        Image currentDiddy;
        Image currentDixie;
        
        // Create a new instance to use
        CustomMessageBox customMessageBox = new CustomMessageBox();

        // Default colors clothes
        public static Color backupColorDiddyBrightClothes;
        public static Color backupColorDiddyRegClothes;
        public static Color backupColorDiddyDimClothes;
        public static Color backupColorDixieBrightClothes;
        public static Color backupColorDixieRegClothes;
        public static Color backupColorDixieDimClothes;
        public static Color backupColorDixieBrightHair;
        public static Color backupColorDixieRegHair;
        public static Color backupColorDixieDimHair;

        // Last color
        public static Color lastColorDiddyBrightClothes;
        public static Color lastColorDiddyRegClothes;
        public static Color lastColorDiddyDimClothes;
        public static Color lastColorDixieBrightClothes;
        public static Color lastColorDixieRegClothes;
        public static Color lastColorDixieDimClothes;
        public static Color lastColorDixieBrightHair;
        public static Color lastColorDixieRegHair;
        public static Color lastColorDixieDimHair;


        ColorsClothes colorClothes;
        ColorsHair colorHair;

        // Make clothes global
        ColorDialog clothes = new ColorDialog();
        ColorDialog customHair = new ColorDialog();
        List<Int32> availableEntrances;
        ROM rom_;
        List<Int32> backupAvailableEntrances = new List<int>();
        public static Int32 seed;
        // Which logic did we choose?
        // 'Global'
        string[] selectedLogic;


        private void Randomize()
        {
            // Apply ASM before anything
            if (comboBox_bosses.SelectedIndex > 1)
            {
                ASM.ApplyPatch(ASM.ROMaddressesPricey, ASM.ROMvaluesPricey, rom_.rom);
            }

            // Store entrance tuple
            var entranceTuple = EntranceSetup();
            List<Entrance> entrances = entranceTuple.Item1;
            List<Int32> availableEntrances = entranceTuple.Item2;
            availableEntrances.AddRange(new Int32[] { 0x0300, 0x0400, 0x02f00, 0x0302, 0x0305, 0x0402, 0x0300 });
            backupAvailableEntrances.AddRange(availableEntrances);

            #region logic
            List<string> logic = new List<string>();
            logic.Add("Logic:");
            foreach (var entrance in entrances)
            {
                // Different exits
                foreach (var exit in entrance.exits)
                {
                    string e = Entrance.nameByCompleteCode[exit];
                    e = e.Contains("(") ? e : e + " (Level exit)";
                    logic.Add($"Starting at {entrance.name}, you can reach {e}");
                }
                logic.Add("");
            }
            #endregion

            if (comboBox_logic.SelectedIndex != 2)
            {
                ApplySanity(entrances);
            }
            else
            {
                // Randomize entrances
                foreach (var entrance in entrances)
                {
                    entrance.RandomizeEntrance(rom_, availableEntrances);
                }

                logic = new List<string>()
                {
                    "No logic to be found :("
                };

            }

            // Do cranky hints before spoiler log
            CrankyHints hints = new CrankyHints(rom_, entrances);

            #region spoilerlog
            List<String> spoilerLog = new List<String>();

            spoilerLog.Add("// Seed: " + seed.ToString());
            spoilerLog.Add("===========================================");
            spoilerLog.Add("================SPOILER LOG================");
            spoilerLog.Add("===========================================");
            spoilerLog.Add("");

            spoilerLog.Add("*******************************************");
            spoilerLog.Add("****************CRANKY HINTS***************");
            spoilerLog.Add("*******************************************");
            spoilerLog.AddRange(hints.hints);
            spoilerLog.Add("");


            spoilerLog.Add("*******************************************");
            spoilerLog.Add("*******************BOSSES******************");
            spoilerLog.Add("*******************************************");
            spoilerLog.Add("Krow w1:");
            spoilerLog.Add(entrances[0].GenerateSpoilerString(0x0900, rom_));
            spoilerLog.Add("");
            spoilerLog.Add("Kleever w2:");
            spoilerLog.Add(entrances[0].GenerateSpoilerString(0x2100, rom_));
            spoilerLog.Add("");
            spoilerLog.Add("Kudgel w3:");
            spoilerLog.Add(entrances[0].GenerateSpoilerString(0x6300, rom_));
            spoilerLog.Add("");
            spoilerLog.Add("King Zing w4:");
            spoilerLog.Add(entrances[0].GenerateSpoilerString(0x6000, rom_));
            spoilerLog.Add("");
            spoilerLog.Add("Kreepy Krow w5:");
            spoilerLog.Add(entrances[0].GenerateSpoilerString(0x0d00, rom_));
            spoilerLog.Add("");
            spoilerLog.Add("K Rool w7:");
            spoilerLog.Add(entrances[0].GenerateSpoilerString(0x6100, rom_));


            #endregion
            if (comboBox_music.SelectedItem.ToString() == "Randomized music")
            {
                foreach (var entrance in entrances)
                {
                    entrance.RandomizeSong(rom_);
                }
            }
            else
            {
                foreach (var entrance in entrances)
                {
                    entrance.WriteOriginalSong(rom_);
                }
            }


            // Apply enemy rando?
            int tempFlags = 0;
            // Enemy Rando 
            tempFlags = (int)(comboBox_enemyRando.SelectedIndex == 1 ? (tempFlags | 1) : tempFlags);
            // Checkpoint save
            tempFlags = (int)(comboBox_checkpointStyle.SelectedIndex == 1 ? (tempFlags | 2) : tempFlags);
            // Kong #
            tempFlags = (int)(comboBox_kongNumber.SelectedIndex == 1 ? (tempFlags | 4) : tempFlags);
            // Which logic?
            tempFlags |= (comboBox_logic.SelectedIndex == 0 ? 8 : 0);
            rom_.Write16(0x3efb9d, tempFlags);

            /*
             * 
            */

            // Apply before rom is randomized
            colorClothes.chooseColor[comboBox_clothes.SelectedIndex].Apply(0x18);

            colorHair.chooseColor[comboBox_hair.SelectedIndex].Apply(0x12);




            // Fix head color
            ColorChoice.ChangeHeadColor(rom_.rom);

            var bosses = comboBox_bosses.SelectedIndex + 2;

            // Force screech's and rambi rumble music to be unaltered
            rom_.rom[Entrance.musicLUTStart + 0x2f] = 9;
            rom_.rom[Entrance.musicLUTStart + 0x2] = 0xb;

            rom_.Write16(0x32fb87, bosses);

            string[] logicVarient = new string[]
            {
                "Easy",
                "Hard",
                "None"
            };
            string fileAddition = $"Seed - {seed} Logic - {logicVarient[comboBox_logic.SelectedIndex]}";
            fileAddition += $" Bosses - {bosses}";

            // Is dev checked?
            if (checkBox_devSpoilerLog.Checked)
            {
                spoilerLog.Add("\n\n\n");
                spoilerLog.Add("Dev spoiler log");

                // If so, generate the entranced tied to each exit
                foreach (var entrance in entrances)
                {
                    spoilerLog.Add($"{Entrance.nameByCompleteCode[entrance.completeCode]} goes to {Entrance.nameByCompleteCode[entrance.currentStage]}");
                }
            }

            // Write strings to rom
            rom_.WriteString(0x3efbac, Version.GetVersion());
            rom_.WriteString(0x3efbca, seed.ToString());
            rom_.WriteString(0x3efbe4, logicVarient[comboBox_logic.SelectedIndex]);
            rom_.WriteString(0x3efc02, comboBox_bosses.SelectedItem.ToString());

            // Clear add to file
            fileAddition = $"{Version.GetVersion()} for seed {seed}";

            // 0x3efba5 random seed number
            rom_.Write16(0x3efba5, seed);

            rom_.SaveRandoROM(new Save(seed, spoilerLog, logic,  fileAddition), checkBox_race.Checked);
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rom_ = new ROM();
            rom_.Load();
            Init();
        }
        private void Init()
        {
            if (ROM.loadROMSuccess)
            {
                // Turn off hint
                label_start.Visible = false;

                // Setup our default colors
                backupColorDiddyBrightClothes = ReadColorFromROM(Defaults.diddyPal + 0x18);
                backupColorDiddyRegClothes = ReadColorFromROM(Defaults.diddyPal + 0x16);
                backupColorDiddyDimClothes = ReadColorFromROM(Defaults.diddyPal + 0x14);
                backupColorDixieBrightClothes = ReadColorFromROM(Defaults.dixiePal + 0x18);
                backupColorDixieRegClothes = ReadColorFromROM(Defaults.dixiePal + 0x16);
                backupColorDixieDimClothes = ReadColorFromROM(Defaults.dixiePal + 0x14);
                backupColorDixieBrightHair = ReadColorFromROM(Defaults.dixiePal + 0x12);
                backupColorDixieRegHair = ReadColorFromROM(Defaults.dixiePal + 0x10);
                backupColorDixieDimHair = ReadColorFromROM(Defaults.dixiePal + 0xe);

                // Set first else bad things happen
                colorHair = new ColorsHair(rom_, new byte[] { });
                colorHair.chooseColor[0].Apply(0x12);

                // Last color
                lastColorDiddyBrightClothes = ReadColorFromROM(Defaults.diddyPal + 0x18);
                lastColorDiddyRegClothes = ReadColorFromROM(Defaults.diddyPal + 0x16);
                lastColorDiddyDimClothes = ReadColorFromROM(Defaults.diddyPal + 0x14);
                lastColorDixieBrightClothes = ReadColorFromROM(Defaults.dixiePal + 0x18);
                lastColorDixieRegClothes = ReadColorFromROM(Defaults.dixiePal + 0x16);
                lastColorDixieDimClothes = ReadColorFromROM(Defaults.dixiePal + 0x14);
                lastColorDixieBrightHair = ReadColorFromROM(Defaults.dixiePal + 0x12);
                lastColorDixieRegHair = ReadColorFromROM(Defaults.dixiePal + 0x10);
                lastColorDixieDimHair = ReadColorFromROM(Defaults.dixiePal + 0x0e);


                ASM.ApplyPatch(ColorsClothes.dixieFixAddresses, ColorsClothes.dixieFixValues, rom_.rom);

                panel_randomizer.Visible = true;

                // Prevent multiple ROM use
                loadToolStripMenuItem.Enabled = false;

                // Set all comboboxes to 0
                SetAllTo0(this);

                comboBox_bosses.SelectedIndex = 3;

                textBox_custom.Focus();

                // Enable timer
                timer_preview.Enabled = true;

            }

        }

        // Set default indexes to 0
        private void SetAllTo0 (Control ctrl)
        {
            // Is this a combobox?
            ComboBox cmbBox = ctrl as ComboBox;
            if (cmbBox == null)
            {
                foreach (Control child in ctrl.Controls)
                {
                    SetAllTo0(child);
                }
            }
            else
            {
                cmbBox.SelectedIndex = 0;
            }
        }

        private void button_randomize_Click(object sender, EventArgs e)
        {

            var tempSeed = new Random(Environment.TickCount);
            int[] seedNum = new int[]
            {
                tempSeed.Next(100000 / 3 * 0,100000 / 3 * 1),
                tempSeed.Next(100000 / 3 * 1,100000 / 3 * 2),
                tempSeed.Next(100000 / 3 * 2,100000 / 3 * 3)
            };
            seed = seedNum[comboBox_logic.SelectedIndex];

            RandoInit();
            //customMessageBox.ShowDialog();
            MessageBox.Show("Randomized!");
            SetAllTo0(this);
            comboBox_bosses.SelectedIndex = 3;


        }


        public void RandoInit()
        {
            // Change cursor so we don't have a silent program
            Cursor.Current = Cursors.WaitCursor;

            // Set up like this so custom entry can be a thing
            Defaults.rng = new Random(seed);

            Randomize();



            // Be sure to empty because static!
            Defaults.rng = null;
            Entrance.nameByCompleteCode = new Dictionary<int, string>();
            Entrance.songList = new List<byte>();
            Entrance.sanity = new Dictionary<int, int[]>();
            ColorChoice.visited = false;
            rom_.RestoreFromBackup();
            backupAvailableEntrances = new List<int>();

            // Fix our cursor
            Cursor.Current = Cursors.Default;

        }

        // Enter custom seed logic
        private void textBox_custom_TextChanged(object sender, EventArgs e)
        {
            // Do we equal 0?
            if (textBox_custom.Text.Length == 0)
            {
                comboBox_logic.Enabled = true;
                button_randomize.Enabled = true;
                button_randomizeAll.Enabled = true;
                comboBox_logic.SelectedIndex = 0;
            }
            else
            {
                comboBox_logic.Enabled = false;
                button_randomize.Enabled = false;
                button_randomizeAll.Enabled = false;

                // Try converting contents of textbox to int
                try
                {
                    var textAsNumber = Convert.ToInt32(textBox_custom.Text);
                    if (textAsNumber < 100000 / 3 * 1)
                    {
                        comboBox_logic.SelectedIndex = 0;
                    }
                    else if (textAsNumber < 100000 / 3 * 2)
                    {
                        comboBox_logic.SelectedIndex = 1;
                    }
                    else
                    {
                        comboBox_logic.SelectedIndex = 2;
                    }


                }
                catch (Exception ex)
                {

                }
            }
        }

        private Tuple<List<Entrance>, List<Int32>> EntranceSetup()
        {
            List<Entrance> entrances = new List<Entrance>();
            availableEntrances = new List<int>();

            // Use array to make easier
            string[][] arrayOfLogics = new string[][]
            {
                Defaults.entranceLogicForwardRaw,
                Defaults.entranceLogicHardcoreRaw,
                Defaults.entranceNoLogicRaw
            };
            selectedLogic = arrayOfLogics[comboBox_logic.SelectedIndex];            

            // 0x38dd8e - matrix start
            // 0x38df9a - array from matrix start

            // Loop through raw data
            foreach (var line in selectedLogic)
            {
                // Split Pirate Panic	03 06 00 02,03,04,05,00
                // Level name, LevelCode, SongCode, Entrance, Available exits
                string[] splitLine = line.Split('\t');
                string levelName = splitLine[0];
                byte levelCode = Convert.ToByte(splitLine[1], 16);
                byte songCode = Convert.ToByte(splitLine[2], 16);
                byte entrance = Convert.ToByte(splitLine[3], 16);
                List<int> exitsAsList = new List<int>();

                foreach (var exit in splitLine[4].Split(','))
                {
                    exitsAsList.Add((levelCode << 8) | Convert.ToByte(exit, 16));
                }

                // Calculate address by consulting ROM

                // 0x38dd8e - matrix start
                // 0x38df9a - array from matrix start

                // Where are we going?
                // Look up in matrix. First index LevelCode, second ParentEntrance
                // lda $=index
                // asl a
                // tax
                // lda $=Matrix,x
                // tax 
                // Second index stored as * 2
                // lda ($=2ndIndex),x
                Int32 matrixAddress = rom_.Read16(0x38dd8e + (levelCode << 1));
                Int32 address = (0x380000 | matrixAddress) + (entrance << 1);


                // Complete code has level code and entrance
                Int32 completeCode = (levelCode << 8) | entrance;
                availableEntrances.Add(completeCode);
                entrances.Add(new Entrance(address, levelName, levelCode, songCode, entrance, exitsAsList.ToArray()));
            }
            return new Tuple<List<Entrance>, List<int>>(entrances, availableEntrances);
        }
        private void ApplySanity (List<Entrance> entrances)
        {

            #region sanity
            Int32[] bosses = new Int32[] { 0x0900, 0x2100, 0x6300, 0x6000, 0x0d00, 0x6100 };
            List<bool> canGetAnywhere;
            List<bool[]> accessible;
            do
            {
                accessible = new List<bool[]>();

                // Refill each time
                availableEntrances = new List<int>();
                availableEntrances.AddRange(backupAvailableEntrances);
                canGetAnywhere = new List<bool>();
                foreach (var entrance in entrances)
                {
                    entrance.RandomizeEntrance(rom_, availableEntrances);
                }
                foreach (var entrance in entrances)
                {
                    bool[] canGetArray = entrance.Sanity(rom_);
                    accessible.Add(canGetArray);

                    if (!bosses.All(e => canGetArray[e]))
                    {
                        break;
                    }

                }

            } while (!accessible.All(e => e[0x900] && e[0xd00] && e[0x2100] && e[0x6000] && e[0x6100] && e[0x6300]));
            #endregion
        }

        private void EnterCustom()
        {

            // Get input text
            int customSeed;
            try
            {
                customSeed = Convert.ToInt32(textBox_custom.Text);
                if (customSeed == 0)
                {
                    throw new System.ArgumentException("Seed can't be zero!");
                }

                // Which logic are we?
                if (customSeed < 100000 / 3 * 1)
                {
                    comboBox_logic.SelectedIndex = 0;
                }
                else if (customSeed < 100000 / 3 * 2)
                {
                    comboBox_logic.SelectedIndex = 1;
                }
                else
                {
                    comboBox_logic.SelectedIndex = 2;
                }
                seed = customSeed;
                RandoInit();
                MessageBox.Show("Customized!");

                SetAllTo0(this);
                comboBox_bosses.SelectedIndex = 3;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid entry\n" + ex.Message);
            }
            textBox_custom.Clear();
        }

        private void button_custom_Click(object sender, EventArgs e)
        {
            EnterCustom();
        }

        private void textBox_custom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                EnterCustom();
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Version.OnLoad();
            this.Text = "DKC2 Entrance Randomizer " + Version.GetVersion();

            // Backup our pictures
            backupDiddy = (Image)pictureBox_previewDiddy.Image.Clone();
            backupDixie = (Image)pictureBox_previewDixie.Image.Clone();

            // Current pictures
            currentDiddy = (Image)pictureBox_previewDiddy.Image.Clone();
            currentDixie = (Image)pictureBox_previewDixie.Image.Clone();

        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version.ManualCheck();
        }

        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/61a33ecd-98f2-4ad7-8077-7e8aaeb0b0b3/uncheck-all-checkboxes?forum=csharpgeneral
        private void GetAllComboBoxes(Control ctrl, bool randomize)
        {
            ComboBox cmbBox = ctrl as ComboBox;
            if (cmbBox == null)
            {
                foreach (Control child in ctrl.Controls)
                {
                    GetAllComboBoxes(child, randomize);
                }
            }
            else
            {
                if (randomize)
                {
                    if (cmbBox.Name == "comboBox_clothes" || cmbBox.Name == "comboBox_hair")
                    {
                        cmbBox.SelectedIndex = new Random().Next(0, cmbBox.Items.Count - 1);

                    }
                    else
                    {
                        cmbBox.SelectedIndex = new Random().Next(0, cmbBox.Items.Count);
                    }
                }
                else
                {
                    cmbBox.SelectedIndex = 0;
                }

            }
        }

        private void button_randomizeAll_Click(object sender, EventArgs e)
        {
            // Randomize every combobox
            GetAllComboBoxes(this, true);
            // Select a new random seed
            var tempRandom = new Random(Environment.TickCount);
            // Which logic are we?
            // Decide seed based on logic
            if (comboBox_logic.SelectedIndex == 0)
            {
                seed = tempRandom.Next(100000 / 3 * 0, 100000 / 3 * 1);
            }
            else if (comboBox_logic.SelectedIndex == 1)
            {
                seed = tempRandom.Next(100000 / 3 * 1, 100000 / 3 * 2);

            }
            else if (comboBox_logic.SelectedIndex == 2)
            {
                seed = tempRandom.Next(100000 / 3 * 2, 100000 / 3 * 3);

            }
            RandoInit();

            // Set all back to default
            GetAllComboBoxes(this, false);

            SetAllTo0(this);


            MessageBox.Show($"Fully randomized!");

            comboBox_bosses.SelectedIndex = 3;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("This is a randomizer for dkc2 created by Rainbowsprinklez.\n\nPlease send all inquiries to mikemingrone@gmail.com", "DKC2 Entrance Randomizer");

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        // -----------------------------------------------------------
        // DEBUG
        private void button1_Click(object sender, EventArgs e)
        {
            // Check all (most) seeds
            var x = 1;
            while (x < 10000)
            {
                seed = x++;
                RandoInit();
            }
            MessageBox.Show("Cleared");

        }

        private void comboBox_clothes_SelectedIndexChanged(object sender, EventArgs e)
        {   
            
            if (comboBox_clothes.SelectedItem.ToString() == "Custom")
            {
                // Pop open a color menu
                clothes.ShowDialog();

            }

            // Update 

            // Get the rgb from the color box
            byte rClothes = (byte)(clothes.Color.R * 0x1f / 0xff);
            byte gClothes = (byte)(clothes.Color.G * 0x1f / 0xff);
            byte bClothes = (byte)(clothes.Color.B * 0x1f / 0xff);
            // Add to arr
            byte[] arr = new byte[] { rClothes, gClothes, bClothes };
            colorClothes = new ColorsClothes(rom_, arr);

            // Save changes
            colorClothes.chooseColor[comboBox_clothes.SelectedIndex].SaveColors(0x18);

            UpdateColors();

        }

        private Image ChangeImage (Image img, Dictionary<Color, Color> dict)
        {
            Bitmap bmp = (Bitmap)img;
            
            // Loop through image
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    // Get current pixel
                    var curr = bmp.GetPixel(x, y);

                    // Is current in our dictionary?
                    if (dict.TryGetValue(curr, out Color changeTo))
                    {
                        bmp.SetPixel(x, y, changeTo);
                    }

                }
            }


            return bmp;

        }

        private Color ReadColorFromROM (int address)
        {
            int value = rom_.Read16(address);
            // Convert to snes format and * by 8 to put in snes9x format
            byte r = (byte)(((value >> 0) & 0x1f) << 3);
            byte g = (byte)(((value >> 5) & 0x1f) << 3);
            byte b = (byte)(((value >> 10) & 0x1f) << 3);


            return Color.FromArgb(r, g, b);
        }

        private void comboBox_hair_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_hair.SelectedItem.ToString() == "Custom")
            {
                // Pop open a color menu
                customHair.ShowDialog();
            }

            // Update 

            // Get the rgb from the color box
            byte rHair = (byte)(customHair.Color.R * 0x1f / 0xff);
            byte gHair = (byte)(customHair.Color.G * 0x1f / 0xff);
            byte bHair = (byte)(customHair.Color.B * 0x1f / 0xff);
            // Add to arr
            byte[] arr = new byte[] { rHair, gHair, bHair };
            colorHair = new ColorsHair(rom_, arr);

            // Save changes
            colorHair.chooseColor[comboBox_hair.SelectedIndex].SaveColors(0x12);


            UpdateColorsHair();

        }

        private void UpdateColors()
        {
            #region Clothes
            // So we have access
            var longText = colorClothes.chooseColor[comboBox_clothes.SelectedIndex];


            Color dBright = longText.GetColorBrightDiddy();
            Color dReg = longText.GetColorRegDiddy();
            Color dDim = longText.GetColorDimDiddy();

            var img = (Image)pictureBox_previewDiddy.Image.Clone();
            Dictionary<Color, Color> colorDict = new Dictionary<Color, Color>()
            {
                [lastColorDiddyBrightClothes] = dBright,
                [lastColorDiddyRegClothes] = dReg,
                [lastColorDiddyDimClothes] = dDim,
            };
            img = ChangeImage(img, colorDict);

            var imgDix = (Image)pictureBox_previewDixie.Image.Clone();
            Dictionary<Color, Color> colorDictDixie = new Dictionary<Color, Color>()
            {
                [lastColorDixieBrightClothes] = longText.GetColorBrightDixie(),
                [lastColorDixieRegClothes] = longText.GetColorRegDixie(),
                [lastColorDixieDimClothes] = longText.GetColorDimDixie(),
            };
            imgDix = ChangeImage(imgDix, colorDictDixie);
            lastColorDiddyBrightClothes = dBright;
            lastColorDiddyRegClothes = dReg;
            lastColorDiddyDimClothes = dDim;
            lastColorDixieBrightClothes = longText.GetColorBrightDixie();
            lastColorDixieRegClothes = longText.GetColorRegDixie();
            lastColorDixieDimClothes = longText.GetColorDimDixie();


            pictureBox_previewDiddy.Image = img;
            pictureBox_previewDixie.Image = imgDix;

            currentDiddy = (Image)img.Clone();
            currentDixie = (Image)imgDix.Clone();



            #endregion 

        }
        private void UpdateColorsHair()
        {
            #region Hair
            // So we have access
            var longText = colorHair.chooseColor[comboBox_hair.SelectedIndex];

            var imgDix = (Image)pictureBox_previewDixie.Image.Clone();
            Dictionary<Color, Color> colorDictDixie = new Dictionary<Color, Color>()
            {

                [lastColorDixieBrightHair] = longText.GetColorBrightDixieHair(),
                [lastColorDixieRegHair] = longText.GetColorRegDixieHair(),
                [lastColorDixieDimHair] = longText.GetColorDimDixieHair()
            };
            imgDix = ChangeImage(imgDix, colorDictDixie);
            lastColorDixieBrightHair = longText.GetColorBrightDixieHair();
            lastColorDixieRegHair = longText.GetColorRegDixieHair();
            lastColorDixieDimHair = longText.GetColorDimDixieHair();


            pictureBox_previewDixie.Image = imgDix;
            #endregion 

        }
    }
}
