using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHW2102ex3
{
    static class Program
    {
        
        static Mutex mutex = new Mutex(true, "{A7A05B4B-1C2D-4E78-8D2F-4AC5DFFDC6B8}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
               
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Приложение уже запущено в максимальном количестве копий.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}