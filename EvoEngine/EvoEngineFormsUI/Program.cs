using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvoEngine;
using EvoEngineFormsUI.Frame;

namespace EvoEngineFormsUI
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
            Engine engine = Engine.StartEngine(new PublicInitializer()
            {
                FrameType = typeof(FullFrame)
            });
            Form form = new Form1(engine);
            Application.Run(form);
        }
    }
}
