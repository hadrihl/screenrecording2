using System;
using System.Windows.Forms;

namespace ScreenRecording2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Screen Recording is Started!");
            Form1 frm = new Form1();
            frm.startRecording();
            Console.WriteLine("Please Enter to Stop the Recording!");
            var rl = Console.ReadLine();
            if (rl != null)
            {
                frm.stopRecording();
                Application.Run(new Form2());
            }
        }
    }
}
