using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Timers;
using System.Threading;

namespace LogitechGMineSweeper
{
    public partial class Form1 : Form
    {
        #region Constructor and Class Variables

        public static System.Timers.Timer aTimer = new System.Timers.Timer();
        private static readonly Stopwatch timer = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            
            if (!LogitechGSDK.LogiLedInit()) Console.Write("Not connected to GSDK");

            //wait for a short time do logiled is intíalized
            Thread.Sleep(100);

            ActiveControl = label3;
            label6.BringToFront();
            timer1.BringToFront();

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = false;
            aTimer.Stop();

            UpdateTimer();

            if (MineSweeper.KeyboardLayout == "US")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (MineSweeper.KeyboardLayout == "DE")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 2;
            }

            numericUpDown1.Value = Convert.ToDecimal(MineSweeper.Bombs);

            // Define the border style of the form to a dialog box.
            FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            MaximizeBox = false;

            // Set the start position of the form to the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;

            UpdateColors();
            UpdateStats();

            MineSweeper.newGame();
        }
        #endregion

        #region SettingsChanged

        //Bomb Number Changes
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MineSweeper.Bombs = Convert.ToInt32(numericUpDown1.Value);
            MineSweeper.newGame();

            StopWatchDefeat();
            ResetWatch();

            UpdateFile();
            UpdateStats();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                MineSweeper.KeyboardLayout = "US";
                MineSweeper.newGame();
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                MineSweeper.KeyboardLayout = "DE";
                MineSweeper.newGame();
            }
            else
            {
                MineSweeper.KeyboardLayout = "UK";
                MineSweeper.newGame();
            }

            StopWatchDefeat();
            ResetWatch();

            UpdateFile();
            UpdateStats();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 13;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 7;
        }

        void numericUpDown1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        #endregion

        #region Timer

        string BestTime(string layout, int bombs)
        {
            var file = "a";
            string[] US = { "", "", "", "", "", "5: 30:00", "6: 30:00", "7: 30:00", "8: 30:00", "9: 30:00", "10: 30:00", "11: 30:00", "12: 30:00", "13: 30:00", "14: 30:00", "15: 30:00", "16: 30:00", "17: 30:00", "18: 30:00", "19: 30:00", "20: 30:00", "21: 30:00", "22: 30:00", "23: 30:00", "24: 30:00", "25: 30:00", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            string best = "";
            int a = 0;

            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            if (MineSweeper.KeyboardLayout == "US")
            {
                file = Path.Combine(systemPath, "Logitech MineSweeper/US.txt");
            }
            else if (MineSweeper.KeyboardLayout == "DE")
            {
                file = Path.Combine(systemPath, "Logitech MineSweeper/DE.txt");
            }
            else
            {
                file = Path.Combine(systemPath, "Logitech MineSweeper/UK.txt");
            }

            try
            {
                string skip = bombs + ": ";
                string line = File.ReadLines(file).Skip(bombs).Take(1).First();
                a = line.IndexOf(skip);
                best = line.Substring(a + skip.Length);
                int min = Convert.ToInt32(best.Substring(0, 2));
                int sek = Convert.ToInt32(best.Substring(3, 2));
            }
            catch
            {
                File.WriteAllLines(file, US);
            }
            if (best.Length != 5 || best.Substring(2, 1) != ":" || Convert.ToInt32(best.Substring(0, 2)) > 30 || Convert.ToInt32(best.Substring(3, 2)) > 60 || Convert.ToInt32(best.Substring(0, 2)) < 0 || Convert.ToInt32(best.Substring(3, 2)) < 0)
            {
                File.WriteAllLines(file, US);
            }

            return best;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (timer.Elapsed.Minutes >= 30)
            {
                MineSweeper.newGame();
                StopWatchDefeat();
                ResetWatch();
            }
            fnUpdate_Label("Hello!");
        }

        public void StopWatchVictory()
        {
            timer1.ForeColor = System.Drawing.Color.Green;
            timer.Stop();
            aTimer.Enabled = false;
            fnUpdate_Label("Hello!");

            string best = BestTime(MineSweeper.KeyboardLayout, MineSweeper.Bombs);

            if(Convert.ToInt32(best.Substring(0, 2)) * 60 + Convert.ToInt32(best.Substring(3, 2)) >= timer.Elapsed.Minutes * 60 + timer.Elapsed.Seconds)
            {
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var directory = Path.Combine(systemPath, "Logitech MineSweeper");

                var file = "a";

                if (MineSweeper.KeyboardLayout == "US")
                {
                    file = Path.Combine(systemPath, "Logitech MineSweeper/US.txt");
                }
                else if (MineSweeper.KeyboardLayout == "DE")
                {
                    file = Path.Combine(systemPath, "Logitech MineSweeper/DE.txt");
                }
                else
                {
                    file = Path.Combine(systemPath, "Logitech MineSweeper/UK.txt");
                }

                string[] US = File.ReadAllLines(file);

                US[MineSweeper.Bombs] = MineSweeper.Bombs.ToString() + ": " + string.Format("{0:00}:{1:00}",timer.Elapsed.Minutes,timer.Elapsed.Seconds);

                File.WriteAllLines(file, US);

                label5.Text = BestTime(MineSweeper.KeyboardLayout, MineSweeper.Bombs);
            }
        }

        public void StopWatchDefeat()
        {
            timer1.ForeColor = System.Drawing.Color.Red;
            timer.Stop();
            aTimer.Enabled = false;
        }

        public void StartWatch()
        {
            timer1.ForeColor = System.Drawing.Color.Black;
            timer.Reset();
            aTimer.Enabled = true;
            timer.Start();
        }


        public void ResetWatch()
        {
            timer1.ForeColor = System.Drawing.Color.Black;
            timer.Reset();
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            timer1.Text = GetTimeString(timer.Elapsed);
        }

        private string GetTimeString(TimeSpan elapsed)
        {
            string result = string.Empty;

            result = string.Format("{0:00}:{1:00}",
                elapsed.Minutes,
                elapsed.Seconds);

            return result;
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
                timer1.Text = GetTimeString(timer.Elapsed);
            }
        }

        #endregion

        #region Color Button Handlers

        private void UpdateColors()
        {
            b0.BackColor = Color.FromArgb(MineSweeper.colors[0, 2], MineSweeper.colors[0, 1], MineSweeper.colors[0, 0]);
            b1.BackColor = Color.FromArgb(MineSweeper.colors[1, 2], MineSweeper.colors[1, 1], MineSweeper.colors[1, 0]);
            b2.BackColor = Color.FromArgb(MineSweeper.colors[2, 2], MineSweeper.colors[2, 1], MineSweeper.colors[2, 0]);
            b3.BackColor = Color.FromArgb(MineSweeper.colors[3, 2], MineSweeper.colors[3, 1], MineSweeper.colors[3, 0]);
            b4.BackColor = Color.FromArgb(MineSweeper.colors[4, 2], MineSweeper.colors[4, 1], MineSweeper.colors[4, 0]);
            b5.BackColor = Color.FromArgb(MineSweeper.colors[5, 2], MineSweeper.colors[5, 1], MineSweeper.colors[5, 0]);
            b6.BackColor = Color.FromArgb(MineSweeper.colors[6, 2], MineSweeper.colors[6, 1], MineSweeper.colors[6, 0]);


            bBomb.BackColor = Color.FromArgb(MineSweeper.colors[7, 2], MineSweeper.colors[7, 1], MineSweeper.colors[7, 0]);
            bClear.BackColor = Color.FromArgb(MineSweeper.colors[8, 2], MineSweeper.colors[8, 1], MineSweeper.colors[8, 0]);
            bFlag.BackColor = Color.FromArgb(MineSweeper.colors[10, 2], MineSweeper.colors[10, 1], MineSweeper.colors[10, 0]);
            bNew.BackColor = Color.FromArgb(MineSweeper.colors[11, 2], MineSweeper.colors[11, 1], MineSweeper.colors[11, 0]);
            bDefeat.BackColor = Color.FromArgb(MineSweeper.colors[12, 2], MineSweeper.colors[12, 1], MineSweeper.colors[12, 0]);
            bWin.BackColor = Color.FromArgb(MineSweeper.colors[13, 2], MineSweeper.colors[13, 1], MineSweeper.colors[13, 0]);
            bDefault.BackColor = Color.FromArgb(MineSweeper.colors[14, 2], MineSweeper.colors[14, 1], MineSweeper.colors[14, 0]);
            bCounter.BackColor = Color.FromArgb(MineSweeper.colors[15, 2], MineSweeper.colors[15, 1], MineSweeper.colors[15, 0]);
        }

        private void b0_Click(object sender, EventArgs e)
        {
            int index = 0;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            int index = 1;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            int index = 2;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            int index = 3;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {
            int index = 4;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {
            int index = 5;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void b6_Click(object sender, EventArgs e)
        {
            int index = 6;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bWin_Click(object sender, EventArgs e)
        {
            int index = 13;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bDefeat_Click(object sender, EventArgs e)
        {
            int index = 12;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bFlag_Click(object sender, EventArgs e)
        {
            int index = 10;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bBomb_Click(object sender, EventArgs e)
        {
            int index = 7;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            int index = 8;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            int index = 11;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bDefault_Click(object sender, EventArgs e)
        {
            int index = 14;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        private void bCounter_Click(object sender, EventArgs e)
        {
            int index = 15;

            // Show the color dialog.
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.FullOpen = true;

            MyDialog.Color = Color.FromArgb(MineSweeper.colors[index, 2], MineSweeper.colors[index, 1], MineSweeper.colors[index, 0]);
            // See if user pressed ok.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {

                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                for (int i = 0; i < MineSweeper.colors.GetLength(0); i++)
                {
                    colors[i] = File.ReadLines(fileColors).Skip(i).Take(1).First();
                }

                ((Button)sender).BackColor = MyDialog.Color;
                MineSweeper.colors[index, 0] = MyDialog.Color.B;
                MineSweeper.colors[index, 1] = MyDialog.Color.G;
                MineSweeper.colors[index, 2] = MyDialog.Color.R;

                colors[index] = MyDialog.Color.B.ToString().PadLeft(3, '0') + "," + MyDialog.Color.G.ToString().PadLeft(3, '0') + "," + MyDialog.Color.R.ToString().PadLeft(3, '0'); ;

                File.WriteAllLines(fileColors, colors);

                MineSweeper.printLogiLED();
            }
        }

        #endregion

        #region Reset Button Handlers

        private void resetColors_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All colors will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255" };

                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var directory = Path.Combine(systemPath, "Logitech MineSweeper");

                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                File.WriteAllLines(fileColors, colors);

                MineSweeper.colors = new byte[,] { { 000, 000, 000 }, { 000, 127, 255 }, { 255, 255, 000 }, { 000, 128, 000 }, { 000, 255, 255 }, { 128, 000, 064 }, { 255, 000, 000 }, { 000, 000, 255 }, { 255, 255, 255 }, { 255, 200, 200 }, { 000, 000, 255 }, { 255, 000, 000 }, { 000, 000, 255 }, { 000, 255, 255 }, { 255, 160, 160 }, {000, 255, 255} };

                UpdateColors();

                StopWatchDefeat();
                ResetWatch();

                MineSweeper.printLogiLED();
            }
        }

        private void resetSettings_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All settings will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                string[] lines = { "Wins: 0", "Bombs: 13", "Layout: DE", "Total: 0", "Losses: 0" };
                
                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var directory = Path.Combine(systemPath, "Logitech MineSweeper");

                var file = Path.Combine(systemPath, "Logitech MineSweeper/config.txt");
                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");

                File.WriteAllLines(file, lines);

                MineSweeper.Bombs = 13;
                MineSweeper.KeyboardLayout = "DE";
                comboBox1.SelectedIndex = 0;
                numericUpDown1.Value = 13;

                UpdateStats();

                MineSweeper.newGame();

                StopWatchDefeat();
                ResetWatch();
            }
        }

        private void resetStats_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All statistics will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                string[] US = { "", "", "", "", "", "5: 30:00", "6: 30:00", "7: 30:00", "8: 30:00", "9: 30:00", "10: 30:00", "11: 30:00", "12: 30:00", "13: 30:00", "14: 30:00", "15: 30:00", "16: 30:00", "17: 30:00", "18: 30:00", "19: 30:00", "20: 30:00", "21: 30:00", "22: 30:00", "23: 30:00", "24: 30:00", "25: 30:00", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                string[] lines = { "Wins: 0", "Bombs: " + MineSweeper.Bombs, "Layout: " + MineSweeper.KeyboardLayout, "Total: " + MineSweeper.Total.ToString(), "Losses: " + MineSweeper.Losses.ToString() };

                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var directory = Path.Combine(systemPath, "Logitech MineSweeper");

                var fileUS = Path.Combine(systemPath, "Logitech MineSweeper/US.txt");
                var fileDE = Path.Combine(systemPath, "Logitech MineSweeper/DE.txt");
                var fileUK = Path.Combine(systemPath, "Logitech MineSweeper/UK.txt");
                var file = Path.Combine(systemPath, "Logitech MineSweeper/config.txt");

                File.WriteAllLines(file, lines);

                File.WriteAllLines(fileUS, US);
                File.WriteAllLines(fileDE, US);
                File.WriteAllLines(fileUK, US);

                label5.Text = "30:00";
                MineSweeper.Wins = 0;
                MineSweeper.Losses = 0;
                MineSweeper.Total = 0;

                UpdateStats();

                StopWatchDefeat();
                ResetWatch();

                MineSweeper.newGame();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to Reset. All wins, colors and best times will be lost.", "Reset",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                string[] lines = { "Wins: 0", "Bombs: 13", "Layout: DE", "Total: 0", "Losses: 0" };
                string[] colors = { "000,000,000", "000,127,255", "255,255,000", "000,128,000", "000,255,255", "128,000,064", "255,000,000", "000,000,255", "255,255,255", "255,200,200", "000,000,255", "255,000,000", "000,000,255", "000,255,255", "255,160,160", "000,255,255", "000,255,255" };
                string[] US = { "", "", "", "", "", "5: 30:00", "6: 30:00", "7: 30:00", "8: 30:00", "9: 30:00", "10: 30:00", "11: 30:00", "12: 30:00", "13: 30:00", "14: 30:00", "15: 30:00", "16: 30:00", "17: 30:00", "18: 30:00", "19: 30:00", "20: 30:00", "21: 30:00", "22: 30:00", "23: 30:00", "24: 30:00", "25: 30:00", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };

                var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                var directory = Path.Combine(systemPath, "Logitech MineSweeper");

                var fileColors = Path.Combine(systemPath, "Logitech MineSweeper/colors.txt");
                var fileUS = Path.Combine(systemPath, "Logitech MineSweeper/US.txt");
                var fileDE = Path.Combine(systemPath, "Logitech MineSweeper/DE.txt");
                var fileUK = Path.Combine(systemPath, "Logitech MineSweeper/UK.txt");
                var file = Path.Combine(systemPath, "Logitech MineSweeper/config.txt");

                File.WriteAllLines(file, lines);

                File.WriteAllLines(fileUS, US);
                File.WriteAllLines(fileDE, US);
                File.WriteAllLines(fileUK, US);
                File.WriteAllLines(fileColors, colors);

                MineSweeper.colors = new byte[,] { { 000, 000, 000 }, { 128, 000, 128 }, { 255, 255, 000 }, { 000, 128, 000 }, { 000, 255, 255 }, { 000, 127, 255 }, { 255, 000, 000 }, { 000, 000, 255 }, { 255, 255, 255 }, { 255, 200, 200 }, { 000, 000, 255 }, { 255, 000, 000 }, { 000, 000, 255 }, { 000, 255, 255 }, { 255, 160, 160 }, { 000, 255, 255 } };

                UpdateColors();

                MineSweeper.Wins = 0;
                MineSweeper.Total = 0;
                MineSweeper.Losses = 0;
                MineSweeper.Bombs = 13;
                MineSweeper.KeyboardLayout = "DE";

                label5.Text = "30:00";
                comboBox1.SelectedIndex = 0;
                numericUpDown1.Value = 13;

                UpdateStats();
                UpdateFile();

                MineSweeper.newGame();

                StopWatchDefeat();
                ResetWatch();
            }
        }

        #endregion

        #region Update Config and Stats Display

        void UpdateFile()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string[] lines = { "Wins: " + MineSweeper.Wins, "Bombs: " + MineSweeper.Bombs, "Layout: " + MineSweeper.KeyboardLayout, "Total: " + MineSweeper.Total.ToString(), "Losses: " + MineSweeper.Losses.ToString() };
            var file = Path.Combine(systemPath, "Logitech MineSweeper/config.txt");
            File.WriteAllLines(file, lines);
        }

        public void UpdateStats()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var directory = Path.Combine(systemPath, "Logitech MineSweeper");

            var file = "a";

            if (MineSweeper.KeyboardLayout == "US")
            {
                file = Path.Combine(systemPath, "Logitech MineSweeper/US.txt");
            }
            else if (MineSweeper.KeyboardLayout == "DE")
            {
                file = Path.Combine(systemPath, "Logitech MineSweeper/DE.txt");
            }
            else
            {
                file = Path.Combine(systemPath, "Logitech MineSweeper/UK.txt");
            }

            label3.Text = MineSweeper.Wins.ToString();
            lLosses.Text = MineSweeper.Losses.ToString();
            lTotal.Text = MineSweeper.Total.ToString();
            lBombsTotal.Text = File.ReadLines(file).Skip(MineSweeper.Bombs + 63).Take(1).First().ToString();
            lBombsLosses.Text = File.ReadLines(file).Skip(MineSweeper.Bombs + 42).Take(1).First().ToString();
            lStats.Text = "Statistics for " + (MineSweeper.KeyboardLayout == "US" ? "US" : MineSweeper.KeyboardLayout == "DE" ? "DE" : "UK") + " with " + MineSweeper.Bombs.ToString() + " Bombs:";
            lWinsX.Text = File.ReadLines(file).Skip(MineSweeper.Bombs + 21).Take(1).First().ToString();
            label5.Text = BestTime(MineSweeper.KeyboardLayout, MineSweeper.Bombs);

            UpdateFile();
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
