using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Xml;

namespace ReportForm
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent( );
        }

        ReportLibrary.FromOne _model = new ReportLibrary.FromOne( );
        ReportBll.Bll.FormOne _bll = new ReportBll.Bll.FormOne( );
        string file = "";
        Report report = new Report( );
        DataSet RDataSet = new DataSet( );
        DataTable tableQuery;

        private void Form1_Load ( object sender ,EventArgs e )
        {

        }
        //Select
        private void button1_Click ( object sender ,EventArgs e )
        {
            tableQuery = _bll.GetDataTable( dateTimePicker1.Value ,dateTimePicker2.Value );
            gridControl1.DataSource = tableQuery;
            assign( );
        }
        void assign ( )
        {
            CP.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( GK.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( BZ.SummaryItem.SummaryValue ) / Convert.ToDecimal( GK.SummaryItem.SummaryValue ) ,0 ).ToString( ) + "%" );
            CL.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( NP.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( BZ.SummaryItem.SummaryValue ) / Convert.ToDecimal( NP.SummaryItem.SummaryValue ) ,0 ).ToString( ) + "%" );
        }
        //Print
        void CreatePrint ( )
        {
            DataTable print = _bll.GetDataTable( dateTimePicker1.Value ,dateTimePicker2.Value );
            DataTable prints = _bll.GetDataTableOf( dateTimePicker1.Value ,dateTimePicker2.Value );
            print.TableName = "SGMBGD";
            prints.TableName = "SGMBGDS";
            RDataSet.Tables.Clear( );
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
        }
        //Export
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( tableQuery == null )
                return;
            CreatePrint( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\月成品率报表.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        //Print
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( tableQuery == null )
                return;
            CreatePrint( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\月成品率报表.frx" );
            report.RegisterData( RDataSet );
            report.Show( );
        }

        private void gridView1_CustomDrawRowFooterCell ( object sender ,DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e )
        {
            decimal d1 = 0M, d2 = 0M, d3 = 0M;
            if ( e.Column == this.CP )
            {
                d1 = d2 = d3 = 0M;
                d1 = this.gridView1.GetRowFooterCellText( e.RowHandle ,this.BZ ) == "" ? 0 : Convert.ToDecimal( this.gridView1.GetRowFooterCellText( e.RowHandle ,this.BZ ) );
                d2 = this.gridView1.GetRowFooterCellText( e.RowHandle ,this.GK ) == "" ? 0 : Convert.ToDecimal( this.gridView1.GetRowFooterCellText( e.RowHandle ,this.GK ) );
                d3 = d2 == 0 ? 0 : Math.Round( Convert.ToDecimal( d1 / d2 ) * 100,0 ) ;
                e.Info.DisplayText = d3.ToString( ) + "%";
            }
            if ( e.Column == this.CL )
            {
                d1 = d2 = d3 = 0M;
                d1 = this.gridView1.GetRowFooterCellText( e.RowHandle ,this.BZ ) == "" ? 0 : Convert.ToDecimal( this.gridView1.GetRowFooterCellText( e.RowHandle ,this.BZ ) );
                d2 = this.gridView1.GetRowFooterCellText( e.RowHandle ,this.NP ) == "" ? 0 : Convert.ToDecimal( this.gridView1.GetRowFooterCellText( e.RowHandle ,this.NP ) );
                d3 = d2 == 0 ? 0 : Math.Round( Convert.ToDecimal( d1 / d2 ) * 100,0 ) ;
                e.Info.DisplayText = d3.ToString( ) + "%";
            }
        }
    }
}
