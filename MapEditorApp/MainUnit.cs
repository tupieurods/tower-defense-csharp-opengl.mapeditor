using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
  static class MainUnit
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    /// 
    [DllImport("kernel32.dll")]
    public static extern bool SetProcessWorkingSetSize(IntPtr handle,
      int minimumWorkingSetSize, int maximumWorkingSetSize);
    [STAThread]
    static void Main()
    {
      SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
