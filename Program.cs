using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semipro
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
            Application.Run(new Login());
        }
        public static string username;
        public static string collection;
        public static string price;
        public static string custom;
        public static string size;
        public static string color;
        public static string total;
        public static string amount;
        public static string datetime;
        public static string team;
    }
}
