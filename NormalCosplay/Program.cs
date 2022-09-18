using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

var key = Registry.CurrentUser.CreateSubKey("normalcosplay");
var mode = key.GetValue("mode");
if (mode == null)
{
    Console.WriteLine("no existing key found! creating new one...");
    key.SetValue("mode", 0);
    mode = key.GetValue("mode");
}

switch (mode)
{
    case 0:

}



class Tool
{
    public static string BackupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "NormalCosplay");
    public static void BackupCurrentWallpaper()
    {
        string current = Convert.ToString(Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Desktop").GetValue("Wallpaper"));
        File.Copy(current, Path.Combine(BackupPath, "last"));
    }

    public static void ChangeCurrentWallpaper()
    {
        
    }
    private static void DisplayPicture(string file_name)
    {
        uint flags = 0;
        if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0, file_name, flags))
        {
            Console.WriteLine("Error");
        }
    }

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

    private const uint SPI_SETDESKWALLPAPER = 0x14;
    private const uint SPIF_UPDATEINIFILE = 0x1;
    private const uint SPIF_SENDWININICHANGE = 0x2;
}