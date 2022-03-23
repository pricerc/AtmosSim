namespace WinFormsApp1
{
    using System;

    public static class GDI
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern bool SetPixel(IntPtr hdc, int X, int Y, uint crColor);

        internal static uint ToBGR(this Color pixelColor)
        { return (uint)((pixelColor.B << 16) | (pixelColor.G << 8) | (pixelColor.R)); }
    }
}