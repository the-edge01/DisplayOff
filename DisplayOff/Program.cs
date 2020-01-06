using System;
using System.Runtime.InteropServices;

namespace DisplayOff
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
         IntPtr hWnd,
         UInt32 Msg,
         IntPtr wParam,
         IntPtr lParam
      );

        //https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand
        //#define WM_SYSCOMMAND      0x0112
        //SC_MONITORPOWER            0xF170
        //Sets the state of the display.This command supports devices that have power-saving features, such as a battery-powered personal computer.
        //The lParam parameter can have the following values:
        //  -1 (the display is powering on)
        //   1 (the display is going to low power)
        //   2 (the display is being shut off)

        static void Main(string[] args)
        {
            SendMessage(
               (IntPtr)0xffff, // HWND_BROADCAST
               0x0112,         // WM_SYSCOMMAND
               (IntPtr)0xf170, // SC_MONITORPOWER
               (IntPtr)0x0002  // POWER_OFF
            );
        }

    }
}
