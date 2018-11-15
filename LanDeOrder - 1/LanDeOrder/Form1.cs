using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using LanDeOrder.Class;

namespace LanDeOrder
{
    public partial class Form1 : Form
    {
        public Form1 ( )
        {
            InitializeComponent( );
        }

        LanDeLibrary.LanDeOrderEntity _model = new LanDeLibrary.LanDeOrderEntity( );
        LanDeBll.Bll.LanDeOrderBll _bll = new LanDeBll.Bll.LanDeOrderBll( );
        DataTable tableQuery, personInfor;
        //工艺
        DataTable dp = new DataTable( );
        //工单
        DataTable gd = new DataTable( ); 
        bool result = false;
        string strWhere = "1=1", sign = "";
        int recordLast = 0;
        List<string> strList = new List<string>( );
        DateTime dt;

        private void Form1_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );


            personInfor = _bll.GetDataTablePeople( );
            lookUpEdit1.Properties.DataSource = personInfor;
            lookUpEdit1.Properties.DisplayMember = "DBA001";
            lookUpEdit1.Properties.ValueMember = "DBA002";

            lookUpEdit4.Properties.DataSource = personInfor.Copy( );
            lookUpEdit4.Properties.DisplayMember = "DBA001";
            lookUpEdit4.Properties.ValueMember = "DBA002";

            lookUpEdit5.Properties.DataSource = personInfor.Copy( );
            lookUpEdit5.Properties.DisplayMember = "DBA001";
            lookUpEdit5.Properties.ValueMember = "DBA002";

            toolQuery.Enabled = toolAdd.Enabled = true;
            toolEdit.Enabled = toolClear.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
            StateOfControl.SpliEnableFalse( splitContainer1 );

            button2.Enabled = button1.Enabled = button4.Enabled = true;
            lookUpEdit1.Enabled =  lookUpEdit3.Enabled = true;

            gd = _bll.GetDataTableWorkOrderOne( );
            lookUpEdit3.Properties.DataSource = gd;
            lookUpEdit3.Properties.DisplayMember = "RAC001";

