using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportForm
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
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo( "zh-CN" );

            //if ( Encrypt.GetDataTable( ) == "34171" )
            //{
                Application.EnableVisualStyles( );
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new Form1( ) );
            //}
        }
    }
}
