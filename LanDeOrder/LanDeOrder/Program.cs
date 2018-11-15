using System;
using System . Windows . Forms;

namespace LanDeOrder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main ( )
        {
            //Devexpress 13.1  汉化
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo( "zh-Hans" );

            //if ( Encrypt . GetDataTable ( ) == "34171" )
            //{
                Application . EnableVisualStyles ( );
                Application . SetCompatibleTextRenderingDefault ( false );
                Application . Run ( new Form1 ( ) );
            //}
        }
    }
}
