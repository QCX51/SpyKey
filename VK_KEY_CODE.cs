namespace Classes
{
    /// <summary>
    /// Virtual keyboard Key Code
    /// by QCX51
    /// </summary>
    internal enum VK_KEY_CODE : uint
    {
        /// <summary> Left mouse button </summary>
        VK_LBUTTON = 0x01,
        /// <summary> Right mouse button </summary>
        VK_RBUTTON = 0x02,
        /// <summary> Control-break processing </summary>
        VK_CANCEL = 0x03,
        /// <summary> Middle mouse button (three-button mouse) </summary>
        VK_MBUTTON = 0x04,
        /// <summary> X1 mouse button </summary>
        VK_XBUTTON1 = 0x05,
        /// <summary> X2 mouse button </summary>
        VK_XBUTTON2 = 0x06,

        // - = 0x07. // Undefined
        VK_UNDEFINED_07 = 0x07,

        /// <summary> BACKSPACE key </summary>
        VK_BACK = 0x08,
        /// <summary> TAB key </summary>
        VK_TAB = 0x09,

        // - = 0x0A - 0B, // Reserved
        VK_RESERVED_0A = 0x0A,
        VK_RESERVED_0B = 0x0B,

        /// <summary> CLEAR key </summary>
        VK_CLEAR = 0x0C,
        /// <summary> ENTER key </summary>
        VK_RETURN = 0x0D,

        // - = 0x0E - 0F, // Undefined
        VK_UNDEFINED_0E = 0x0E,
        VK_UNDEFINED_0F = 0x0F,

        /// <summary> SHIFT key </summary>
        VK_SHIFT = 0x10,
        /// <summary> CTRL key </summary>
        VK_CONTROL = 0x11,
        /// <summary> ALT key </summary>
        VK_MENU = 0x12,
        /// <summary> PAUSE key </summary>
        VK_PAUSE = 0x13,
        /// <summary> CAPS LOCK key </summary>
        VK_CAPITAL = 0x14,

        /// <summary> IME Kana mode </summary>
        VK_KANA = 0x15,
        /// <summary> IME Hanguel mode (maintained for compatibility; use VK_HANGUL) </summary>
        VK_HANGUEL = 0x15,
        /// <summary> IME Hangul mode </summary>
        VK_HANGUL = 0x15,

        // - = 0x16 // Undefined
        VK_UNDEFINED_16 = 0x16,

        /// <summary> IME Junja mode </summary>
        VK_JUNJA = 0x17,
        /// <summary> IME final mode </summary>
        VK_FINAL = 0x18,
        /// <summary> IME Hanja mode </summary>
        VK_HANJA = 0x19,
        /// <summary> IME Kanji mode </summary>
        VK_KANJI = 0x19,

        // - = 0x1A, // Undefined
        VK_UNDEFINED_1A = 0x1A,

        /// <summary> ESC key </summary>
        VK_ESCAPE = 0x1B,

        /// <summary> IME convert </summary>
        VK_CONVERT = 0x1C,
        /// <summary> IME nonconvert </summary>
        VK_NONCONVERT = 0x1D,
        /// <summary> IME accept </summary>
        VK_ACCEPT = 0x1E,
        /// <summary> IME mode change request </summary>
        VK_MODECHANGE = 0x1F,

        /// <summary> SPACEBAR </summary>
        VK_SPACE = 0x20,
        /// <summary> PAGE UP key </summary>
        VK_PRIOR = 0x21,
        /// <summary> PAGE DOWN key </summary>
        VK_NEXT = 0x22,
        /// <summary> END key </summary>
        VK_END = 0x23,
        /// <summary> HOME key </summary>
        VK_HOME = 0x24,
        /// <summary> LEFT ARROW key </summary>
        VK_LEFT = 0x25,
        /// <summary> UP ARROW key </summary>
        VK_UP = 0x26,
        /// <summary> RIGHT ARROW key </summary>
        VK_RIGHT = 0x27,
        /// <summary> DOWN ARROW key </summary>
        VK_DOWN = 0x28,
        /// <summary> SELECT key </summary>
        VK_SELECT = 0x29,
        /// <summary> PRINT key </summary>
        VK_PRINT = 0x2A,
        /// <summary> EXECUTE key </summary>
        VK_EXECUTE = 0x2B,
        /// <summary> PRINT SCREEN key </summary>
        VK_SNAPSHOT = 0x2C,
        /// <summary> INSERT key </summary>
        VK_INSERT = 0x2D,
        /// <summary> DEL key </summary>
        VK_DELETE = 0x2E,
        /// <summary> HELP key </summary>
        VK_HELP = 0x2F,

        /// <summary> 0 key </summary>
        VK_0 = 0x30,
        /// <summary> 1 key </summary>
        VK_1 = 0x31,
        /// <summary> 2 key </summary>
        VK_2 = 0x32,
        /// <summary> 3 key </summary>
        VK_3 = 0x33,
        /// <summary> 4 key </summary>
        VK_4 = 0x34,
        /// <summary> 5 key </summary>
        VK_5 = 0x35,
        /// <summary> 6 key </summary>
        VK_6 = 0x36,
        /// <summary> 7 key </summary>
        VK_7 = 0x37,
        /// <summary> 8 key </summary>
        VK_8 = 0x38,
        /// <summary> 9 key </summary>
        VK_9 = 0x39,

        // - = 0x3A-40, // Undefined
        VK_UNDEFINED_3A = 0x3A,
        VK_UNDEFINED_3B = 0x3B,
        VK_UNDEFINED_3C = 0x3C,
        VK_UNDEFINED_3D = 0x3D,
        VK_UNDEFINED_3E = 0x3E,
        VK_UNDEFINED_3F = 0x3F,
        VK_UNDEFINED_40 = 0x40,

        /// <summary> A key </summary>
        VK_A = 0x41,
        /// <summary> B key </summary>
        VK_B = 0x42,
        /// <summary> C key </summary>
        VK_C = 0x43,
        /// <summary> D key </summary>
        VK_D = 0x44,
        /// <summary> E key </summary>
        VK_E = 0x45,
        /// <summary> F key </summary>
        VK_F = 0x46,
        /// <summary> G key </summary>
        VK_G = 0x47,
        /// <summary> H key </summary>
        VK_H = 0x48,
        /// <summary> I key </summary>
        VK_I = 0x49,
        /// <summary> J key </summary>
        VK_J = 0x4A,
        /// <summary> K key </summary>
        VK_K = 0x4B,
        /// <summary> L key </summary>
        VK_L = 0x4C,
        /// <summary> M key </summary>
        VK_M = 0x4D,
        /// <summary> N key </summary>
        VK_N = 0x4E,
        /// <summary> O key </summary>
        VK_O = 0x4F,
        /// <summary> P key </summary>
        VK_P = 0x50,
        /// <summary> Q key </summary>
        VK_Q = 0x51,
        /// <summary> R key </summary>
        VK_R = 0x52,
        /// <summary> S key </summary>
        VK_S = 0x53,
        /// <summary> T key </summary>
        VK_T = 0x54,
        /// <summary> U key </summary>
        VK_U = 0x55,
        /// <summary> V key </summary>
        VK_V = 0x56,
        /// <summary> W key </summary>
        VK_W = 0x57,
        /// <summary> X key </summary>
        VK_X = 0x58,
        /// <summary> Y key </summary>
        VK_Y = 0x59,
        /// <summary> Z key </summary>
        VK_Z = 0x5A,

        /// <summary> Left Windows key (Natural keyboard) </summary>
        VK_LWIN = 0x5B,
        /// <summary> Right Windows key (Natural keyboard) </summary>
        VK_RWIN = 0x5C,
        /// <summary> Applications key (Natural keyboard) </summary>
        VK_APPS = 0x5D,

        //- = 0x5E, // Reserved
        VK_RESERVED_5E = 0x5E,

        /// <summary> Computer Sleep key </summary>
        VK_SLEEP = 0x5F,

        /// <summary> Numeric keypad 0 key </summary>
        VK_NUMPAD0 = 0x60,
        /// <summary> Numeric keypad 1 key </summary>
        VK_NUMPAD1 = 0x61,
        /// <summary> Numeric keypad 2 key </summary>
        VK_NUMPAD2 = 0x62,
        /// <summary> Numeric keypad 3 key </summary>
        VK_NUMPAD3 = 0x63,
        /// <summary> Numeric keypad 4 key </summary>
        VK_NUMPAD4 = 0x64,
        /// <summary> Numeric keypad 5 key </summary>
        VK_NUMPAD5 = 0x65,
        /// <summary> Numeric keypad 6 key </summary>
        VK_NUMPAD6 = 0x66,
        /// <summary> Numeric keypad 7 key </summary>
        VK_NUMPAD7 = 0x67,
        /// <summary> Numeric keypad 8 key </summary>
        VK_NUMPAD8 = 0x68,
        /// <summary> Numeric keypad 9 key </summary>
        VK_NUMPAD9 = 0x69,

        /// <summary> Multiply key </summary>
        VK_MULTIPLY = 0x6A,
        /// <summary> Add key </summary>
        VK_ADD = 0x6B,
        /// <summary> Separator key </summary>
        VK_SEPARATOR = 0x6C,
        /// <summary> Subtract key </summary>
        VK_SUBTRACT = 0x6D,
        /// <summary> Decimal key </summary>
        VK_DECIMAL = 0x6E,
        /// <summary> Divide key </summary>
        VK_DIVIDE = 0x6F,

        VK_F1 = 0x70, // F1 key
        VK_F2 = 0x71, // F2 key
        VK_F3 = 0x72, // F3 key
        VK_F4 = 0x73, // F4 key
        VK_F5 = 0x74, // F5 key
        VK_F6 = 0x75, // F6 key
        VK_F7 = 0x76, // F7 key
        VK_F8 = 0x77, // F8 key
        VK_F9 = 0x78, // F9 key
        VK_F10 = 0x79, // F10 key
        VK_F11 = 0x7A, // F11 key
        VK_F12 = 0x7B, // F12 key
        VK_F13 = 0x7C, // F13 key
        VK_F14 = 0x7D, // F14 key
        VK_F15 = 0x7E, // F15 key
        VK_F16 = 0x7F, // F16 key
        VK_F17 = 0x80, // F17 key
        VK_F18 = 0x81, // F18 key
        VK_F19 = 0x82, // F19 key
        VK_F20 = 0x83, // F20 key
        VK_F21 = 0x84, // F21 key
        VK_F22 = 0x85, // F22 key
        VK_F23 = 0x86, // F23 key
        VK_F24 = 0x87, // F24 key

        // - = 0x88-8F, // Unassigned
        VK_UNASSIGNED_88 = 0x88,
        VK_UNASSIGNED_89 = 0x89,
        VK_UNASSIGNED_8A = 0x8A,
        VK_UNASSIGNED_8B = 0x8B,
        VK_UNASSIGNED_8C = 0x8C,
        VK_UNASSIGNED_8D = 0x8D,
        VK_UNASSIGNED_8E = 0x8E,
        VK_UNASSIGNED_8F = 0x8F,
        
        /// <summary> NUM LOCK key </summary>
        VK_NUMLOCK = 0x90,
        /// <summary> SCROLL LOCK key </summary>
        VK_SCROLL = 0x91,

        // 0x92-96 // OEM specific
        VK_OEM_SPECIFIC_92 = 0x92,
        VK_OEM_SPECIFIC_93 = 0x93,
        VK_OEM_SPECIFIC_94 = 0x94,
        VK_OEM_SPECIFIC_95 = 0x95,
        VK_OEM_SPECIFIC_96 = 0x96,

        // - = 0x97-9F, // Unassigned
        VK_UNASSIGNED_97 = 0x97,
        VK_UNASSIGNED_98 = 0x98,
        VK_UNASSIGNED_99 = 0x99,
        VK_UNASSIGNED_9A = 0x9A,
        VK_UNASSIGNED_9B = 0x9B,
        VK_UNASSIGNED_9C = 0x9C,
        VK_UNASSIGNED_9D = 0x9D,
        VK_UNASSIGNED_9E = 0x9E,
        VK_UNASSIGNED_9F = 0x9F,

        /// <summary> Left SHIFT key </summary>
        VK_LSHIFT = 0xA0,
        /// <summary> Right SHIFT key </summary>
        VK_RSHIFT = 0xA1,
        /// <summary> Left CONTROL key </summary>
        VK_LCONTROL = 0xA2,
        /// <summary> Right CONTROL key </summary>
        VK_RCONTROL = 0xA3,
        /// <summary> Left MENU key </summary>
        VK_LMENU = 0xA4,
        /// <summary> Right MENU key </summary>
        VK_RMENU = 0xA5,

        /// <summary> Browser Back key </summary>
        VK_BROWSER_BACK = 0xA6,
        /// <summary> Browser Forward key </summary>
        VK_BROWSER_FORWARD = 0xA7,
        /// <summary> Browser Refresh key </summary>
        VK_BROWSER_REFRESH = 0xA8,
        /// <summary> Browser Stop key </summary>
        VK_BROWSER_STOP = 0xA9,
        /// <summary> Browser Search key </summary>
        VK_BROWSER_SEARCH = 0xAA,
        /// <summary> Browser Favorites key </summary>
        VK_BROWSER_FAVORITES = 0xAB,
        /// <summary> Browser Start and Home key </summary>
        VK_BROWSER_HOME = 0xAC,

        /// <summary> Volume Mute key </summary>
        VK_VOLUME_MUTE = 0xAD,
        /// <summary> Volume Down key </summary>
        VK_VOLUME_DOWN = 0xAE,
        /// <summary> Volume Up key </summary>
        VK_VOLUME_UP = 0xAF,
        /// <summary> Next Track key </summary>
        VK_MEDIA_NEXT_TRACK = 0xB0,
        /// <summary> Previous Track key </summary>
        VK_MEDIA_PREV_TRACK = 0xB1,
        /// <summary> Stop Media key </summary>
        VK_MEDIA_STOP = 0xB2,
        /// <summary> Play/Pause Media key </summary>
        VK_MEDIA_PLAY_PAUSE = 0xB3,

        /// <summary> Start Mail key </summary>
        VK_LAUNCH_MAIL = 0xB4,
        /// <summary> Select Media key </summary>
        VK_LAUNCH_MEDIA_SELECT = 0xB5,
        /// <summary> Start Application 1 key </summary>
        VK_LAUNCH_APP1 = 0xB6,
        /// <summary> Start Application 2 key </summary>
        VK_LAUNCH_APP2 = 0xB7,
        
        // - = 0xB8-B9, // Reserved
        VK_RESERVED_B8 = 0xB8,
        VK_RESERVED_B9 = 0xB9,

        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ';:' key </summary>
        VK_OEM_1 = 0xBA,

        /// <summary> For any country/region, the '+' key </summary>
        VK_OEM_PLUS = 0xBB,
        /// <summary> For any country/region, the ',' key </summary>
        VK_OEM_COMMA = 0xBC,
        /// <summary> For any country/region, the '-' key </summary>
        VK_OEM_MINUS = 0xBD,
        /// <summary> For any country/region, the '.' key </summary>
        VK_OEM_PERIOD = 0xBE,

        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '/?' key </summary>
        VK_OEM_2 = 0xBF,
        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '`~' key </summary>
        VK_OEM_3 = 0xC0,
        
        // - = 0xC1-D7, Reserved
        VK_RESERVED_C1 = 0xC1,
        VK_RESERVED_C2 = 0xC2,
        VK_RESERVED_C3 = 0xC3,
        VK_RESERVED_C4 = 0xC4,
        VK_RESERVED_C5 = 0xC5,
        VK_RESERVED_C6 = 0xC6,
        VK_RESERVED_C7 = 0xC7,
        VK_RESERVED_C8 = 0xC8,
        VK_RESERVED_C9 = 0xC9,
        VK_RESERVED_CA = 0xCA,
        VK_RESERVED_CB = 0xCB,
        VK_RESERVED_CC = 0xCC,
        VK_RESERVED_CD = 0xCD,
        VK_RESERVED_CE = 0xCE,
        VK_RESERVED_CF = 0xCF,
        VK_RESERVED_D0 = 0xD0,
        VK_RESERVED_D1 = 0xD1,
        VK_RESERVED_D2 = 0xD2,
        VK_RESERVED_D3 = 0xD3,
        VK_RESERVED_D4 = 0xD4,
        VK_RESERVED_D5 = 0xD5,
        VK_RESERVED_D6 = 0xD6,
        VK_RESERVED_D7 = 0xD7,

        // - = 0xD8-DA, // Unassigned
        VK_UNASSIGNED_D8 = 0xD8,
        VK_UNASSIGNED_D9 = 0xD9,
        VK_UNASSIGNED_DA = 0xDA,

        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '[{' key </summary>
        VK_OEM_4 = 0xDB,
        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '\|' key</summary>
        VK_OEM_5 = 0xDC,
        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ']}' key </summary>
        VK_OEM_6 = 0xDD,
        /// <summary> Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the 'single-quote/double-quote' key</summary>
        VK_OEM_7 = 0xDE,
        /// <summary> Used for miscellaneous characters; it can vary by keyboard. </summary>
        VK_OEM_8 = 0xDF,

        VK_RESERVED_E0 = 0xE0,
        VK_OEM_SPECIFIC_E1 = 0xE1,

        /// <summary> Either the angle bracket key or the backslash key on the RT 102-key keyboard </summary>
        VK_OEM_102 = 0xE2,

        VK_OEM_SPECIFIC_E3 = 0xE3,
        VK_OEM_SPECIFIC_E4 = 0xE4,

        /// <summary> IME PROCESS key </summary>
        VK_PROCESSKEY = 0xE5,

        VK_OEM_SPECIFIC_E6 = 0xE6,

        /// <summary> Used to pass Unicode characters as if they were keystrokes.
        /// The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods.
        /// For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP </summary>
        VK_PACKET = 0xE7,

        // - = 0xE8, // Unassigned
        VK_UNASSIGNED_E8 = 0xE8,

        // 0xE9-F5, // OEM specific
        VK_OEM_SPECIFIC_E9 = 0xE9,
        VK_OEM_SPECIFIC_EA = 0xEA,
        VK_OEM_SPECIFIC_EB = 0xEB,
        VK_OEM_SPECIFIC_EC = 0xEC,
        VK_OEM_SPECIFIC_ED = 0xED,
        VK_OEM_SPECIFIC_EE = 0xEE,
        VK_OEM_SPECIFIC_EF = 0xEF,
        VK_OEM_SPECIFIC_F0 = 0xF0,
        VK_OEM_SPECIFIC_F1 = 0xF1,
        VK_OEM_SPECIFIC_F2 = 0xF2,
        VK_OEM_SPECIFIC_F3 = 0xF3,
        VK_OEM_SPECIFIC_F4 = 0xF4,
        VK_OEM_SPECIFIC_F5 = 0xF5,

        /// <summary> Attn key </summary>
        VK_ATTN = 0xF6,
        /// <summary> CrSel key </summary>
        VK_CRSEL = 0xF7,
        /// <summary> ExSel key </summary>
        VK_EXSEL = 0xF8,
        /// <summary> Erase EOF key </summary>
        VK_EREOF = 0xF9,
        /// <summary> Play key </summary>
        VK_PLAY = 0xFA,
        /// <summary> Zoom key </summary>
        VK_ZOOM = 0xFB,
        /// <summary> Reserved </summary>
        VK_NONAME = 0xFC,
        /// <summary> PA1 key </summary>
        VK_PA1 = 0xFD,
        /// <summary> Clear key </summary>
        VK_OEM_CLEAR = 0xFE
    }
}
