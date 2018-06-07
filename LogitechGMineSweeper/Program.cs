using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;

namespace LogitechGMineSweeper
{
    class InterceptKeys
    {
        #region Class Variables
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static int last = -1;

        //for single instance
        static Mutex mutex = new Mutex(true, "{8F6FGAC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

        #endregion

        #region Main
        [STAThread]
        public static void Main()
        {
            if (!LogitechGSDK.LogiLedInit()) Console.WriteLine("Not connected to GSDK");

            SaveFileSettings settings = new SaveFileSettings(Config.PathSettingsFile);
            Config.MineSweeper = new MineSweeper(settings, new SaveFileGlobalStatistics(Config.PathGlobalStatisticsFile), Config.KeyboardLayouts[settings.LayoutIndex], new SaveFileColors(Config.PathColorsFile));

            //one instance code
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                _hookID = SetHook(_proc);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                mutex.ReleaseMutex();
                UnhookWindowsHookEx(_hookID);
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                (IntPtr)NativeMethods.HWND_BROADCAST,
                NativeMethods.WM_SHOWME,
                IntPtr.Zero,
                IntPtr.Zero);
            }
        }
        #endregion

        #region Get Keypress and Parse

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Debug.WriteLine("Key ID-Code: " + vkCode);
                if (Config.MineSweeper.KeyboardLayout.KeyIds.Contains(vkCode))
                {
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        if (last != 107 && vkCode == 107) Config.MineSweeper.KeyPressed(48);
                        else if (vkCode != 107)
                        {
                            Config.MineSweeper.SetFlag(Array.IndexOf(Config.MineSweeper.KeyboardLayout.KeyIds, vkCode));
                            last = -1;
                        }
                    }
                    else if (last != vkCode)
                    {
                        last = vkCode;
                        Config.MineSweeper.KeyPressed(Array.IndexOf(Config.MineSweeper.KeyboardLayout.KeyIds, vkCode));
                    }
                    else
                    {
                        Debug.WriteLine("REJECTED: Double Press - Key ID-Code: " + vkCode);
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        #endregion
    }

    #region One Instance
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
    #endregion
}
