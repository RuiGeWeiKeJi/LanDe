using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LanDeQuery
{
    public partial class TechnologyAll : Form
    {
        public TechnologyAll ( )
        {
            InitializeComponent( );
        }

        LanDeBll.Bll.LanDeOrderBll _bll = new LanDeBll.Bll.LanDeOrderBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", strWhere = "1=1";
        public string str = "";

        private void TechnologyAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( str ) )
                strWhere = strWhere + " AND RAC001='" + str + "'";
            query( );
        }

        void query ( )
        {
            DataTable tableQuery = _bll.GetDataTableTeah( strWhere );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "RAC003" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "QBA002" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "QBA960" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "QBA961" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "RAC002" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
