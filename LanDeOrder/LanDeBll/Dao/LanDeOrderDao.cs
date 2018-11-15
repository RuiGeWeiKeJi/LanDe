using StudentMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanDeBll.Dao
{
    public class LanDeOrderDao
    {
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( LanDeLibrary.LanDeOrderEntity _model)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM SGMBGD" );
            strSql.Append( " WHERE BGD006=@BGD006 AND BGD004=@BGD004 AND BGD005=@BGD005" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD004",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD005",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD006",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.BGD004;
            parameter[1].Value = _model.BGD005;
            parameter[2].Value = _model.BGD006;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Esits ( LanDeLibrary.LanDeOrderEntity _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM SGMBGD" );
            strSql.Append( " WHERE BGD001=@BGD001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.BGD001;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="odd"></param>
        /// <returns></returns>
        public bool ExistsTotal ( string odd )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM SGMBGD" );
            strSql.Append( " WHERE BGD006=@BGD006 AND BGD005='镀膜'" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD006",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = odd;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在上一工序
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="workProcude"></param>
        /// <returns></returns>
        public bool ExistsPrevious ( string odd ,string workProcude )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM SGMBGD" );
            strSql.Append( " WHERE BGD030=CONVERT(INT,@BGD030)-10 AND BGD006=@BGD006" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD030",SqlDbType.NVarChar),
                new SqlParameter("@BGD006",SqlDbType.NVarChar)
            };
            parameter[0].Value = workProcude;
            parameter[1].Value = odd;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 同工单单号  同工序
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="gx"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string gx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM SGMBGD" );
            strSql.Append( " WHERE BGD006=@BGD006 AND BGD030=@BGD030" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD006",SqlDbType.NVarChar),
                new SqlParameter("@BGD030",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;
            parameter[1].Value = gx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateTrans ( LanDeLibrary.LanDeOrderEntity _model )
        {
            using ( SqlConnection conn = new SqlConnection( SqlHelper.connstr ) )
            {
                conn.Open( );
                SqlCommand cmd = new SqlCommand( );
                cmd.Connection = conn;
                SqlTransaction tran = conn.BeginTransaction( );
                cmd.Transaction = tran;
                try
                {
                    StringBuilder strSql = new StringBuilder( );
                    strSql.Append( "UPDATE SGMBGD SET " );
                    strSql.Append( "BGD001=@BGD001,"  );
                    strSql.Append( "BGD002=@BGD002,"  );
                    strSql.Append( "BGD003=@BGD003,"  );
                    strSql.Append( "BGD004=@BGD004,"  );
                    strSql.Append( "BGD005=@BGD005,"  );
                    strSql.Append( "BGD007=@BGD007,"  );
                    strSql.Append( "BGD008=@BGD008,"  );
                    strSql.Append( "BGD009=@BGD009,"  );
                    strSql.Append( "BGD010=@BGD010,"  );
                    strSql.Append( "BGD011=@BGD011,"  );
                    strSql.Append( "BGD012=@BGD012,"  );
                    strSql.Append( "BGD013=@BGD013,"  );
                    strSql.Append( "BGD014=@BGD014,"  );
                    strSql.Append( "BGD015=@BGD015,"  );
                    strSql.Append( "BGD016=@BGD016,"  );
                    strSql.Append( "BGD017=@BGD017,"  );
                    strSql.Append( "BGD018=@BGD018,"  );
                    strSql.Append( "BGD019=@BGD019,"  );
                    strSql.Append( "BGD020=@BGD020,"  );
                    strSql.Append( "BGD021=@BGD021,"  );
                    strSql.Append( "BGD022=@BGD022,"  );
                    //strSql.Append( "BGD023=@BGD023,"  );
                    strSql.Append( "BGD024=@BGD024,"  );
                    strSql.Append( "BGD027=@BGD027,"  );
                    //strSql.Append( "BGD032=@BGD032," );
                    strSql.Append( "BGD033=@BGD033,"  );
                    strSql.Append( "BGD035=@BGD035,"  );
                    strSql.Append( "BGD036=@BGD036"  );
                    strSql.Append( " WHERE BGD006=@BGD006 AND BGD030=@BGD030"  );
                    SqlParameter[] parameter = {
                new SqlParameter("@BGD001",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD002",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD003",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD004",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD005",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD006",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD007",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD008",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD009",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD010",SqlDbType.Int),
                new SqlParameter("@BGD011",SqlDbType.Int),
                new SqlParameter("@BGD012",SqlDbType.Int),
                new SqlParameter("@BGD013",SqlDbType.Int),
                new SqlParameter("@BGD014",SqlDbType.Int),
                new SqlParameter("@BGD015",SqlDbType.Int),
                new SqlParameter("@BGD016",SqlDbType.Int),
                new SqlParameter("@BGD017",SqlDbType.Int),
                new SqlParameter("@BGD018",SqlDbType.Int),
                new SqlParameter("@BGD019",SqlDbType.Int),
                new SqlParameter("@BGD020",SqlDbType.Int),
                new SqlParameter("@BGD021",SqlDbType.Int),
                new SqlParameter("@BGD022",SqlDbType.Int),
                //new SqlParameter("@BGD023",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD024",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD027",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD030",SqlDbType.NVarChar,20),
                //new SqlParameter("@BGD032",SqlDbType.DateTime),
                new SqlParameter("@BGD033",SqlDbType.NVarChar,3000),
                //new SqlParameter("@BGD034",SqlDbType.Date),
                new SqlParameter("@BGD035",SqlDbType.NChar,10),
                new SqlParameter("@BGD036",SqlDbType.NChar,10)
            };
                    parameter[0].Value = _model.BGD001;
                    parameter[1].Value = _model.BGD002;
                    parameter[2].Value = _model.BGD003;
                    parameter[3].Value = _model.BGD004;
                    parameter[4].Value = _model.BGD005;
                    parameter[5].Value = _model.BGD006;
                    parameter[6].Value = _model.BGD007;
                    parameter[7].Value = _model.BGD008;
                    parameter[8].Value = _model.BGD009;
                    parameter[9].Value = _model.BGD010;
                    parameter[10].Value = _model.BGD011;
                    parameter[11].Value = _model.BGD012;
                    parameter[12].Value = _model.BGD013;
                    parameter[13].Value = _model.BGD014;
                    parameter[14].Value = _model.BGD015;
                    parameter[15].Value = _model.BGD016;
                    parameter[16].Value = _model.BGD017;
                    parameter[17].Value = _model.BGD018;
                    parameter[18].Value = _model.BGD019;
                    parameter[19].Value = _model.BGD020;
                    parameter[20].Value = _model.BGD021;
                    parameter[21].Value = _model.BGD022;
                    //parameter[22].Value = _model.BGD023;
                    parameter[22].Value = _model.BGD024;
                    parameter[23].Value = _model.BGD027;
                    parameter[24].Value = _model.BGD030;
                    //parameter[25].Value = _model.BGD032;
                    parameter[25].Value = _model.BGD033;
                    //parameter[28].Value = _model.BGD034;
                    parameter[26].Value = _model.BGD035;
                    parameter[27].Value = _model.BGD036;

                    SqlHelper.PrepareCommand( cmd ,conn ,tran ,strSql.ToString( ) ,parameter );
                    cmd.CommandText = strSql.ToString( );
                    cmd.ExecuteNonQuery( );

                    SqlHelper . SaveLog ( strSql . ToString ( ) ,parameter );

                    StringBuilder strS = new StringBuilder( );
                    strS.Append( "UPDATE SGMRAC SET " );
                    strS.Append( "RAC008=@BGD018,"  );//投入
                    strS.Append( "RAC009=@BGD010,"  );//产出
                    strS.Append( "RAC010=@BGD026," );//在制
                    strS.Append( "RAC011=@BGD010,"  );
                    strS.Append( "RAC026=@BGD011,"  );
                    strS.Append( "RAC980=@BGD012," );
                    strS.Append( "RAC981=@BGD013,"  );
                    strS.Append( "RAC982=@BGD014,"  );
                    strS.Append( "RAC983=@BGD015,"  );
                    strS.Append( "RAC984=@BGD016,"  );
                    strS.Append( "RAC985=@BGD017,"  );
                    strS.Append( "RAC960=@BGD019,"  );
                    strS.Append( "RAC961=@BGD020,"  );
                    strS.Append( "RAC962=@BGD021,"  );
                    strS.Append( "RAC963=@BGD022"  );
                    strS.Append( " WHERE RAC001=@BGD006 AND RAC002=@BGD030" );
                    SqlParameter[] paramete = {
                    new SqlParameter("@BGD010",SqlDbType.Int),
                    new SqlParameter("@BGD011",SqlDbType.Int),
                    new SqlParameter("@BGD012",SqlDbType.Int),
                    new SqlParameter("@BGD013",SqlDbType.Int),
                    new SqlParameter("@BGD014",SqlDbType.Int),
                    new SqlParameter("@BGD015",SqlDbType.Int),
                    new SqlParameter("@BGD016",SqlDbType.Int),
                    new SqlParameter("@BGD017",SqlDbType.Int),
                    new SqlParameter("@BGD018",SqlDbType.Int),
                    new SqlParameter("@BGD019",SqlDbType.Int),
                    new SqlParameter("@BGD020",SqlDbType.Int),
                    new SqlParameter("@BGD021",SqlDbType.Int),
                    new SqlParameter("@BGD022",SqlDbType.Int),
                    new SqlParameter("@BGD026",SqlDbType.NChar,10),
                    new SqlParameter("@BGD006",SqlDbType.NVarChar,20),
                    new SqlParameter("@BGD030",SqlDbType.NVarChar,20)
                };
                    paramete[0].Value = _model.BGD010;
                    paramete[1].Value = _model.BGD011;
                    paramete[2].Value = _model.BGD012;
                    paramete[3].Value = _model.BGD013;
                    paramete[4].Value = _model.BGD014;
                    paramete[5].Value = _model.BGD015;
                    paramete[6].Value = _model.BGD016;
                    paramete[7].Value = _model.BGD017;
                    paramete[8].Value = _model.BGD018;
                    paramete[9].Value = _model.BGD019;
                    paramete[10].Value = _model.BGD020;
                    paramete[11].Value = _model.BGD021;
                    paramete[12].Value = _model.BGD022;
                    paramete[13].Value = _model.BGD026;
                    paramete[14].Value = _model.BGD006;
                    paramete[15].Value = _model.BGD030;
                    cmd.Parameters.Clear( );
                    SqlHelper.PrepareCommand( cmd ,conn ,tran ,strS.ToString( ) ,paramete );
                    cmd.CommandText = strS.ToString( );
                    cmd.ExecuteNonQuery( );

                    SqlHelper . SaveLog ( strS . ToString ( ) ,paramete );

                    tran .Commit( );
                    return true;
                }
                catch
                {
                    tran.Rollback( );
                    return false;
                }
                finally
                {
                    cmd.Dispose( );
                    conn.Close( );
                }
            }
        }

        /// <summary>
        /// 录入一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool InsertTran ( LanDeLibrary . LanDeOrderEntity _model )
        {
            using ( SqlConnection conn = new SqlConnection ( SqlHelper . connstr ) )
            {
                conn . Open ( );
                SqlCommand cmd = new SqlCommand ( );
                cmd . Connection = conn;
                SqlTransaction tran = conn . BeginTransaction ( );
                cmd . Transaction = tran;
                try
                {
                    StringBuilder strSql = new StringBuilder ( );

                    //if ( DeleteExists ( _model . BGD006 ,_model . BGD030 ) )
                    //{
                    strSql . Append ( "UPDATE SGMBGD SET " );
                    strSql . Append ( "BGD023='F'" );
                    strSql . AppendFormat ( " WHERE BGD006=@BGD006" );// AND BGD030=CONVERT(INT,@BGD030)-10
                    SqlParameter [ ] paramet = {
                                       new SqlParameter("@BGD006",SqlDbType.NVarChar,20)//,
                                       //new SqlParameter("@BGD030",SqlDbType.NVarChar,20)
                        };
                    paramet [ 0 ] . Value = _model . BGD006;
                    //paramet [ 1 ] . Value = _model . BGD030;
                    //cmd . Parameters . Clear ( );
                    SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,paramet );
                    cmd . CommandText = strSql . ToString ( );
                    cmd . ExecuteNonQuery ( );
                    //}
                    
                    SqlHelper.SaveLog ( strSql . ToString ( ) ,paramet );

                    strSql = new StringBuilder ( );
                    strSql . Append ( "INSERT INTO SGMBGD ( " );
                    strSql . Append ( "BGD001,BGD002,BGD003,BGD004,BGD005,BGD006,BGD007,BGD008,BGD009,BGD010,BGD011,BGD012,BGD013,BGD014,BGD015,BGD016,BGD017,BGD018,BGD019,BGD020,BGD021,BGD022,BGD023,BGD024,BGD027,BGD030,BGD032,BGD033,BGD034,BGD035,BGD036)" );
                    strSql . Append ( " VALUES (@BGD001,@BGD002,@BGD003,@BGD004,@BGD005,@BGD006,@BGD007,@BGD008,@BGD009,@BGD010,@BGD011,@BGD012,@BGD013,@BGD014,@BGD015,@BGD016,@BGD017,@BGD018,@BGD019,@BGD020,@BGD021,@BGD022,@BGD023,@BGD024,@BGD027,@BGD030,@BGD032,@BGD033,@BGD034,@BGD035,@BGD036)" );
                    SqlParameter [ ] parameter = {
                new SqlParameter("@BGD001",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD002",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD003",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD004",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD005",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD006",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD007",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD008",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD009",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD010",SqlDbType.Int),
                new SqlParameter("@BGD011",SqlDbType.Int),
                new SqlParameter("@BGD012",SqlDbType.Int),
                new SqlParameter("@BGD013",SqlDbType.Int),
                new SqlParameter("@BGD014",SqlDbType.Int),
                new SqlParameter("@BGD015",SqlDbType.Int),
                new SqlParameter("@BGD016",SqlDbType.Int),
                new SqlParameter("@BGD017",SqlDbType.Int),
                new SqlParameter("@BGD018",SqlDbType.Int),
                new SqlParameter("@BGD019",SqlDbType.Int),
                new SqlParameter("@BGD020",SqlDbType.Int),
                new SqlParameter("@BGD021",SqlDbType.Int),
                new SqlParameter("@BGD022",SqlDbType.Int),
                new SqlParameter("@BGD023",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD024",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD027",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD030",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD032",SqlDbType.DateTime),
                new SqlParameter("@BGD033",SqlDbType.NVarChar,3000),
                new SqlParameter("@BGD034",SqlDbType.Date),
                new SqlParameter("@BGD035",SqlDbType.NChar,10),
                new SqlParameter("@BGD036",SqlDbType.NChar,10)
            };
                    parameter [ 0 ] . Value = _model . BGD001;
                    parameter [ 1 ] . Value = _model . BGD002;
                    parameter [ 2 ] . Value = _model . BGD003;
                    parameter [ 3 ] . Value = _model . BGD004;
                    parameter [ 4 ] . Value = _model . BGD005;
                    parameter [ 5 ] . Value = _model . BGD006;
                    parameter [ 6 ] . Value = _model . BGD007;
                    parameter [ 7 ] . Value = _model . BGD008;
                    parameter [ 8 ] . Value = _model . BGD009;
                    parameter [ 9 ] . Value = _model . BGD010;
                    parameter [ 10 ] . Value = _model . BGD011;
                    parameter [ 11 ] . Value = _model . BGD012;
                    parameter [ 12 ] . Value = _model . BGD013;
                    parameter [ 13 ] . Value = _model . BGD014;
                    parameter [ 14 ] . Value = _model . BGD015;
                    parameter [ 15 ] . Value = _model . BGD016;
                    parameter [ 16 ] . Value = _model . BGD017;
                    parameter [ 17 ] . Value = _model . BGD018;
                    parameter [ 18 ] . Value = _model . BGD019;
                    parameter [ 19 ] . Value = _model . BGD020;
                    parameter [ 20 ] . Value = _model . BGD021;
                    parameter [ 21 ] . Value = _model . BGD022;
                    parameter [ 22 ] . Value = _model . BGD023;
                    parameter [ 23 ] . Value = _model . BGD024;
                    parameter [ 24 ] . Value = _model . BGD027;
                    parameter [ 25 ] . Value = _model . BGD030;
                    parameter [ 26 ] . Value = _model . BGD032;
                    parameter [ 27 ] . Value = _model . BGD033;
                    parameter [ 28 ] . Value = _model . BGD034;
                    parameter [ 29 ] . Value = _model . BGD035;
                    parameter [ 30 ] . Value = _model . BGD036;

                    cmd . Parameters . Clear ( );
                    SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
                    cmd . CommandText = strSql . ToString ( );
                    cmd . ExecuteNonQuery ( );

                    SqlHelper . SaveLog ( strSql . ToString ( ) ,parameter );

                    DataTable tableQuery = GetData ( _model . BGD006 ,_model . BGD004 );
                    if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                    {
                        _model . BGD018 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC008" ] . ToString ( ) );
                        _model . BGD010 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC009" ] . ToString ( ) );
                        _model . BGD011 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC026" ] . ToString ( ) );
                        _model . BGD012 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC980" ] . ToString ( ) );
                        _model . BGD013 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC981" ] . ToString ( ) );
                        _model . BGD014 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC982" ] . ToString ( ) );
                        _model . BGD015 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC983" ] . ToString ( ) );
                        _model . BGD016 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC984" ] . ToString ( ) );
                        _model . BGD017 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC985" ] . ToString ( ) );
                        _model . BGD019 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC960" ] . ToString ( ) );
                        _model . BGD020 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC961" ] . ToString ( ) );
                        _model . BGD021 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC962" ] . ToString ( ) );
                        _model . BGD022 += Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "RAC963" ] . ToString ( ) );
                    }
                    StringBuilder strS = new StringBuilder ( );
                    strS . Append ( "UPDATE SGMRAC SET " );
                    strS . Append ( "RAC008=@BGD018," );
                    strS . Append ( "RAC009=@BGD010," );
                    strS . Append ( "RAC010=@BGD026," );
                    strS . Append ( "RAC011=@BGD010," );
                    strS . Append ( "RAC026=@BGD011," );
                    strS . Append ( "RAC980=@BGD012," );
                    strS . Append ( "RAC981=@BGD013," );
                    strS . Append ( "RAC982=@BGD014," );
                    strS . Append ( "RAC983=@BGD015," );
                    strS . Append ( "RAC984=@BGD016," );
                    strS . Append ( "RAC985=@BGD017," );
                    strS . Append ( "RAC960=@BGD019," );
                    strS . Append ( "RAC961=@BGD020," );
                    strS . Append ( "RAC962=@BGD021," );
                    strS . Append ( "RAC963=@BGD022" );
                    strS . Append ( " WHERE RAC001=@BGD006 AND RAC002=@BGD030" );
                    SqlParameter [ ] paramete = {
                    new SqlParameter("@BGD010",SqlDbType.Int),
                    new SqlParameter("@BGD011",SqlDbType.Int),
                    new SqlParameter("@BGD012",SqlDbType.Int),
                    new SqlParameter("@BGD013",SqlDbType.Int),
                    new SqlParameter("@BGD014",SqlDbType.Int),
                    new SqlParameter("@BGD015",SqlDbType.Int),
                    new SqlParameter("@BGD016",SqlDbType.Int),
                    new SqlParameter("@BGD017",SqlDbType.Int),
                    new SqlParameter("@BGD018",SqlDbType.Int),
                    new SqlParameter("@BGD019",SqlDbType.Int),
                    new SqlParameter("@BGD020",SqlDbType.Int),
                    new SqlParameter("@BGD021",SqlDbType.Int),
                    new SqlParameter("@BGD022",SqlDbType.Int),
                    new SqlParameter("@BGD026",SqlDbType.NChar,10),
                    new SqlParameter("@BGD006",SqlDbType.NVarChar,20),
                    new SqlParameter("@BGD030",SqlDbType.NVarChar,20)
                };
                    paramete [ 0 ] . Value = _model . BGD010;
                    paramete [ 1 ] . Value = _model . BGD011;
                    paramete [ 2 ] . Value = _model . BGD012;
                    paramete [ 3 ] . Value = _model . BGD013;
                    paramete [ 4 ] . Value = _model . BGD014;
                    paramete [ 5 ] . Value = _model . BGD015;
                    paramete [ 6 ] . Value = _model . BGD016;
                    paramete [ 7 ] . Value = _model . BGD017;
                    paramete [ 8 ] . Value = _model . BGD018;
                    paramete [ 9 ] . Value = _model . BGD019;
                    paramete [ 10 ] . Value = _model . BGD020;
                    paramete [ 11 ] . Value = _model . BGD021;
                    paramete [ 12 ] . Value = _model . BGD022;
                    paramete [ 13 ] . Value = _model . BGD026;
                    paramete [ 14 ] . Value = _model . BGD006;
                    paramete [ 15 ] . Value = _model . BGD030;
                    cmd . Parameters . Clear ( );
                    SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strS . ToString ( ) ,paramete );
                    cmd . CommandText = strS . ToString ( );
                    cmd . ExecuteNonQuery ( );

                    SqlHelper . SaveLog ( strS . ToString ( ) ,paramete );

                    tran . Commit ( );
                    return true;
                }
                catch
                {
                    tran . Rollback ( );
                    return false;
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }
        DataTable GetData (string bgd006,string bgd004 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ISNULL(SUM(CONVERT(INT,RAC008)),0) RAC008,ISNULL(SUM(CONVERT(INT,RAC009)),0) RAC009,ISNULL(SUM(CONVERT(INT,RAC011)),0) RAC011,ISNULL(SUM(CONVERT(INT,RAC026)),0) RAC026,ISNULL(SUM(CONVERT(INT,RAC980)),0) RAC980,ISNULL(SUM(CONVERT(INT,RAC981)),0) RAC981,ISNULL(SUM(CONVERT(INT,RAC982)),0) RAC982,ISNULL(SUM(CONVERT(INT,RAC983)),0) RAC983,ISNULL(SUM(CONVERT(INT,RAC984)),0) RAC984,ISNULL(SUM(CONVERT(INT,RAC985)),0) RAC985,ISNULL(SUM(CONVERT(INT,RAC960)),0) RAC960,ISNULL(SUM(CONVERT(INT,RAC961)),0) RAC961,ISNULL(SUM(CONVERT(INT,RAC962)),0) RAC962,ISNULL(SUM(CONVERT(INT,RAC963)),0) RAC963 FROM SGMRAC" );
            strSql.Append( " WHERE RAC001=@RAC001 AND RAC003=@RAC003" );
            SqlParameter[] parameter = {
                new SqlParameter("@RAC001",SqlDbType.NVarChar),
                new SqlParameter("@RAC003",SqlDbType.NVarChar)
            };
            parameter[0].Value = bgd006;
            parameter[1].Value = bgd004;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在上一道工序
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="workProduce"></param>
        /// <returns></returns>
        public bool DeleteExists ( string odd ,string workProduce )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM SGMBGD" );
            strSql.Append( " WHERE BGD030=CONVERT(INT,@BGD030)-10 AND BGD006=@BGD006" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD030",SqlDbType.NVarChar),
                new SqlParameter("@BGD006",SqlDbType.NVarChar)
            };
            parameter[0].Value = workProduce;
            parameter[1].Value = odd;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        public int UpdateOfSign ( string odd ,string workProduce )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE SGMBGD SET " );
            strSql.Append( "BGD023='F'" );
            strSql.AppendFormat( " WHERE BGD006=@BGD006 AND BGD030=CONVERT(INT,@BGD030)-10" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD006",SqlDbType.NVarChar,20),
                new SqlParameter("@BGD030",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = odd;
            parameter[1].Value = workProduce;
            return SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,BGD001,BGD002,BGD003,BGD004,BGD005,BGD006,BGD007,BGD008,BGD009,BGD010,BGD011,BGD012,BGD013,BGD014,BGD015,BGD016,BGD017,BGD018,BGD019,BGD020,BGD021,BGD022,BGD023,BGD024,BGD025,BGD026,BGD027,CASE WHEN BGD029=0 THEN CASE WHEN BGD005='镀膜' OR BGD005='光刻' THEN BGD010 ELSE 0 END ELSE BGD029 END BGD029,BGD028,BGD030,BGD032,BGD033,BGD034,BGD035,BGD036 FROM SGMBGD " );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY BGD001" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTables ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,BGD001,BGD002,BGD003,BGD004,BGD005,BGD006,BGD007,BGD008,BGD009,BGD010,BGD011,BGD012,BGD013,BGD014,BGD015,BGD016,BGD017,BGD018,BGD019,BGD020,BGD021,BGD022,BGD023,BGD024,BGD025,BGD026,BGD027,CASE WHEN BGD029=0 THEN CASE WHEN BGD005='镀膜' OR BGD005='光刻' THEN BGD010 ELSE 0 END ELSE BGD029 END BGD029,BGD028,BGD030,BGD032,BGD033,BGD034,BGD035,BGD036 FROM SGMBGD " );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY BGD001" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableBuild ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,BGD001,BGD002,BGD003,BGD004,BGD005,BGD006,BGD007,BGD008,BGD009,BGD010,BGD011,BGD012,BGD013,BGD014,BGD015,BGD016,BGD017,BGD018,BGD019,BGD020,BGD021,BGD022,BGD023,BGD024,BGD025,BGD026,BGD027,CASE WHEN BGD029=0 THEN CASE WHEN BGD005='镀膜' OR BGD005='光刻' THEN BGD010 ELSE 0 END ELSE BGD029 END BGD029,BGD028,BGD030,BGD032,BGD033,BGD034,BGD035,BGD036 FROM SGMBGD " );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY BGD001" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePeople (  )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DBA001,DBA002 FROM TPADBA WHERE DBA043='F'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取工序信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTeah ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT QBA960,QBA961,RAC003,QBA002,RAC002 FROM SGMRAC LEFT JOIN SGMQBA ON QBA001=RAC003" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " AND QBA002 IS NOT NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取工单单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkOrder ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT RAC001,DEA001,DEA002,DEA057 FROM SGMRAA A RIGHT JOIN SGMRAC B ON A.RAA001=B.RAC001 LEFT JOIN TPADEA C ON A.RAA015=C.DEA001 WHERE RAC001 NOT IN (SELECT BGD006 FROM SGMBGD WHERE BGD005='包装') AND RAA020 NOT IN ('Y','F') ORDER BY RAC001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableWorkOrderOne ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT RAC001,DEA001,DEA002,DEA057 FROM SGMRAA A RIGHT JOIN SGMRAC B ON A.RAA001=B.RAC001 LEFT JOIN TPADEA C ON A.RAA015=C.DEA001 RIGHT JOIN SGMBGD D ON B.RAC001=D.BGD006 WHERE RAC001 IS NOT NULL ORDER BY RAC001" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 生成报工单号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOddNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(BGD001) BGD001 FROM SGMBGD" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public LanDeLibrary.LanDeOrderEntity GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,BGD001,BGD002,BGD003,BGD004,BGD005,BGD006,BGD007,BGD008,BGD009,BGD010,BGD011,BGD012,BGD013,BGD014,BGD015,BGD016,BGD017,BGD018,BGD019,BGD020,BGD021,BGD022,BGD023,BGD024,BGD025,BGD026,BGD027,CASE WHEN BGD029=0 THEN CASE WHEN BGD005='镀膜' OR BGD005='光刻' THEN BGD010 ELSE 0 END ELSE BGD029 END BGD029,BGD028,BGD030,BGD032,BGD033,BGD034,BGD035,BGD036 FROM SGMBGD " );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public LanDeLibrary.LanDeOrderEntity GetDataRow ( DataRow row )
        {
            LanDeLibrary.LanDeOrderEntity _model = new LanDeLibrary.LanDeOrderEntity( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["BGD001"] != null && row["BGD001"].ToString( ) != "" )
                    _model.BGD001 = row["BGD001"].ToString( );
                if ( row["BGD002"] != null && row["BGD002"].ToString( ) != "" )
                    _model.BGD002 = row["BGD002"].ToString( );
                if ( row["BGD003"] != null && row["BGD003"].ToString( ) != "" )
                    _model.BGD003 = row["BGD003"].ToString( );
                if ( row["BGD004"] != null && row["BGD004"].ToString( ) != "" )
                    _model.BGD004 = row["BGD004"].ToString( );
                if ( row["BGD005"] != null && row["BGD005"].ToString( ) != "" )
                    _model.BGD005 = row["BGD005"].ToString( );
                if ( row["BGD006"] != null && row["BGD006"].ToString( ) != "" )
                    _model.BGD006 = row["BGD006"].ToString( );
                if ( row["BGD007"] != null && row["BGD007"].ToString( ) != "" )
                    _model.BGD007 = row["BGD007"].ToString( );
                if ( row["BGD008"] != null && row["BGD008"].ToString( ) != "" )
                    _model.BGD008 = row["BGD008"].ToString( );
                if ( row["BGD009"] != null && row["BGD009"].ToString( ) != "" )
                    _model.BGD009 = row["BGD009"].ToString( );
                if ( row["BGD010"] != null && row["BGD010"].ToString( ) != "" )
                    _model.BGD010 = int.Parse( row["BGD010"].ToString( ) );
                if ( row["BGD011"] != null && row["BGD011"].ToString( ) != "" )
                    _model.BGD011 = int.Parse( row["BGD011"].ToString( ) );
                if ( row["BGD012"] != null && row["BGD012"].ToString( ) != "" )
                    _model.BGD012 = int.Parse( row["BGD012"].ToString( ) );
                if ( row["BGD013"] != null && row["BGD013"].ToString( ) != "" )
                    _model.BGD013 = int.Parse( row["BGD013"].ToString( ) );
                if ( row["BGD014"] != null && row["BGD014"].ToString( ) != "" )
                    _model.BGD014 = int.Parse( row["BGD014"].ToString( ) );
                if ( row["BGD015"] != null && row["BGD015"].ToString( ) != "" )
                    _model.BGD015 = int.Parse( row["BGD015"].ToString( ) );
                if ( row["BGD016"] != null && row["BGD016"].ToString( ) != "" )
                    _model.BGD016 = int.Parse( row["BGD016"].ToString( ) );
                if ( row["BGD017"] != null && row["BGD017"].ToString( ) != "" )
                    _model.BGD017 = int.Parse( row["BGD017"].ToString( ) );
                if ( row["BGD018"] != null && row["BGD018"].ToString( ) != "" )
                    _model.BGD018 = int.Parse( row["BGD018"].ToString( ) );
                if ( row["BGD019"] != null && row["BGD019"].ToString( ) != "" )
                    _model.BGD019 = int.Parse( row["BGD019"].ToString( ) );
                if ( row["BGD020"] != null && row["BGD020"].ToString( ) != "" )
                    _model.BGD020 = int.Parse( row["BGD020"].ToString( ) );
                if ( row["BGD021"] != null && row["BGD021"].ToString( ) != "" )
                    _model.BGD021 = int.Parse( row["BGD021"].ToString( ) );
                if ( row["BGD022"] != null && row["BGD022"].ToString( ) != "" )
                    _model.BGD022 = int.Parse( row["BGD022"].ToString( ) );
                if ( row["BGD023"] != null && row["BGD023"].ToString( ) != "" )
                    _model.BGD023 = row["BGD023"].ToString( );
                if ( row["BGD024"] != null && row["BGD024"].ToString( ) != "" )
                    _model.BGD024 = row["BGD024"].ToString( );
                //if ( row["BGD025"] != null && row["BGD025"].ToString( ) != "" )
                //    _model.BGD025 = int.Parse( row["BGD025"].ToString( ) );
                //if ( row["BGD026"] != null && row["BGD026"].ToString( ) != "" )
                //    _model.BGD026 = int.Parse( row["BGD026"].ToString( ) );
                if ( row["BGD027"] != null && row["BGD027"].ToString( ) != "" )
                    _model.BGD027 = row["BGD027"].ToString( );
                //if ( row["BGD028"] != null && row["BGD028"].ToString( ) != "" )
                //    _model.BGD028 = row["BGD028"].ToString( );
                //if ( row["BGD029"] != null && row["BGD029"].ToString( ) != "" )
                //    _model.BGD029 = long.Parse( row["BGD029"].ToString( ) );
                if ( row["BGD030"] != null && row["BGD030"].ToString( ) != "" )
                    _model.BGD030 = row["BGD030"].ToString( );
                if ( row["BGD032"] != null && row["BGD032"].ToString( ) != "" )
                    _model.BGD032 = DateTime.Parse( row["BGD032"].ToString( ) );
                if ( row["BGD033"] != null && row["BGD033"].ToString( ) != "" )
                    _model.BGD033 = row["BGD033"].ToString( );
                if ( row["BGD034"] != null && row["BGD034"].ToString( ) != "" )
                    _model.BGD034 = DateTime.Parse( row["BGD034"].ToString( ) );
                if ( row["BGD035"] != null && row["BGD035"].ToString( ) != "" )
                    _model.BGD035 = row["BGD036"].ToString( );
                if ( row["BGD036"] != null && row["BGD035"].ToString( ) != "" )
                    _model.BGD036 = row["BGD036"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBatch ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT RAA001 FROM SGMRAA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取上工序产出数量
        /// </summary>
        /// <param name="workProduce"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrevious ( string workProduce,string oddNum)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BGD010 FROM SGMBGD" );
            strSql.Append( " WHERE BGD030=CONVERT(INT,@BGD030)-10 AND BGD006=@BGD006" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD030",SqlDbType.NVarChar),
                new SqlParameter("@BGD006",SqlDbType.NVarChar)
            };
            parameter[0].Value = workProduce;
            parameter[1].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取上工序的操作工
        /// </summary>
        public DataTable GetDataTableOfPrevious ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BGD003,BGD005 FROM SGMBGD WHERE BGD005 IN ('去胶','划片') AND BGD006=@BGD006" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD006",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否是最后一道工序
        /// </summary>
        /// <param name="odd"></param>
        /// <param name="gx"></param>
        /// <returns></returns>
        public bool ExistsOfMax ( string odd ,string gx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(BGD030) BGD030 FROM SGMBGD" );
            strSql.Append( " WHERE BGD006=@BGD006" );
            SqlParameter[] parameter = {
                new SqlParameter("@BGD006",SqlDbType.NVarChar)
            };
            parameter[0].Value = odd;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Select( "BGD030='" + gx + "'" ).Length > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableGetDate ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GETDATE() t" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取工序信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableTeahs ( string rac001 )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT RAC003,QBA002,RAC002 FROM SGMRAC LEFT JOIN SGMQBA ON QBA001=RAC003" );
            strSql.Append( " WHERE RAC001=@RAC001"  );
            strSql.Append( " AND QBA002 IS NOT NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@RAC001",SqlDbType.NVarChar)
            };
            parameter[0].Value = rac001;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 查看工单单号是否有多余T，有则改
        /// </summary>
        /// <param name="bgd006"></param>
        public void findAndEidt ( string bgd006 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT BGD030 FROM SGMBGD WHERE BGD006='{0}' AND BGD023='T' AND BGD030!=(SELECT MAX(BGD030) FROM SGMBGD WHERE BGD006='{0}') ORDER BY BGD030" ,bgd006 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table != null || table . Rows . Count > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE SGMBGD SET BGD023='F' WHERE BGD006='{0}' AND BGD023='T' AND BGD030!=(SELECT MAX(BGD030) FROM SGMBGD WHERE BGD006='{0}')" ,bgd006 );
                SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );

                SqlHelper . SaveLog ( strSql . ToString ( ) ,null );

            }
        }

    }
}
