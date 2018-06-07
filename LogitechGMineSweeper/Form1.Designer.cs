using System.Windows.Forms;

namespace LogitechGMineSweeper
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.timer1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.resetSettings = new System.Windows.Forms.Button();
            this.resetColors = new System.Windows.Forms.Button();
            this.resetStats = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.bCounter = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.bNew = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.b6 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.b5 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.b4 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.b3 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.b2 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.b1 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.b0 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.bClear = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.bBomb = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.bFlag = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.bDefeat = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.bWin = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.bDefault = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.lBombsTotal = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lBombsLosses = new System.Windows.Forms.Label();
            this.lWinsX = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lTotal = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lLosses = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lStats = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.AutoSize = true;
            this.timer1.BackColor = System.Drawing.Color.Transparent;
            this.timer1.Location = new System.Drawing.Point(258, 9);
            this.timer1.Name = "timer1";
            this.timer1.Size = new System.Drawing.Size(34, 13);
            this.timer1.TabIndex = 4;
            this.timer1.Text = "00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(219, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Time:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.resetSettings);
            this.tabPage4.Controls.Add(this.resetColors);
            this.tabPage4.Controls.Add(this.resetStats);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(276, 244);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Reset";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // resetSettings
            // 
            this.resetSettings.Location = new System.Drawing.Point(94, 84);
            this.resetSettings.Name = "resetSettings";
            this.resetSettings.Size = new System.Drawing.Size(87, 23);
            this.resetSettings.TabIndex = 18;
            this.resetSettings.Text = "Settings";
            this.resetSettings.UseVisualStyleBackColor = true;
            this.resetSettings.Click += new System.EventHandler(this.resetSettings_Click);
            // 
            // resetColors
            // 
            this.resetColors.Location = new System.Drawing.Point(4, 84);
            this.resetColors.Name = "resetColors";
            this.resetColors.Size = new System.Drawing.Size(84, 23);
            this.resetColors.TabIndex = 17;
            this.resetColors.Text = "Colors";
            this.resetColors.UseVisualStyleBackColor = true;
            this.resetColors.Click += new System.EventHandler(this.resetColors_Click);
            // 
            // resetStats
            // 
            this.resetStats.Location = new System.Drawing.Point(187, 84);
            this.resetStats.Name = "resetStats";
            this.resetStats.Size = new System.Drawing.Size(84, 23);
            this.resetStats.TabIndex = 16;
            this.resetStats.Text = "Statistics";
            this.resetStats.UseVisualStyleBackColor = true;
            this.resetStats.Click += new System.EventHandler(this.resetStats_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(94, 140);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Reset All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Controls.Add(this.bCounter);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.bNew);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.b6);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.b5);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.b4);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.b3);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.b2);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.b1);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.b0);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.bClear);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.bBomb);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.bFlag);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.bDefeat);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.bWin);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.bDefault);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(276, 244);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Colors";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(76, 219);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 33;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 223);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 15);
            this.label30.TabIndex = 32;
            this.label30.Text = "Shift Key:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(121, 223);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(86, 15);
            this.label28.TabIndex = 31;
            this.label28.Text = "Bomb Counter:";
            // 
            // bCounter
            // 
            this.bCounter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCounter.Location = new System.Drawing.Point(240, 219);
            this.bCounter.Name = "bCounter";
            this.bCounter.Size = new System.Drawing.Size(23, 23);
            this.bCounter.TabIndex = 30;
            this.bCounter.UseVisualStyleBackColor = true;
            this.bCounter.Click += new System.EventHandler(this.bCounter_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(121, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "New Game Key:";
            // 
            // bNew
            // 
            this.bNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNew.Location = new System.Drawing.Point(240, 187);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(23, 23);
            this.bNew.TabIndex = 28;
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 15);
            this.label15.TabIndex = 27;
            this.label15.Text = "6:";
            // 
            // b6
            // 
            this.b6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b6.Location = new System.Drawing.Point(76, 189);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(23, 23);
            this.b6.TabIndex = 26;
            this.b6.UseVisualStyleBackColor = true;
            this.b6.Click += new System.EventHandler(this.b6_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 163);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "5:";
            // 
            // b5
            // 
            this.b5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b5.Location = new System.Drawing.Point(76, 158);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(23, 23);
            this.b5.TabIndex = 24;
            this.b5.UseVisualStyleBackColor = true;
            this.b5.Click += new System.EventHandler(this.b5_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 133);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 15);
            this.label17.TabIndex = 23;
            this.label17.Text = "4:";
            // 
            // b4
            // 
            this.b4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b4.Location = new System.Drawing.Point(76, 129);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(23, 23);
            this.b4.TabIndex = 22;
            this.b4.UseVisualStyleBackColor = true;
            this.b4.Click += new System.EventHandler(this.b4_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 15);
            this.label18.TabIndex = 21;
            this.label18.Text = "3:";
            // 
            // b3
            // 
            this.b3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b3.Location = new System.Drawing.Point(76, 100);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(23, 23);
            this.b3.TabIndex = 20;
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.b3_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 72);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(16, 15);
            this.label19.TabIndex = 19;
            this.label19.Text = "2:";
            // 
            // b2
            // 
            this.b2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b2.Location = new System.Drawing.Point(76, 68);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(23, 23);
            this.b2.TabIndex = 18;
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 42);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(16, 15);
            this.label20.TabIndex = 17;
            this.label20.Text = "1:";
            // 
            // b1
            // 
            this.b1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b1.Location = new System.Drawing.Point(76, 38);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(23, 23);
            this.b1.TabIndex = 16;
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 15);
            this.label21.TabIndex = 15;
            this.label21.Text = "0:";
            // 
            // b0
            // 
            this.b0.BackColor = System.Drawing.Color.Transparent;
            this.b0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b0.Location = new System.Drawing.Point(76, 7);
            this.b0.Name = "b0";
            this.b0.Size = new System.Drawing.Size(23, 23);
            this.b0.TabIndex = 14;
            this.b0.UseVisualStyleBackColor = false;
            this.b0.Click += new System.EventHandler(this.b0_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(121, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Covered Field:";
            // 
            // bClear
            // 
            this.bClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bClear.Location = new System.Drawing.Point(240, 158);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(23, 23);
            this.bClear.TabIndex = 10;
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(121, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Bomb Field:";
            // 
            // bBomb
            // 
            this.bBomb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBomb.Location = new System.Drawing.Point(240, 129);
            this.bBomb.Name = "bBomb";
            this.bBomb.Size = new System.Drawing.Size(23, 23);
            this.bBomb.TabIndex = 8;
            this.bBomb.UseVisualStyleBackColor = true;
            this.bBomb.Click += new System.EventHandler(this.bBomb_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(121, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 15);
            this.label13.TabIndex = 7;
            this.label13.Text = "Flag Field:";
            // 
            // bFlag
            // 
            this.bFlag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bFlag.Location = new System.Drawing.Point(240, 97);
            this.bFlag.Name = "bFlag";
            this.bFlag.Size = new System.Drawing.Size(23, 23);
            this.bFlag.TabIndex = 6;
            this.bFlag.UseVisualStyleBackColor = true;
            this.bFlag.Click += new System.EventHandler(this.bFlag_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(121, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Background Defeat:";
            // 
            // bDefeat
            // 
            this.bDefeat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bDefeat.Location = new System.Drawing.Point(240, 68);
            this.bDefeat.Name = "bDefeat";
            this.bDefeat.Size = new System.Drawing.Size(23, 23);
            this.bDefeat.TabIndex = 4;
            this.bDefeat.UseVisualStyleBackColor = true;
            this.bDefeat.Click += new System.EventHandler(this.bDefeat_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Background Win:";
            // 
            // bWin
            // 
            this.bWin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bWin.Location = new System.Drawing.Point(240, 36);
            this.bWin.Name = "bWin";
            this.bWin.Size = new System.Drawing.Size(23, 23);
            this.bWin.TabIndex = 2;
            this.bWin.UseVisualStyleBackColor = true;
            this.bWin.Click += new System.EventHandler(this.bWin_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Background Default:";
            // 
            // bDefault
            // 
            this.bDefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bDefault.Location = new System.Drawing.Point(240, 7);
            this.bDefault.Name = "bDefault";
            this.bDefault.Size = new System.Drawing.Size(23, 23);
            this.bDefault.TabIndex = 0;
            this.bDefault.UseVisualStyleBackColor = true;
            this.bDefault.Click += new System.EventHandler(this.bDefault_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(30, 135);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(194, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Background Color for Shift Keys:";
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(34, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Easy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 7.8F);
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bombs:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 7.8F);
            this.label2.Location = new System.Drawing.Point(31, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keyboard Layout:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Open Sans", 7.8F);
            this.numericUpDown1.Location = new System.Drawing.Point(179, 46);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(45, 22);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TabStop = false;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.numericUpDown1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseWheel);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Open Sans", 7.8F);
            this.button3.Location = new System.Drawing.Point(162, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(62, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Hard";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Open Sans", 7.8F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(45, 22);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(98, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Medium";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Open Sans", 7.8F);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 271);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.lBombsTotal);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.lBombsLosses);
            this.tabPage2.Controls.Add(this.lWinsX);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.lTotal);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.lLosses);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.lStats);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(276, 244);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(42, 210);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 15);
            this.label23.TabIndex = 30;
            this.label23.Text = "Total Games:";
            // 
            // lBombsTotal
            // 
            this.lBombsTotal.Location = new System.Drawing.Point(173, 210);
            this.lBombsTotal.Name = "lBombsTotal";
            this.lBombsTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lBombsTotal.Size = new System.Drawing.Size(81, 15);
            this.lBombsTotal.TabIndex = 29;
            this.lBombsTotal.Text = "2";
            this.lBombsTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(42, 190);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 15);
            this.label29.TabIndex = 28;
            this.label29.Text = "Losses:";
            // 
            // lBombsLosses
            // 
            this.lBombsLosses.Location = new System.Drawing.Point(170, 190);
            this.lBombsLosses.Name = "lBombsLosses";
            this.lBombsLosses.Size = new System.Drawing.Size(84, 15);
            this.lBombsLosses.TabIndex = 27;
            this.lBombsLosses.Text = "2";
            this.lBombsLosses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lWinsX
            // 
            this.lWinsX.Location = new System.Drawing.Point(170, 171);
            this.lWinsX.Name = "lWinsX";
            this.lWinsX.Size = new System.Drawing.Size(84, 15);
            this.lWinsX.TabIndex = 26;
            this.lWinsX.Text = "2";
            this.lWinsX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(42, 171);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(35, 15);
            this.label27.TabIndex = 25;
            this.label27.Text = "Wins:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(42, 88);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 15);
            this.label25.TabIndex = 24;
            this.label25.Text = "Total Games:";
            // 
            // lTotal
            // 
            this.lTotal.Location = new System.Drawing.Point(173, 88);
            this.lTotal.Name = "lTotal";
            this.lTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lTotal.Size = new System.Drawing.Size(81, 15);
            this.lTotal.TabIndex = 23;
            this.lTotal.Text = "2";
            this.lTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(42, 68);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(44, 15);
            this.label26.TabIndex = 22;
            this.label26.Text = "Losses:";
            // 
            // lLosses
            // 
            this.lLosses.Location = new System.Drawing.Point(170, 68);
            this.lLosses.Name = "lLosses";
            this.lLosses.Size = new System.Drawing.Size(84, 15);
            this.lLosses.TabIndex = 21;
            this.lLosses.Text = "2";
            this.lLosses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(45, 137);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 15);
            this.label24.TabIndex = 20;
            // 
            // lStats
            // 
            this.lStats.AutoSize = true;
            this.lStats.Font = new System.Drawing.Font("Open Sans Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStats.Location = new System.Drawing.Point(26, 122);
            this.lStats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStats.Name = "lStats";
            this.lStats.Size = new System.Drawing.Size(227, 19);
            this.lStats.TabIndex = 19;
            this.lStats.Text = "Statistics for DE with 13 Bombs:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Open Sans Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(26, 20);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(124, 19);
            this.label22.TabIndex = 18;
            this.label22.Text = "Global Statistics:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Wins:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(170, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(170, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "30:00";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Best Time:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Logitech MineSweeper";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(299, 287);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Logitech MineSweeper";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private Label label6;
        private Label timer1;
        private ColorDialog colorDialog1;
        private TabPage tabPage4;
        private Button button4;
        private TabPage tabPage3;
        private Button bDefault;
        private TabPage tabPage1;
        private Button button1;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button3;
        private ComboBox comboBox1;
        private Button button2;
        private TabControl tabControl1;
        private Label label8;
        private Label label9;
        private Button bWin;
        private Label label11;
        private Button bClear;
        private Label label12;
        private Button bBomb;
        private Label label13;
        private Button bFlag;
        private Label label10;
        private Button bDefeat;
        private Label label15;
        private Button b6;
        private Label label16;
        private Button b5;
        private Label label17;
        private Button b4;
        private Label label18;
        private Button b3;
        private Label label19;
        private Button b2;
        private Label label20;
        private Button b1;
        private Label label21;
        private Button b0;
        private Label label14;
        private Button bNew;
        private Button resetSettings;
        private Button resetColors;
        private Button resetStats;
        private TabPage tabPage2;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label7;
        private Label label24;
        private Label lStats;
        private Label label22;
        private Label label25;
        private Label lTotal;
        private Label label26;
        private Label lLosses;
        private Label lWinsX;
        private Label label27;
        private Label label23;
        private Label lBombsTotal;
        private Label label29;
        private Label lBombsLosses;
        private NotifyIcon notifyIcon1;
        private Button bCounter;
        private Label label28;
        private Button button5;
        private Label label30;
        private CheckBox checkBox1;
    }
}