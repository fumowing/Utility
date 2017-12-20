using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtil.DataPinger
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
            Application.Run(new UrlQuery());
        }

        //public int solution2(int[] A)
        //{
        //    // write your code in C# 5.0 with .NET 4.5 (Mono)
        //    int result = -1;
        //    Array.Sort(A);
        //    for (int i = 1; i < A.Length; i++)
        //    {
        //        int temp = Math.Abs(A[i] - A[i - 1]);
        //        if (result < 0 || temp < result)
        //            result = temp;
        //    }
        //    return result;
        //}
    }
}
