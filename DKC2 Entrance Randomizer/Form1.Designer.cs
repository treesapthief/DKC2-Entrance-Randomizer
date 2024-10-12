namespace DKC2_Entrance_Randomizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_randomizer = new System.Windows.Forms.Panel();
            this.checkBox_race = new System.Windows.Forms.CheckBox();
            this.pictureBox_previewDixie = new System.Windows.Forms.PictureBox();
            this.pictureBox_previewDiddy = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_kongNumber = new System.Windows.Forms.Label();
            this.comboBox_kongNumber = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_checkpointStyle = new System.Windows.Forms.ComboBox();
            this.checkBox_devSpoilerLog = new System.Windows.Forms.CheckBox();
            this.comboBox_bosses = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_enemyRando = new System.Windows.Forms.ComboBox();
            this.Hair = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_hair = new System.Windows.Forms.ComboBox();
            this.comboBox_clothes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_music = new System.Windows.Forms.ComboBox();
            this.button_randomizeAll = new System.Windows.Forms.Button();
            this.textBox_custom = new System.Windows.Forms.TextBox();
            this.button_custom = new System.Windows.Forms.Button();
            this.comboBox_logic = new System.Windows.Forms.ComboBox();
            this.button_randomize = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_preview = new System.Windows.Forms.Timer(this.components);
            this.label_start = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel_randomizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_previewDixie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_previewDiddy)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel_randomizer
            // 
            this.panel_randomizer.Controls.Add(this.checkBox_race);
            this.panel_randomizer.Controls.Add(this.pictureBox_previewDixie);
            this.panel_randomizer.Controls.Add(this.pictureBox_previewDiddy);
            this.panel_randomizer.Controls.Add(this.button1);
            this.panel_randomizer.Controls.Add(this.label_kongNumber);
            this.panel_randomizer.Controls.Add(this.comboBox_kongNumber);
            this.panel_randomizer.Controls.Add(this.label8);
            this.panel_randomizer.Controls.Add(this.comboBox_checkpointStyle);
            this.panel_randomizer.Controls.Add(this.checkBox_devSpoilerLog);
            this.panel_randomizer.Controls.Add(this.comboBox_bosses);
            this.panel_randomizer.Controls.Add(this.label7);
            this.panel_randomizer.Controls.Add(this.label6);
            this.panel_randomizer.Controls.Add(this.label5);
            this.panel_randomizer.Controls.Add(this.label4);
            this.panel_randomizer.Controls.Add(this.comboBox_enemyRando);
            this.panel_randomizer.Controls.Add(this.Hair);
            this.panel_randomizer.Controls.Add(this.label3);
            this.panel_randomizer.Controls.Add(this.comboBox_hair);
            this.panel_randomizer.Controls.Add(this.comboBox_clothes);
            this.panel_randomizer.Controls.Add(this.label2);
            this.panel_randomizer.Controls.Add(this.label1);
            this.panel_randomizer.Controls.Add(this.comboBox_music);
            this.panel_randomizer.Controls.Add(this.button_randomizeAll);
            this.panel_randomizer.Controls.Add(this.textBox_custom);
            this.panel_randomizer.Controls.Add(this.button_custom);
            this.panel_randomizer.Controls.Add(this.comboBox_logic);
            this.panel_randomizer.Controls.Add(this.button_randomize);
            this.panel_randomizer.Location = new System.Drawing.Point(0, 27);
            this.panel_randomizer.Name = "panel_randomizer";
            this.panel_randomizer.Size = new System.Drawing.Size(284, 635);
            this.panel_randomizer.TabIndex = 2;
            this.panel_randomizer.Visible = false;
            // 
            // checkBox_race
            // 
            this.checkBox_race.AutoSize = true;
            this.checkBox_race.Location = new System.Drawing.Point(25, 5);
            this.checkBox_race.Name = "checkBox_race";
            this.checkBox_race.Size = new System.Drawing.Size(52, 17);
            this.checkBox_race.TabIndex = 26;
            this.checkBox_race.Text = "Race";
            this.toolTip1.SetToolTip(this.checkBox_race, "Disable spoiler log generation");
            this.checkBox_race.UseVisualStyleBackColor = true;
            // 
            // pictureBox_previewDixie
            // 
            this.pictureBox_previewDixie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_previewDixie.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_previewDixie.Image")));
            this.pictureBox_previewDixie.Location = new System.Drawing.Point(151, 210);
            this.pictureBox_previewDixie.Margin = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.pictureBox_previewDixie.Name = "pictureBox_previewDixie";
            this.pictureBox_previewDixie.Size = new System.Drawing.Size(121, 115);
            this.pictureBox_previewDixie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_previewDixie.TabIndex = 25;
            this.pictureBox_previewDixie.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox_previewDixie, "Dixie Color Preview");
            // 
            // pictureBox_previewDiddy
            // 
            this.pictureBox_previewDiddy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_previewDiddy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_previewDiddy.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_previewDiddy.Image")));
            this.pictureBox_previewDiddy.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_previewDiddy.InitialImage")));
            this.pictureBox_previewDiddy.Location = new System.Drawing.Point(10, 210);
            this.pictureBox_previewDiddy.Name = "pictureBox_previewDiddy";
            this.pictureBox_previewDiddy.Size = new System.Drawing.Size(119, 115);
            this.pictureBox_previewDiddy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_previewDiddy.TabIndex = 24;
            this.pictureBox_previewDiddy.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox_previewDiddy, "Diddy Color Preview");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_kongNumber
            // 
            this.label_kongNumber.AutoSize = true;
            this.label_kongNumber.Location = new System.Drawing.Point(98, 397);
            this.label_kongNumber.Name = "label_kongNumber";
            this.label_kongNumber.Size = new System.Drawing.Size(72, 13);
            this.label_kongNumber.TabIndex = 22;
            this.label_kongNumber.Text = "Kong Number";
            // 
            // comboBox_kongNumber
            // 
            this.comboBox_kongNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_kongNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_kongNumber.FormattingEnabled = true;
            this.comboBox_kongNumber.Items.AddRange(new object[] {
            "Default",
            "Force 2"});
            this.comboBox_kongNumber.Location = new System.Drawing.Point(52, 413);
            this.comboBox_kongNumber.Name = "comboBox_kongNumber";
            this.comboBox_kongNumber.Size = new System.Drawing.Size(163, 21);
            this.comboBox_kongNumber.TabIndex = 21;
            this.toolTip1.SetToolTip(this.comboBox_kongNumber, "Select number of Kongs to start each entrance with");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Checkpoint Style";
            // 
            // comboBox_checkpointStyle
            // 
            this.comboBox_checkpointStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_checkpointStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_checkpointStyle.FormattingEnabled = true;
            this.comboBox_checkpointStyle.Items.AddRange(new object[] {
            "Barrels (Standard)",
            "Entrance + Barrels"});
            this.comboBox_checkpointStyle.Location = new System.Drawing.Point(160, 353);
            this.comboBox_checkpointStyle.Name = "comboBox_checkpointStyle";
            this.comboBox_checkpointStyle.Size = new System.Drawing.Size(112, 21);
            this.comboBox_checkpointStyle.TabIndex = 19;
            this.toolTip1.SetToolTip(this.comboBox_checkpointStyle, "Select how checkpoints will be managed");
            // 
            // checkBox_devSpoilerLog
            // 
            this.checkBox_devSpoilerLog.AutoSize = true;
            this.checkBox_devSpoilerLog.Location = new System.Drawing.Point(176, 553);
            this.checkBox_devSpoilerLog.Name = "checkBox_devSpoilerLog";
            this.checkBox_devSpoilerLog.Size = new System.Drawing.Size(96, 17);
            this.checkBox_devSpoilerLog.TabIndex = 18;
            this.checkBox_devSpoilerLog.Text = "Dev spoiler log";
            this.checkBox_devSpoilerLog.UseVisualStyleBackColor = true;
            this.checkBox_devSpoilerLog.Visible = false;
            // 
            // comboBox_bosses
            // 
            this.comboBox_bosses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bosses.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_bosses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_bosses.FormattingEnabled = true;
            this.comboBox_bosses.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.comboBox_bosses.Location = new System.Drawing.Point(10, 353);
            this.comboBox_bosses.Name = "comboBox_bosses";
            this.comboBox_bosses.Size = new System.Drawing.Size(121, 21);
            this.comboBox_bosses.TabIndex = 17;
            this.toolTip1.SetToolTip(this.comboBox_bosses, "Bosses required to encounter K Rool \r\n(changes the cost of hints too!)");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Bosses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Logic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Music";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Enemy Randomizer";
            // 
            // comboBox_enemyRando
            // 
            this.comboBox_enemyRando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_enemyRando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_enemyRando.FormattingEnabled = true;
            this.comboBox_enemyRando.Items.AddRange(new object[] {
            "Default",
            "Randomized"});
            this.comboBox_enemyRando.Location = new System.Drawing.Point(10, 86);
            this.comboBox_enemyRando.Name = "comboBox_enemyRando";
            this.comboBox_enemyRando.Size = new System.Drawing.Size(121, 21);
            this.comboBox_enemyRando.TabIndex = 12;
            this.toolTip1.SetToolTip(this.comboBox_enemyRando, "Dynamic enemy randomizer");
            // 
            // Hair
            // 
            this.Hair.AutoSize = true;
            this.Hair.Location = new System.Drawing.Point(157, 147);
            this.Hair.Name = "Hair";
            this.Hair.Size = new System.Drawing.Size(58, 13);
            this.Hair.TabIndex = 11;
            this.Hair.Text = "Hair (Dixie)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Clothes";
            // 
            // comboBox_hair
            // 
            this.comboBox_hair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_hair.FormattingEnabled = true;
            this.comboBox_hair.Items.AddRange(new object[] {
            "Default",
            "Red",
            "White",
            "Purple",
            "Green",
            "Orange",
            "Black",
            "Custom"});
            this.comboBox_hair.Location = new System.Drawing.Point(151, 171);
            this.comboBox_hair.Name = "comboBox_hair";
            this.comboBox_hair.Size = new System.Drawing.Size(121, 21);
            this.comboBox_hair.TabIndex = 9;
            this.toolTip1.SetToolTip(this.comboBox_hair, "Color select (Dixie hair)");
            this.comboBox_hair.SelectedIndexChanged += new System.EventHandler(this.comboBox_hair_SelectedIndexChanged);
            // 
            // comboBox_clothes
            // 
            this.comboBox_clothes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_clothes.FormattingEnabled = true;
            this.comboBox_clothes.Items.AddRange(new object[] {
            "Default",
            "Lime Green",
            "Teal",
            "Yellow",
            "Purple",
            "White",
            "Pink",
            "Custom"});
            this.comboBox_clothes.Location = new System.Drawing.Point(10, 171);
            this.comboBox_clothes.Name = "comboBox_clothes";
            this.comboBox_clothes.Size = new System.Drawing.Size(121, 21);
            this.comboBox_clothes.TabIndex = 8;
            this.toolTip1.SetToolTip(this.comboBox_clothes, "Color select (clothes)");
            this.comboBox_clothes.SelectedIndexChanged += new System.EventHandler(this.comboBox_clothes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select colors";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter custom seed (1-99,999)";
            // 
            // comboBox_music
            // 
            this.comboBox_music.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_music.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_music.FormattingEnabled = true;
            this.comboBox_music.Items.AddRange(new object[] {
            "Default",
            "Randomized music"});
            this.comboBox_music.Location = new System.Drawing.Point(151, 86);
            this.comboBox_music.Name = "comboBox_music";
            this.comboBox_music.Size = new System.Drawing.Size(121, 21);
            this.comboBox_music.TabIndex = 5;
            this.toolTip1.SetToolTip(this.comboBox_music, "Tracks between stages (not bosses) are randomized");
            // 
            // button_randomizeAll
            // 
            this.button_randomizeAll.Location = new System.Drawing.Point(95, 590);
            this.button_randomizeAll.Name = "button_randomizeAll";
            this.button_randomizeAll.Size = new System.Drawing.Size(75, 36);
            this.button_randomizeAll.TabIndex = 4;
            this.button_randomizeAll.Text = "Randomize All";
            this.toolTip1.SetToolTip(this.button_randomizeAll, "Randomizes everything");
            this.button_randomizeAll.UseVisualStyleBackColor = true;
            this.button_randomizeAll.Click += new System.EventHandler(this.button_randomizeAll_Click);
            // 
            // textBox_custom
            // 
            this.textBox_custom.Location = new System.Drawing.Point(95, 479);
            this.textBox_custom.MaxLength = 5;
            this.textBox_custom.Name = "textBox_custom";
            this.textBox_custom.Size = new System.Drawing.Size(75, 20);
            this.textBox_custom.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_custom, "Enter custom seed");
            this.textBox_custom.TextChanged += new System.EventHandler(this.textBox_custom_TextChanged);
            this.textBox_custom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_custom_KeyDown);
            // 
            // button_custom
            // 
            this.button_custom.Location = new System.Drawing.Point(95, 515);
            this.button_custom.Name = "button_custom";
            this.button_custom.Size = new System.Drawing.Size(75, 23);
            this.button_custom.TabIndex = 2;
            this.button_custom.Text = "Customize";
            this.toolTip1.SetToolTip(this.button_custom, "Customizes your ROM based on the seed you entered and options selected");
            this.button_custom.UseVisualStyleBackColor = true;
            this.button_custom.Click += new System.EventHandler(this.button_custom_Click);
            // 
            // comboBox_logic
            // 
            this.comboBox_logic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_logic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_logic.FormattingEnabled = true;
            this.comboBox_logic.Items.AddRange(new object[] {
            "Easy Logic",
            "Hard Logic",
            "No Logic"});
            this.comboBox_logic.Location = new System.Drawing.Point(52, 26);
            this.comboBox_logic.Name = "comboBox_logic";
            this.comboBox_logic.Size = new System.Drawing.Size(167, 21);
            this.comboBox_logic.TabIndex = 1;
            this.toolTip1.SetToolTip(this.comboBox_logic, "Select Logic");
            // 
            // button_randomize
            // 
            this.button_randomize.Location = new System.Drawing.Point(95, 553);
            this.button_randomize.Name = "button_randomize";
            this.button_randomize.Size = new System.Drawing.Size(75, 23);
            this.button_randomize.TabIndex = 0;
            this.button_randomize.Text = "Randomize";
            this.toolTip1.SetToolTip(this.button_randomize, "Randomizes based on the options you selected");
            this.button_randomize.UseVisualStyleBackColor = true;
            this.button_randomize.Click += new System.EventHandler(this.button_randomize_Click);
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_start.Location = new System.Drawing.Point(58, 145);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(167, 26);
            this.label_start.TabIndex = 3;
            this.label_start.Text = "Goto File>Load!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 661);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.panel_randomizer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DKC2 Entrance Randomizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_randomizer.ResumeLayout(false);
            this.panel_randomizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_previewDixie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_previewDiddy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.Panel panel_randomizer;
        private System.Windows.Forms.Button button_randomize;
        private System.Windows.Forms.ComboBox comboBox_logic;
        private System.Windows.Forms.TextBox textBox_custom;
        private System.Windows.Forms.Button button_custom;
        private System.Windows.Forms.Button button_randomizeAll;
        private System.Windows.Forms.ComboBox comboBox_music;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Hair;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_hair;
        private System.Windows.Forms.ComboBox comboBox_clothes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_enemyRando;
        private System.Windows.Forms.ComboBox comboBox_bosses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_devSpoilerLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_checkpointStyle;
        private System.Windows.Forms.Label label_kongNumber;
        private System.Windows.Forms.ComboBox comboBox_kongNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox_previewDixie;
        private System.Windows.Forms.PictureBox pictureBox_previewDiddy;
        private System.Windows.Forms.Timer timer_preview;
        private System.Windows.Forms.Label label_start;
        private System.Windows.Forms.CheckBox checkBox_race;
    }
}