            toolEdit.Visible = false;
        }

        #region Main
        private void toolQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND BGD002='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND BGD004='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND BGD006='" + lookUpEdit3.Text + "'";
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "''";
            tableQuery = _bll.GetDataTables( strWhere );
            gridControl1.DataSource = tableQuery;

            toolEdit.Enabled = toolQuery.Enabled = toolAdd.Enabled = toolClear.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            StateOfControl.SpliEnableFalse( splitContainer1 );

            button2.Enabled = button1.Enabled = button4.Enabled = true;
            lookUpEdit1.Enabled =  lookUpEdit3.Enabled = true;
        }
        private void toolClear_Click ( object sender ,EventArgs e )
        {
            
            //dateTimePicker1.Value = DateTime.Now;
            StateOfControl.SpliClear( splitContainer1 );
        }
        private void toolAdd_Click ( object sender ,EventArgs e )
        {
            toolEdit.Enabled = toolQuery.Enabled = toolAdd.Enabled =  false;
            toolClear.Enabled = toolSave.Enabled = toolCancel.Enabled = true;
            StateOfControl.SpliEnableTrue( splitContainer1 );
            StateOfControl.SpliClear( splitContainer1 );
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = getDate( );
            sign = "1";

            button11_Click( null ,null );
        }
        private void toolEdit_Click ( object sender ,EventArgs e )
        {
            /*
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = getDate( ).AddDays( -1 );
            if ( !( DateTime.Now.AddDays( -1 ) <= dateTimePicker1.Value ) )
            {
                MessageBox.Show( "只能编辑当天及前一天的记录" );
                return;
            }
            */

            if (string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("idx").ToString()))
            {
                MessageBox.Show( "请选择需要编辑的内容" );
                return;
            }
            //if ( !_bll.ExistsOfMax( lookUpEdit3.Text ,textBox30.Text ) )
            //{
            //    MessageBox.Show( "只允许更改本工单最后一道工序" );
            //    return;
            //}
            toolEdit.Enabled = toolQuery.Enabled = toolAdd.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            StateOfControl.SpliEnableTrue( splitContainer1 );
            dateTimePicker1.Enabled = false;
            sign = "2";
        }
        private void toolSave_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
            {
                MessageBox.Show( "请生成报工单号" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "员工编号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "员工姓名不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit2.Text ) )
            {
                MessageBox.Show( "工艺不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "工艺名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit3.Text ) )
            {
                MessageBox.Show( "工单单号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox8.Text ) )
            {
                MessageBox.Show( "主件品号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox9.Text ) )
            {
                MessageBox.Show( "主件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox10.Text ) )
            {
                MessageBox.Show( "产出数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox18.Text ) )
            {
                MessageBox.Show( "投入数量不可为空" );
                return;
            }
            if ( textBox4.Text == "光刻" )
            {
                if ( string.IsNullOrEmpty( textBox27.Text ) )
                {
                    MessageBox.Show( "请选择操作工1" );
                    return;
                }
            }
            if ( textBox4.Text == "粘片" )
            {
                if ( string.IsNullOrEmpty( textBox27.Text ) )
                {
                    MessageBox.Show( "请选择操作工1" );
                    return;
                }
                if ( string.IsNullOrEmpty( textBox23.Text ) )
                {
                    MessageBox.Show( "请选择操作工2" );
                    return;
                }
            }
            variable( );
            if ( _model.BGD010 > _model.BGD018 )
            {
                MessageBox.Show( "产出数量多于投入数量" );
                return;
            }
            if ( sign == "1" )
            {
                result = _bll.Exists( _model.BGD006 ,_model.BGD030 );
                if ( result == true )
                {
                    MessageBox.Show( "同工单单号、同工序只能存在一条记录" );
                    return;
                }
                if ( textBox30.Text != "010" )
                {
                    result = _bll.ExistsPrevious( _model.BGD006 ,_model.BGD030 );
                    if ( result == false )
                    {
                        MessageBox.Show( "不能跳工序新建,请重新选择工序" );
                        return;
                    }
                }
                result = _bll.Esits( _model );
                if ( result == true )
                    button11_Click( null ,null );
                if ( _model.BGD006 == null || _model.BGD004==null)
                    variable( );

                _model . BGD032 = _model . BGD034 = getDate ( );
                result = _bll.InsertTran( _model );
                if ( result == true )
                {
                    MessageBox.Show( "已录入" );

                    toolQuery.Enabled = toolAdd.Enabled = toolEdit.Enabled = toolClear.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = false;
                    StateOfControl.SpliEnableFalse( splitContainer1 );
                    button2.Enabled = button1.Enabled = button4.Enabled = true;
                    lookUpEdit1.Enabled = lookUpEdit2.Enabled = lookUpEdit3.Enabled = true;
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BGD006='" + lookUpEdit3.Text + "'";
                    queryBuild( );
                    _bll . findAndEidt ( _model . BGD006 );
                }
                else
                    MessageBox.Show( "录入失败" );
            }
            if ( sign == "2" )
            {
                if ( gdh != _model.BGD006 )
                {
                    MessageBox.Show( "工单单号不允许编辑" );
                    return;
                }
                if ( gdh != _model.BGD006 && odd != _model.BGD030 )
                {
                    MessageBox.Show( "工单单号、工序不可更改" );
                    return;
                }
                if ( _model.BGD006 == null || _model.BGD004 == null )
                    variable( );
                result = _bll.UpdateTrans( _model );
                if ( result == true )
                {
                    MessageBox.Show( "编辑成功" );

                    toolQuery.Enabled = toolAdd.Enabled = toolEdit.Enabled = toolClear.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = false;
                    StateOfControl.SpliEnableFalse( splitContainer1 );
                    button2.Enabled = button1.Enabled = button4.Enabled = true;
                    lookUpEdit1.Enabled = lookUpEdit2.Enabled = lookUpEdit3.Enabled = true;
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BGD006='" + lookUpEdit3.Text + "'";
                    query( );
                    _bll . findAndEidt ( _model . BGD006 );
                }
                else
                    MessageBox.Show( "编辑失败" );
            }
        }
        void variable ( )
        {
            _model.BGD001 = textBox3.Text;
            _model.BGD002 = lookUpEdit1.Text;
            _model.BGD003 = textBox2.Text;
            _model.BGD004 = lookUpEdit2.Text;
            _model.BGD005 = textBox4.Text;
            _model.BGD006 = lookUpEdit3.Text;
            _model.BGD007 = textBox8.Text;
            _model.BGD008 = textBox9.Text;
            _model.BGD009 = textBox7.Text;
            _model.BGD010 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToInt32( textBox10.Text );
            _model.BGD011 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToInt32( textBox11.Text );
            _model.BGD012 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
            _model.BGD013 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToInt32( textBox12.Text );
            _model.BGD014 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToInt32( textBox14.Text );
            _model.BGD015 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0 : Convert.ToInt32( textBox17.Text );
            _model.BGD016 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToInt32( textBox16.Text );
            _model.BGD017 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToInt32( textBox15.Text );
            _model.BGD018 = string.IsNullOrEmpty( textBox18.Text ) == true ? 0 : Convert.ToInt32( textBox18.Text );
            _model.BGD019 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text );
            _model.BGD020 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToInt32( textBox20.Text );
            _model.BGD021 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt32( textBox21.Text );
            _model.BGD022 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text );
            _model.BGD023 = "T";
            _model.BGD024 = textBox23.Text;
            _model.BGD027 = textBox27.Text;
            _model.BGD030 = textBox30.Text;
            _model.BGD032 = dateTimePicker1.Value;
            _model.BGD033 = textBox1.Text;
            _model.BGD034 = dateTimePicker1.Value;
            _model.BGD035 = lookUpEdit4.Text;
            _model.BGD036 = lookUpEdit5.Text;
        }
        private void toolCancel_Click ( object sender ,EventArgs e )
        {
            toolQuery.Enabled = toolAdd.Enabled = toolClear.Enabled = toolEdit.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            StateOfControl.SpliEnableFalse( splitContainer1 );
            button2.Enabled = button1.Enabled = button4.Enabled = true;
            lookUpEdit1.Enabled = lookUpEdit3.Enabled = true;

            if ( sign == "1" )
            {
                _model . BGD001 = string . Empty;
                textBox3 . Text = string . Empty;
            }
        }
        DateTime getDate ( )
        {
            DataTable date = _bll.GetDataTableGetDate( );
            if ( date != null && date.Rows.Count > 0 )
            {
                dt = string.IsNullOrEmpty( date.Rows[0]["t"].ToString( ) ) == true ? DateTime.Now : Convert.ToDateTime( date.Rows[0]["t"].ToString( ) );
            }

            return dt;
        }
        #endregion

        #region Table
        //refre
        private void button7_Click ( object sender ,EventArgs e )
        {
            strWhere = "";
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( strWhere == "" )
                    strWhere = "'" + gridView1.GetDataRow( i )["idx"].ToString( ) + "'";
                else
                    strWhere = strWhere + "," + "'" + gridView1.GetDataRow( i )["idx"].ToString( ) + "'";
            }
            query( );   
        }
        void query ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "''";
            tableQuery = _bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableQuery;
        }
        void queryBuild ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "''";
            tableQuery = _bll.GetDataTableBuild( strWhere );
            gridControl1.DataSource = tableQuery;
        }
        #endregion

        #region Event
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
                textBox2.Text = lookUpEdit1.EditValue.ToString( );
        }
        private void lookUpEdit4_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit4.EditValue != null )
                textBox27.Text = lookUpEdit4.EditValue.ToString( );
        }
        private void lookUpEdit5_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit5.EditValue != null )
                textBox23.Text = lookUpEdit5.EditValue.ToString( );
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox10 );
            DateDay.intgra( e );
        }
        private void textBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox11 );
            DateDay.intgra( e );
        }
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox13 );
            DateDay.intgra( e );
        }
        private void textBox13_TextChanged ( object sender ,EventArgs e )
        {
            if ( textBox4.Text == "初测" || textBox4.Text == "包装" || textBox4.Text == "复测" )
            {
                int xs = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
                int ys = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToInt32( textBox20.Text );
                textBox10.Text = ( ys + xs ).ToString( );
            }  
        }
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox12 );
            DateDay.intgra( e );
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox14 );
            DateDay.intgra( e );
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox17 );
            DateDay.intgra( e );
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox16 );
            DateDay.intgra( e );
        }
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox15 );
            DateDay.intgra( e );
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox18 );
            DateDay.intgra( e );
        }
        //投入数量
        private void textBox18_TextChanged ( object sender ,EventArgs e )
        {
            if ( textBox4.Text == "光刻" || textBox4.Text == "划片" || textBox4.Text == "去胶" )
                textBox10.Text = textBox18.Text;
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox19 );
            DateDay.intgra( e );
        }
        private void textBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox20 );
            DateDay.intgra( e );
        }
        private void textBox20_TextChanged ( object sender ,EventArgs e )
        {
            if ( textBox4.Text == "初测" || textBox4.Text == "包装" || textBox4.Text == "复测" )
                textBox10.Text = ( string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToInt32( textBox20.Text ) + ( string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text ) ) ).ToString( );
        }
        private void textBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox21 );
            DateDay.intgra( e );
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox22 );
            DateDay.intgra( e );
        }
        //工艺名称
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            if ( textBox4.Text == "光刻" )
                textBox18.ReadOnly = false;
            else
            {
                textBox18.ReadOnly = true;
                textBox18.Text = textBox10.Text = "";
                DataTable da = _bll.GetDataTableOfPrevious( textBox30.Text ,lookUpEdit3.Text );
                if ( da != null && da.Rows.Count > 0 )
                    textBox18.Text = da.Rows[0]["BGD010"].ToString( );
            }
            if ( textBox4.Text == "初测" ||  textBox4.Text == "包装" || textBox4.Text == "复测" )
                textBox10.ReadOnly = true;
            else
                textBox10.ReadOnly = false;

            if ( textBox4.Text == "粘片" )
            {
                DataTable dl = _bll.GetDataTableOfPrevious( lookUpEdit3.Text );
                if ( dl != null && dl.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < dl.Rows.Count ; i++ )
                    {
                        if ( dl.Rows[i]["BGD005"].ToString( ) == "去胶" )
                            textBox23.Text = dl.Rows[i]["BGD003"].ToString( );
                        else if ( dl.Rows[i]["BGD005"].ToString( ) == "划片" )
                            textBox27.Text = dl.Rows[i]["BGD003"].ToString( );
                    }
                }
            }
        }
        string gdh = "", odd = "";
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                recordLast = _model.IDX;
                if ( _model.IDX > 0 )
                    assignMent( );
            }
        }
        void assignMent ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( _model == null )
                return;        
            textBox11.Text = _model.BGD011.ToString( );            
            textBox3.Text = _model.BGD001;
            lookUpEdit1.Text = _model.BGD002;
            textBox2.Text = _model.BGD003;
            textBox4.Text = _model.BGD005;
            lookUpEdit3.Text = _model.BGD006;
            lookUpEdit2.Text = _model.BGD004;
            textBox8.Text = _model.BGD007;
            textBox9.Text = _model.BGD008;
            textBox7.Text = _model.BGD009;          
            textBox13.Text = _model.BGD012.ToString( );
            textBox12.Text = _model.BGD013.ToString( );
            textBox14.Text = _model.BGD014.ToString( );
            textBox17.Text = _model.BGD015.ToString( );
            textBox16.Text = _model.BGD016.ToString( );
            textBox15.Text = _model.BGD017.ToString( );        
            textBox19.Text = _model.BGD019.ToString( );
            textBox20.Text = _model.BGD020.ToString( );
            textBox21.Text = _model.BGD021.ToString( );
            textBox22.Text = _model.BGD022.ToString( );
            textBox27.Text = _model.BGD027;         
            textBox30.Text = _model.BGD030;
            textBox18.Text = _model.BGD018.ToString( );
            textBox10.Text = _model.BGD010.ToString( );
            textBox23.Text = _model.BGD024;           
            textBox1.Text = _model.BGD033;
            lookUpEdit4.Text = _model.BGD035;
            lookUpEdit5.Text = _model.BGD036;
            if ( sign != "1" )
            {
                if ( _model . BGD032 > DateTime . MinValue && _model . BGD032 < DateTime . MaxValue )
                    dateTimePicker1 . Value = _model . BGD032;
            }
            gdh = lookUpEdit3.Text;
            odd = textBox30.Text;
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            dp = _bll.GetDataTableTeahs( lookUpEdit3.Text );
            lookUpEdit2.Properties.DataSource = dp;
            lookUpEdit2.Properties.DisplayMember = "RAC003";
            textBox4.Text = textBox30.Text = "";

            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) && gd.Select( "RAC001='" + lookUpEdit3.Text + "'" ).Length > 0 )
            {
                textBox8.Text = gd.Select( "RAC001='" + lookUpEdit3.Text + "'" )[0]["DEA001"].ToString( );
                textBox7.Text = gd.Select( "RAC001='" + lookUpEdit3.Text + "'" )[0]["DEA057"].ToString( );
                textBox9.Text = gd.Select( "RAC001='" + lookUpEdit3.Text + "'" )[0]["DEA002"].ToString( );
                //lookUpEdit2_EditValueChanged( null ,null );
            }
            else
                textBox7.Text = textBox8.Text = textBox9.Text = "";
        }
        private void lookUpEdit2_EditValueChanged ( object sender ,EventArgs e )
        {  
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) && dp.Select( ).Length > 0 )
            {
                textBox30.Text = dp.Select( "RAC003='" + lookUpEdit2.Text + "'" )[0]["RAC002"].ToString( );
                textBox4.Text = dp.Select( "RAC003='" + lookUpEdit2.Text + "'" )[0]["QBA002"].ToString( );
                //textBox4_TextChanged( null ,null );
            }
            else
                textBox4.Text = textBox30.Text = "";
        }
        private void toolAdd_EnabledChanged ( object sender ,EventArgs e )
        {
            //recordLast = lookUpEdit3.Text;
            //record = lookUpEdit2.Text;
            if ( toolAdd.Enabled == false )
            {
                gd = _bll.GetDataTableWorkOrder( );
                lookUpEdit3.Properties.DataSource = gd;
                lookUpEdit3.Properties.DisplayMember = "RAC001";
                _model.IDX = recordLast;
                assignMent( );
                //lookUpEdit3.Text = recordLast;
                //lookUpEdit3_EditValueChanged( null ,null );
                //lookUpEdit2.Text = record;
                //lookUpEdit2_EditValueChanged( null ,null );
            }
        }
        private void toolEdit_EnabledChanged ( object sender ,EventArgs e )
        {
            //if ( toolEdit.Enabled == false )
            //{
            //    gd = _bll.GetDataTableWorkOrder( );
            //    lookUpEdit3.Properties.DataSource = gd;
            //    lookUpEdit3.Properties.DisplayMember = "RAC001";
            //}  
        }
        private void textBox21_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = ( ( string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt32( textBox21.Text ) ) + ( string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text ) ) + ( string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text ) ) ).ToString( );
        }
        private void textBox22_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = ( ( string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt32( textBox21.Text ) ) + ( string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text ) ) + ( string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text ) ) ).ToString( );
        }
        private void textBox19_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = ( ( string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt32( textBox21.Text ) ) + ( string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text ) ) + ( string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text ) ) ).ToString( );
        }
        private void toolSave_EnabledChanged ( object sender ,EventArgs e )
        {
            //if ( toolSave.Enabled == true )
            //    gridView1_RowClick( null ,null );
        }
        #endregion

        #region query
        //Generate
        private void button11_Click ( object sender ,EventArgs e )
        {
            DateTime dtThis = getDate ( );
            //_model = new LanDeLibrary.LanDeOrderEntity( );
            if ( _model == null )
                _model = new LanDeLibrary . LanDeOrderEntity ( );
            DataTable bg = _bll . GetDataTableOddNum ( );
            if ( bg == null || bg . Rows . Count < 1 )
                _model . BGD001 = dtThis . ToString ( "yyyyMMdd" ) . Substring ( 2 ,6 ) + "0001";
            else
            {
                if ( string . IsNullOrEmpty ( bg . Rows [ 0 ] [ "BGD001" ] . ToString ( ) ) )
                    _model . BGD001 = dtThis . ToString ( "yyyyMMdd" ) . Substring ( 2 ,6 ) + "0001";
                else
                {
                    if ( bg . Rows [ 0 ] [ "BGD001" ] . ToString ( ) . Substring ( 0 ,6 ) == dtThis . ToString ( "yyyyMMdd" ) . Substring ( 2 ,6 ) )
                        _model . BGD001 = ( Convert . ToInt64 ( bg . Rows [ 0 ] [ "BGD001" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        _model . BGD001 = dtThis . ToString ( "yyyyMMdd" ) . Substring ( 2 ,6 ) + "0001";
                }
            }
            textBox3 . Text = _model . BGD001;
        }
        //ple     
        private void button1_Click ( object sender ,EventArgs e )
        {
            LanDeQuery.PersonnelInformationAll personQuery = new LanDeQuery.PersonnelInformationAll( );
            personQuery.StartPosition = FormStartPosition.CenterScreen;
            personQuery.PassDataBetweenForm += new LanDeQuery.PersonnelInformationAll.PassDataBetweenFormHandler( personQuery_PassDataBetweenForm );
            personQuery.ShowDialog( );
        }
        private void personQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            lookUpEdit1.Text = e.ConOne;
            textBox2.Text = e.ConTwo;
        }
        private void button12_Click ( object sender ,EventArgs e )
        {
            LanDeQuery.PersonnelInformationAll personQuery = new LanDeQuery.PersonnelInformationAll( );
            personQuery.StartPosition = FormStartPosition.CenterScreen;
            personQuery.PassDataBetweenForm += new LanDeQuery.PersonnelInformationAll.PassDataBetweenFormHandler( personQuerys_PassDataBetweenForm );
            personQuery.ShowDialog( );
        }
        private void personQuerys_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            lookUpEdit4.Text = e.ConOne;
            textBox27.Text = e.ConTwo;
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            LanDeQuery.PersonnelInformationAll personQuery = new LanDeQuery.PersonnelInformationAll( );
            personQuery.StartPosition = FormStartPosition.CenterScreen;
            personQuery.PassDataBetweenForm += new LanDeQuery.PersonnelInformationAll.PassDataBetweenFormHandler( personQueryEs_PassDataBetweenForm );
            personQuery.ShowDialog( );
        }
        private void personQueryEs_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            lookUpEdit5.Text = e.ConOne;
            textBox23.Text = e.ConTwo;
        }
        //work
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit3.Text ) )
            {
                MessageBox.Show( "请选择工单信息" );
                return;
            }

            LanDeQuery.TechnologyAll techQuery = new LanDeQuery.TechnologyAll( );
            techQuery.StartPosition = FormStartPosition.CenterScreen;
            techQuery.PassDataBetweenForm += new LanDeQuery.TechnologyAll.PassDataBetweenFormHandler( techQuery_PassDataBetweenForm );
            techQuery.str = lookUpEdit3.Text;
            techQuery.ShowDialog( );
        }
        private void techQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox30.Text = e.ConFiv;
            textBox27.Text = e.ConTre;
            lookUpEdit2.Text = e.ConOne;
            textBox4.Text = e.ConTwo;                   
        }
        //orderNum
        private void button2_Click ( object sender ,EventArgs e )
        {
            LanDeQuery.WorkOrderAll workQuery = new LanDeQuery.WorkOrderAll( );
            workQuery.StartPosition = FormStartPosition.CenterScreen;
            workQuery.PassDataBetweenForm += new LanDeQuery.WorkOrderAll.PassDataBetweenFormHandler( workQuery_PassDataBetweenForm );
            if ( toolSave.Enabled )
                workQuery.sign = "1";
            else
                workQuery.sign = "2";
            workQuery.ShowDialog( );
        }
        private void workQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            lookUpEdit3.Text = e.ConOne;
            textBox8.Text = e.ConTwo;
            textBox9.Text = e.ConTre;
            textBox7.Text = e.ConFor;
        }
        #endregion
    }
}
