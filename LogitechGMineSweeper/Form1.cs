using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace LogitechGMineSweeper
{
    public partial class Form1 : Form
    {
        #region Constructor and Class Variables

        public static System.Timers.Timer aTimer = new System.Timers.Timer();

        //variable for minesweeper object
        public MineSweeper MineSweeper { get; set; }

        public Form1()
        {
            InitializeComponent();

            ActiveControl = label3;
            label6.BringToFront();
            timer1.BringToFront();

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = false;

            SaveFileSettings settings = new SaveFileSettings(Config.PathSettingsFile);
            MineSweeper = new MineSweeper(settings, new SaveFileGlobalStatistics(Config.PathGlobalStatisticsFile), Config.KeyboardLayouts[settings.LayoutIndex], new SaveFileColors(Config.PathColorsFile), Config.SetLogiLogo);

            MineSweeper.StatsChangedEvent += new MineSweeper.UpdateStatsEventHandler(UpdateStats);
            MineSweeper.UpdateTimerEvent += new MineSweeper.TimerEventHandler(UpdateTimer);

            foreach (KeyboardLayout layout in Config.KeyboardLayouts)
            {
                comboBox1.Items.Add(layout.Text);
            }

            comboBox1.SelectedIndex = MineSweeper.KeyboardLayout.Index;

            checkBox1.Checked = MineSweeper.UseBackground;

            numericUpDown1.Minimum = Config.MinBombs;
            numericUpDown1.Maximum = Config.MaxBombs;
            numericUpDown1.Value = Convert.ToDecimal(MineSweeper.Bombs);

            // Define the border style of the form to a dialog box.
            FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            MaximizeBox = false;

            // Set the start position of the form to the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;

            UpdateColors();

            UpdateStats();
            UpdateTimerText();
        }
        #endregion

        #region SettingsChanged

        //Bomb Number Changes
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MineSweeper.Bombs = Convert.ToInt32(numericUpDown1.Value);
            UpdateStats();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MineSweeper.KeyboardLayout = Config.KeyboardLayouts[comboBox1.SelectedIndex];
            UpdateStats();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = MineSweeper.KeyboardLayout.Hard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = MineSweeper.KeyboardLayout.Medium;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = MineSweeper.KeyboardLayout.Easy;
        }

        void numericUpDown1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        #endregion

        #region Timer

        string MillisecondsToHoursMinutes(int ms)
        {
            if (ms == -1)
            {
                return Config.TimeNotSetText;
            }

            TimeSpan t = TimeSpan.FromMilliseconds(ms);

            if (t.Hours == 0)
            {
                return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            }
            else
            {
                return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (MineSweeper.Stopwatch.Elapsed.TotalMilliseconds >= Config.MaxTimerValue)
            {
                MineSweeper.NewGame();
            }

            fnUpdate_Label("Hello!");
        }

        public void UpdateTimer(UpdateTimerEventArgs TimerState)
        {
            switch (TimerState.State)
            {
                case (int)MineSweeper.TimerStateEnum.started:
                    timer1.ForeColor = Config.Default;
                    aTimer.Enabled = true;
                    aTimer.Start();
                    UpdateTimerText();
                    break;
                case (int)MineSweeper.TimerStateEnum.resetButNotStarted:
                    timer1.ForeColor = Config.Default;
                    aTimer.Enabled = false;
                    aTimer.Stop();
                    UpdateTimerText();
                    break;
                case (int)MineSweeper.TimerStateEnum.stoppedDefeat:
                    timer1.ForeColor = Config.Defeat;
                    aTimer.Enabled = false;
                    aTimer.Stop();
                    UpdateTimerText();
                    break;
                case (int)MineSweeper.TimerStateEnum.stoppedVictory:
                    timer1.ForeColor = Config.Victory;
                    aTimer.Enabled = false;
                    aTimer.Stop();
                    UpdateTimerText();
                    break;
                case (int)MineSweeper.TimerStateEnum.stoppedNewRecord:
                    timer1.ForeColor = Config.NewRecord;
                    aTimer.Enabled = false;
                    aTimer.Stop();
                    UpdateTimerText();
                    timer1.Text += Config.TextNewRecord;
                    break;
            }
        }

        private void UpdateTimerText()
        {
            timer1.Text = GetTimeString(MineSweeper.Stopwatch.Elapsed);
        }

        private string GetTimeString(TimeSpan elapsed)
        {
            if (elapsed.Hours == 0)
            {
                return string.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds);
            }
            else
            {
                return string.Format("{0:00}:{1:00}:{2:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
            }
        }

        public delegate void Update_label_delegate(string msg);

        public void fnUpdate_Label(string msg)
        {
            if (timer1.InvokeRequired)
            {
                timer1.BeginInvoke(new Update_label_delegate(fnUpdate_Label), new Object[] { msg });
            }
            else
            {
                timer1.Text = GetTimeString(MineSweeper.Stopwatch.Elapsed);
            }
        }

        #endregion

        #region Color Button Handlers

        private void UpdateColors()
        {
            b0.BackColor = Color.FromArgb(MineSweeper.Colors[0, 2], MineSweeper.Colors[0, 1], MineSweeper.Colors[0, 0]);
            b1.BackColor = Color.FromArgb(MineSweeper.Colors[1, 2], MineSweeper.Colors[1, 1], MineSweeper.Colors[1, 0]);
            b2.BackColor = Color.FromArgb(MineSweeper.Colors[2, 2], MineSweeper.Colors[2, 1], MineSweeper.Colors[2, 0]);
            b3.BackColor = Color.FromArgb(MineSweeper.Colors[3, 2], MineSweeper.Colors[3, 1], MineSweeper.Colors[3, 0]);
            b4.BackColor = Color.FromArgb(MineSweeper.Colors[4, 2], MineSweeper.Colors[4, 1], MineSweeper.Colors[4, 0]);
            b5.BackColor = Color.FromArgb(MineSweeper.Colors[5, 2], MineSweeper.Colors[5, 1], MineSweeper.Colors[5, 0]);
            b6.BackColor = Color.FromArgb(MineSweeper.Colors[6, 2], MineSweeper.Colors[6, 1], MineSweeper.Colors[6, 0]);


            bBomb.BackColor = Color.FromArgb(MineSweeper.Colors[7, 2], MineSweeper.Colors[7, 1], MineSweeper.Colors[7, 0]);
            bClear.BackColor = Color.FromArgb(MineSweeper.Colors[8, 2], MineSweeper.Colors[8, 1], MineSweeper.Colors[8, 0]);
            bFlag.BackColor = Color.FromArgb(MineSweeper.Colors[10, 2], MineSweeper.Colors[10, 1], MineSweeper.Colors[10, 0]);
            bNew.BackColor = Color.FromArgb(MineSweeper.Colors[11, 2], MineSweeper.Colors[11, 1], MineSweeper.Colors[11, 0]);
            bDefeat.BackColor = Color.FromArgb(MineSweeper.Colors[12, 2], MineSweeper.Colors[12, 1], MineSweeper.Colors[12, 0]);
            bWin.BackColor = Color.FromArgb(MineSweeper.Colors[13, 2], MineSweeper.Colors[13, 1], MineSweeper.Colors[13, 0]);
            bDefault.BackColor = Color.FromArgb(MineSweeper.Colors[14, 2], MineSweeper.Colors[14, 1], MineSweeper.Colors[14, 0]);
            bCounter.BackColor = Color.FromArgb(MineSweeper.Colors[15, 2], MineSweeper.Colors[15, 1], MineSweeper.Colors[15, 0]);
            button5.BackColor = Color.FromArgb(MineSweeper.Colors[16, 2], MineSweeper.Colors[16, 1], MineSweeper.Colors[16, 0]);
        }

        // for the color picker list
        private void ColorPopupCreator(int index, object sender)
        {
            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog
            {
                FullOpen = true
            };

            MyDialog.Color = Color.FromArgb(MineSweeper.Colors[index, 2], MineSweeper.Colors[index, 1], MineSweeper.Colors[index, 0]);

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.Colors[index, 0] = MyDialog.Color.B;
                MineSweeper.Colors[index, 1] = MyDialog.Color.G;
                MineSweeper.Colors[index, 2] = MyDialog.Color.R;
                MineSweeper.ColorsFile.SavedColors = MineSweeper.Colors;

                MineSweeper.PrintLogiLED();
            }
        }

        private void b0_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(0, sender);
        }

        private void b1_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(1, sender);
        }

        private void b2_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(2, sender);
        }

        private void b3_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(3, sender);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(4, sender);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(5, sender);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(6, sender);
        }

        private void bWin_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(13, sender);
        }

        private void bDefeat_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(12, sender);
        }

        private void bFlag_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(10, sender);
        }

        private void bBomb_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(7, sender);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(8, sender);
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(11, sender);
        }

        private void bDefault_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(14, sender);
        }

        private void bCounter_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(15, sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorPopupCreator(16, sender);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MineSweeper.UseBackground = checkBox1.Checked;
            MineSweeper.PrintLogiLED();
        }

        #endregion

        #region Reset Button Handlers

        private void resetColors_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All colors will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                ResetColors();
            }
        }

        private void resetSettings_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All settings will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                ResetSettings();

                MineSweeper.NewGame();
            }
        }

        private void resetStats_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All statistics will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                ResetStatistics();

                MineSweeper.NewGame();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All wins, colors and best times will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                ResetStatistics();
                ResetColors();
                ResetSettings();

                MineSweeper.NewGame();
            }
        }

        private void ResetColors()
        {
            MineSweeper.ColorsFile.ResetToDefault();
            MineSweeper.Colors = MineSweeper.ColorsFile.SavedColors;
            UpdateColors();
            MineSweeper.PrintLogiLED();
        }

        private void ResetSettings()
        {
            MineSweeper.Settings.ResetToDefault();
            comboBox1.SelectedIndex = Config.KeyboardLayoutDefaultIndex;
            numericUpDown1.Value = MineSweeper.Bombs;

            UpdateStats();
        }

        private void ResetStatistics()
        {
            MineSweeper.GlobalStats.ResetToDefault();

            foreach (KeyboardLayout layout in Config.KeyboardLayouts)
            {
                layout.SaveFile.ResetToDefault();
            }

            UpdateStats();
        }

        #endregion

        #region Update Config and Stats Display

        public void UpdateStats()
        {
            label3.Text = MineSweeper.Wins.ToString();
            lLosses.Text = MineSweeper.Losses.ToString();
            lTotal.Text = MineSweeper.Total.ToString();
            lBombsTotal.Text = MineSweeper.KeyboardLayout.SaveFile.GetTotal(MineSweeper.Bombs).ToString();
            lBombsLosses.Text = MineSweeper.KeyboardLayout.SaveFile.GetLosses(MineSweeper.Bombs).ToString();
            lStats.Text = "Statistics for " + MineSweeper.KeyboardLayout.Text + " with " + MineSweeper.Bombs + " Bombs:";
            lWinsX.Text = MineSweeper.KeyboardLayout.SaveFile.GetWins(MineSweeper.Bombs).ToString();
            label5.Text = MillisecondsToHoursMinutes(MineSweeper.KeyboardLayout.SaveFile.GetBestTime(MineSweeper.Bombs));
        }

        #endregion

        #region Minimize to System Tray

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        #endregion

        #region OneInstance

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        #endregion
    }
}
