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
    public partial class WorkOrderAll : Form
    {
        public WorkOrderAll ( )
        {
            InitializeComponent( );
        }
        
        LanDeBll.Bll.LanDeOrderBll _bll = new LanDeBll.Bll.LanDeOrderBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm; DataTable tableQuery;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "";
        public string sign = "";

        private void WorkOrderAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            if ( sign == "1" )
                tableQuery = _bll.GetDataTableWorkOrder( );
            else if ( sign == "2" )
                tableQuery = _bll.GetDataTableWorkOrderOne( );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "RAC001" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "DEA001" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "DEA002" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "DEA057" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
